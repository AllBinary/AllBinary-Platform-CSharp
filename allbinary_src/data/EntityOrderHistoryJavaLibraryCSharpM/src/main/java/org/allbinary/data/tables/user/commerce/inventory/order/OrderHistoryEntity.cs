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
using Calendar = java.util.Calendar;
using java.util;
using Random = java.util.Random;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using EntryData = org.allbinary.business.entry.EntryData;
using HistoryDbInitInfo = org.allbinary.business.init.db.HistoryDbInitInfo;
using UserData = org.allbinary.business.user.UserData;
using BillingAddressData = org.allbinary.business.user.address.BillingAddressData;
using ShippingAddressData = org.allbinary.business.user.address.ShippingAddressData;
using StreetAddress = org.allbinary.business.user.address.StreetAddress;
using Basket = org.allbinary.business.user.commerce.inventory.basket.Basket;
using BasketInterface = org.allbinary.business.user.commerce.inventory.basket.BasketInterface;
using Order = org.allbinary.business.user.commerce.inventory.order.Order;
using OrderData = org.allbinary.business.user.commerce.inventory.order.OrderData;
using OrderHistory = org.allbinary.business.user.commerce.inventory.order.OrderHistory;
using OrderHistoryData = org.allbinary.business.user.commerce.inventory.order.OrderHistoryData;
using Money = org.allbinary.business.user.commerce.money.Money;
using PaymentData = org.allbinary.business.user.commerce.money.payment.PaymentData;
using PaymentInterface = org.allbinary.business.user.commerce.money.payment.PaymentInterface;
using TaxFactory = org.allbinary.business.user.commerce.money.tax.TaxFactory;
using ShippingMethodData = org.allbinary.business.user.commerce.shipping.ShippingMethodData;
using ShippingMethods = org.allbinary.business.user.commerce.shipping.ShippingMethods;
using ShippingInterface = org.allbinary.business.user.commerce.shipping.modules.ShippingInterface;
using OrderHistoryIdGenerator = org.allbinary.data.generator.OrderHistoryIdGenerator;
using TableDataFactory = org.allbinary.data.tables.TableDataFactory;
using BillingAddressesEntity = org.allbinary.data.tables.user.address.billing.BillingAddressesEntity;
using ShippingAddressesEntity = org.allbinary.data.tables.user.address.shipping.ShippingAddressesEntity;
using PaymentEntity = org.allbinary.data.tables.user.commerce.money.payment.PaymentEntity;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlBean = org.allbinary.logic.communication.sql.AbSqlBean;
using SuperCrypt = org.allbinary.logic.control.crypt.SuperCrypt;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ServiceClientInformationInterfaceFactory = org.allbinary.logic.system.security.licensing.ServiceClientInformationInterfaceFactory;

namespace org.allbinary.data.tables.user.commerce.inventory.order;

public class OrderHistoryEntity : AbSqlBean, OrderHistoryEntityInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly string tableName = "orderhistory";
    public OrderHistoryEntity() : base(new HistoryDbInitInfo())
    {
        // base(new HistoryDbInitInfo()) is called from the constructor declaration
        this.setTableName(this.tableName);
    }

    public virtual void insert(string userName, Order order)
    {
        BasicArrayList vector = new BasicArrayListD();
        try {
            PaymentInterface paymentInterface = new PaymentEntity().getDefault(userName);
            StreetAddress billingAddress = new BillingAddressesEntity(userName).getDefault();
            StreetAddress shippingAddress = new ShippingAddressesEntity(userName).getDefault();
            AbeClientInformationInterface abeClientInformation = ServiceClientInformationInterfaceFactory.getInstance();
            StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(order.getStoreName());
            ShippingInterface shippingInterface = new ShippingMethods(abeClientInformation, storeFrontInterface).getShippingInterface(order.getShippingMethod());
            Money shippingCost = shippingInterface.getCost(order);
            BasketInterface basketInterface = order.getBasket();
            Money subTotal = basketInterface.getSubTotal();
            float? taxRate = TaxFactory.getInstance().getInstance(abeClientInformation, storeFrontInterface).getTaxRate(shippingAddress, storeFrontInterface);
            Money tax = new Money();
            Money total = new Money();
            total.add(shippingCost.ToString());
            total.add(subTotal.ToString());
            tax.add(total.ToString());
            tax.multiply(taxRate);
            total.add(tax.ToString());
            string empty = StringUtil.getInstance().EMPTY_STRING;
            vector.add(new OrderHistoryIdGenerator().getNext());
            string ZERO = TableDataFactory.getInstance().ZERO_STRING;
            vector.add(order.getId());
            vector.add(userName);
            vector.add(order.getStoreName());
            Calendar calendar = Calendar.getInstance();
            string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
            vector.add(ZERO);
            vector.add(time);
            vector.add(ZERO);
            vector.add(ZERO);
            vector.add(OrderHistoryData.PREPROCESSING);
            vector.add(order.getPaymentMethod());
            if (paymentInterface != null) {
                vector.add(paymentInterface.getName());
                vector.add(paymentInterface.getType());
                vector.add(paymentInterface.getExpiration());
                int random = new Random().nextInt(SuperCrypt.KEYMAX);
                vector.add(new SuperCrypt(random).encrypt(paymentInterface.getNumber()));
                vector.add(random.ToString());
            } else {
                vector.add(empty);
                vector.add(empty);
                vector.add(empty);
                vector.add(empty);
                vector.add(ZERO);
            }
            if (billingAddress != null) {
                vector.add(billingAddress.getName());
                vector.add(billingAddress.getStreet());
                vector.add(billingAddress.getCity());
                vector.add(billingAddress.getState());
                vector.add(billingAddress.getCode());
                vector.add(billingAddress.getCountry());
            } else {
                vector.add(empty);
                vector.add(empty);
                vector.add(empty);
                vector.add(empty);
                vector.add(empty);
                vector.add(empty);
            }
            if (shippingAddress != null) {
                vector.add(shippingAddress.getName());
                vector.add(shippingAddress.getStreet());
                vector.add(shippingAddress.getCity());
                vector.add(shippingAddress.getState());
                vector.add(shippingAddress.getCode());
                vector.add(shippingAddress.getCountry());
            } else {
                vector.add(empty);
                vector.add(empty);
                vector.add(empty);
                vector.add(empty);
                vector.add(empty);
                vector.add(empty);
            }
            vector.add(order.getShippingMethod());
            vector.add(subTotal.ToString());
            vector.add(shippingCost.ToString());
            vector.add(tax.ToString());
            vector.add(total.ToString());
            vector.add(order.getSpecial());
            vector.add(order.getUserComments());
            vector.add(order.getUserCancelComments());
            vector.add(order.getStoreComments());
            vector.add(order.getStoreCancelComments());
            this.insert(vector);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, INSERT);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put("Command Failed: " + vector, this, INSERT, e);
            }
        }
    }

    public virtual void insert(BasicArrayList values)
    {
        try {
            base.insert(values);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.putF(this.commonStrings.SUCCESS, this, INSERT);
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, INSERT, e);
            }
        }
    }

    public virtual void setStatus(string orderId, string status)
    {
        try {
            Calendar calendar = Calendar.getInstance();
            string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
            HashMap<object, object> updateHashMap = StdUtil.getInstance().createHashMap();
            updateHashMap.put(OrderHistoryData.STATUS, status);
            if (string.CompareOrdinal(status, OrderHistoryData.CANCELLED) == 0) {
                updateHashMap.put(OrderHistoryData.CANCELDATE, time);
            } else if (string.CompareOrdinal(status, OrderHistoryData.SHIPPED) == 0) {
                updateHashMap.put(OrderHistoryData.SHIPPEDDATE, time);
            }
            base.updateWhere(OrderData.ID, orderId, updateHashMap);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "setStatus", e);
            }
        }
    }

    public virtual void setPaymentMethod(string orderId, string paymentMethod)
    {
        try {
            Calendar calendar = Calendar.getInstance();
            string time = new string((calendar.getTimeInMillis().ToString()).ToCharArray());
            HashMap<object, object> updateHashMap = StdUtil.getInstance().createHashMap();
            updateHashMap.put(PaymentData.METHOD, paymentMethod);
            updateHashMap.put(OrderHistoryData.TRANSDATE, time);
            base.updateWhere(OrderData.ID, orderId, updateHashMap);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLLOGGING)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "setPaymentMethod", e);
            }
        }
    }

    // throws Exception
    public virtual BasicArrayList getStoreOrders(StoreFrontInterface storeFrontInterface)
    {
        BasicArrayList orderReviewVector = new BasicArrayListD();
        HashMap<object, object> whereHashMap = StdUtil.getInstance().createHashMap();
        whereHashMap.put(StoreFrontData.getInstance().NAME, storeFrontInterface.getName());
        BasicArrayList orderHashMapVector = base.getRows(whereHashMap);
        int size = orderHashMapVector.size();
        for (int i = 0; i < size; i++) {
            HashMap<object, object> orderReviewHashMap = ((HashMap<object, object>) orderHashMapVector.get(i));
            OrderHistory orderReview = new OrderHistory(new Basket(), orderReviewHashMap);
            orderReviewVector.add(orderReview);
        }
        return orderReviewVector;
    }

    // throws Exception
    public virtual BasicArrayList getOrders(string userName)
    {
        BasicArrayList orderReviewVector = new BasicArrayListD();
        HashMap<object, object> whereHashMap = StdUtil.getInstance().createHashMap();
        whereHashMap.put(UserData.USERNAME, userName);
        BasicArrayList orderHashMapVector = base.getRows(whereHashMap);
        int size = orderHashMapVector.size();
        for (int index = 0; index < size; index++) {
            HashMap<object, object> orderReviewHashMap = ((HashMap<object, object>) orderHashMapVector.get(index));
            OrderHistory orderReview = new OrderHistory(new Basket(), orderReviewHashMap);
            orderReviewVector.add(orderReview);
        }
        return orderReviewVector;
    }

    // throws Exception
    public virtual BasicArrayList getOrders(string status, string fromDate, string toDate)
    {
        BasicArrayList orderReviewVector = new BasicArrayListD();
        HashMap<object, object> whereHashMap = StdUtil.getInstance().createHashMap();
        whereHashMap.put(OrderHistoryData.STATUS, status);
        BasicArrayList orderHashMapVector = base.getRowsWhereBetween(whereHashMap, OrderHistoryData.ORDERDATE, fromDate, toDate);
        int size = orderHashMapVector.size();
        for (int index = 0; index < size; index++) {
            HashMap<object, object> orderReviewHashMap = ((HashMap<object, object>) orderHashMapVector.get(index));
            OrderHistory orderReview = new OrderHistory(new Basket(), orderReviewHashMap);
            orderReviewVector.add(orderReview);
        }
        return orderReviewVector;
    }

    // throws Exception
    public virtual BasicArrayList getOrders(string fromDate, string toDate)
    {
        BasicArrayList orderReviewVector = new BasicArrayListD();
        BasicArrayList orderHashMapVector = base.getRowsWhereBetween(OrderHistoryData.ORDERDATE, fromDate, toDate);
        int size = orderHashMapVector.size();
        for (int index = 0; index < size; index++) {
            HashMap<object, object> orderReviewHashMap = ((HashMap<object, object>) orderHashMapVector.get(index));
            OrderHistory orderReview = new OrderHistory(new Basket(), orderReviewHashMap);
            orderReviewVector.add(orderReview);
        }
        return orderReviewVector;
    }

    // throws Exception
    public virtual OrderHistory getOrder(string id)
    {
        HashMap<object, object> whereHashMap = StdUtil.getInstance().createHashMap();
        whereHashMap.put(OrderData.ID, id);
        HashMap<object, object> orderReviewHashMap = base.getRow(whereHashMap);
        if (orderReviewHashMap != null) {
            OrderHistory orderHistory = new OrderHistory(new Basket(), orderReviewHashMap);
            return orderHistory;
        } else {
            return null;
        }
    }

    public string createTableStatement()
    {
        EntryData entryData = EntryData.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("CREATE TABLE ");
        stringBuffer.append(this.tableName);
        stringBuffer.append(" (");
        stringBuffer.append(entryData.ID);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(OrderData.ID);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(UserData.USERNAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(StoreFrontData.getInstance().NAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(OrderHistoryData.SHIPPEDDATE);
        stringBuffer.append(" BIGINT(19) UNSIGNED ,");
        stringBuffer.append(OrderHistoryData.ORDERDATE);
        stringBuffer.append(this.sqlTypeStrings.MAX_BIG_INT_UNSIGNED_NOT_NULL);
        stringBuffer.append(OrderHistoryData.TRANSDATE);
        stringBuffer.append(" BIGINT(19) UNSIGNED ,");
        stringBuffer.append(OrderHistoryData.CANCELDATE);
        stringBuffer.append(" BIGINT(19) UNSIGNED ,");
        stringBuffer.append(OrderHistoryData.STATUS);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentData.METHOD);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(PaymentData.NAME);
        stringBuffer.append(" VARCHAR(255) ,");
        stringBuffer.append(PaymentData.TYPE);
        stringBuffer.append(" VARCHAR(255) ,");
        stringBuffer.append(PaymentData.EXPIRATION);
        stringBuffer.append(" VARCHAR(255) ,");
        stringBuffer.append(PaymentData.NUMBER);
        stringBuffer.append(" VARCHAR(255) ,");
        stringBuffer.append(entryData.ENCRYPTION);
        stringBuffer.append(" BIGINT(19) UNSIGNED ,");
        stringBuffer.append(BillingAddressData.NAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(BillingAddressData.STREET);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(BillingAddressData.CITY);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(BillingAddressData.STATE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(BillingAddressData.CODE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(BillingAddressData.COUNTRY);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(ShippingAddressData.NAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(ShippingAddressData.STREET);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(ShippingAddressData.CITY);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(ShippingAddressData.STATE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(ShippingAddressData.CODE);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(ShippingAddressData.COUNTRY);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(ShippingMethodData.NAME);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(OrderHistoryData.SUBTOTAL);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(OrderHistoryData.SHIPPINGCOST);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(OrderHistoryData.TAX);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(OrderHistoryData.TOTAL);
        stringBuffer.append(this.sqlTypeStrings.MAX_CHAR_COLUMN_NOT_NULL);
        stringBuffer.append(entryData.SPECIAL);
        stringBuffer.append(" VARCHAR(255) ,");
        stringBuffer.append(OrderData.CUSTOMERCOMMENT);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append(OrderData.CUSTOMERCANCELCOMMENT);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append(OrderData.STORECOMMENT);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append(OrderData.STORECANCELCOMMENT);
        stringBuffer.append(this.sqlTypeStrings.BLOB_NOT_NULL);
        stringBuffer.append("PRIMARY KEY(");
        stringBuffer.append(entryData.ID);
        stringBuffer.append(") )");
        return stringBuffer.ToString();
    }

    public virtual string createTable()
    {
        return base.createTable(this.createTableStatement());
    }

    public virtual string dropTable()
    {
        return base.dropTable();
    }

    // throws Exception
    public virtual void update(HashMap<object, object> whereHashMap, HashMap<object, object> orderHashMap)
    {
        try {
            updateWhere(whereHashMap, orderHashMap);
        } catch (Exception e) {
            throw e;
        }
    }

}

