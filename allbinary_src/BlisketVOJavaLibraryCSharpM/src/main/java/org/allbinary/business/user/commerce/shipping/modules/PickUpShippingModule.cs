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
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.user.commerce.shipping.modules;

public class PickUpShippingModule : ShippingInterface
{
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly string name = "No Shipping (For Pickup Orders Only)";
    private readonly string description = "This shipping method is for pickup orders only.";
    public PickUpShippingModule()
    {
    }

    public virtual Money getCost(OrderInterface order)
    {
        return new Money();
    }

    public virtual string getDescription()
    {
        return this.description;
    }

    public virtual string getName()
    {
        return this.name;
    }

}

