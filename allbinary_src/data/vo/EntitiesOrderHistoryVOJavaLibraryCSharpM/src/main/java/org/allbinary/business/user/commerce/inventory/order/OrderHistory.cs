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
using Date = java.util.Date;
using java.util;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using EntryData = org.allbinary.business.entry.EntryData;
using UserData = org.allbinary.business.user.UserData;
using BillingAddressData = org.allbinary.business.user.address.BillingAddressData;
using ShippingAddressData = org.allbinary.business.user.address.ShippingAddressData;
using StreetAddress = org.allbinary.business.user.address.StreetAddress;
using BasketInterface = org.allbinary.business.user.commerce.inventory.basket.BasketInterface;
using Money = org.allbinary.business.user.commerce.money.Money;
using MoneyException = org.allbinary.business.user.commerce.money.MoneyException;
using Payment = org.allbinary.business.user.commerce.money.payment.Payment;
using PaymentData = org.allbinary.business.user.commerce.money.payment.PaymentData;
using ShippingMethodData = org.allbinary.business.user.commerce.shipping.ShippingMethodData;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.user.commerce.inventory.order;

public class OrderHistory : Order, OrderHistoryInterface
{
    private string userName;
    private StreetAddress shippingAddress;
    private StreetAddress billingAddress;
    private Payment payment;
    private string shipDate;
    private string orderDate;
    private string transDate;
    private string cancelDate;
    private string status;
    private Money subTotal;
    private Money shippingCost;
    private Money taxes;
    private Money total;
    public OrderHistory(BasketInterface basketInterface) : base(basketInterface)
    {
        // base(basketInterface) is called from the constructor declaration
    }

    public OrderHistory(BasketInterface basketInterface, OrderHistory orderHistory) : base(orderHistory.getStoreName(), basketInterface, orderHistory.getId(), orderHistory.getShippingMethod(), orderHistory.getSpecial(), orderHistory.getPaymentMethod())
    {
        // base(orderHistory.getStoreName(), basketInterface, orderHistory.getId(), orderHistory.getShippingMethod(), orderHistory.getSpecial(), orderHistory.getPaymentMethod()) is called from the constructor declaration
        this.userName = orderHistory.getUserName();
        this.shippingAddress = orderHistory.getShippingAddress();
        this.billingAddress = orderHistory.getBillingAddress();
        this.payment = orderHistory.getPaymentInfo();
        this.shipDate = orderHistory.getShipDate();
        this.orderDate = orderHistory.getOrderDate();
        this.transDate = orderHistory.getTransDate();
        this.cancelDate = orderHistory.getCancelDate();
        this.status = orderHistory.getStatus();
        this.subTotal = orderHistory.getSubTotal();
        this.shippingCost = orderHistory.getShippingCost();
        this.taxes = orderHistory.getTaxes();
        this.total = orderHistory.getTotal();
        base.setUserComments(((string) orderHistory.getUserComments()));
        base.setUserCancelComments(((string) orderHistory.getUserCancelComments()));
        base.setStoreComments(((string) orderHistory.getStoreComments()));
        base.setStoreCancelComments(((string) orderHistory.getStoreCancelComments()));
    }

    public OrderHistory(BasketInterface basketInterface, HashMap orderHistoryHashMap) : base(((string) orderHistoryHashMap.get(StoreFrontData.getInstance().NAME)), basketInterface, ((string) orderHistoryHashMap.get(OrderData.ID)), ((string) orderHistoryHashMap.get(ShippingMethodData.NAME)), ((string) orderHistoryHashMap.get(EntryData.getInstance().SPECIAL)), ((string) orderHistoryHashMap.get(PaymentData.METHOD)))
    {
        // base(((string) orderHistoryHashMap.get(StoreFrontData.getInstance().NAME)), basketInterface, ((string) orderHistoryHashMap.get(OrderData.ID)), ((string) orderHistoryHashMap.get(ShippingMethodData.NAME)), ((string) orderHistoryHashMap.get(EntryData.getInstance().SPECIAL)), ((string) orderHistoryHashMap.get(PaymentData.METHOD))) is called from the constructor declaration
        this.shippingAddress = new StreetAddress(((string) orderHistoryHashMap.get(ShippingAddressData.NAME)), ((string) orderHistoryHashMap.get(ShippingAddressData.STREET)), ((string) orderHistoryHashMap.get(ShippingAddressData.CITY)), ((string) orderHistoryHashMap.get(ShippingAddressData.STATE)), ((string) orderHistoryHashMap.get(ShippingAddressData.CODE)), ((string) orderHistoryHashMap.get(ShippingAddressData.COUNTRY)));
        this.billingAddress = new StreetAddress(((string) orderHistoryHashMap.get(BillingAddressData.NAME)), ((string) orderHistoryHashMap.get(BillingAddressData.STREET)), ((string) orderHistoryHashMap.get(BillingAddressData.CITY)), ((string) orderHistoryHashMap.get(BillingAddressData.STATE)), ((string) orderHistoryHashMap.get(BillingAddressData.CODE)), ((string) orderHistoryHashMap.get(BillingAddressData.COUNTRY)));
        this.payment = new Payment(orderHistoryHashMap);
        this.userName = ((string) orderHistoryHashMap.get(UserData.USERNAME));
        this.orderDate = ((string) orderHistoryHashMap.get(OrderHistoryData.ORDERDATE));
        this.shipDate = ((string) orderHistoryHashMap.get(OrderHistoryData.SHIPPEDDATE));
        this.transDate = ((string) orderHistoryHashMap.get(OrderHistoryData.TRANSDATE));
        this.cancelDate = ((string) orderHistoryHashMap.get(OrderHistoryData.CANCELDATE));
        this.status = ((string) orderHistoryHashMap.get(OrderHistoryData.STATUS));
        this.subTotal = new Money(((string) orderHistoryHashMap.get(OrderHistoryData.SUBTOTAL)));
        this.total = new Money(((string) orderHistoryHashMap.get(OrderHistoryData.TOTAL)));
        this.shippingCost = new Money(((string) orderHistoryHashMap.get(OrderHistoryData.SHIPPINGCOST)));
        this.taxes = new Money(((string) orderHistoryHashMap.get(OrderHistoryData.TAX)));
        base.setUserComments(((string) orderHistoryHashMap.get(OrderData.CUSTOMERCOMMENT)));
        base.setUserCancelComments(((string) orderHistoryHashMap.get(OrderData.CUSTOMERCANCELCOMMENT)));
        base.setStoreComments(((string) orderHistoryHashMap.get(OrderData.STORECOMMENT)));
        base.setStoreCancelComments(((string) orderHistoryHashMap.get(OrderData.STORECANCELCOMMENT)));
    }

    public virtual void setUserName(string value)
    {
        this.userName = value;
    }

    public virtual void setDefaultShippingAddress(StreetAddress shippingAddress)
    {
        this.shippingAddress = shippingAddress;
    }

    public virtual void setBillingAddress(StreetAddress billingAddress)
    {
        this.billingAddress = billingAddress;
    }

    public virtual void setPaymentInfo(Payment payment)
    {
        this.payment = payment;
    }

    public virtual void setShipDate(string value)
    {
        this.shipDate = value;
    }

    public virtual void setOrderDate(string value)
    {
        this.orderDate = value;
    }

    public virtual void setTransDate(string value)
    {
        this.transDate = value;
    }

    public virtual void setCancelDate(string value)
    {
        this.cancelDate = value;
    }

    public virtual void setStatus(string value)
    {
        this.status = value;
    }

    public virtual void setSubTotal(Money value)
    {
        this.subTotal = value;
    }

    public virtual void setShippingCost(Money value)
    {
        this.shippingCost = value;
    }

    public virtual void setTaxes(Money value)
    {
        this.taxes = value;
    }

    public virtual void setTotal(Money value)
    {
        this.total = value;
    }

    public virtual string getUserName()
    {
        return this.userName;
    }

    public virtual StreetAddress getShippingAddress()
    {
        return this.shippingAddress;
    }

    public virtual StreetAddress getBillingAddress()
    {
        return this.billingAddress;
    }

    public virtual Payment getPaymentInfo()
    {
        return this.payment;
    }

    public virtual string getShipDate()
    {
        return this.shipDate;
    }

    public virtual string getOrderDate()
    {
        return this.orderDate;
    }

    public virtual string getTransDate()
    {
        return this.transDate;
    }

    public virtual string getCancelDate()
    {
        return this.cancelDate;
    }

    public virtual string getStatus()
    {
        return this.status;
    }

    public virtual Money getSubTotal()
    {
        return this.subTotal;
    }

    public virtual Money getShippingCost()
    {
        return this.shippingCost;
    }

    public virtual Money getTaxes()
    {
        return this.taxes;
    }

    public virtual Money getTotal()
    {
        return this.total;
    }

    public virtual HashMap toHashMap()
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(UserData.USERNAME, this.userName);
        hashMap.put(OrderHistoryData.ORDERDATE, this.orderDate);
        hashMap.put(OrderHistoryData.SHIPPEDDATE, this.shipDate);
        hashMap.put(OrderHistoryData.TRANSDATE, this.transDate);
        hashMap.put(OrderHistoryData.CANCELDATE, this.cancelDate);
        hashMap.put(OrderHistoryData.ORDERDATEFORMATTED, new Date(((long) this.orderDate)).ToString());
        hashMap.put(OrderHistoryData.SHIPPEDDATEFORMATTED, new Date(((long) this.shipDate)).ToString());
        hashMap.put(OrderHistoryData.TRANSDATEFORMATTED, new Date(((long) this.transDate)).ToString());
        hashMap.put(OrderHistoryData.CANCELDATEFORMATTED, new Date(((long) this.cancelDate)).ToString());
        hashMap.put(OrderHistoryData.STATUS, this.status);
        hashMap.put(OrderHistoryData.SUBTOTAL, this.subTotal.ToString());
        hashMap.put(OrderHistoryData.TOTAL, this.total.ToString());
        hashMap.put(OrderHistoryData.SHIPPINGCOST, this.shippingCost.ToString());
        hashMap.put(OrderHistoryData.TAX, this.taxes.ToString());
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        HashMap hashMap = this.toHashMap();
        Set keySet = hashMap.keySet();
        object[] keyArray = keySet.toArray();
        int size = keyArray.Length;
        Node node = document.createElement(OrderHistoryData.ORDERHISTORY);
        node.appendChild(base.toXmlNode(document));
        Node billingAddressNode = document.createElement(BillingAddressData.BILLINGADDRESS);
        billingAddressNode.appendChild(this.billingAddress.toXmlNode(document));
        Node shippingAddressNode = document.createElement(ShippingAddressData.SHIPPINGADDRESS);
        shippingAddressNode.appendChild(this.shippingAddress.toXmlNode(document));
        node.appendChild(billingAddressNode);
        node.appendChild(shippingAddressNode);
        node.appendChild(this.payment.toXmlNode(document));
        for (int i = 0; i < size; i++) {
            string name = ((string) keyArray[i]);
            string value = ((string) hashMap.get(name));
            value = StringUtil.getInstance().getNonNull(value);
            node.appendChild(ModDomHelper.createNameValueNodes(document, name, value));
        }
        return node;
    }

}

