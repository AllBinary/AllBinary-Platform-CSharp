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
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using EntryData = org.allbinary.business.entry.EntryData;
using UserData = org.allbinary.business.user.UserData;
using BillingAddressData = org.allbinary.business.user.address.BillingAddressData;
using ShippingAddressData = org.allbinary.business.user.address.ShippingAddressData;
using OrderData = org.allbinary.business.user.commerce.inventory.order.OrderData;
using OrderHistoryData = org.allbinary.business.user.commerce.inventory.order.OrderHistoryData;
using PaymentData = org.allbinary.business.user.commerce.money.payment.PaymentData;
using ShippingMethodData = org.allbinary.business.user.commerce.shipping.ShippingMethodData;
using OrderHistoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.order.OrderHistoryEntityFactory;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace admin.taghelpers;

public class UpdateOrderHelper : TagHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private HttpServletRequest request;
    private string entryId = null;
    private string orderId = null;
    private string userName = null;
    private string storeName = null;
    private string shipDate = null;
    private string orderDate = null;
    private string transDate = null;
    private string cancelDate = null;
    private string status = null;
    private string paymentMethod = null;
    private string name = null;
    private string type = null;
    private string expiration = null;
    private string number = null;
    private string encryption = null;
    private string billingName = null;
    private string billingStreet = null;
    private string billingCity = null;
    private string billingState = null;
    private string billingCode = null;
    private string billingCountry = null;
    private string shippingName = null;
    private string shippingStreet = null;
    private string shippingCity = null;
    private string shippingState = null;
    private string shippingCode = null;
    private string shippingCountry = null;
    private string shippingMethodName = null;
    private string subTotal = null;
    private string shippingCost = null;
    private string tax = null;
    private string total = null;
    private string special = null;
    private string userComment = null;
    private string userCancelComment = null;
    private string storeComment = null;
    private string storeCancelComment = null;
    public UpdateOrderHelper(HashMap<object, object> hashMap, PageContext pageContext)
    {
        this.request = ((HttpServletRequest) pageContext.getRequest());
        this.getFormData();
    }

    private void getFormData()
    {
        this.entryId = this.request.getParameter(EntryData.getInstance().ID);
        this.orderId = this.request.getParameter(OrderData.ID);
        this.userName = this.request.getParameter(UserData.USERNAME);
        this.storeName = this.request.getParameter(StoreFrontData.getInstance().NAME);
        this.shipDate = this.request.getParameter(OrderHistoryData.SHIPPEDDATE);
        this.orderDate = this.request.getParameter(OrderHistoryData.ORDERDATE);
        this.transDate = this.request.getParameter(OrderHistoryData.TRANSDATE);
        this.cancelDate = this.request.getParameter(OrderHistoryData.CANCELDATE);
        this.status = this.request.getParameter(OrderHistoryData.STATUS);
        this.paymentMethod = this.request.getParameter(PaymentData.METHOD);
        this.name = this.request.getParameter(PaymentData.NAME);
        this.type = this.request.getParameter(PaymentData.TYPE);
        this.expiration = this.request.getParameter(PaymentData.EXPIRATION);
        this.number = this.request.getParameter(PaymentData.NUMBER);
        this.encryption = this.request.getParameter(EntryData.getInstance().ENCRYPTION);
        this.billingName = this.request.getParameter(BillingAddressData.NAME);
        this.billingStreet = this.request.getParameter(BillingAddressData.STREET);
        this.billingCity = this.request.getParameter(BillingAddressData.CITY);
        this.billingState = this.request.getParameter(BillingAddressData.STATE);
        this.billingCode = this.request.getParameter(BillingAddressData.CODE);
        this.billingCountry = this.request.getParameter(BillingAddressData.COUNTRY);
        this.shippingName = this.request.getParameter(ShippingAddressData.NAME);
        this.shippingStreet = this.request.getParameter(ShippingAddressData.STREET);
        this.shippingCity = this.request.getParameter(ShippingAddressData.CITY);
        this.shippingState = this.request.getParameter(ShippingAddressData.STATE);
        this.shippingCode = this.request.getParameter(ShippingAddressData.CODE);
        this.shippingCountry = this.request.getParameter(ShippingAddressData.COUNTRY);
        this.shippingMethodName = this.request.getParameter(ShippingMethodData.NAME);
        this.subTotal = this.request.getParameter(OrderHistoryData.SUBTOTAL);
        this.shippingCost = this.request.getParameter(OrderHistoryData.SHIPPINGCOST);
        this.tax = this.request.getParameter(OrderHistoryData.TAX);
        this.total = this.request.getParameter(OrderHistoryData.TOTAL);
        this.special = this.request.getParameter(EntryData.getInstance().SPECIAL);
        this.userComment = this.request.getParameter(OrderData.CUSTOMERCOMMENT);
        this.userCancelComment = this.request.getParameter(OrderData.CUSTOMERCANCELCOMMENT);
        this.storeComment = this.request.getParameter(OrderData.STORECOMMENT);
        this.storeCancelComment = this.request.getParameter(OrderData.STORECANCELCOMMENT);
    }

    public virtual string update()
    {
        try {
            string success = "Successful update";
            HashMap<object, object> orderHashMap = StdUtil.getInstance().createHashMap();
            HashMap<object, object> whereHashMap = StdUtil.getInstance().createHashMap();
            orderHashMap.put(EntryData.getInstance().ID, this.entryId);
            orderHashMap.put(OrderData.ID, this.orderId);
            orderHashMap.put(UserData.USERNAME, userName);
            orderHashMap.put(StoreFrontData.getInstance().NAME, this.storeName);
            orderHashMap.put(OrderHistoryData.SHIPPEDDATE, shipDate);
            orderHashMap.put(OrderHistoryData.ORDERDATE, orderDate);
            orderHashMap.put(OrderHistoryData.TRANSDATE, transDate);
            orderHashMap.put(OrderHistoryData.CANCELDATE, cancelDate);
            orderHashMap.put(OrderHistoryData.STATUS, status);
            orderHashMap.put(PaymentData.METHOD, paymentMethod);
            orderHashMap.put(PaymentData.NAME, name);
            orderHashMap.put(PaymentData.TYPE, type);
            orderHashMap.put(PaymentData.EXPIRATION, expiration);
            orderHashMap.put(BillingAddressData.NAME, billingName);
            orderHashMap.put(BillingAddressData.STREET, billingStreet);
            orderHashMap.put(BillingAddressData.CITY, billingCity);
            orderHashMap.put(BillingAddressData.STATE, billingState);
            orderHashMap.put(BillingAddressData.CODE, billingCode);
            orderHashMap.put(BillingAddressData.COUNTRY, billingCountry);
            orderHashMap.put(ShippingAddressData.NAME, shippingName);
            orderHashMap.put(ShippingAddressData.STREET, shippingStreet);
            orderHashMap.put(ShippingAddressData.CITY, shippingCity);
            orderHashMap.put(ShippingAddressData.STATE, shippingState);
            orderHashMap.put(ShippingAddressData.CODE, shippingCode);
            orderHashMap.put(ShippingAddressData.COUNTRY, shippingCountry);
            orderHashMap.put(ShippingMethodData.NAME, this.shippingMethodName);
            orderHashMap.put(OrderHistoryData.SUBTOTAL, this.subTotal);
            orderHashMap.put(OrderHistoryData.SHIPPINGCOST, this.shippingCost);
            orderHashMap.put(OrderHistoryData.TAX, this.tax);
            orderHashMap.put(OrderHistoryData.TOTAL, this.total);
            orderHashMap.put(EntryData.getInstance().SPECIAL, this.special);
            orderHashMap.put(OrderData.CUSTOMERCOMMENT, this.userComment);
            orderHashMap.put(OrderData.CUSTOMERCANCELCOMMENT, this.userCancelComment);
            orderHashMap.put(OrderData.STORECOMMENT, this.storeComment);
            orderHashMap.put(OrderData.STORECANCELCOMMENT, this.storeCancelComment);
            whereHashMap.put(OrderData.ID, orderId);
            OrderHistoryEntityFactory.getInstance().update(whereHashMap, orderHashMap);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "update()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to update order table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "update()", e);
            }
            return error;
        }
    }

}

