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
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.user.commerce.money.payment.gateway;

public class PaymentGatewayView : DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private PaymentGatewayInterface paymentGatewayInterface;
    public PaymentGatewayView(PaymentGatewayInterface paymentGatewayInterface)
    {
        this.paymentGatewayInterface = paymentGatewayInterface;
    }

    public virtual PaymentGatewayInterface getPaymentGatewayInterface()
    {
        return this.paymentGatewayInterface;
    }

    // throws Exception
    public virtual HashMap<object, object> toHashMap()
    {
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF(this.commonStrings.START, this, "toXmlNode");
            }
            HashMap<object, object> hashMap = new PaymentGatewayMapping(this.paymentGatewayInterface).toHashMap();
            hashMap.putAll(this.toHashMap());
            Node paymentGatewayNode = ModDomHelper.createNodeWithValueNodes(document, PaymentGatewayData.NAME.ToString(), hashMap);
            return paymentGatewayNode;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().XSLLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "toXmlNode", e);
            }
            throw e;
        }
    }

}

