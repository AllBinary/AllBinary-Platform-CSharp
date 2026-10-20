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
using OrderData = org.allbinary.business.user.commerce.inventory.order.OrderData;
using OrderHistory = org.allbinary.business.user.commerce.inventory.order.OrderHistory;
using OrderHistoryData = org.allbinary.business.user.commerce.inventory.order.OrderHistoryData;
using OrderStatusEmail = org.allbinary.business.user.commerce.inventory.order.status.OrderStatusEmail;
using ShippingMethodData = org.allbinary.business.user.commerce.shipping.ShippingMethodData;
using OrderHistoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.order.OrderHistoryEntityFactory;
using OrderItemsEntityFactory = org.allbinary.data.tables.user.commerce.inventory.order.OrderItemsEntityFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;

namespace admin.taghelpers;

public class OrderHistoryRequestHelper : TagHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
    private HttpServletRequest request;
    private string id = null;
    private string groupId = null;
    private string status = null;
    public OrderHistoryRequestHelper(HashMap<object, object> hashMap, PageContext pageContext)
    {
        this.request = ((HttpServletRequest) pageContext.getRequest());
        this.getFormData();
    }

    private void getFormData()
    {
        this.id = this.request.getParameter(OrderData.ID);
        this.groupId = this.request.getParameter(ShippingMethodData.GROUP);
        this.status = this.request.getParameter(OrderHistoryData.STATUS);
    }

    public virtual string setOrderStatus()
    {
        try {
            if (string.CompareOrdinal(this.groupId, CommonPhoneStrings.getInstance().ZERO) != 0) {
                if (OrderItemsEntityFactory.getInstance().isEverythingShipped(this.id)) {
                    this.status = OrderHistoryData.SHIPPED;
                } else {
                    this.status = OrderHistoryData.PARTIALLYSHIPPED;
                }
            }
            string success = "Status successfully set to: " + this.status;
            OrderHistoryEntityFactory.getInstance().setStatus(this.id, this.status);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF("Success", this, "setOrderStatus()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to set order status";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "setOrderStatus()", e);
            }
            return error;
        }
    }

    public virtual string setOrderStatus(string newStatus)
    {
        try {
            if (newStatus == null) {
                newStatus = this.status;
            }
            string success = "Status successfully set to: " + newStatus;
            OrderHistoryEntityFactory.getInstance().setStatus(this.id, newStatus);
            OrderHistory orderHistory = OrderHistoryEntityFactory.getInstance().getOrder(this.id);
            new OrderStatusEmail(this.abeClientInformation, orderHistory).process();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF("Success", this, "setOrderStatus()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to view order table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "setOrderStatus(newStatus)", e);
            }
            return error;
        }
    }

}

