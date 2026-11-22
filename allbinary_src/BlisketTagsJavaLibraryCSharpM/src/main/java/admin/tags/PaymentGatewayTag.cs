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
using PaymentGatewayHelperFactory = admin.taghelpers.PaymentGatewayHelperFactory;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using GLOBALS2 = org.allbinary.globals.GLOBALS2;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace admin.tags;

public class PaymentGatewayTag : TableTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public PaymentGatewayTag()
    {
        this.setTagHelperFactory(new PaymentGatewayHelperFactory());
        this.setTagRequestHelperFactory(new PaymentGatewayHelperFactory());
    }

    // throws LicensingException, Exception
    public virtual string process()
    {
        try {
            object anyType = new PaymentGatewayHelperFactory().getInstance(this.getPropertiesHashMap(), this.pageContext);
            Type helperClass = anyType.GetType();
            global::System.Reflection.MethodInfo method = helperClass.getMethod(commonStrings.PROCESS, null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            this.logUtil.put("LicensingException", this, this.commonStrings.PROCESS, e);
            throw e;
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.PROCESS, e);
            }
            throw e;
        }
    }

    // throws JspTagException
    public override int doStartTag()
    {
        try {
            if (this.isEnabled()) {
                if (this.getCommand().compareTo(GLOBALS2.AUTHORIZEORDEREVALBODYONERROR) == 0 || this.getCommand().compareTo(GLOBALS2.AUTHORIZEORDERANDEVALBODY) == 0 || this.getCommand().compareTo(GLOBALS2.AUTHORIZEFORMEVALBODYONERROR) == 0) {
                    string output = this.process();
                    {
                        this.pageContext.getOut().print(output + "<br />");
                    }
                    if (this.getCommand().compareTo(GLOBALS2.AUTHORIZEORDEREVALBODYONERROR) == 0) {
                        return this.SKIP_BODY;
                    } else {
                        return this.EVAL_BODY_INCLUDE;
                    }
                } else {
                    return base.doStartTag();
                }
            }
            return SKIP_BODY;
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

