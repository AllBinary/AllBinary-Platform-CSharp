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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CachePolicyFactory = org.allbinary.logic.util.cache.CachePolicyFactory;
using PoolInterface = org.allbinary.logic.util.cache.PoolInterface;
using PoolInterfaceFactory = org.allbinary.logic.util.cache.PoolInterfaceFactory;
using PoolTypeFactory = org.allbinary.logic.util.cache.PoolTypeFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.image.cache;

public class BufferedImagePoolSingleton
{
    private static PoolInterface poolInterface = null;
    static BufferedImagePoolSingleton()
    {
        LogUtil logUtil = LogUtil.getInstance();
        CommonStrings commonStrings = CommonStrings.getInstance();
        string STATIC_BLOCK = "Static Block";
        string instance = "BufferedImagePoolSingleton";
        try {
            logUtil.putF(commonStrings.START, instance, STATIC_BLOCK);
            BufferedImagePoolSingleton.poolInterface = PoolInterfaceFactory.getInstance(new BufferedImageCacheableFactory(), PoolTypeFactory.getInstance().VECTOR_POOL, CachePolicyFactory.getInstance().MAX_TIME_THOUSAND_MAX);
            logUtil.putF(commonStrings.END, instance, STATIC_BLOCK);
        } catch (Exception e) {
            logUtil.put(commonStrings.EXCEPTION, instance, STATIC_BLOCK, e);
        }
    }
    private BufferedImagePoolSingleton()
    {
    }

    public static PoolInterface getInstance()
    {
        return BufferedImagePoolSingleton.poolInterface;
    }

}

