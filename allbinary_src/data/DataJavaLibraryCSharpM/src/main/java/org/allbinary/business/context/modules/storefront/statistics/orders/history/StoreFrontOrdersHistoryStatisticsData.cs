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

namespace org.allbinary.business.context.modules.storefront.statistics.orders.history;

public class StoreFrontOrdersHistoryStatisticsData
{
    private static readonly StoreFrontOrdersHistoryStatisticsData instance = new StoreFrontOrdersHistoryStatisticsData();
    public static StoreFrontOrdersHistoryStatisticsData getInstance()
    {
        return StoreFrontOrdersHistoryStatisticsData.instance;
    }

    private StoreFrontOrdersHistoryStatisticsData()
    {
    }

    public readonly string NAME = "STOREFRONT_ORDERS_HISTORY_STATISTICS_NAME";
    public readonly string NUMBEROFORDERS = "STOREFRONT_ORDERS_HISTORY_STATISTICS_NUMBER_OF_ORDERS";
    public readonly string SUBTOTAL = "STOREFRONT_ORDERS_HISTORY_STATISTICS_SUBTOTAL";
    public readonly string SHIPPINGCOST = "STOREFRONT_ORDERS_HISTORY_STATISTICS_SHIPPINGCOST";
    public readonly string TAXES = "STOREFRONT_ORDERS_HISTORY_STATISTICS_TAXES";
    public readonly string TOTAL = "STOREFRONT_ORDERS_HISTORY_STATISTICS_TOTAL";
}

