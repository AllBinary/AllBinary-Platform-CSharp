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
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.game.layer.hud;

public class LapInfo
{
    public static LapInfo NULL_LAP_INFO = new LapInfo(-1);
    private int numberOfLaps;
    private int totalLaps;
    public LapInfo(int totalLaps)
    {
        this.totalLaps = totalLaps;
        this.numberOfLaps = 1;
    }

    public virtual void add()
    {
        this.numberOfLaps++;
    }

    public virtual int getCurrentLap()
    {
        return this.numberOfLaps;
    }

    public virtual int getTotalLaps()
    {
        return this.totalLaps;
    }

    public virtual bool isDone()
    {
        if (this.numberOfLaps >= this.totalLaps) {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("isDone: ");
        stringBuffer.appendboolean(this.isDone());
        stringBuffer.append(" CurrentLap: ");
        stringBuffer.appendint(this.getCurrentLap());
        stringBuffer.append(" Total Laps: ");
        stringBuffer.appendint(this.getTotalLaps());
        return stringBuffer.ToString();
    }

}

