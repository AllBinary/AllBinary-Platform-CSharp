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
using AutomaticCacheInterface = org.allbinary.logic.util.cache.AutomaticCacheInterface;
using AutomaticCacheInterfaceFactory = org.allbinary.logic.util.cache.AutomaticCacheInterfaceFactory;
using CachePolicyFactory = org.allbinary.logic.util.cache.CachePolicyFactory;
using CacheTypeFactory = org.allbinary.logic.util.cache.CacheTypeFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.graphics.color;

public class ColorCacheFactory
{
    private static AutomaticCacheInterface cacheInterface = null;
    static ColorCacheFactory()
    {
        LogUtil logUtil = LogUtil.getInstance();
        CommonStrings commonStrings = CommonStrings.getInstance();
        string STATIC_BLOCK = "Static Block";
        try {
            logUtil.putF(commonStrings.START, typeof(ColorCacheFactory), STATIC_BLOCK);
            ColorCacheFactory.cacheInterface = AutomaticCacheInterfaceFactory.getInstance(new ColorCacheableFactory(), CacheTypeFactory.getInstance().CACHE, CachePolicyFactory.getInstance().THIRTY_MINUTES_TEN_THOUSAND_MAX);
            logUtil.putF(commonStrings.END, typeof(ColorCacheFactory), STATIC_BLOCK);
        } catch (Exception e) {
            logUtil.put(commonStrings.EXCEPTION, typeof(ColorCacheFactory), STATIC_BLOCK, e);
        }
    }
    private ColorCacheFactory()
    {
    }

    public static AutomaticCacheInterface getInstance()
    {
        return ColorCacheFactory.cacheInterface;
    }

}

