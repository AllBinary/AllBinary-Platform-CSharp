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
using PaymentProcessorInterfaceFactoryInterface = org.allbinary.business.user.commerce.money.payment.gateway.processor.PaymentProcessorInterfaceFactoryInterface;
using PaymentTransactionInterfaceFactoryInterface = org.allbinary.business.user.commerce.money.payment.gateway.transaction.PaymentTransactionInterfaceFactoryInterface;
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.business.user.commerce.money.payment.types;

public class PaymentType
{
    private readonly BasicPaymentType basicPaymentType;
    private readonly PaymentTransactionInterfaceFactoryInterface paymentTransactionInterfaceFactoryInterface;
    private readonly PaymentProcessorInterfaceFactoryInterface paymentProcessorInterfaceFactoryInterface;
    public PaymentType(BasicPaymentType basicPaymentType)
    {
        this.basicPaymentType = basicPaymentType;
        this.paymentTransactionInterfaceFactoryInterface = null;
        this.paymentProcessorInterfaceFactoryInterface = null;
        PaymentTypeUtil.getInstance().add(this);
    }

    public PaymentType(BasicPaymentType basicPaymentType, PaymentTransactionInterfaceFactoryInterface paymentTransactionInterfaceFactoryInterface, PaymentProcessorInterfaceFactoryInterface paymentProcessorInterfaceFactoryInterface)
    {
        this.basicPaymentType = basicPaymentType;
        this.paymentTransactionInterfaceFactoryInterface = paymentTransactionInterfaceFactoryInterface;
        this.paymentProcessorInterfaceFactoryInterface = paymentProcessorInterfaceFactoryInterface;
        PaymentTypeUtil.getInstance().add(this);
    }

    // throws Exception
    public virtual PaymentTransactionInterfaceFactoryInterface getPaymentTransactionInterfaceFactoryInterface()
    {
        if (this.paymentTransactionInterfaceFactoryInterface == null) {
            throw new Exception("PaymentTransactionInterfaceFactoryInterface is Null");
        }
        return this.paymentTransactionInterfaceFactoryInterface;
    }

    // throws Exception
    public virtual PaymentProcessorInterfaceFactoryInterface getPaymentProcessorInterfaceFactoryInterface()
    {
        if (this.paymentProcessorInterfaceFactoryInterface == null) {
            throw new Exception("PaymentProcessorInterfaceFactoryInterface is Null");
        }
        return this.paymentProcessorInterfaceFactoryInterface;
    }

    public virtual BasicArrayList toVector()
    {
        BasicArrayList vector = new BasicArrayListD();
        vector.addAllList(this.getBasicPaymentType().toVector());
        if (this.paymentTransactionInterfaceFactoryInterface != null) {
            vector.add(this.paymentTransactionInterfaceFactoryInterface.GetType().FullName);
        }
        if (this.paymentProcessorInterfaceFactoryInterface != null) {
            vector.add(this.paymentProcessorInterfaceFactoryInterface.GetType().FullName);
        }
        return vector;
    }

    public virtual HashMap<object, object> toHashMap()
    {
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        hashMap.putAll(this.getBasicPaymentType().toHashMap());
        if (this.paymentTransactionInterfaceFactoryInterface != null) {
            hashMap.put(PaymentGatewayData.PAYMENTTRANSACTIONINTERFACEFACTORYINTERFACE.ToString(), this.paymentTransactionInterfaceFactoryInterface.GetType().FullName);
        }
        if (this.paymentProcessorInterfaceFactoryInterface != null) {
            hashMap.put(PaymentGatewayData.PAYMENTPROCESSORINTERFACEFACTORYINTERFACE.ToString(), this.paymentProcessorInterfaceFactoryInterface.GetType().FullName);
        }
        return hashMap;
    }

    public virtual BasicPaymentType getBasicPaymentType()
    {
        return this.basicPaymentType;
    }

}

