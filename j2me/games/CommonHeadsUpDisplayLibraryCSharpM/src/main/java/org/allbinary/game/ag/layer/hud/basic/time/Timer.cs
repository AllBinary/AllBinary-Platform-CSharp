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
using PrimitiveLongSingleton = org.allbinary.logic.math.PrimitiveLongSingleton;
using PrimitiveLongUtil = org.allbinary.logic.math.PrimitiveLongUtil;
using GameTickTimeDelayHelper = org.allbinary.time.GameTickTimeDelayHelper;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;

namespace org.allbinary.game.ag.layer.hud.basic.time;

public class Timer
{
    private long startTime = ((long) (-1));
    private long hundredthTime = 0L;
    private long maxTime;
    private long modifier = 0L;
    private char[] hundrethsString = PrimitiveLongSingleton.getInstance().ZERO;
    private int totalDigits = 1;
    private PrimitiveLongUtil primitiveLongUtil;
    private readonly char[] MAX = new char[] { 'L', 'O', 'L' };
    private readonly GameTickTimeDelayHelper gameTickTimeDelayHelper = GameTickTimeDelayHelperFactory.getInstance();
    public Timer(int maxTime)
    {
        this.primitiveLongUtil = PrimitiveLongUtil.createPowerOfTen(maxTime);
        this.maxTime = ((long) maxTime);
    }

    public virtual void start()
    {
        this.hundredthTime = 0L;
        this.startTime = this.gameTickTimeDelayHelper.startTime;
    }

    public virtual long get()
    {
        return this.hundredthTime;
    }

    public virtual void update()
    {
        long lastLowerTime = this.hundredthTime;
        long currentTime = ((this.modifier + this.gameTickTimeDelayHelper.startTime) - this.startTime);
        if (currentTime < 0L) {
            currentTime = 0L;
        }
        this.hundredthTime = currentTime / 100L;
        if (this.hundredthTime >= this.maxTime) {
            if (this.startTime > 0L) {
                this.hundrethsString = this.MAX;
            }
        } else if (lastLowerTime != this.hundredthTime) {
            this.hundrethsString = this.primitiveLongUtil.getCharArray(((int) this.hundredthTime));
            this.totalDigits = this.primitiveLongUtil.getCurrentTotalDigits();
        }
    }

    public virtual void reduce(int value)
    {
        this.modifier -= ((long) value);
    }

    public virtual void add(int value)
    {
        this.modifier += ((long) value);
    }

    public virtual char[] getTimeChars()
    {
        return this.hundrethsString;
    }

    public virtual int getCurrentTotalDigits()
    {
        return this.totalDigits;
    }

}

