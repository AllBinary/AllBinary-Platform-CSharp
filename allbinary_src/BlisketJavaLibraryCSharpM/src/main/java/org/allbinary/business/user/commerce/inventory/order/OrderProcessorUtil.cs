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
using OrderIdGenerator = org.allbinary.data.generator.OrderIdGenerator;
using OrderHistoryEntity = org.allbinary.data.tables.user.commerce.inventory.order.OrderHistoryEntity;
using OrderItemsEntity = org.allbinary.data.tables.user.commerce.inventory.order.OrderItemsEntity;

namespace org.allbinary.business.user.commerce.inventory.order;

public class OrderProcessorUtil
{
    private static readonly OrderProcessorUtil instance = new OrderProcessorUtil();
    public static OrderProcessorUtil getInstance()
    {
        return OrderProcessorUtil.instance;
    }

    private readonly string ORDER_PROCESSED = "Order Processed";
    // throws Exception
    public virtual string process(string userName, Order order)
    {
        OrderItemsEntity orderItems = new OrderItemsEntity();
        OrderHistoryEntity orderHistory = new OrderHistoryEntity();
        order.setId(new OrderIdGenerator().getNext());
        orderItems.insert(userName, order);
        orderHistory.insert(userName, order);
        return this.ORDER_PROCESSED;
    }

}

