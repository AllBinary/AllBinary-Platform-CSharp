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
using Direction = org.allbinary.direction.Direction;
using GameState = org.allbinary.game.state.GameState;

namespace org.allbinary.business.advertisement;

public class AdConfiguration
{
    public readonly string INNERACTIVE;
    public readonly string LEADBOLT;
    public readonly string ADMOB;
    public AdConfiguration(object[] advertIdArray)
    {
        this.INNERACTIVE = ((string) advertIdArray[0]);
        this.ADMOB = ((string) advertIdArray[1]);
        this.LEADBOLT = ((string) advertIdArray[2]);
    }

    public virtual Direction[] getValidAdSpots()
    {
        return new Direction[0];
    }

    public virtual void process(GameState gameState)
    {
    }

    public virtual void processDemo(int state)
    {
    }

    public virtual void setShowAds()
    {
    }

    public virtual void setToggleAds(bool showAds)
    {
    }

    public virtual bool isShowAds()
    {
        return true;
    }

}

