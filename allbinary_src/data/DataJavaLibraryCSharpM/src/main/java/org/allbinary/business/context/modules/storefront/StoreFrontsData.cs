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

namespace org.allbinary.business.context.modules.storefront;

public class StoreFrontsData
{
    private static readonly StoreFrontsData instance = new StoreFrontsData();
    public static StoreFrontsData getInstance()
    {
        return StoreFrontsData.instance;
    }

    public readonly string TYPE = "STOREFRONTS_TYPE";
    public readonly string RETAIL = "STOREFRONTS_RETAIL";
    public readonly string SUBSCRIPTION = "STOREFRONTS_SUBSCRIPTION";
    public readonly string AUCTION = "STOREFRONTS_AUCTION";
    public readonly string NEWS = "STOREFRONTS_NEWS";
    public readonly string BLOG = "STOREFRONTS_BLOG";
    public readonly string FORUM = "STOREFRONTS_FORUM";
}

