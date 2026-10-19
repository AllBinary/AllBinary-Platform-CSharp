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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasketReview = org.allbinary.business.user.commerce.inventory.basket.BasketReview;
using OrderInterface = org.allbinary.business.user.commerce.inventory.order.OrderInterface;
using BasicDataTableInterface = org.allbinary.data.tables.BasicDataTableInterface;

namespace org.allbinary.data.tables.user.commerce.inventory.order;

public interface OrderItemsEntityInterface : BasicDataTableInterface
{
    void setStatus(string orderId, string groupId, string status);

    bool isEverythingShipped(string orderId);

    BasketReview getBasketReview(string orderId);

    void insert(string userName, OrderInterface order);

    void insert(BasicArrayList values);

}

