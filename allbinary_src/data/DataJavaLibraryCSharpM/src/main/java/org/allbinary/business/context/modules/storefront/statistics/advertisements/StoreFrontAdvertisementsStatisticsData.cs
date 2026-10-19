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

namespace org.allbinary.business.context.modules.storefront.statistics.advertisements;

public class StoreFrontAdvertisementsStatisticsData
{
    private static readonly StoreFrontAdvertisementsStatisticsData instance = new StoreFrontAdvertisementsStatisticsData();
    public static StoreFrontAdvertisementsStatisticsData getInstance()
    {
        return StoreFrontAdvertisementsStatisticsData.instance;
    }

    private StoreFrontAdvertisementsStatisticsData()
    {
    }

    public readonly string NAME = "STOREFRONT_ADVERTISEMENTS_STATISTICS_NAME";
}

