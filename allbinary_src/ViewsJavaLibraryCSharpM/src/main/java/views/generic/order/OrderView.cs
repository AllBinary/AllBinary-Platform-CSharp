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
using Basket = org.allbinary.business.user.commerce.inventory.basket.Basket;
using BasketReview = org.allbinary.business.user.commerce.inventory.basket.BasketReview;
using Order = org.allbinary.business.user.commerce.inventory.order.Order;
using OrderData = org.allbinary.business.user.commerce.inventory.order.OrderData;
using OrderHistory = org.allbinary.business.user.commerce.inventory.order.OrderHistory;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;

namespace views.generic.order;

public class OrderView : HttpStoreComponentView, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private HttpServletRequest request;
    public Order order = null;
    public OrderHistory orderHistory = null;
    public BasketReview basketReview = null;
    public OrderView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.request = ((HttpServletRequest) this.getPageContext().getRequest());
        this.getFormData();
    }

    // throws Exception
    private void getFormData()
    {
        string id = this.request.getParameter(OrderData.ID);
        if (id == null) {
            id = this.getWeblisketSession().getOrder().getId();
        }
        this.order = new Order(new Basket());
        this.order.setId(id);
    }

    public virtual Node toXmlNode(Document document)
    {
        try {
            Node orderHistoryNode = this.orderHistory.toXmlNode(document);
            Node node = document.createElement(this.orderHistory.getPaymentMethod());
            orderHistoryNode.appendChild(this.basketReview.toXmlNode(document));
            node.appendChild(orderHistoryNode);
            return node;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().XSLLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "toXmlNode", e);
            }
            return null;
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

