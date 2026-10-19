/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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

namespace org.allbinary.time;

public class GameTickTimeDelayHelper
{
    public long timeDelta = 0L;
    public long startTime;
    public long lastStartTime;
    public GameTickTimeDelayHelper(long startTime)
    {
        this.startTime = startTime;
        this.lastStartTime = 0L;
    }

    public virtual long setStartTime()
    {
        this.startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        return this.startTime;
    }

    public virtual void loop()
    {
        if (this.lastStartTime == Long.MIN_VALUE) {
            this.timeDelta = 0L;
        } else {
            this.timeDelta = DateTimeOffset.Now.ToUnixTimeMilliseconds() - this.lastStartTime;
        }
    }

    public virtual long getTimeFromStart()
    {
        return this.startTime - this.lastStartTime;
    }

}

