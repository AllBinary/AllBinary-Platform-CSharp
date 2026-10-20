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
using MoneyException = org.allbinary.business.user.commerce.money.MoneyException;
using BasicDataTableInterface = org.allbinary.data.tables.BasicDataTableInterface;

namespace org.allbinary.data.tables.user.commerce.inventory.item;

public interface InventoryEntityInterface : BasicDataTableInterface
{
    // throws MoneyException
    ItemInterface getItem(string id);

    // throws Exception
    BasicArrayList getItems(StoreFrontInterface storeFrontInterface);

    string getWeight(string id);

    void deleteWhere(string key, string value);

    void insert(BasicArrayList values);

    void update(HashMap<object, object> updatedValues);

}

