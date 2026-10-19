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
using CustomLoaderHelperFactory = admin.taghelpers.CustomLoaderHelperFactory;
using StdUtil = org.allbinary.logic.StdUtil;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using CustomTagSupport = tags.CustomTagSupport;

namespace admin.tags;

public class CustomLoaderTag : CustomTagSupport
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string command = null;
    private string webappPath = null;
    private HashMap propertiesHashMap = null;
    public CustomLoaderTag()
    {
    }

    public virtual void setCommand(string command)
    {
        this.command = command;
    }

    public virtual void setWebappPath(string value)
    {
        this.webappPath = value;
    }

    // throws LicensingException
    private void setCustomLoaderWebappPath()
    {
        try {
            object anyType = new CustomLoaderHelperFactory().getInstance(this.propertiesHashMap, pageContext);
            Type helperClass = anyType.GetType();
            Type[] methodParams = new Type[] { this.webappPath.GetType() };
            object[] methodArgs = new object[] { this.webappPath };
            Method setMethod = helperClass.getMethod("setWebappPath", methodParams);
            setMethod.invoke(anyType, methodArgs);
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "setCustomLoaderWebappPath()", e);
            }
        }
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().JSPTAG)) {
                this.logUtil.putF(this.commonStrings.START, this, tagStrings.DO_START_TAG);
            }
            if (this.command != null) {
                this.propertiesHashMap = StdUtil.getInstance().createHashMap();
                if (string.CompareOrdinal(this.command, org.allbinary.globals.GLOBALS2.SET) == 0) {
                    this.setCustomLoaderWebappPath();
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

