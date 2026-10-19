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
using ItemInterface = org.allbinary.business.user.commerce.inventory.item.ItemInterface;
using Money = org.allbinary.business.user.commerce.money.Money;
using InventoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntityFactory;
using InventoryEntityInterface = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntityInterface;
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.business.context.modules.storefront.statistics.inventory;

public class StoreFrontInventoryStatistics : StoreFrontInventoryStatisticsInterface
{
    private long totalNumberOfItems = 0L;
    private Money totalInventorySaleValueMoney;
    public StoreFrontInventoryStatistics(StoreFrontInterface storeFrontInterface)
    {
        this.totalInventorySaleValueMoney = new Money();
        InventoryEntityInterface inventoryEntityInterface = InventoryEntityFactory.getInstance().getInventoryEntityInstance();
        BasicArrayList itemVector = inventoryEntityInterface.getItems(storeFrontInterface);
        int size = itemVector.size();
        for (int index = 0; index < size; index++) {
            ItemInterface itemInterface = ((ItemInterface) itemVector.get(index));
            int numberInStock = ((int) (itemInterface.getNumber()).ToString());
            this.totalNumberOfItems = this.totalNumberOfItems + ((long) numberInStock);
            Money itemPriceMoney = itemInterface.getPrice();
            itemPriceMoney.multiply(numberInStock);
            this.totalInventorySaleValueMoney.add(itemPriceMoney.ToString());
        }
    }

    public virtual long? getNumber()
    {
        return this.totalNumberOfItems;
    }

    public virtual Money getTotal()
    {
        return this.totalInventorySaleValueMoney;
    }

    public virtual HashMap toHashMap()
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(StoreFrontInventoryStatisticsData.getInstance().NUMBEROFITEMS, this.getNumber().ToString());
        hashMap.put(StoreFrontInventoryStatisticsData.getInstance().TOTALVALUE, this.getTotal().ToString());
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

