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
using GLOBALS2 = org.allbinary.globals.GLOBALS2;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

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
            global::System.Reflection.MethodInfo method = helperClass.getMethod(commonStrings.PROCESS, null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().LICENSINGERROR)) {
                this.logUtil.put("LicensingException", this, this.commonStrings.PROCESS, e);
            }
            throw e;
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.PROCESS, e);
            }
            throw e;
        }
    }

    // throws JspTagException
    public override int doStartTag()
    {
        try {
            if (this.getCommand().compareTo(GLOBALS2.AUTHORIZEORDEREVALBODYONERROR) == 0 || this.getCommand().compareTo(GLOBALS2.AUTHORIZEORDERANDEVALBODY) == 0 || this.getCommand().compareTo(GLOBALS2.AUTHORIZEFORMEVALBODYONERROR) == 0) {
                this.pageContext.getOut().print(this.process() + "<br />");
                if (this.getCommand().compareTo(GLOBALS2.AUTHORIZEORDEREVALBODYONERROR) == 0) {
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

