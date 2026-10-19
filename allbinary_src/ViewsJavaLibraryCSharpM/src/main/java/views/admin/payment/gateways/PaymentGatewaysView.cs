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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using EntryData = org.allbinary.business.entry.EntryData;
using PaymentGatewayData = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayData;
using PaymentGatewaysData = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewaysData;
using BasicPaymentType = org.allbinary.business.user.commerce.money.payment.types.BasicPaymentType;
using PaymentTypeUtil = org.allbinary.business.user.commerce.money.payment.types.PaymentTypeUtil;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;

namespace views.admin.payment.gateways;

public class PaymentGatewaysView : HttpStoreComponentView, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private BasicArrayList paymentGatewayVector;
    public PaymentGatewaysView(TransformInfoInterface transformInfoInterface, BasicArrayList gatewayVector) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.paymentGatewayVector = gatewayVector;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        try {
            string storeName = this.getTransformInfoInterface().getStoreName();
            Node paymentGatewaysNode = document.createElement(PaymentGatewaysData.NAME);
            int size = this.paymentGatewayVector.size();
            for (int index = 0; index < size; index++) {
                BasicPaymentType paymentType = ((BasicPaymentType) this.paymentGatewayVector.get(index));
                HashMap hashMap = paymentType.toHashMap();
                hashMap.put(EntryData.getInstance().DEFAULT, PaymentTypeUtil.getInstance().getDefault(storeName).getBasicPaymentType().getName());
                Node paymentGatewayNode = ModDomHelper.createNodeWithValueNodes(document, PaymentGatewayData.NAME.ToString(), hashMap);
                paymentGatewaysNode.appendChild(paymentGatewayNode);
            }
            return paymentGatewaysNode;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().XSLLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "toXmlNode", e);
            }
            throw e;
        }
    }

    public virtual void addDomNodeInterfaces()
    {
        this.addDomNodeInterface(((DomNodeInterface) this));
    }

    public virtual string view()
    {
        try {
            this.addDomNodeInterfaces();
            return base.view();
        } catch (Exception e) {
            string error = "Failed to view payment gateways";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            return error;
        }
    }

}

