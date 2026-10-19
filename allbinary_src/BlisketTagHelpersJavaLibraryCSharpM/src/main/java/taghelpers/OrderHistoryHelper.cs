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
//using PageContext = javax.servlet.jsp.PageContext;
using TagHelper = admin.taghelpers.TagHelper;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using StreetAddress = org.allbinary.business.user.address.StreetAddress;
using OrderData = org.allbinary.business.user.commerce.inventory.order.OrderData;
using OrderHistoryData = org.allbinary.business.user.commerce.inventory.order.OrderHistoryData;
using OrderHistoryFactory = org.allbinary.business.user.commerce.inventory.order.OrderHistoryFactory;
using OrderHistoryInterface = org.allbinary.business.user.commerce.inventory.order.OrderHistoryInterface;
using ShippingMethodData = org.allbinary.business.user.commerce.shipping.ShippingMethodData;
using OrderHistoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.order.OrderHistoryEntityFactory;
using OrderHistoryEntityInterface = org.allbinary.data.tables.user.commerce.inventory.order.OrderHistoryEntityInterface;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace taghelpers;

public class OrderHistoryHelper : TagHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private WeblisketSession weblisketSession = null;
    private StoreFrontInterface storeFrontInterface = null;
    private readonly HashMap propertiesHashMap;
    private readonly PageContext pageContext;
    private readonly HttpServletRequest request;
    private StreetAddress streetAddress = null;
    private string id = null;
    private string groupId = null;
    private string status = null;
    private string newStatus;
    public OrderHistoryHelper(HashMap propertiesHashMap, PageContext pageContext)
    {
        this.propertiesHashMap = propertiesHashMap;
        this.pageContext = pageContext;
        this.request = ((HttpServletRequest) pageContext.getRequest());
        string storeName = ((string) propertiesHashMap.get(StoreFrontData.getInstance().NAME));
        this.newStatus = ((string) propertiesHashMap.get(OrderHistoryData.STATUS));
        if (storeName != null) {
            this.storeFrontInterface = StoreFrontFactory.getInstance(storeName);
        }
        this.getFormData();
    }

    private void getFormData()
    {
        this.id = this.request.getParameter(OrderData.ID);
        this.groupId = this.request.getParameter(ShippingMethodData.GROUP);
        if (this.newStatus == null) {
            this.newStatus = this.request.getParameter(OrderHistoryData.STATUS);
        }
    }

    public virtual string setOrderStatus()
    {
        try {
            string success = "Status successfully set to: " + this.status;
            OrderHistoryInterface orderReviewInterface = OrderHistoryFactory.getInstance(this.id);
            string status = orderReviewInterface.getStatus();
            if (string.CompareOrdinal(status, OrderHistoryData.CANCELLED) == 0) {
                return "Order " + this.id + " Already Cancelled<br/>";
            } else if (string.CompareOrdinal(status, OrderHistoryData.SHIPPED) == 0) {
                return "Order " + this.id + " Already Shipped. You can't cancel a shipped order.<br/>";
            } else if (string.CompareOrdinal(status, OrderHistoryData.PREPROCESSING) == 0) {
                return "Order " + this.id + " has been cancelled.<br/>";
            } else if (string.CompareOrdinal(status, OrderHistoryData.PARTIALLYSHIPPED) == 0) {
                return "Order " + this.id + " Partially Shipped. You can cancel unshipped items, but not the whole order.<br/>";
            } else if (string.CompareOrdinal(status, OrderHistoryData.PROCESSING) == 0) {
                OrderHistoryEntityInterface orderHistoryEntityInterface = OrderHistoryEntityFactory.getInstance();
                orderHistoryEntityInterface.setStatus(this.id, this.newStatus);
                return "Order " + this.id + " has been cancelled.<br/>";
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "setOrderStatus()");
            }
            return "Error Setting Order Status";
        } catch (Exception e) {
            string error = "Failed to set order status";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "setOrderStatus()", e);
            }
            return error + "<br/>" + "Exception: " + e + "<br/>";
        }
    }

}

