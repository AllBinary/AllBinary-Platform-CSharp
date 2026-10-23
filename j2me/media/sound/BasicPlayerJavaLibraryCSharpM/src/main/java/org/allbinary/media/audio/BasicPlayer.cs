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
//using Control = javax.microedition.media.Control;
//using MediaException = javax.microedition.media.MediaException;
//using Player = javax.microedition.media.Player;
//using PlayerListener = javax.microedition.media.PlayerListener;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.media.audio;

//BasicPlayerJavaLibrary
public class BasicPlayer : Player, Controllable2
{
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public static string CONTROL_TYPE = "ToneControl";
    public readonly BasicArrayList listenersList = new BasicArrayListD();
    public int stateP = 0;
    public int loopCountP = 0;
    public BasicPlayer()
    {
        this.setLoopCount(0);
        this.setState(Player.UNREALIZED);
    }

    public virtual string getContentType()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    public virtual Control getControl(string controlType)
    {
        return new NullControl();
    }

    public virtual Control[] getControls()
    {
        return new Control[0];
    }

    public virtual void close()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void addPlayerListener(PlayerListener playerListener)
    {
        if (!this.listenersList.contains(playerListener)) {
            this.listenersList.add(playerListener);
        }
    }

    public virtual void removePlayerListener(PlayerListener playerListener)
    {
        this.listenersList.remove(playerListener);
    }

    public virtual int getState()
    {
        return this.stateP;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void setState(int state)
    {
        this.stateP = state;
    }

    public virtual long getDuration()
    {
        return 0L;
    }

    public virtual long getMediaTime()
    {
        return 0L;
    }

    public virtual void deallocate()
    {
    }

    // throws MediaException
    public virtual void prefetch()
    {
    }

    // throws MediaException
    public virtual void realize()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void setLoopCount(int count)
    {
        this.loopCountP = count;
    }

    public virtual int getLoopCount()
    {
        return this.loopCountP;
    }

    // throws MediaException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual long setMediaTime(long now)
    {
        return 0L;
    }

    // throws MediaException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void start()
    {
        this.setState(Player.STARTED);
    }

    // throws MediaException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void stop()
    {
        this.setState(Player.PREFETCHED);
    }

    public virtual void setVolume(int leftVolume, int rightVolume)
    {
    }

}

