// Java Sound compatibility for the generated desktop WAV media module.
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace javax.sound.sampled
{
    public class AudioFormat
    {
        public enum Encoding { PCM_UNSIGNED, PCM_SIGNED }

        internal readonly int Channels;
        internal readonly int FrameSize;
        internal readonly int SampleSize;
        internal readonly int SampleRate;

        public AudioFormat(Encoding encoding, float sampleRate, int sampleSize,
            int channels, int frameSize, float frameRate, bool bigEndian)
        {
            Channels = channels;
            FrameSize = frameSize;
            SampleSize = sampleSize;
            SampleRate = (int) sampleRate;
        }
    }

    public class AudioInputStream : IDisposable
    {
        internal readonly Stream Data;
        internal readonly AudioFormat Format;

        public AudioInputStream(Stream stream, AudioFormat format, long frameLength)
        {
            Data = stream;
            Format = format;
        }

        public void Dispose() => Data.Dispose();
    }

    public class Control
    {
        public class Type { }
        protected Control(Type type) { }
    }

    public class BooleanControl : Control
    {
        public new class Type : Control.Type
        {
            public static readonly Type MUTE = new Type();
        }

        protected BooleanControl(Type type) : base(type) { }
    }

    public class FloatControl : Control
    {
        public new class Type : Control.Type
        {
            public static readonly Type MASTER_GAIN = new Type();
        }

        private float value;
        private readonly Action<float> onChange;

        internal FloatControl(Action<float> onChange) : base(Type.MASTER_GAIN)
        {
            this.onChange = onChange;
        }

        public float getValue() => value;

        public void setValue(float gain)
        {
            value = gain;
            onChange(gain);
        }
    }

    public interface Line
    {
        public class Info
        {
            public Info(System.Type lineClass, AudioFormat format) { }
        }
    }

    public interface Clip : Line
    {
        void open(AudioInputStream stream);
        void close();
        void start();
        void stop();
        void loop(int count);
        void drain();
        void flush();
        void setFramePosition(int position);
        long getMicrosecondLength();
        Control getControl(Control.Type type);
        void addLineListener(LineListener listener);
        void removeLineListener(LineListener listener);
    }

    public interface LineListener
    {
        void update(LineEvent lineEvent);
    }

    public class LineEvent
    {
        public enum Type { STOP }

        public Type getType() => Type.STOP;
    }

    public class LineUnavailableException : InvalidOperationException
    {
        internal LineUnavailableException(string message) : base(message) { }
    }

    public static class AudioSystem
    {
        public static Clip getClip()
        {
            if (!OperatingSystem.IsWindows())
                throw new PlatformNotSupportedException("WAV playback requires Windows.");
            return new WaveClip();
        }

        public static AudioInputStream getAudioInputStream(Stream stream)
        {
            using var reader = new BinaryReader(stream);
            if (reader.ReadUInt32() != 0x46464952) // RIFF
                throw new InvalidDataException("Expected a RIFF WAV stream.");
            long remaining = reader.ReadUInt32();
            if (remaining < 4 || reader.ReadUInt32() != 0x45564157) // WAVE
                throw new InvalidDataException("Expected WAV data.");
            remaining -= 4;

            AudioFormat format = null;
            byte[] samples = null;
            while (remaining >= 8 && (format == null || samples == null))
            {
                uint kind = reader.ReadUInt32();
                uint length = reader.ReadUInt32();
                long paddedLength = (long) length + (length & 1);
                remaining -= 8 + paddedLength;
                if (remaining < 0)
                    throw new InvalidDataException("WAV chunk exceeds the RIFF length.");

                if (kind == 0x20746d66 && format == null) // fmt
                {
                    if (length < 16 || reader.ReadUInt16() != 1)
                        throw new InvalidDataException("Expected a PCM WAV format.");
                    int channels = reader.ReadUInt16();
                    int rate = reader.ReadInt32();
                    reader.ReadUInt32(); // byte rate
                    int frameSize = reader.ReadUInt16();
                    int bits = reader.ReadUInt16();
                    if (channels == 0 || rate <= 0 || (bits != 8 && bits != 16 && bits != 24 && bits != 32)
                        || frameSize != channels * (bits / 8) || (long) rate * frameSize > uint.MaxValue)
                        throw new InvalidDataException("Invalid PCM WAV format.");
                    format = new AudioFormat(bits == 8 ? AudioFormat.Encoding.PCM_UNSIGNED :
                        AudioFormat.Encoding.PCM_SIGNED, rate, bits, channels, frameSize, rate, false);
                    paddedLength -= 16;
                }
                else if (kind == 0x61746164 && samples == null) // data
                {
                    samples = reader.ReadBytes(checked((int) length));
                    if (samples.Length != length)
                        throw new EndOfStreamException();
                    paddedLength -= length;
                }

                // InputStream can be non-seekable.
                while (paddedLength > 0)
                {
                    int chunkSize = (int) Math.Min(paddedLength, 8192);
                    if (reader.ReadBytes(chunkSize).Length != chunkSize)
                        throw new EndOfStreamException();
                    paddedLength -= chunkSize;
                }
            }

            if (format == null || samples == null || samples.Length % format.FrameSize != 0)
                throw new InvalidDataException("WAV format or frame data is missing or incomplete.");
            return new AudioInputStream(new MemoryStream(samples, false), format, samples.Length / format.FrameSize);
        }
    }

    internal sealed class WaveClip : Clip
    {
        private readonly object gate = new object();
        private readonly List<LineListener> listeners = new List<LineListener>();
        private readonly FloatControl volume;
        private AudioFormat format;
        private byte[] samples;
        private int firstFrame;
        private int loops;
        private Playback playback;

        internal WaveClip()
        {
            volume = new FloatControl(gain =>
            {
                lock (gate)
                    playback?.SetGain(gain);
            });
        }

        public void open(AudioInputStream stream)
        {
            using var data = new MemoryStream();
            stream.Data.CopyTo(data);
            lock (gate)
            {
                if (samples != null)
                    throw new InvalidOperationException("The WAV clip is already open.");
                samples = data.ToArray();
                format = stream.Format;
            }
        }

        public void start()
        {
            lock (gate)
            {
                if (playback != null || samples == null)
                    return;
                int offset = firstFrame * format.FrameSize;
                if (offset == samples.Length)
                    return;
                var active = new Playback(format, samples, offset, loops, volume.getValue());
                playback = active;
                active.Completion = Task.Run(() => WaitForPlayback(active));
            }
        }

        private void WaitForPlayback(Playback active)
        {
            LineListener[] completedListeners;
            while (true)
            {
                active.Changed.WaitOne();
                lock (gate)
                {
                    if (playback != active || !active.IsDone)
                        continue;
                    active.Dispose();
                    playback = null;
                    completedListeners = listeners.ToArray();
                    break;
                }
            }
            var stopped = new LineEvent();
            foreach (LineListener listener in completedListeners)
                listener.update(stopped);
        }

        public void stop()
        {
            lock (gate)
                playback?.Stop();
        }

        public void close()
        {
            lock (gate)
            {
                playback?.Stop();
                samples = null;
                format = null;
                firstFrame = 0;
            }
        }

        public void drain()
        {
            Task completion;
            lock (gate)
                completion = playback?.Completion;
            completion?.GetAwaiter().GetResult();
        }

        public void flush() => stop();

        public void loop(int count)
        {
            lock (gate)
                loops = count;
        }

        public void setFramePosition(int position)
        {
            lock (gate)
                firstFrame = samples == null ? 0 : Math.Clamp(position, 0, samples.Length / format.FrameSize);
        }

        public long getMicrosecondLength()
        {
            lock (gate)
                return samples == null ? 0 : 1000000L * (samples.Length / format.FrameSize) / format.SampleRate;
        }

        public Control getControl(Control.Type type)
        {
            if (type != FloatControl.Type.MASTER_GAIN)
                throw new ArgumentException("Unsupported WAV clip control.", nameof(type));
            return volume;
        }

        public void addLineListener(LineListener listener)
        {
            lock (gate)
                listeners.Add(listener);
        }

        public void removeLineListener(LineListener listener)
        {
            lock (gate)
                listeners.Remove(listener);
        }

        private sealed class Playback : IDisposable
        {
            private const uint CallbackEvent = 0x00050000;
            private const uint Done = 1;
            private const uint BeginLoop = 4;
            private const uint EndLoop = 8;
            private static readonly uint HeaderSize = (uint) Marshal.SizeOf<WaveHeader>();
            private IntPtr handle;
            private IntPtr header;
            private GCHandle data;
            private bool prepared;

            internal readonly AutoResetEvent Changed = new AutoResetEvent(false);
            internal Task Completion;
            internal bool IsDone => (Marshal.PtrToStructure<WaveHeader>(header).Flags & Done) != 0;

            internal Playback(AudioFormat format, byte[] samples, int offset, int loops, float gain)
            {
                try
                {
                    var waveFormat = new WaveFormat
                    {
                        FormatTag = 1,
                        Channels = (ushort) format.Channels,
                        SamplesPerSecond = (uint) format.SampleRate,
                        BytesPerSecond = (uint) ((long) format.SampleRate * format.FrameSize),
                        BlockAlign = (ushort) format.FrameSize,
                        BitsPerSample = (ushort) format.SampleSize
                    };
                    Check(waveOutOpen(out handle, uint.MaxValue, ref waveFormat,
                        Changed.SafeWaitHandle.DangerousGetHandle(), IntPtr.Zero, CallbackEvent));
                    data = GCHandle.Alloc(samples, GCHandleType.Pinned);
                    header = Marshal.AllocHGlobal((int) HeaderSize);
                    var waveHeader = new WaveHeader
                    {
                        Data = IntPtr.Add(data.AddrOfPinnedObject(), offset),
                        BufferLength = (uint) (samples.Length - offset),
                        Flags = loops == 0 ? 0 : BeginLoop | EndLoop,
                        Loops = loops < 0 ? uint.MaxValue : (uint) loops + 1
                    };
                    Marshal.StructureToPtr(waveHeader, header, false);
                    Check(waveOutPrepareHeader(handle, header, HeaderSize));
                    prepared = true;
                    SetGain(gain);
                    Check(waveOutWrite(handle, header, HeaderSize));
                }
                catch
                {
                    Dispose();
                    throw;
                }
            }

            internal void SetGain(float gain)
            {
                uint level = (uint) (Math.Clamp(Math.Pow(10, gain / 20), 0, 1) * ushort.MaxValue);
                waveOutSetVolume(handle, (level << 16) | level);
            }

            internal void Stop() => Check(waveOutReset(handle));

            public void Dispose()
            {
                if (prepared)
                    Check(waveOutUnprepareHeader(handle, header, HeaderSize));
                if (handle != IntPtr.Zero)
                    Check(waveOutClose(handle));
                if (header != IntPtr.Zero)
                    Marshal.FreeHGlobal(header);
                if (data.IsAllocated)
                    data.Free();
                Changed.Dispose();
            }

            private static void Check(uint result)
            {
                if (result != 0)
                    throw new LineUnavailableException("Waveform audio error " + result);
            }

            [StructLayout(LayoutKind.Sequential, Pack = 2)]
            private struct WaveFormat
            {
                internal ushort FormatTag, Channels;
                internal uint SamplesPerSecond, BytesPerSecond;
                internal ushort BlockAlign, BitsPerSample, ExtraSize;
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct WaveHeader
            {
                internal IntPtr Data;
                internal uint BufferLength, BytesRecorded;
                internal IntPtr User;
                internal uint Flags, Loops;
                internal IntPtr Next, Reserved;
            }

            [DllImport("winmm.dll")] private static extern uint waveOutOpen(out IntPtr handle, uint device,
                ref WaveFormat format, IntPtr callback, IntPtr instance, uint flags);
            [DllImport("winmm.dll")] private static extern uint waveOutPrepareHeader(IntPtr handle, IntPtr header, uint size);
            [DllImport("winmm.dll")] private static extern uint waveOutWrite(IntPtr handle, IntPtr header, uint size);
            [DllImport("winmm.dll")] private static extern uint waveOutReset(IntPtr handle);
            [DllImport("winmm.dll")] private static extern uint waveOutUnprepareHeader(IntPtr handle, IntPtr header, uint size);
            [DllImport("winmm.dll")] private static extern uint waveOutClose(IntPtr handle);
            [DllImport("winmm.dll")] private static extern uint waveOutSetVolume(IntPtr handle, uint volume);
        }
    }

    internal sealed class AudioTask : global::java.lang.Runnable
    {
        private readonly Action action;
        internal AudioTask(Action action) => this.action = action;
        public void run() => action();
    }
}

namespace java.io
{
    internal sealed class BufferedInputStream : InputStream
    {
        private readonly BufferedStream stream;

        internal BufferedInputStream(InputStream inputStream) => stream = new BufferedStream(inputStream);

        public override int read() => stream.ReadByte();

        public override int read(sbyte[] buffer, int offset, int length)
        {
            int count = stream.Read((byte[]) (Array) buffer, offset, length);
            return count == 0 && length != 0 ? -1 : count;
        }

        public override void close() => stream.Dispose();
    }
}
