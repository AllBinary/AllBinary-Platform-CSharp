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
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using Order = org.allbinary.business.user.commerce.inventory.order.Order;
using OrderHistory = org.allbinary.business.user.commerce.inventory.order.OrderHistory;
using BasicDataTableInterface = org.allbinary.data.tables.BasicDataTableInterface;

namespace org.allbinary.data.tables.user.commerce.inventory.order;

public interface OrderHistoryEntityInterface : BasicDataTableInterface
{
    void insert(string userName, Order order);

    void setStatus(string orderId, string status);

    void setPaymentMethod(string orderId, string status);

    // throws Exception
    BasicArrayList getStoreOrders(StoreFrontInterface storeFrontInterface);

    // throws Exception
    BasicArrayList getOrders(string userName);

    // throws Exception
    BasicArrayList getOrders(string status, string fromDate, string toDate);

    // throws Exception
    OrderHistory getOrder(string id);

    // throws Exception
    void update(HashMap whereHashMap, HashMap orderHashMap);

}

