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
using System.Runtime.CompilerServices;
using PaymentTransactionInterface = org.allbinary.business.user.commerce.money.payment.gateway.transaction.PaymentTransactionInterface;
using PaymentTransactionInterfaceRequestFactory = org.allbinary.business.user.commerce.money.payment.gateway.transaction.PaymentTransactionInterfaceRequestFactory;
using PaymentType = org.allbinary.business.user.commerce.money.payment.types.PaymentType;
using PaymentTypeUtil = org.allbinary.business.user.commerce.money.payment.types.PaymentTypeUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.user.commerce.money.payment.gateway.processor;

public class PaymentProcessorInterfaceFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly PaymentProcessorInterfaceFactory instance = new PaymentProcessorInterfaceFactory();
    public static PaymentProcessorInterfaceFactory getInstance()
    {
        return PaymentProcessorInterfaceFactory.instance;
    }

    private PaymentProcessorInterfaceFactory()
    {
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual PaymentProcessorInterface getInstance(TransformInfoInterface transformInfoInterface)
    {
        try {
            PaymentTransactionInterface paymentTransactionInterface = PaymentTransactionInterfaceRequestFactory.getInstance().getInstance(transformInfoInterface);
            string gatewayName = paymentTransactionInterface.getOrderHistory().getPaymentMethod();
            if (!StringValidationUtil.getInstance().isEmpty(gatewayName)) {
                PaymentType paymentType = PaymentTypeUtil.getInstance().get(gatewayName);
                PaymentProcessorInterfaceFactoryInterface paymentProcessorInterfaceFactoryInterface = paymentType.getPaymentProcessorInterfaceFactoryInterface();
                return ((PaymentProcessorInterface) paymentProcessorInterfaceFactoryInterface.getInstance(transformInfoInterface, paymentTransactionInterface));
            }
            throw new Exception("Error Getting PaymentProcessorInterface");
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PAYMENTERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
            }
            throw e;
        }
    }

}

