/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2011 AllBinary
 * 
 * By agreeing to this license you and any business entity you represent are
 * legally bound to the AllBinary Open License Version 1 legal agreement.
 * 
 * You may obtain the AllBinary Open License Version 1 legal agreement from
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository.
 * 
 * Created By: Travis Berthelot
 *  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using ARunnable = org.allbinary.thread.ARunnable;
//using ByteArrayInputStream = java.io.ByteArrayInputStream;
//using InputStream = java.io.InputStream;
//using Control = javax.microedition.media.Control;
//using MediaException = javax.microedition.media.MediaException;
//using PlayerListener = javax.microedition.media.PlayerListener;
//using AudioInputStream = javax.sound.sampled.AudioInputStream;
//using AudioSystem = javax.sound.sampled.AudioSystem;
//using Clip = javax.sound.sampled.Clip;
//using FloatControl = javax.sound.sampled.FloatControl;
//using LineEvent = javax.sound.sampled.LineEvent;
//using LineListener = javax.sound.sampled.LineListener;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using MusicThreadPool = org.allbinary.thread.MusicThreadPool;

namespace org.allbinary.media.audio;

public class PCClipWavPlayer : BasicPlayer, LineListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AudioInputStream audioInputStream;
    private readonly Clip clip;
    public PCClipWavPlayer(InputStream inputStream)
    {
        AudioInputStream audioInputStream = new AudioInputStream(new ByteArrayInputStream(NullUtil.getInstance().NULL_BYTE_ARRAY), NullAudioFormat.NULL_AUDIO_FORMAT, 0);
        Clip clip = new NullClip();
        try {
            audioInputStream = AudioSystem.getAudioInputStream(inputStream);
            clip = this.create(audioInputStream);
            if (clip == null) {
                this.logUtil.put("Clip was null", this, this.commonStrings.CONSTRUCTOR, new Exception());
                throw new SystemException();
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.CONSTRUCTOR, e);
        }
        this.audioInputStream = audioInputStream;
        this.clip = clip;
    }

    public override void close()
    {
        MusicThreadPool.getInstance().runTask(new ARunnable()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void run()
            {
                try {
                    close2();
                } catch (Exception e) {
                    PreLogUtil.putOE(commonStrings.EXCEPTION, this, commonStrings.PROCESS, e);
                }
            }

#endif
);
    }

    // throws Exception
    private void close2()
    {
        this.clip.drain();
        this.clip.flush();
        this.clip.close();
    }

    public override string getContentType()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    // throws MediaException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void start()
    {
        MusicThreadPool.getInstance().runTask(new ARunnable()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void run()
            {
                try {
                    start2();
                } catch (Exception e) {
                    PreLogUtil.putOE(commonStrings.EXCEPTION, this, commonStrings.PROCESS, e);
                }
            }

#endif
);
    }

    // throws Exception
    private void start2()
    {
        this.clip.setFramePosition(0);
        this.clip.loop(this.getLoopCount());
        this.clip.start();
        base.start();
    }

    // throws Exception
    private Clip create(AudioInputStream audioInputStream)
    {
        Clip clip = AudioSystem.getClip();
        clip.addLineListener(this);
        clip.open(audioInputStream);
        return clip;
    }

    // throws MediaException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void stop()
    {
        MusicThreadPool.getInstance().runTask(new ARunnable()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void run()
            {
                try {
                    stop2();
                } catch (Exception e) {
                    PreLogUtil.putOE(commonStrings.EXCEPTION, this, commonStrings.PROCESS, e);
                }
            }

#endif
);
    }

    // throws Exception
    private void stop2()
    {
        this.clip.stop();
        base.stop();
    }

    public override Control getControl(string controlType)
    {
        return new NullControl();
    }

    public override Control[] getControls()
    {
        return new Control[0];
    }

    public override void setVolume(int leftVolume, int rightVolume)
    {
        this.setVolumeF((((float) leftVolume)) / 100.0f);
    }

    private float getVolume()
    {
        FloatControl masterGainFloatControl = ((FloatControl) clip.getControl(FloatControl.Type.MASTER_GAIN));
        return ((float) Math.Pow(10f, masterGainFloatControl.getValue() / 20f));
    }

    private void setVolumeF(float volume)
    {
        if (volume < 0f || volume > 1f) {
            throw new ArgumentException("Volume: " + volume);
        }
        FloatControl masterGainFloatControl = ((FloatControl) this.clip.getControl(FloatControl.Type.MASTER_GAIN));
        masterGainFloatControl.setValue(20f * ((float) Math.Log10(volume)));
    }

    public override long getDuration()
    {
        return this.clip.getMicrosecondLength() / 1000;
    }

    public override void update(LineEvent @event)
    {
        if (@event.getType().Equals(LineEvent.Type.STOP)) {
            int size = this.listenersList.size();
            for (int index = 0; index < size; index++) {
                PlayerListener listener = ((PlayerListener) this.listenersList.get(size));
                listener.playerUpdate(this, PlayerListener.END_OF_MEDIA, null);
            }
        }
    }

}

