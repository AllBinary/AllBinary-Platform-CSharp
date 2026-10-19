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
using BasketInterface = org.allbinary.business.user.commerce.inventory.basket.BasketInterface;
using OrderInterface = org.allbinary.business.user.commerce.inventory.order.OrderInterface;
using Money = org.allbinary.business.user.commerce.money.Money;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.user.commerce.shipping.modules;

public class BasicWeightShippingModule : ShippingInterface
{
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly string name = "Basic Shipping (5 to 7 working days)";
    private readonly string description = "We will soon provide a variety of shipping methods.";
    public BasicWeightShippingModule()
    {
    }

    public virtual Money getCost(OrderInterface order)
    {
        BasketInterface basket = order.getBasket();
        Money money = new Money();
        money.add(basket.getTotalWeight());
        money.multiply(1);
        money.add("3.50");
        return money;
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

