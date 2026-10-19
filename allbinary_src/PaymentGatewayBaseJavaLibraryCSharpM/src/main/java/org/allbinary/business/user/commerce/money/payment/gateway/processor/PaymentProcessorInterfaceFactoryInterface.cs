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
using PaymentTransactionInterface = org.allbinary.business.user.commerce.money.payment.gateway.transaction.PaymentTransactionInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;

namespace org.allbinary.business.user.commerce.money.payment.gateway.processor;

public interface PaymentProcessorInterfaceFactoryInterface
{
    // throws Exception
    PaymentProcessorInterface getInstance(TransformInfoInterface transformInfoInterface, PaymentTransactionInterface paymentTransactionInterface);

}

