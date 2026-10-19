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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.business.user.commerce.money.payment.gateway;

public class PaymentGatewayPageData
{
    private static readonly string EXTENSION = ".jsp";
    private static readonly string NAME = StringUtil.getInstance().EMPTY_STRING;
    public static readonly string FORWARDMAKEPAYMENT = "MakePayment.jsp";
    public readonly string MAKEPAYMENT;
    public static readonly string PAYMENTOPTIONS = "PaymentOptions" + PaymentGatewayPageData.EXTENSION;
    public static readonly string STARTCHECKOUT = "StartCheckout" + PaymentGatewayPageData.EXTENSION;
    public readonly string CHECKOUT;
    public readonly string SHIPPING;
    public readonly string SHIPPINGADDRESS;
    public readonly string SHIPPINGADDRESSACTION;
    public readonly string BILLINGADDRESS;
    public readonly string PAYMENT;
    public readonly string AUTHORIZE;
    public readonly string FINISH;
    public PaymentGatewayPageData(string location, string paymentMethod)
    {
        string paymentMethodString = PaymentGatewayPageData.NAME + paymentMethod;
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(location);
        stringBuffer.append("MakePayment");
        stringBuffer.append(PaymentGatewayPageData.EXTENSION);
        MAKEPAYMENT = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(paymentMethodString);
        stringBuffer.append("Checkout");
        stringBuffer.append(PaymentGatewayPageData.EXTENSION);
        CHECKOUT = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(paymentMethodString);
        stringBuffer.append("Shipping");
        stringBuffer.append(PaymentGatewayPageData.EXTENSION);
        SHIPPING = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(paymentMethodString);
        stringBuffer.append("ShippingAddress");
        stringBuffer.append(PaymentGatewayPageData.EXTENSION);
        SHIPPINGADDRESS = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(paymentMethodString);
        stringBuffer.append("ShippingAddressAction");
        stringBuffer.append(PaymentGatewayPageData.EXTENSION);
        SHIPPINGADDRESSACTION = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(paymentMethodString);
        stringBuffer.append("BillingAddress");
        stringBuffer.append(PaymentGatewayPageData.EXTENSION);
        BILLINGADDRESS = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(paymentMethodString);
        stringBuffer.append("Payment");
        stringBuffer.append(PaymentGatewayPageData.EXTENSION);
        PAYMENT = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(paymentMethodString);
        stringBuffer.append("Authorize");
        stringBuffer.append(PaymentGatewayPageData.EXTENSION);
        AUTHORIZE = stringBuffer.ToString();
        stringBuffer.delete(0, stringBuffer.length());
        stringBuffer.append(paymentMethodString);
        stringBuffer.append("PaymentFinish");
        stringBuffer.append(PaymentGatewayPageData.EXTENSION);
        FINISH = stringBuffer.ToString();
    }

}

