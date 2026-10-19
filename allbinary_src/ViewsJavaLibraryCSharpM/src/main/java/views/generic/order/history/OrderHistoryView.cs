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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using OrderData = org.allbinary.business.user.commerce.inventory.order.OrderData;
using OrderHistory = org.allbinary.business.user.commerce.inventory.order.OrderHistory;
using OrderHistoryData = org.allbinary.business.user.commerce.inventory.order.OrderHistoryData;
using OrderHistoryEntity = org.allbinary.data.tables.user.commerce.inventory.order.OrderHistoryEntity;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using GLOBALS2 = org.allbinary.globals.GLOBALS2;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;

namespace views.generic.order.history;

public class OrderHistoryView : HttpStoreComponentView, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private HttpServletRequest request;
    private string shipped;
    private string partiallyShipped;
    private string processing;
    private string preprocessing;
    private string cancelled;
    public OrderHistoryView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.request = ((HttpServletRequest) this.getPageContext().getRequest());
        this.preprocessing = this.request.getParameter(OrderHistoryData.PREPROCESSINGNAME);
        this.shipped = this.request.getParameter(OrderHistoryData.SHIPPEDNAME);
        this.partiallyShipped = this.request.getParameter(OrderHistoryData.PARTIALLYSHIPPEDNAME);
        this.processing = this.request.getParameter(OrderHistoryData.PROCESSINGNAME);
        this.cancelled = this.request.getParameter(OrderHistoryData.CANCELLEDNAME);
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        try {
            Node node = document.createElement(OrderData.ORDERS);
            OrderHistoryEntity orderHistoryEntity = new OrderHistoryEntity();
            BasicArrayList orderReviewVector = orderHistoryEntity.getOrders(this.getWeblisketSession().getUserName());
            int size = orderReviewVector.size();
            for (int index = 0; index < size; index++) {
                OrderHistory orderHistory = ((OrderHistory) orderReviewVector.get(index));
                Node orderHistoryNode = orderHistory.toXmlNode(document);
                Node orderNode = document.createElement(orderHistory.getPaymentMethod());
                node.appendChild(orderHistory.toXmlNode(document));
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Attempt to View a users order history", this, "view");
            }
            node.appendChild(ModDomHelper.createNameValueNodes(document, OrderHistoryData.PREPROCESSINGNAME, OrderHistoryData.PREPROCESSING));
            node.appendChild(ModDomHelper.createNameValueNodes(document, OrderHistoryData.PROCESSINGNAME, OrderHistoryData.PROCESSING));
            node.appendChild(ModDomHelper.createNameValueNodes(document, OrderHistoryData.CANCELLEDNAME, OrderHistoryData.CANCELLED));
            node.appendChild(ModDomHelper.createNameValueNodes(document, OrderHistoryData.PARTIALLYSHIPPEDNAME, OrderHistoryData.PARTIALLYSHIPPED));
            node.appendChild(ModDomHelper.createNameValueNodes(document, OrderHistoryData.SHIPPEDNAME, OrderHistoryData.SHIPPED));
            node.appendChild(ModDomHelper.createNameValueNodes(document, GLOBALS2.VIEWNAME, GLOBALS2.VIEW));
            return node;
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

    // throws Exception
    public virtual string view()
    {
        try {
            this.addDomNodeInterfaces();
            return base.view();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

}

