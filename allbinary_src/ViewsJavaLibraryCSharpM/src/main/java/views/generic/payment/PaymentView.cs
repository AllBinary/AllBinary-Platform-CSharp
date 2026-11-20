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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using Payment = org.allbinary.business.user.commerce.money.payment.Payment;
using PaymentData = org.allbinary.business.user.commerce.money.payment.PaymentData;
using PaymentEntityFactory = org.allbinary.data.tables.user.commerce.money.payment.PaymentEntityFactory;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace views.generic.payment;

public class PaymentView : HttpStoreComponentView, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public PaymentView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        try {
            Node paymentNode = document.createElement(PaymentData.PAYMENT);
            document.appendChild(paymentNode);
            BasicArrayList paymentVector = PaymentEntityFactory.getInstance().getPaymentEntityInstance().get(this.getWeblisketSession().getUserName());
            int size = paymentVector.size();
            for (int index = 0; index < size; index++) {
                Payment payment = ((Payment) paymentVector.get(index));
                paymentNode.appendChild(payment.toXmlNode(document));
            }
            return paymentNode;
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "toXmlNode", e);
            }
            throw e;
        }
    }

    public virtual void addDomNodeInterfaces()
    {
        this.addDomNodeInterface(((DomNodeInterface) this));
    }

    public override string view()
    {
        try {
            this.addDomNodeInterfaces();
            return base.view();
        } catch (Exception e) {
            string error = "Failed to view Payment";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            return error;
        }
    }

}

