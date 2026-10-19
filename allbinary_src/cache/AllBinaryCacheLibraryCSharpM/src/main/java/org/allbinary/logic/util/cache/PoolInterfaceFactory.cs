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

public class PoolInterfaceFactory
{
    private PoolInterfaceFactory()
    {
    }

    // throws Exception
    public static PoolInterface getInstance(CacheableInterfaceFactoryInterface cacheableInterfaceFactoryInterface, PoolType poolType, CachePolicy cachePolicy)
    {
        throw new Exception("No Such PoolType: " + poolType.ToString());
    }

}

