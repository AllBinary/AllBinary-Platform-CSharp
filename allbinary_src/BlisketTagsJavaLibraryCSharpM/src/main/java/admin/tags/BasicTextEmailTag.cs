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
using BasicTextEmailHelperFactory = admin.taghelpers.BasicTextEmailHelperFactory;
using StdUtil = org.allbinary.logic.StdUtil;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CustomTagSupport = tags.CustomTagSupport;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace admin.tags;

public class BasicTextEmailTag : CustomTagSupport
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string subject = null;
    private string body = null;
    public BasicTextEmailTag()
    {
    }

    public virtual void setSubject(string value)
    {
        this.subject = value;
    }

    public virtual void setBody(string value)
    {
        this.body = value;
    }

    public virtual string send()
    {
        try {
            HashMap<object, object> propertiesHashMap = StdUtil.getInstance().createHashMap();
            propertiesHashMap.put("Subject", this.subject);
            propertiesHashMap.put("Body", this.body);
            object anyType = new BasicTextEmailHelperFactory().getInstance(propertiesHashMap, this.pageContext);
            global::System.Reflection.MethodInfo method = anyType.GetType().getMethod("send", null);
            method.invoke(anyType, null);
            return "Email Sent";
        } catch (Exception e) {
            string error = "Failed to Send Email.";
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "send()", e);
            }
            return error;
        }
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            this.pageContext.getOut().print(this.send());
            return SKIP_BODY;
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

