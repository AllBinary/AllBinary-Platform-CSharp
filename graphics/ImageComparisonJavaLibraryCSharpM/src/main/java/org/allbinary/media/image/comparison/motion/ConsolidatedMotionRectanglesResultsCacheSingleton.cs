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
using CacheInterface = org.allbinary.logic.util.cache.CacheInterface;
using CacheInterfaceFactory = org.allbinary.logic.util.cache.CacheInterfaceFactory;
using CachePolicyFactory = org.allbinary.logic.util.cache.CachePolicyFactory;
using CacheTypeFactory = org.allbinary.logic.util.cache.CacheTypeFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.image.comparison.motion;

public class ConsolidatedMotionRectanglesResultsCacheSingleton
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static CacheInterface cacheInterface = null;
    static ConsolidatedMotionRectanglesResultsCacheSingleton()
    {
        LogUtil logUtil = LogUtil.getInstance();
        CommonStrings commonStrings = CommonStrings.getInstance();
        string STATIC_BLOCK = "Static Block";
        string instance = "MotionRectanglesResultsCacheSingleton";
        try {
            logUtil.putF(commonStrings.START, instance, STATIC_BLOCK);
            ConsolidatedMotionRectanglesResultsCacheSingleton.cacheInterface = CacheInterfaceFactory.getInstance(CacheTypeFactory.getInstance().CACHE, CachePolicyFactory.getInstance().ONE_MINUTE_FIVE_MAX);
            logUtil.putF(commonStrings.END, instance, STATIC_BLOCK);
        } catch (Exception e) {
            logUtil.put(commonStrings.EXCEPTION, instance, STATIC_BLOCK, e);
        }
    }
    private ConsolidatedMotionRectanglesResultsCacheSingleton()
    {
    }

    public static CacheInterface getInstance()
    {
        return ConsolidatedMotionRectanglesResultsCacheSingleton.cacheInterface;
    }

}

