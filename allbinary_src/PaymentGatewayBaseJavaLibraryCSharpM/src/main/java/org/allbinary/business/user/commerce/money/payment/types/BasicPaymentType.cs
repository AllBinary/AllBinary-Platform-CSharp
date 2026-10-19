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
using PaymentGatewayData = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayData;
using PaymentGatewayInterfaceFactoryInterface = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayInterfaceFactoryInterface;
using PaymentGatewayDomNodeFactoryInterface = org.allbinary.business.user.commerce.money.payment.gateway.modules.gateway.PaymentGatewayDomNodeFactoryInterface;
using StdUtil = org.allbinary.logic.StdUtil;
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using Replace = org.allbinary.logic.@string.regex.replace.Replace;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.business.user.commerce.money.payment.types;

public class BasicPaymentType
{
    private string name = null;
    private string value = null;
    private PaymentGatewayInterfaceFactoryInterface paymentGatewayInterfaceFactoryInterface;
    private PaymentGatewayDomNodeFactoryInterface paymentGatewayDomNodeFactoryInterface;
    protected BasicPaymentType(string paymentMethod)
    {
        this.init(paymentMethod);
    }

    protected BasicPaymentType(string paymentMethod, PaymentGatewayInterfaceFactoryInterface paymentGatewayInterfaceFactoryInterface, PaymentGatewayDomNodeFactoryInterface paymentGatewayDomNodeFactoryInterface)
    {
        this.init(paymentMethod);
        this.paymentGatewayInterfaceFactoryInterface = paymentGatewayInterfaceFactoryInterface;
        this.paymentGatewayDomNodeFactoryInterface = paymentGatewayDomNodeFactoryInterface;
    }

    private void init(string paymentMethod)
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        string UNDERSCORE = "_";
        hashMap.put(CommonSeps.getInstance().SPACE, UNDERSCORE);
        hashMap.put(AbPathData.getInstance().EXTENSION_SEP, UNDERSCORE);
        hashMap.put("-", UNDERSCORE);
        Replace replace = new Replace(hashMap);
        this.name = replace.all(paymentMethod);
        this.value = paymentMethod;
        BasicPaymentTypeUtil.getInstance().add(this);
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual string getValue()
    {
        return this.value;
    }

    // throws Exception
    public virtual PaymentGatewayInterfaceFactoryInterface getPaymentGatewayInterfaceFactoryInterface()
    {
        if (this.paymentGatewayInterfaceFactoryInterface == null) {
            throw new Exception("PaymentGatewayInterfaceFactoryInterface is Null");
        }
        return this.paymentGatewayInterfaceFactoryInterface;
    }

    // throws Exception
    public virtual PaymentGatewayDomNodeFactoryInterface getPaymentGatewayDomNodeFactoryInterface()
    {
        if (this.paymentGatewayDomNodeFactoryInterface == null) {
            throw new Exception("PaymentGatewayDomNodeFactoryInterface is Null");
        }
        return this.paymentGatewayDomNodeFactoryInterface;
    }

    public virtual object getKey()
    {
        return this.getName();
    }

    public virtual BasicArrayList toVector()
    {
        BasicArrayList vector = new BasicArrayListD();
        vector.add(this.name);
        vector.add(this.value);
        return vector;
    }

    public virtual HashMap toHashMap()
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(PaymentGatewayData.NAME.ToString(), this.name);
        hashMap.put(PaymentGatewayData.VALUE.ToString(), this.value);
        return hashMap;
    }

    public override string ToString()
    {
        return this.name;
    }

}

