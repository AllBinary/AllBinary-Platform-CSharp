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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using BasicPaymentType = org.allbinary.business.user.commerce.money.payment.types.BasicPaymentType;
using BasicPaymentTypeUtil = org.allbinary.business.user.commerce.money.payment.types.BasicPaymentTypeUtil;
using StdUtil = org.allbinary.logic.StdUtil;
using RequestParams = org.allbinary.logic.communication.http.request.RequestParams;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace org.allbinary.business.user.commerce.money.payment.gateway;

public class PaymentGatewayInterfaceFactory : PaymentGatewayInterfaceFactoryInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public PaymentGatewayInterfaceFactory()
    {
    }

    // throws Exception
    public virtual PaymentGatewayInterface getInstance(HttpServletRequest httpServletRequest)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        try {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PAYMENT)) {
                this.logUtil.putF("Getting", this, commonStrings.GET_INSTANCE);
            }
            return this.getInstance(new RequestParams(httpServletRequest).toHashMap());
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PAYMENTERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, "getInstance(HttpServletRequest)", e);
            }
            throw e;
        }
    }

    // throws Exception
    public virtual PaymentGatewayInterface getInstance(BasicPaymentType paymentType)
    {
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(PaymentGatewayData.NAME.ToString(), paymentType.getName());
        return this.getInstance(hashMap);
    }

    // throws Exception
    public virtual PaymentGatewayInterface getInstance(HashMap<object, object> hashMap)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        try {
            string gatewayName = ((string) hashMap.get(PaymentGatewayData.NAME.ToString()));
            BasicPaymentType paymentType = BasicPaymentTypeUtil.getInstance().get(gatewayName);
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PAYMENT)) {
                this.logUtil.putF("Getting PaymentGatewayInterface for PaymentType: " + paymentType.getName() + " with: " + hashMap, this, commonStrings.GET_INSTANCE);
            }
            PaymentGatewayInterfaceFactoryInterface paymentGatewayInterfaceFactoryInterface = paymentType.getPaymentGatewayInterfaceFactoryInterface();
            return paymentGatewayInterfaceFactoryInterface.getInstance(hashMap);
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PAYMENTERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.GET_INSTANCE, e);
            }
            throw e;
        }
    }

}

