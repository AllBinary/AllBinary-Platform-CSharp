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
using PaymentProcessorInterface = org.allbinary.business.user.commerce.money.payment.gateway.processor.PaymentProcessorInterface;
using PaymentProcessorInterfaceFactory = org.allbinary.business.user.commerce.money.payment.gateway.processor.PaymentProcessorInterfaceFactory;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoHttpInterface = org.allbinary.logic.visual.transform.info.TransformInfoHttpInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;

namespace views.admin.payment;

public class PaymentProcessorComponent : HttpStoreComponentView
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public PaymentProcessorComponent(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    // throws Exception
    public virtual void addDomNodeInterfaces()
    {
        PaymentProcessorInterface paymentProcessorInterface = PaymentProcessorInterfaceFactory.getInstance().getInstance(this.getTransformInfoInterface());
        paymentProcessorInterface.process();
        TransformInfoHttpInterface httpTransformInfoInterface = ((TransformInfoHttpInterface) this.getTransformInfoInterface());
        httpTransformInfoInterface.getWeblisketSession().removeBasket();
        this.addDomNodeInterface(((DomNodeInterface) paymentProcessorInterface));
    }

    // throws Exception
    public virtual string view()
    {
        try {
            this.addDomNodeInterfaces();
            return base.view();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

}

