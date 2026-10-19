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

public class CachePolicyFactory
{
    private static readonly CachePolicyFactory instance = new CachePolicyFactory();
    public static CachePolicyFactory getInstance()
    {
        return CachePolicyFactory.instance;
    }

    public readonly string NAME = "lru";
    public CachePolicy MAX_TIME_THOUSAND_MAX;
    public CachePolicy THIRTY_MINUTES_TEN_THOUSAND_MAX;
    public CachePolicy THIRTY_MINUTES_FIFTY_THOUSAND_MAX;
    public CachePolicy ONE_MINUTE_FIVE_MAX;
    public CachePolicy ONE_MINUTE_TEN_MAX;
    public CachePolicy ONE_MINUTE_ONE_HUNDRED_MAX;
    public CachePolicyFactory()
    {
        this.MAX_TIME_THOUSAND_MAX = new CachePolicy(this.NAME, Long.MAX_VALUE, 1000);
        this.THIRTY_MINUTES_TEN_THOUSAND_MAX = new CachePolicy(this.NAME, 1000 * 60 * 30, 10000);
        this.THIRTY_MINUTES_FIFTY_THOUSAND_MAX = new CachePolicy(this.NAME, 1000 * 60 * 30, 100000);
        this.ONE_MINUTE_FIVE_MAX = new CachePolicy(this.NAME, 1000 * 60 * 1, 5);
        this.ONE_MINUTE_TEN_MAX = new CachePolicy(this.NAME, 1000 * 60 * 1, 10);
        this.ONE_MINUTE_ONE_HUNDRED_MAX = new CachePolicy(this.NAME, 1000 * 60 * 1, 100);
    }

}

