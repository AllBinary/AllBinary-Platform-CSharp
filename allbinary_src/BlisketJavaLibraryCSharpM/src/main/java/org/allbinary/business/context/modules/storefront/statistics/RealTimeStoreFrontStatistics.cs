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
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using StoreFrontAdvertisementsStatistics = org.allbinary.business.context.modules.storefront.statistics.advertisements.StoreFrontAdvertisementsStatistics;
using StoreFrontAdvertisementsStatisticsInterface = org.allbinary.business.context.modules.storefront.statistics.advertisements.StoreFrontAdvertisementsStatisticsInterface;
using StoreFrontInventoryStatistics = org.allbinary.business.context.modules.storefront.statistics.inventory.StoreFrontInventoryStatistics;
using StoreFrontInventoryStatisticsInterface = org.allbinary.business.context.modules.storefront.statistics.inventory.StoreFrontInventoryStatisticsInterface;
using StoreFrontOrdersHistoryStatistics = org.allbinary.business.context.modules.storefront.statistics.orders.history.StoreFrontOrdersHistoryStatistics;
using StoreFrontOrdersHistoryStatisticsInterface = org.allbinary.business.context.modules.storefront.statistics.orders.history.StoreFrontOrdersHistoryStatisticsInterface;
using StoreFrontUsersStatistics = org.allbinary.business.context.modules.storefront.statistics.users.StoreFrontUsersStatistics;
using StoreFrontUsersStatisticsInterface = org.allbinary.business.context.modules.storefront.statistics.users.StoreFrontUsersStatisticsInterface;

namespace org.allbinary.business.context.modules.storefront.statistics;

public class RealTimeStoreFrontStatistics : StoreFrontStatisticsInterface
{
    private StoreFrontAdvertisementsStatisticsInterface storeFrontAdvertisementsStatisticsInterface;
    private StoreFrontUsersStatisticsInterface storeFrontUsersStatisticsInterface;
    private StoreFrontInventoryStatisticsInterface storeFrontInventoryStatisticsInterface;
    private StoreFrontOrdersHistoryStatisticsInterface storeFrontOrderHistoryStatisticsInterface;
    public RealTimeStoreFrontStatistics(StoreFrontInterface storeFrontInterface)
    {
        this.storeFrontAdvertisementsStatisticsInterface = ((StoreFrontAdvertisementsStatisticsInterface) new StoreFrontAdvertisementsStatistics(storeFrontInterface));
        this.storeFrontUsersStatisticsInterface = ((StoreFrontUsersStatisticsInterface) new StoreFrontUsersStatistics(storeFrontInterface));
        this.storeFrontInventoryStatisticsInterface = ((StoreFrontInventoryStatisticsInterface) new StoreFrontInventoryStatistics(storeFrontInterface));
        this.storeFrontOrderHistoryStatisticsInterface = ((StoreFrontOrdersHistoryStatisticsInterface) new StoreFrontOrdersHistoryStatistics(storeFrontInterface));
    }

    public virtual StoreFrontAdvertisementsStatisticsInterface getAdvertisements()
    {
        return this.storeFrontAdvertisementsStatisticsInterface;
    }

    public virtual StoreFrontUsersStatisticsInterface getUsers()
    {
        return this.storeFrontUsersStatisticsInterface;
    }

    public virtual StoreFrontInventoryStatisticsInterface getInventory()
    {
        return this.storeFrontInventoryStatisticsInterface;
    }

    public virtual StoreFrontOrdersHistoryStatisticsInterface getOrders()
    {
        return this.storeFrontOrderHistoryStatisticsInterface;
    }

}

