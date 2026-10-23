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
using Serializable = java.io.Serializable;
using java.util;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using EntryData = org.allbinary.business.entry.EntryData;
using BasketInterface = org.allbinary.business.user.commerce.inventory.basket.BasketInterface;
using PaymentData = org.allbinary.business.user.commerce.money.payment.PaymentData;
using ShippingMethodData = org.allbinary.business.user.commerce.shipping.ShippingMethodData;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.user.commerce.inventory.order;

public class Order : OrderInterface, Serializable
{
    private readonly BasketInterface basket;
    private string paymentMethod;
    private string shippingType;
    private string storeName;
    private string special;
    private string id;
    private string userComment = null;
    private string userCancelComment = null;
    private string storeComment = null;
    private string storeCancelComment = null;
    public Order(BasketInterface basket)
    {
        this.basket = basket;
        this.id = null;
        this.shippingType = StringUtil.getInstance().EMPTY_STRING;
    }

    public Order(string storeName, BasketInterface basket, string id, string shippingType, string special, string paymentMethod)
    {
        this.storeName = storeName;
        this.basket = basket;
        this.id = id;
        this.shippingType = shippingType;
        this.special = special;
        this.paymentMethod = paymentMethod;
    }

    public virtual bool? isIdValid()
    {
        if (this.getId() == null || this.getId().compareTo(StringUtil.getInstance().EMPTY_STRING) == 0 || this.getId().length() > OrderHistoryData.MAXIDLEN || !StringValidationUtil.getInstance().isNumber(this.getId())) {
            return false;
        }
        return true;
    }

    public virtual bool? isValid()
    {
        return true;
    }

    public virtual string getIdValidationInfo()
    {
        string EMPTY_STRING = StringUtil.getInstance().EMPTY_STRING;
        if (this.getId() == null || this.getId().compareTo(EMPTY_STRING) == 0 || this.getId().length() > OrderHistoryData.MAXIDLEN || !StringValidationUtil.getInstance().isNumber(this.getId())) {
            return "Please enter a valid order Id < " + OrderHistoryData.MAXIDLEN + " digits in length.<br>";
        }
        return EMPTY_STRING;
    }

    public virtual void setShippingMethod(string shippingType)
    {
        this.shippingType = shippingType;
    }

    public virtual void setPaymentMethod(string value)
    {
        this.paymentMethod = value;
    }

    public virtual void setSpecial(string special)
    {
        this.special = special;
    }

    public virtual void setId(string value)
    {
        this.id = value;
    }

    public virtual void setStoreName(string value)
    {
        this.storeName = value;
    }

    public virtual void setUserComments(string value)
    {
        this.userComment = value;
    }

    public virtual void setUserCancelComments(string value)
    {
        this.userCancelComment = value;
    }

    public virtual void setStoreComments(string value)
    {
        this.storeComment = value;
    }

    public virtual void setStoreCancelComments(string value)
    {
        this.storeCancelComment = value;
    }

    public virtual BasketInterface getBasket()
    {
        return this.basket;
    }

    public virtual string getShippingMethod()
    {
        return this.shippingType;
    }

    public virtual string getPaymentMethod()
    {
        return this.paymentMethod;
    }

    public virtual string getSpecial()
    {
        return this.special;
    }

    public virtual string getId()
    {
        return this.id;
    }

    public virtual string getStoreName()
    {
        return this.storeName;
    }

    public virtual string getUserComments()
    {
        return this.userComment;
    }

    public virtual string getUserCancelComments()
    {
        return this.userCancelComment;
    }

    public virtual string getStoreComments()
    {
        return this.storeComment;
    }

    public virtual string getStoreCancelComments()
    {
        return this.storeCancelComment;
    }

    public virtual string reviewOrder(string paymentMethod)
    {
        return "Create your own Order.reviewOrder";
    }

    public virtual string viewOrder(string paymentMethod)
    {
        return "Create your own Order.viewOrder";
    }

    public virtual string emailOrder(string userName, string paymentMethod, StoreFrontInterface storeFrontInterface)
    {
        return "Create your own Order.emailOrder";
    }

    public virtual HashMap<object, object> toHashMapOrder()
    {
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(PaymentData.METHOD, this.paymentMethod);
        hashMap.put(ShippingMethodData.NAME, this.shippingType);
        hashMap.put(StoreFrontData.getInstance().NAME, this.storeName);
        hashMap.put(EntryData.getInstance().SPECIAL, this.special);
        hashMap.put(OrderData.ID, this.id);
        hashMap.put(OrderData.CUSTOMERCOMMENT, this.userComment);
        hashMap.put(OrderData.CUSTOMERCANCELCOMMENT, this.userCancelComment);
        hashMap.put(OrderData.STORECOMMENT, this.storeComment);
        hashMap.put(OrderData.STORECANCELCOMMENT, this.storeCancelComment);
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        HashMap<object, object> hashMap = this.toHashMapOrder();
        Set<object> keySet = hashMap.keySet();
        object[] keyArray = keySet.toArray();
        int size = keyArray.Length;
        Node node = document.createElement(OrderData.ORDER);
        for (int i = 0; i < size; i++) {
            string name = ((string) keyArray[i]);
            string value = ((string) hashMap.get(name));
            value = StringUtil.getInstance().getNonNull(value);
            node.appendChild(ModDomHelper.createNameValueNodes(document, name, value));
        }
        return node;
    }

}

