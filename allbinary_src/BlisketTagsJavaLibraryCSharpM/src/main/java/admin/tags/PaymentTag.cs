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
using PaymentHelperFactory = admin.taghelpers.PaymentHelperFactory;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using PaymentData = org.allbinary.business.user.commerce.money.payment.PaymentData;
using StdUtil = org.allbinary.logic.StdUtil;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;

namespace admin.tags;

public class PaymentTag : TableTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string storeName = null;
    private HashMap propertiesHashMap = null;
    public PaymentTag()
    {
        this.setTagHelperFactory(new PaymentHelperFactory());
        this.setTagRequestHelperFactory(new PaymentHelperFactory());
    }

    public virtual void setStoreName(string value)
    {
        this.storeName = value;
    }

    // throws LicensingException
    private string select()
    {
        try {
            object anyType = new PaymentHelperFactory().getInstance(this.getPropertiesHashMap(), pageContext);
            Type addressHelperClass = anyType.GetType();
            Method method = addressHelperClass.getMethod("select", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to select Payment";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "selectPayment()", e);
            }
            return error;
        }
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            if (this.isEnabled()) {
                this.propertiesHashMap = StdUtil.getInstance().createHashMap();
                this.propertiesHashMap.put(StoreFrontData.getInstance().NAME, this.storeName);
                if (this.getCommand() != null) {
                    if (this.getCommand().compareTo(PaymentData.SELECT) == 0) {
                        string output = this.select();
                        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGEXTRAOUTPUT)) {
                            this.pageContext.getOut().print(output + "<br />");
                        }
                        return this.EVAL_BODY_INCLUDE;
                    } else {
                        return base.doStartTag();
                    }
                }
            }
            return SKIP_BODY;
        } catch (LicensingException e) {
            AbResponseHandler.sendJspTagLicensingRedirect(this.pageContext, e);
            return SKIP_BODY;
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

