/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
//using IOException = java.io.IOException;
//using AudioFormat = javax.sound.sampled.AudioFormat;
//using AudioInputStream = javax.sound.sampled.AudioInputStream;
//using BooleanControl = javax.sound.sampled.BooleanControl;
//using Clip = javax.sound.sampled.Clip;
//using Control = javax.sound.sampled.Control;
//using Type = javax.sound.sampled.Control.Type;
//using Info = javax.sound.sampled.Line.Info;
//using LineListener = javax.sound.sampled.LineListener;
//using LineUnavailableException = javax.sound.sampled.LineUnavailableException;

namespace org.allbinary.media.audio;

public class NullClip : Clip
{
    public static readonly NullJ2SEControl NULL_CONTROL = new NullJ2SEControl(BooleanControl.Type.MUTE);
    // throws LineUnavailableException
    public virtual void open(AudioFormat format, sbyte[] data, int offset, int bufferSize)
    {
    }

    // throws LineUnavailableException, IOException
    public virtual void open(AudioInputStream stream)
    {
    }

    public virtual int getFrameLength()
    {
        return 0;
    }

    public virtual long getMicrosecondLength()
    {
        return 0L;
    }

    public virtual void setFramePosition(int frames)
    {
    }

    public virtual void setMicrosecondPosition(long microseconds)
    {
    }

    public virtual void setLoopPoints(int start, int end)
    {
    }

    public virtual void loop(int count)
    {
    }

    public virtual void drain()
    {
    }

    public virtual void flush()
    {
    }

    public virtual void start()
    {
    }

    public virtual void stop()
    {
    }

    public virtual bool isRunning()
    {
        return false;
    }

    public virtual bool isActive()
    {
        return false;
    }

    public virtual AudioFormat getFormat()
    {
        return NullAudioFormat.NULL_AUDIO_FORMAT;
    }

    public virtual int getBufferSize()
    {
        return 0;
    }

    public virtual int available()
    {
        return 0;
    }

    public virtual int getFramePosition()
    {
        return 0;
    }

    public virtual long getLongFramePosition()
    {
        return 0L;
    }

    public virtual long getMicrosecondPosition()
    {
        return 0L;
    }

    public virtual float getLevel()
    {
        return 0.0f;
    }

    public virtual Info getLineInfo()
    {
        return new Info(this.GetType(), NullAudioFormat.NULL_AUDIO_FORMAT);
    }

    // throws LineUnavailableException
    public virtual void open()
    {
    }

    public virtual void close()
    {
    }

    public virtual bool isOpen()
    {
        return false;
    }

    public virtual Control[] getControls()
    {
        return new Control[0];
    }

    public virtual bool isControlSupported(Type control)
    {
        return false;
    }

    public virtual Control getControl(Type control)
    {
        return NullClip.NULL_CONTROL;
    }

    public virtual void addLineListener(LineListener listener)
    {
    }

    public virtual void removeLineListener(LineListener listener)
    {
    }

}

