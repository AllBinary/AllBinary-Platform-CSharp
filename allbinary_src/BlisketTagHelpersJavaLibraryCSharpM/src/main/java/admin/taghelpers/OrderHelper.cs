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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using PageContext = javax.servlet.jsp.PageContext;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using Order = org.allbinary.business.user.commerce.inventory.order.Order;
using OrderInterface = org.allbinary.business.user.commerce.inventory.order.OrderInterface;
using OrderProcessorUtil = org.allbinary.business.user.commerce.inventory.order.OrderProcessorUtil;
using PaymentGatewayData = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayData;
using PaymentGatewayInterface = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayInterface;
using BasicPaymentType = org.allbinary.business.user.commerce.money.payment.types.BasicPaymentType;
using PaymentGatewayEntity = org.allbinary.data.tables.user.commerce.money.payment.gateway.PaymentGatewayEntity;
using PaymentGatewayEntityFactory = org.allbinary.data.tables.user.commerce.money.payment.gateway.PaymentGatewayEntityFactory;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;

namespace admin.taghelpers;

public class OrderHelper : TagHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private WeblisketSession weblisketSession;
    private StoreFrontInterface storeFrontInterface = null;
    private HashMap<object, object> propertiesHashMap;
    private PageContext pageContext;
    private HttpServletRequest request;
    public OrderHelper(HashMap<object, object> propertiesHashMap, PageContext pageContext)
    {
        this.propertiesHashMap = propertiesHashMap;
        this.pageContext = pageContext;
        this.request = ((HttpServletRequest) pageContext.getRequest());
        string storeName = ((string) propertiesHashMap.get(StoreFrontData.getInstance().NAME));
        if (!StringValidationUtil.getInstance().isEmpty(storeName)) {
            this.storeFrontInterface = StoreFrontFactory.getInstance(storeName);
        }
        this.weblisketSession = new WeblisketSession(this.propertiesHashMap, this.pageContext);
    }

    public virtual bool? setPaymentGateway()
    {
        try {
            bool? paymentGatewayBoolean = false;
            OrderInterface orderInterface = this.weblisketSession.getOrder();
            string requestPaymentGateway = ((string) this.request.getParameter(PaymentGatewayData.NAME.ToString()));
            if (!StringValidationUtil.getInstance().isEmpty(requestPaymentGateway)) {
                this.weblisketSession.setPaymentMethod(requestPaymentGateway);
                orderInterface.setPaymentMethod(requestPaymentGateway);
                paymentGatewayBoolean = true;
            }
            PaymentGatewayEntity paymentGatewayEntityInterface = ((PaymentGatewayEntity) PaymentGatewayEntityFactory.getInstance());
            BasicArrayList paymentTypeVector = paymentGatewayEntityInterface.findPaymentTypeVectorByStore(this.weblisketSession.getStoreName());
            if (paymentTypeVector.size() == 1) {
                BasicPaymentType paymentType = ((BasicPaymentType) paymentTypeVector.get(0));
                PaymentGatewayInterface paymentGatewayInterface = ((PaymentGatewayInterface) paymentGatewayEntityInterface.getPaymentGatewayInterface(this.weblisketSession.getStoreName(), paymentType));
                string paymentGateway = paymentGatewayInterface.getName();
                this.weblisketSession.setPaymentMethod(paymentGateway);
                orderInterface.setPaymentMethod(paymentGateway);
                paymentGatewayBoolean = true;
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Successfully set PaymentGateway Order: ");
                stringBuffer.append(orderInterface.getId());
                stringBuffer.append(" to: ");
                stringBuffer.append(orderInterface.getPaymentMethod());
                this.logUtil.putF(stringBuffer.ToString(), this, "setPaymentGateway()");
            }
            return paymentGatewayBoolean;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Failed to set PaymentGateway for Order: ");
                try {
                    OrderInterface orderInterface = this.weblisketSession.getOrder();
                    if (orderInterface != null) {
                        stringBuffer.append(orderInterface.getId());
                        stringBuffer.append(" to: ");
                        stringBuffer.append(orderInterface.getPaymentMethod());
                    }
                } catch (Exception ex) {
                    stringBuffer.append(" Exception Getting");
                }
                this.logUtil.put(stringBuffer.ToString(), this, "setPaymentGateway()", e);
            }
            return false;
        }
    }

    public virtual string process()
    {
        try {
            OrderInterface order = this.weblisketSession.getOrder();
            order.setStoreName(this.storeFrontInterface.getName());
            string result = OrderProcessorUtil.getInstance().process(this.weblisketSession.getUserName(), ((Order) order));
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF("Successfully Processed Order: " + result, this, "processOrder()");
            }
            return result;
        } catch (Exception e) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Failed to Process Order: ");
            try {
                stringBuffer.append(this.weblisketSession.getOrder().getId());
            } catch (Exception ex) {
                stringBuffer.append(" Exception Getting Id");
            }
            string error = stringBuffer.ToString();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.PROCESS, e);
            }
            return error;
        }
    }

}

