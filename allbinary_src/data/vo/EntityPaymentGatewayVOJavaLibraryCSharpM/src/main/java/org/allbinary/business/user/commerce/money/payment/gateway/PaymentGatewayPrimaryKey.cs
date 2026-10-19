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
using StoreFront = org.allbinary.business.context.modules.storefront.StoreFront;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.business.user.commerce.money.payment.gateway;

public class PaymentGatewayPrimaryKey : java.io.Serializable
{
    private string storeName = null;
    private string name = null;
    public PaymentGatewayPrimaryKey(string storeName, string gatewayName)
    {
        this.setStoreName(storeName);
        this.setName(gatewayName);
    }

    public virtual string getStoreName()
    {
        return this.storeName;
    }

    public virtual void setStoreName(string storeName)
    {
        this.storeName = storeName;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual void setName(string name)
    {
        this.name = name;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(typeof(PaymentGatewayPrimaryKey).getName());
        stringBuffer.append(typeof(StoreFront).getName());
        stringBuffer.append(" =");
        stringBuffer.append(this.getStoreName());
        stringBuffer.append(CommonSeps.getInstance().SPACE);
        stringBuffer.append(typeof(PaymentGateway).getName());
        stringBuffer.append("=");
        stringBuffer.append(this.getName());
        return stringBuffer.ToString();
    }

}

