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
using EntryData = org.allbinary.business.entry.EntryData;
using ShippingAddressData = org.allbinary.business.user.address.ShippingAddressData;
using StreetAddress = org.allbinary.business.user.address.StreetAddress;
using StreetAddressData = org.allbinary.business.user.address.StreetAddressData;
using OrderHistoryData = org.allbinary.business.user.commerce.inventory.order.OrderHistoryData;
using MoneyException = org.allbinary.business.user.commerce.money.MoneyException;
using ShippingMethodData = org.allbinary.business.user.commerce.shipping.ShippingMethodData;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.business.user.commerce.inventory.item;

public class Item : BasicItem, OrderItemInterface
{
    private string group;
    private string tax;
    private string shippingType;
    private string shippingCost;
    private string shippedDate = null;
    private StreetAddress shippingAddress;
    private string special = null;
    public Item(HashMap<object, object> itemHashMap) : base(itemHashMap)
    {
        // base(itemHashMap) is called from the constructor declaration
        this.setData(itemHashMap);
    }

    public Item()
    {
        string EMPTY = StringUtil.getInstance().EMPTY_STRING;
        this.group = EMPTY;
        this.tax = EMPTY;
        this.shippingType = EMPTY;
        this.shippingCost = EMPTY;
        this.shippingAddress = new StreetAddress();
    }

    private void setData(HashMap<object, object> itemHashMap)
    {
        this.group = ((string) itemHashMap.get(ShippingMethodData.GROUP));
        this.tax = ((string) itemHashMap.get(OrderHistoryData.TAX));
        this.shippingType = ((string) itemHashMap.get(ShippingMethodData.NAME));
        this.shippingCost = ((string) itemHashMap.get(ShippingMethodData.COST));
        this.shippedDate = ((string) itemHashMap.get(OrderHistoryData.SHIPPEDDATE));
        itemHashMap.put(StreetAddressData.NAME, itemHashMap.get(ShippingAddressData.NAME));
        itemHashMap.put(StreetAddressData.STREET, itemHashMap.get(ShippingAddressData.STREET));
        itemHashMap.put(StreetAddressData.CITY, itemHashMap.get(ShippingAddressData.CITY));
        itemHashMap.put(StreetAddressData.STATE, itemHashMap.get(ShippingAddressData.STATE));
        itemHashMap.put(StreetAddressData.CODE, itemHashMap.get(ShippingAddressData.CODE));
        itemHashMap.put(StreetAddressData.COUNTRY, itemHashMap.get(ShippingAddressData.COUNTRY));
        this.shippingAddress = new StreetAddress(itemHashMap);
    }

    public virtual void setGroup(string value)
    {
        this.group = value;
    }

    public virtual void setTax(string value)
    {
        this.tax = value;
    }

    public virtual void setShippingType(string value)
    {
        this.shippingType = value;
    }

    public virtual void setShippingCost(string value)
    {
        this.shippingCost = value;
    }

    public virtual void setShippingAddress(StreetAddress value)
    {
        this.shippingAddress = value;
    }

    public virtual void setSpecial(string value)
    {
        this.special = value;
    }

    public virtual string getGroup()
    {
        return this.group;
    }

    public virtual string getTax()
    {
        return this.tax;
    }

    public virtual string getShippingType()
    {
        return this.shippingType;
    }

    public virtual string getShippingCost()
    {
        return this.shippingCost;
    }

    public virtual StreetAddress getShippingAddress()
    {
        return this.shippingAddress;
    }

    public virtual string getSpecial()
    {
        return this.special;
    }

    public virtual HashMap<object, object> toHashMap()
    {
        HashMap<object, object> hashMap = base.toHashMap();
        hashMap.put(ShippingMethodData.GROUP, this.group);
        hashMap.put(OrderHistoryData.TAX, this.tax);
        hashMap.put(ShippingMethodData.NAME, this.shippingType);
        hashMap.put(ShippingMethodData.COST, this.shippingCost);
        hashMap.put(OrderHistoryData.SHIPPEDDATE, this.shippedDate);
        hashMap.put(EntryData.getInstance().SPECIAL, this.special);
        return hashMap;
    }

}

