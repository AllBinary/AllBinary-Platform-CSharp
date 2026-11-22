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
//using JspTagException = javax.servlet.jsp.JspTagException;
using QuoteHelperFactory = admin.taghelpers.QuoteHelperFactory;
using QuoteRequestHelperFactory = admin.taghelpers.QuoteRequestHelperFactory;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace admin.tags;

public class QuoteRequestTag : TableTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string storeName = null;
    public QuoteRequestTag()
    {
        this.setTagHelperFactory(new QuoteHelperFactory());
        this.setTagRequestHelperFactory(new QuoteRequestHelperFactory());
    }

    public virtual void setStoreName(string storeName)
    {
        this.storeName = storeName;
    }

    // throws LicensingException
    private string email()
    {
        try {
            object anyType = new QuoteHelperFactory().getInstance(this.getPropertiesHashMap(), pageContext);
            Type helperClass = anyType.GetType();
            global::System.Reflection.MethodInfo method = helperClass.getMethod("email", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to send QuoteRequest emails";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "sendEmail()", e);
            }
            return error;
        }
    }

    // throws JspTagException
    public override int doStartTag()
    {
        try {
            if (this.getCommand() != null) {
                this.getPropertiesHashMap().put(StoreFrontData.getInstance().NAME, this.storeName);
                if (this.getCommand().compareTo("EMAIL") == 0) {
                    this.email();
                    return this.EVAL_BODY_INCLUDE;
                } else {
                    return base.doStartTag();
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

