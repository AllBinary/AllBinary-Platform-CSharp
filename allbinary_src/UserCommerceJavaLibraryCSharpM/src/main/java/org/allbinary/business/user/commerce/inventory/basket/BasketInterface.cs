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
using Money = org.allbinary.business.user.commerce.money.Money;
using MoneyException = org.allbinary.business.user.commerce.money.MoneyException;

namespace org.allbinary.business.user.commerce.inventory.basket;

public interface BasketInterface
{
    void addItem(string id, string num);

    void removeItem(string id);

    void adjustItem(string id, string num);

    string getTotalWeight();

    int? getNumberOfItems();

    Set getIds();

    HashMap getItems();

    int? getNumberOf(string product);

    // throws MoneyException
    Money getSubTotal();

}

