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
using PaymentGatewayDomNodeFactoryInterface = org.allbinary.business.user.commerce.money.payment.gateway.modules.gateway.PaymentGatewayDomNodeFactoryInterface;
using BasicPaymentType = org.allbinary.business.user.commerce.money.payment.types.BasicPaymentType;
using BasicPaymentTypeUtil = org.allbinary.business.user.commerce.money.payment.types.BasicPaymentTypeUtil;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;

namespace views.admin.payment.gateway;

public class PaymentGatewayComponent : HttpStoreComponentView
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private PaymentGatewayInterface paymentGatewayInterface;
    public PaymentGatewayComponent(TransformInfoInterface transformInfoInterface, PaymentGatewayInterface paymentGatewayInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.paymentGatewayInterface = paymentGatewayInterface;
    }

    // throws Exception
    public virtual void addDomNodeInterfaces()
    {
        BasicPaymentType paymentType = BasicPaymentTypeUtil.getInstance().get(this.paymentGatewayInterface.getName());
        PaymentGatewayDomNodeFactoryInterface paymentGatewayDomNodeFactoryInterface = paymentType.getPaymentGatewayDomNodeFactoryInterface();
        DomNodeInterface domNodeInterface = ((DomNodeInterface) paymentGatewayDomNodeFactoryInterface.getInstance(this.paymentGatewayInterface));
        this.addDomNodeInterface(domNodeInterface);
    }

    public virtual string view()
    {
        try {
            this.addDomNodeInterfaces();
            return base.view();
        } catch (Exception e) {
            string error = "Failed to view payment gateway";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            return error;
        }
    }

}

