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
using OrderHistory = org.allbinary.business.user.commerce.inventory.order.OrderHistory;
using PaymentType = org.allbinary.business.user.commerce.money.payment.types.PaymentType;
using PaymentTypeUtil = org.allbinary.business.user.commerce.money.payment.types.PaymentTypeUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.user.commerce.money.payment.gateway.transaction;

public class PaymentTransactionInterfaceFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly PaymentTransactionInterfaceFactory instance = new PaymentTransactionInterfaceFactory();
    public static PaymentTransactionInterfaceFactory getInstance()
    {
        return PaymentTransactionInterfaceFactory.instance;
    }

    private PaymentTransactionInterfaceFactory()
    {
    }

    // throws Exception
    public virtual PaymentTransactionInterface getInstance(OrderHistory orderReview)
    {
        try {
            string gatewayName = orderReview.getPaymentMethod();
            if (gatewayName != null) {
                PaymentType paymentType = PaymentTypeUtil.getInstance().get(gatewayName);
                PaymentTransactionInterfaceFactoryInterface paymentTransactionInterfaceFactoryInterface = paymentType.getPaymentTransactionInterfaceFactoryInterface();
                PaymentTransactionInterface paymentTransactionInterface = paymentTransactionInterfaceFactoryInterface.getInstance(orderReview);
                return paymentTransactionInterface;
            }
            throw new Exception("Failed to create PaymentTransactionInterface: " + "GatewayName is: " + gatewayName);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PAYMENTERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put("Failed to generate test data", this, commonStrings.GET_INSTANCE, e);
            }
            throw e;
        }
    }

}

