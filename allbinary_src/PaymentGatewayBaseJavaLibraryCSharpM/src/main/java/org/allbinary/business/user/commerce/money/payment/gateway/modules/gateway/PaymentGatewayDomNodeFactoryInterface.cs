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
using PaymentGatewayInterface = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayInterface;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;

namespace org.allbinary.business.user.commerce.money.payment.gateway.modules.gateway;

public interface PaymentGatewayDomNodeFactoryInterface
{
    DomNodeInterface getInstance(PaymentGatewayInterface paymentGatewayInterface);

}

