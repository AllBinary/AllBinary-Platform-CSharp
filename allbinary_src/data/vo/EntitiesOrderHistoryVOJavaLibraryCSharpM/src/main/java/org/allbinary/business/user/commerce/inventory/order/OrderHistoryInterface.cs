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
using StreetAddress = org.allbinary.business.user.address.StreetAddress;
using Money = org.allbinary.business.user.commerce.money.Money;
using Payment = org.allbinary.business.user.commerce.money.payment.Payment;

namespace org.allbinary.business.user.commerce.inventory.order;

public interface OrderHistoryInterface
{
    void setUserName(string value);

    void setDefaultShippingAddress(StreetAddress shippingAddress);

    void setBillingAddress(StreetAddress billingAddress);

    void setPaymentInfo(Payment payment);

    void setShipDate(string value);

    void setOrderDate(string value);

    void setTransDate(string value);

    void setCancelDate(string value);

    void setStatus(string value);

    void setSubTotal(Money value);

    void setShippingCost(Money value);

    void setTaxes(Money value);

    void setTotal(Money value);

    string getUserName();

    StreetAddress getShippingAddress();

    StreetAddress getBillingAddress();

    Payment getPaymentInfo();

    string getShipDate();

    string getOrderDate();

    string getTransDate();

    string getCancelDate();

    string getStatus();

    Money getSubTotal();

    Money getShippingCost();

    Money getTaxes();

    Money getTotal();

    string getPaymentMethod();

}

