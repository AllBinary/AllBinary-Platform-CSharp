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
//using ServletRequest = javax.servlet.ServletRequest;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.user.commerce.money.payment;

public class PaymentFactory
{
    private PaymentFactory()
    {
    }

    public static PaymentInterface getInstance(ServletRequest request)
    {
        LogUtil logUtil = LogUtil.getInstance();
        try {
            return ((PaymentInterface) new org.allbinary.business.user.commerce.money.payment.Payment(request));
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().FACTORYERROR)) {
                logUtil.put(commonStrings.EXCEPTION, "PaymentFactory", commonStrings.GET_INSTANCE, e);
            }
            return null;
        }
    }

}

