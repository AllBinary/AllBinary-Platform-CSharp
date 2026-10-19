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
using GameAdState = org.allbinary.game.GameAdState;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;

namespace org.allbinary.business.advertisement;

public class BottomLimiter
{
    private static readonly BottomLimiter instance = new BottomLimiter();
    public static BottomLimiter getInstance()
    {
        return BottomLimiter.instance;
    }

    private int bottom = 0;
    private int deltaY = 0;
    private int lower = 0;
    private int higher = 0;
    private BottomLimiter()
    {
    }

    public virtual void init(int lower, int higher)
    {
        this.lower = lower;
        this.higher = higher;
    }

    public virtual void update()
    {
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        GameAdState gameAdState = GameAdStateFactory.getInstance().getCurrentInstance();
        if (gameAdState.isShowingAt()) {
            this.deltaY = this.higher;
        } else {
            this.deltaY = this.lower;
        }
        this.bottom = displayInfo.getLastHeight() - this.deltaY;
    }

    public virtual int getDeltaY()
    {
        return this.deltaY;
    }

    public virtual int getBottom()
    {
        return this.bottom;
    }

}

