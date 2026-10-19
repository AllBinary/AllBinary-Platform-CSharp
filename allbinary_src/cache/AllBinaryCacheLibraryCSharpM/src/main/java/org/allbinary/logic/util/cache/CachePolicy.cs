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

namespace org.allbinary.logic.util.cache;

public class CachePolicy
{
    private readonly string name;
    private long maxTime = 0L;
    private long maxSize = 0L;
    public CachePolicy(string name, long maxTime, long maxSize)
    {
        this.name = name;
        this.setMaxTime(maxTime);
        this.setMaxSize(maxSize);
    }

    public virtual long getMaxTime()
    {
        return this.maxTime;
    }

    public virtual void setMaxTime(long maxTime)
    {
        this.maxTime = maxTime;
    }

    public virtual long getMaxSize()
    {
        return this.maxSize;
    }

    public virtual void setMaxSize(long maxSize)
    {
        this.maxSize = maxSize;
    }

    public virtual string getName()
    {
        return this.name;
    }

}

