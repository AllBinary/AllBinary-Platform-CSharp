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
using StoreFrontAdvertisementsStatisticsInterface = org.allbinary.business.context.modules.storefront.statistics.advertisements.StoreFrontAdvertisementsStatisticsInterface;
using StoreFrontInventoryStatisticsInterface = org.allbinary.business.context.modules.storefront.statistics.inventory.StoreFrontInventoryStatisticsInterface;
using StoreFrontOrdersHistoryStatisticsInterface = org.allbinary.business.context.modules.storefront.statistics.orders.history.StoreFrontOrdersHistoryStatisticsInterface;
using StoreFrontUsersStatisticsInterface = org.allbinary.business.context.modules.storefront.statistics.users.StoreFrontUsersStatisticsInterface;

namespace org.allbinary.business.context.modules.storefront.statistics;

public interface StoreFrontStatisticsInterface
{
    StoreFrontAdvertisementsStatisticsInterface getAdvertisements();

    StoreFrontUsersStatisticsInterface getUsers();

    StoreFrontInventoryStatisticsInterface getInventory();

    StoreFrontOrdersHistoryStatisticsInterface getOrders();

}

