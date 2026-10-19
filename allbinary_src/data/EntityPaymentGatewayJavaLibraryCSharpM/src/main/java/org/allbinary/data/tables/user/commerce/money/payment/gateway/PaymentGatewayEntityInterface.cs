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
using PaymentGatewayInterface = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayInterface;
using BasicPaymentType = org.allbinary.business.user.commerce.money.payment.types.BasicPaymentType;
using BasicDataTableInterface = org.allbinary.data.tables.BasicDataTableInterface;

namespace org.allbinary.data.tables.user.commerce.money.payment.gateway;

public interface PaymentGatewayEntityInterface : BasicDataTableInterface
{
    PaymentGatewayInterface getPaymentGatewayInterface(string storeName, BasicPaymentType paymentType);

    BasicArrayList findPaymentTypeVectorByStore(string storeName);

    void remove(string storeName, BasicPaymentType paymentType);

    void add(PaymentGatewayInterface paymentGatewayInterface);

    void update(PaymentGatewayInterface paymentGatewayInterface);

}

