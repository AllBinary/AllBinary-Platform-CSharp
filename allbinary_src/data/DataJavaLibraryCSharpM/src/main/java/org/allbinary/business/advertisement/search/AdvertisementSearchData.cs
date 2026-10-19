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

namespace org.allbinary.business.advertisement.search;

public class AdvertisementSearchData
{
    private static readonly AdvertisementSearchData instance = new AdvertisementSearchData();
    public static AdvertisementSearchData getInstance()
    {
        return AdvertisementSearchData.instance;
    }

    private AdvertisementSearchData()
    {
    }

    public readonly string TITLE = "AFFILIATE_TITLE";
    public readonly string PRICE = "AFFILIATE_PRICE";
    public readonly string RELEVANCY = "AFFILIATE_RELEVANCY";
    public readonly string POPULARITY = "AFFILIATE_POPULARITY";
}

