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
//using Controllable = javax.microedition.media.Controllable;
//using Player = javax.microedition.media.Player;
//using PlayerListener = javax.microedition.media.PlayerListener;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using GameTickTimeDelayHelper = org.allbinary.time.GameTickTimeDelayHelper;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.media.audio;

//BasicPlayer
public class PlayerComposite : Controllable, Player
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly Player player;
    private readonly TimeDelayHelper timeElapsedHelper = new TimeDelayHelper(0);
    public PlayerComposite(Player player, int repeatTime)
    {
        this.player = player;
        this.timeElapsedHelper.delay = repeatTime;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void addPlayerListener(PlayerListener playerListener)
    {
        this.player.addPlayerListener(playerListener);
    }

    public virtual void removePlayerListener(PlayerListener playerListener)
    {
        this.player.removePlayerListener(playerListener);
    }

    public virtual void close()
    {
        this.player.close();
    }

    public virtual void deallocate()
    {
        this.player.deallocate();
    }

    public virtual string getContentType()
    {
        return this.player.getContentType();
    }

    public virtual long getDuration()
    {
        return this.player.getDuration();
    }

    public virtual long getMediaTime()
    {
        return this.player.getMediaTime();
    }

    public virtual void prefetch()
    {
        try {
            this.player.prefetch();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "prefetch", e);
        }
    }

    public virtual void realize()
    {
        try {
            this.player.realize();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "realize", e);
        }
    }

    public virtual int getState()
    {
        return this.player.getState();
    }

    public virtual void setLoopCount(int count)
    {
        this.player.setLoopCount(count);
    }

    public virtual long setMediaTime(long now)
    {
        try {
            return this.player.setMediaTime(now);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "setMediaTime", e);
            return ((long) (-1));
        }
    }

    private readonly GameTickTimeDelayHelper gameTickTimeDelayHelper = GameTickTimeDelayHelperFactory.getInstance();
    public virtual void start()
    {
        try {
            if (this.timeElapsedHelper.isTime(this.gameTickTimeDelayHelper.startTime)) {
                this.player.start();
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.START_METHOD_NAME, e);
        }
    }

    public virtual void stop()
    {
        try {
            this.player.stop();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "stop", e);
        }
    }

    public virtual Control getControl(string controlType)
    {
        return this.player.getControl(controlType);
    }

    public virtual Control[] getControls()
    {
        throw new SystemException();
    }

    public virtual void setVolume(int leftVolume, int rightVolume)
    {
        Controllable2 controllable2 = (((Controllable2) this.player));
        controllable2.setVolume(leftVolume, rightVolume);
    }

    public virtual Player getPlayerP()
    {
        return this.player;
    }

}

