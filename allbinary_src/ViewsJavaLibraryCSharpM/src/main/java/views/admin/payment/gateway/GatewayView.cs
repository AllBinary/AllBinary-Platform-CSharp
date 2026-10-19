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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using PaymentGatewayInterface = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayInterface;
using BasicPaymentTypeUtil = org.allbinary.business.user.commerce.money.payment.types.BasicPaymentTypeUtil;
using PaymentGatewayEntityFactory = org.allbinary.data.tables.user.commerce.money.payment.gateway.PaymentGatewayEntityFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;

namespace views.admin.payment.gateway;

public class GatewayView : PaymentGatewayViewAbstract
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public GatewayView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    public virtual void getFormData(HttpServletRequest request)
    {
        base.getFormData(request);
        if (StringValidationUtil.getInstance().isEmpty(this.getPaymentGatewayPrimaryKey().getName())) {
            this.getPaymentGatewayPrimaryKey().setName(this.getWeblisketSession().getPaymentMethod());
        }
    }

    // throws Exception
    public virtual string view()
    {
        try {
            PaymentGatewayInterface paymentGatewayInterface = PaymentGatewayEntityFactory.getInstance().getPaymentGatewayInterface(this.getPaymentGatewayPrimaryKey().getStoreName(), BasicPaymentTypeUtil.getInstance().get(this.getPaymentGatewayPrimaryKey().getName()));
            return new PaymentGatewayComponent(this.getTransformInfoInterface(), paymentGatewayInterface).view();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "edit()", e);
            }
            throw e;
        }
    }

}

