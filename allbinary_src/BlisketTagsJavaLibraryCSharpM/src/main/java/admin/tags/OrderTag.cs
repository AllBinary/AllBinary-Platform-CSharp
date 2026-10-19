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
//using Method = java.lang.reflect.Method;
using java.util;
//using JspTagException = javax.servlet.jsp.JspTagException;
//using TagSupport = javax.servlet.jsp.tagext.TagSupport;
using OrderHelperFactory = admin.taghelpers.OrderHelperFactory;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using PaymentGatewayData = org.allbinary.business.user.commerce.money.payment.gateway.PaymentGatewayData;
using StdUtil = org.allbinary.logic.StdUtil;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using CustomTagSupport = tags.CustomTagSupport;

namespace admin.tags;

public class OrderTag : CustomTagSupport
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string command = null;
    private string storeName = null;
    private HashMap propertiesHashMap = null;
    public OrderTag()
    {
    }

    public virtual void setCommand(string command)
    {
        this.command = command;
    }

    public virtual void setStoreName(string value)
    {
        this.storeName = value;
    }

    // throws LicensingException
    private string process()
    {
        try {
            object anyType = new OrderHelperFactory().getInstance(this.propertiesHashMap, this.pageContext);
            Type helperClass = anyType.GetType();
            Method method = helperClass.getMethod(commonStrings.PROCESS, null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to Process Order: ";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.PROCESS, e);
            }
            return error;
        }
    }

    // throws LicensingException
    private bool? setPaymentGateway()
    {
        try {
            object anyType = new OrderHelperFactory().getInstance(this.propertiesHashMap, this.pageContext);
            Type addressHelperClass = anyType.GetType();
            Method method = addressHelperClass.getMethod("setPaymentGateway", null);
            bool? result = ((bool?) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to setPaymentGateway for Order";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "setPaymentGateway()", e);
            }
            return false;
        }
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            if (this.command != null) {
                this.propertiesHashMap = StdUtil.getInstance().createHashMap();
                this.propertiesHashMap.put(StoreFrontData.getInstance().NAME, this.storeName);
                if (string.CompareOrdinal(this.command, org.allbinary.globals.GLOBALS2.PROCESS) == 0) {
                    this.process();
                } else if (string.CompareOrdinal(this.command, PaymentGatewayData.NAME.ToString()) == 0) {
                    if (this.setPaymentGateway() == true) {
                        return TagSupport.EVAL_BODY_INCLUDE;
                    }
                }
            }
            return TagSupport.SKIP_BODY;
        } catch (LicensingException e) {
            AbResponseHandler.sendJspTagLicensingRedirect(this.pageContext, e);
            return SKIP_BODY;
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

