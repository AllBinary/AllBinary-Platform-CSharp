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
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using ShippingInterface = org.allbinary.business.user.commerce.shipping.modules.ShippingInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.user.commerce.shipping;

public class ShippingMethods : ShippingMethodsInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private BasicArrayList shippingVector;
    private ShippingInterface defaultShippingMethodInterface;
    public ShippingMethods(AbeClientInformationInterface abeClientInformation, StoreFrontInterface storeFrontInterface)
    {
        this.defaultShippingMethodInterface = new ShippingMethodsFactory(abeClientInformation, storeFrontInterface).getDefaultInstance();
        this.shippingVector = new ShippingMethodsFactory(abeClientInformation, storeFrontInterface).getInstance();
    }

    public virtual BasicArrayList get()
    {
        return this.shippingVector;
    }

    // throws Exception
    public virtual ShippingInterface getShippingInterface(string name)
    {
        ShippingInterface shipping = null;
        int size = this.shippingVector.size();
        for (int index = 0; index < size; index++) {
            shipping = ((ShippingInterface) this.shippingVector.get(index));
            if (string.CompareOrdinal(name, shipping.getName()) == 0) {
                return shipping;
            }
        }
        string error = "Error Finding Shipping: " + name;
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SHIPPINGERROR)) {
            this.logUtil.putF(this.commonStrings.EXCEPTION, this, "getShippingInterface(String name)");
        }
        throw new Exception(error);
    }

    // throws Exception
    public virtual ShippingInterface getDefault()
    {
        return this.defaultShippingMethodInterface;
    }

}

