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
using TableMappingInterface = org.allbinary.data.tables.TableMappingInterface;

namespace org.allbinary.business.user.commerce.money.payment.gateway;

public class PaymentGatewayEncryptedMapping : TableMappingInterface
{
    private PaymentGatewayInterface paymentGatewayInterface;
    public PaymentGatewayEncryptedMapping(PaymentGatewayInterface paymentGatewayInterface)
    {
        this.paymentGatewayInterface = paymentGatewayInterface;
    }

    // throws Exception
    public virtual HashMap toHashMap()
    {
        return this.paymentGatewayInterface.toHashMap(true);
    }

    public virtual BasicArrayList toVector()
    {
        return this.paymentGatewayInterface.toVector(true);
    }

    // throws Exception
    public virtual object getKey()
    {
        return ((object) this.paymentGatewayInterface.getKey());
    }

}

