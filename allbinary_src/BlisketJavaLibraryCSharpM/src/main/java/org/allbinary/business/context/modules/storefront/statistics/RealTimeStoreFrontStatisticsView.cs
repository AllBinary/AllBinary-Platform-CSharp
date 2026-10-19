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
using StoreFrontAdvertisementsStatisticsView = org.allbinary.business.context.modules.storefront.statistics.advertisements.StoreFrontAdvertisementsStatisticsView;
using StoreFrontInventoryStatisticsInterface = org.allbinary.business.context.modules.storefront.statistics.inventory.StoreFrontInventoryStatisticsInterface;
using StoreFrontInventoryStatisticsView = org.allbinary.business.context.modules.storefront.statistics.inventory.StoreFrontInventoryStatisticsView;
using StoreFrontOrdersHistoryStatisticsInterface = org.allbinary.business.context.modules.storefront.statistics.orders.history.StoreFrontOrdersHistoryStatisticsInterface;
using StoreFrontOrdersHistoryStatisticsView = org.allbinary.business.context.modules.storefront.statistics.orders.history.StoreFrontOrdersHistoryStatisticsView;
using StoreFrontUsersStatisticsInterface = org.allbinary.business.context.modules.storefront.statistics.users.StoreFrontUsersStatisticsInterface;
using StoreFrontUsersStatisticsView = org.allbinary.business.context.modules.storefront.statistics.users.StoreFrontUsersStatisticsView;
using UserRole = org.allbinary.business.user.role.UserRole;
using UserRoleFactory = org.allbinary.business.user.role.UserRoleFactory;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.context.modules.storefront.statistics;

public class RealTimeStoreFrontStatisticsView : DomNodeInterface
{
    private readonly StoreFrontStatisticsInterface storeFrontStatisticsInterface;
    private readonly UserRole userRole;
    public RealTimeStoreFrontStatisticsView(StoreFrontStatisticsInterface storeFrontStatisticsInterface, UserRole userRole)
    {
        this.storeFrontStatisticsInterface = storeFrontStatisticsInterface;
        this.userRole = userRole;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = document.createElement(StoreFrontStatisticsData.getInstance().NAME);
        StoreFrontAdvertisementsStatisticsInterface storeFrontAdvertisementsStatisticsInterface = this.storeFrontStatisticsInterface.getAdvertisements();
        DomNodeInterface storeFrontAdvertisementsStatisticsDomNodeInterface = new StoreFrontAdvertisementsStatisticsView(storeFrontAdvertisementsStatisticsInterface);
        node.appendChild(storeFrontAdvertisementsStatisticsDomNodeInterface.toXmlNode(document));
        StoreFrontInventoryStatisticsInterface storeFrontInventoryStatisticsInterface = this.storeFrontStatisticsInterface.getInventory();
        DomNodeInterface storeFrontInventoryStatisticsDomNodeInterface = new StoreFrontInventoryStatisticsView(storeFrontInventoryStatisticsInterface);
        node.appendChild(storeFrontInventoryStatisticsDomNodeInterface.toXmlNode(document));
        StoreFrontOrdersHistoryStatisticsInterface storeFrontOrdersHistoryStatisticsInterface = this.storeFrontStatisticsInterface.getOrders();
        DomNodeInterface storeFrontOrdersHistoryStatisticsDomNodeInterface = new StoreFrontOrdersHistoryStatisticsView(storeFrontOrdersHistoryStatisticsInterface);
        node.appendChild(storeFrontOrdersHistoryStatisticsDomNodeInterface.toXmlNode(document));
        if (this.userRole == UserRoleFactory.getInstance().ADMINISTRATOR) {
            StoreFrontUsersStatisticsInterface storeFrontUsersStatisticsInterface = this.storeFrontStatisticsInterface.getUsers();
            DomNodeInterface storeFrontUsersStatisticsDomNodeInterface = new StoreFrontUsersStatisticsView(storeFrontUsersStatisticsInterface);
            node.appendChild(storeFrontUsersStatisticsDomNodeInterface.toXmlNode(document));
        }
        return node;
    }

}

