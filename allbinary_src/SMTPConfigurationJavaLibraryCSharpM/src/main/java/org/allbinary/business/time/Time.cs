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

namespace org.allbinary.business.time;

public class Time
{
    private long? timeLong;
    public Time(string time)
    {
        this.timeLong = time;
    }

    public Time(long time)
    {
        this.timeLong = time;
    }

    public virtual long? getLong()
    {
        return this.timeLong;
    }

    public virtual long getlong()
    {
        return ((long) this.timeLong);
    }

    public override string ToString()
    {
        return this.getLong().ToString();
    }

}

