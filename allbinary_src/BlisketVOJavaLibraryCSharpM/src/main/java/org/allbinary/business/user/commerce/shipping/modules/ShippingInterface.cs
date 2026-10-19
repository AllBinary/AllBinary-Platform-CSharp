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
using OrderInterface = org.allbinary.business.user.commerce.inventory.order.OrderInterface;
using Money = org.allbinary.business.user.commerce.money.Money;

namespace org.allbinary.business.user.commerce.shipping.modules;

public interface ShippingInterface
{
    Money getCost(OrderInterface order);

    string getName();

    string getDescription();

}

