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
using OrderHistoryInterface = org.allbinary.business.user.commerce.inventory.order.OrderHistoryInterface;
using Money = org.allbinary.business.user.commerce.money.Money;
using OrderHistoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.order.OrderHistoryEntityFactory;
using OrderHistoryEntityInterface = org.allbinary.data.tables.user.commerce.inventory.order.OrderHistoryEntityInterface;
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.business.context.modules.storefront.statistics.orders.history;

public class StoreFrontOrdersHistoryStatistics : StoreFrontOrdersHistoryStatisticsInterface
{
    private long? numberOfOrdersLong;
    private Money subTotalMoney;
    private Money shippingCostMoney;
    private Money taxesMoney;
    private Money totalMoney;
    public StoreFrontOrdersHistoryStatistics(StoreFrontInterface storeFrontInterface)
    {
        this.subTotalMoney = new Money();
        this.shippingCostMoney = new Money();
        this.taxesMoney = new Money();
        this.totalMoney = new Money();
        OrderHistoryEntityInterface orderHistoryEntityInterface = OrderHistoryEntityFactory.getInstance();
        BasicArrayList orderHistoryInterfaceVector = orderHistoryEntityInterface.getStoreOrders(storeFrontInterface);
        long numberOfOrders = 0L;
        OrderHistoryInterface orderHistoryInterface = null;
        int size = orderHistoryInterfaceVector.size();
        for (int index = 0; index < size; index++) {
            orderHistoryInterface = ((OrderHistoryInterface) orderHistoryInterfaceVector.get(index));
            numberOfOrders = numberOfOrders + 1L;
            this.subTotalMoney.add(orderHistoryInterface.getSubTotal());
            this.shippingCostMoney.add(orderHistoryInterface.getShippingCost());
            this.taxesMoney.add(orderHistoryInterface.getTaxes());
            this.totalMoney.add(orderHistoryInterface.getTotal());
        }
        this.numberOfOrdersLong = numberOfOrders;
    }

    public virtual long? getNumberOfOrders()
    {
        return this.numberOfOrdersLong;
    }

    public virtual Money getSubTotal()
    {
        return this.subTotalMoney;
    }

    public virtual Money getShippingCost()
    {
        return this.shippingCostMoney;
    }

    public virtual Money getTaxes()
    {
        return this.taxesMoney;
    }

    public virtual Money getTotal()
    {
        return this.totalMoney;
    }

    public virtual HashMap<object, object> toHashMap()
    {
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        StoreFrontOrdersHistoryStatisticsData storeFrontOrdersHistoryStatisticsData = StoreFrontOrdersHistoryStatisticsData.getInstance();
        hashMap.put(storeFrontOrdersHistoryStatisticsData.NUMBEROFORDERS, this.getNumberOfOrders().ToString());
        hashMap.put(storeFrontOrdersHistoryStatisticsData.SUBTOTAL, this.getSubTotal().ToString());
        hashMap.put(storeFrontOrdersHistoryStatisticsData.SHIPPINGCOST, this.getShippingCost().ToString());
        hashMap.put(storeFrontOrdersHistoryStatisticsData.TAXES, this.getTaxes().ToString());
        hashMap.put(storeFrontOrdersHistoryStatisticsData.TOTAL, this.getTotal().ToString());
        return hashMap;
    }

    public virtual BasicArrayList toVector()
    {
        return null;
    }

    public virtual object getKey()
    {
        return null;
    }

}

