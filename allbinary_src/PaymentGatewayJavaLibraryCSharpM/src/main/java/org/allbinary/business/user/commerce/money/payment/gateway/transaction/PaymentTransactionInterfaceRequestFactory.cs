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
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using StreetAddress = org.allbinary.business.user.address.StreetAddress;
using Basket = org.allbinary.business.user.commerce.inventory.basket.Basket;
using OrderHistory = org.allbinary.business.user.commerce.inventory.order.OrderHistory;
using OrderInterface = org.allbinary.business.user.commerce.inventory.order.OrderInterface;
using Money = org.allbinary.business.user.commerce.money.Money;
using Payment = org.allbinary.business.user.commerce.money.payment.Payment;
using PaymentData = org.allbinary.business.user.commerce.money.payment.PaymentData;
using PaymentGatewayData = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayData;
using TenderTypeFactory = org.allbinary.business.user.commerce.money.payment.types.TenderTypeFactory;
using TransactionTypeFactory = org.allbinary.business.user.commerce.money.payment.types.TransactionTypeFactory;
using OrderIdGenerator = org.allbinary.data.generator.OrderIdGenerator;
using OrderHistoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.order.OrderHistoryEntityFactory;
using OrderHistoryEntityInterface = org.allbinary.data.tables.user.commerce.inventory.order.OrderHistoryEntityInterface;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using TransformInfoHttpInterface = org.allbinary.logic.visual.transform.info.TransformInfoHttpInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.user.commerce.money.payment.gateway.transaction;

public class PaymentTransactionInterfaceRequestFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly PaymentTransactionInterfaceRequestFactory instance = new PaymentTransactionInterfaceRequestFactory();
    public static PaymentTransactionInterfaceRequestFactory getInstance()
    {
        return PaymentTransactionInterfaceRequestFactory.instance;
    }

    private PaymentTransactionInterfaceRequestFactory()
    {
    }

    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    // throws Exception
    public virtual PaymentTransactionInterface getInstance(TransformInfoInterface transformInfoInterface)
    {
        try {
            TransformInfoHttpInterface httpTransformInfoInterface = ((TransformInfoHttpInterface) transformInfoInterface);
            PageContext pageContext = httpTransformInfoInterface.getPageContext();
            HttpServletRequest httpServletRequest = ((HttpServletRequest) pageContext.getRequest());
            string command = httpServletRequest.getParameter(org.allbinary.globals.GLOBALS2.ADMINCOMMAND);
            if (command != null && string.CompareOrdinal(command, org.allbinary.globals.GLOBALS2.AUTHORIZEFORMEVALBODYONERROR) == 0) {
                return this.generateFromTestData(transformInfoInterface);
            } else {
                HashMap propertiesHashMap = httpTransformInfoInterface.getPropertiesHashMap();
                WeblisketSession weblisketSession = new WeblisketSession(propertiesHashMap, pageContext);
                StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(weblisketSession.getStoreName());
                OrderInterface order = weblisketSession.getOrder();
                string orderId = order.getId();
                OrderHistoryEntityInterface orderHistoryEntityInterface = OrderHistoryEntityFactory.getInstance();
                OrderHistory orderReview = orderHistoryEntityInterface.getOrder(orderId);
                Payment orderPaymentInfo = orderReview.getPaymentInfo();
                orderPaymentInfo.setTransactionType(TransactionTypeFactory.getInstance().SALE.ToString());
                orderPaymentInfo.setTenderType(TenderTypeFactory.getInstance().CREDITCARD.ToString());
                orderReview.setPaymentInfo(orderPaymentInfo);
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PAYMENT)) {
                    this.logUtil.putF(orderReview.getId(), this, "getPaymentTransactionInterface()");
                }
                PaymentTransactionInterface paymentTransactionInterface = PaymentTransactionInterfaceFactory.getInstance().getInstance(orderReview);
                return paymentTransactionInterface;
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PAYMENTERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "getPaymentTransactionInterface()", e);
            }
            throw e;
        }
    }

    // throws Exception
    private PaymentTransactionInterface generateFromTestData(TransformInfoInterface transformInfoInterface)
    {
        try {
            TransformInfoHttpInterface httpTransformInfoInterface = ((TransformInfoHttpInterface) transformInfoInterface);
            HashMap propertiesHashMap = httpTransformInfoInterface.getPropertiesHashMap();
            PageContext pageContext = httpTransformInfoInterface.getPageContext();
            WeblisketSession weblisketSession = new WeblisketSession(propertiesHashMap, pageContext);
            StoreFrontInterface storeFrontInterface = StoreFrontFactory.getInstance(weblisketSession.getStoreName());
            HttpServletRequest httpServletRequest = ((HttpServletRequest) pageContext.getRequest());
            string gatewayName = ((string) weblisketSession.getPaymentMethod());
            if (StringValidationUtil.getInstance().isEmpty(gatewayName)) {
                gatewayName = httpServletRequest.getParameter(PaymentGatewayData.NAME.ToString());
            }
            string transactionType = httpServletRequest.getParameter(PaymentData.TRANSACTIONTYPE);
            string tenderType = httpServletRequest.getParameter(PaymentData.TENDERTYPE);
            Payment payment = new Payment();
            payment.setTransactionType(transactionType);
            payment.setTenderType(tenderType);
            OrderHistory orderReview = new OrderHistory(new Basket());
            orderReview.setStoreName(storeFrontInterface.getName());
            orderReview.setPaymentMethod(gatewayName);
            orderReview.setUserName("testing");
            string orderId = httpServletRequest.getParameter("orderNumber");
            if (orderId == null || string.CompareOrdinal(orderId, StringUtil.getInstance().EMPTY_STRING) == 0) {
                orderId = new OrderIdGenerator().getNext();
                orderReview.setId(orderId);
                string account = httpServletRequest.getParameter("account");
                string expirationDate = httpServletRequest.getParameter("expirationDate");
                string checkNumber = httpServletRequest.getParameter("checkNumber");
                string driversLicense = httpServletRequest.getParameter("driversLicense");
                string magneticInkCheckReader = httpServletRequest.getParameter("magneticInkCheckReader");
                string aba = httpServletRequest.getParameter("aba");
                string accountType = httpServletRequest.getParameter("accountType");
                string name = httpServletRequest.getParameter("name");
                payment.setName(name);
                payment.setNumber(account);
                payment.setExpiration(expirationDate);
                payment.setCheckNumber(checkNumber);
                payment.setDriversLicense(driversLicense);
                payment.setMagneticInkCheckReader(magneticInkCheckReader);
                payment.setAba(aba);
                payment.setAccountType(accountType);
                string street = httpServletRequest.getParameter("street");
                string city = httpServletRequest.getParameter("city");
                string state = httpServletRequest.getParameter("state");
                string zip = httpServletRequest.getParameter("zip");
                StreetAddress streetAddress = new StreetAddress();
                streetAddress.setName(name);
                streetAddress.setStreet(street);
                streetAddress.setCity(city);
                streetAddress.setState(state);
                streetAddress.setCode(zip);
                string email = httpServletRequest.getParameter("email");
                string amount = httpServletRequest.getParameter("amount");
                orderReview.setTotal(new Money(amount));
                orderReview.setBillingAddress(streetAddress);
            } else {
                orderReview.setId(orderId);
            }
            orderReview.setPaymentInfo(payment);
            PaymentTransactionInterface paymentTransactionInterface = PaymentTransactionInterfaceFactory.getInstance().getInstance(orderReview);
            return paymentTransactionInterface;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PAYMENTERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "generatePaymentTransactionInterfaceFromTestData()", e);
            }
            throw e;
        }
    }

}

