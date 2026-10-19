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
//using Player = javax.microedition.media.Player;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.audio;

public class Sound : SoundInterface, Runnable
{
    private string resource;
    public Player player = NoPlayer.NO_PLAYER;
    protected Sound(string resource)
    {
        this.resource = resource;
    }

    public virtual string getResource()
    {
        return this.resource;
    }

    public virtual Player getPlayerP()
    {
        return this.player;
    }

    public virtual void setPlayerP(Player player)
    {
        this.player = player;
    }

    // throws Exception
    public virtual void init()
    {
    }

    public virtual int getDuration()
    {
        return -1;
    }

    public virtual void run()
    {
        try {
            this.player.start();
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            PreLogUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN);
        }
    }

}

