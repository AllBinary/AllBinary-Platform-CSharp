/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2007 AllBinary 
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

public class PoolType
{
    private readonly CacheType cacheType;
    public PoolType(CacheType cacheType)
    {
        this.cacheType = cacheType;
    }

    public virtual CacheType getCacheType()
    {
        return this.cacheType;
    }

    public override string ToString()
    {
        string POOL_TYPE = "PoolType: ";
        return POOL_TYPE + this.getCacheType().ToString();
    }

}

