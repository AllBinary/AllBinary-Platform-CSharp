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
using PaymentProcessHelperFactory = admin.taghelpers.PaymentProcessHelperFactory;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using StoreValidationTransformTag = tags.StoreValidationTransformTag;

namespace admin.tags;

public class PaymentProcessTag : StoreValidationTransformTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public PaymentProcessTag()
    {
    }

    // throws LicensingException, Exception
    public virtual string process()
    {
        try {
            object anyType = new PaymentProcessHelperFactory().getInstance(this.getPropertiesHashMap(), this.pageContext);
            Type helperClass = anyType.GetType();
            Method method = helperClass.getMethod(commonStrings.PROCESS, null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().LICENSINGERROR)) {
                this.logUtil.put("LicensingException", this, this.commonStrings.PROCESS, e);
            }
            throw e;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.PROCESS, e);
            }
            throw e;
        }
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            if (this.getCommand().compareTo(org.allbinary.globals.GLOBALS2.AUTHORIZEORDEREVALBODYONERROR) == 0 || this.getCommand().compareTo(org.allbinary.globals.GLOBALS2.AUTHORIZEORDERANDEVALBODY) == 0 || this.getCommand().compareTo(org.allbinary.globals.GLOBALS2.AUTHORIZEFORMEVALBODYONERROR) == 0) {
                this.pageContext.getOut().print(this.process() + "<br />");
                if (this.getCommand().compareTo(org.allbinary.globals.GLOBALS2.AUTHORIZEORDEREVALBODYONERROR) == 0) {
                    return this.SKIP_BODY;
                } else {
                    return this.EVAL_BODY_INCLUDE;
                }
            } else {
                throw new Exception("No Such Payment Processing Command");
            }
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

