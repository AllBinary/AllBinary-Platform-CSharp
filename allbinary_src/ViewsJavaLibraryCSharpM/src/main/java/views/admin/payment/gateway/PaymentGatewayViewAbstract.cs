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
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using PaymentGatewayData = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayData;
using PaymentGatewayPrimaryKey = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayPrimaryKey;
using TransformInfoHttpComposite = org.allbinary.logic.visual.transform.info.TransformInfoHttpComposite;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;

namespace views.admin.payment.gateway;

public class PaymentGatewayViewAbstract : TransformInfoHttpComposite
{
    private PaymentGatewayPrimaryKey paymentGatewayPrimaryKey = null;
    public PaymentGatewayViewAbstract(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.getFormData(((HttpServletRequest) this.getPageContext().getRequest()));
    }

    public virtual void getFormData(HttpServletRequest request)
    {
        string storeName = this.getWeblisketSession().getStoreName();
        string gatewayName = request.getParameter(PaymentGatewayData.NAME.ToString());
        this.setPaymentGatewayPrimaryKey(new PaymentGatewayPrimaryKey(storeName, gatewayName));
    }

    public virtual PaymentGatewayPrimaryKey getPaymentGatewayPrimaryKey()
    {
        return this.paymentGatewayPrimaryKey;
    }

    public virtual void setPaymentGatewayPrimaryKey(PaymentGatewayPrimaryKey paymentGatewayPrimaryKey)
    {
        this.paymentGatewayPrimaryKey = paymentGatewayPrimaryKey;
    }

}

