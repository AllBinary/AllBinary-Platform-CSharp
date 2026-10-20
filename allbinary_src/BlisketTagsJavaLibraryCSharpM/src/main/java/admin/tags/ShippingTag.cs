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
using ShippingHelperFactory = admin.taghelpers.ShippingHelperFactory;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StdUtil = org.allbinary.logic.StdUtil;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using CustomTagSupport = tags.CustomTagSupport;

namespace admin.tags;

public class ShippingTag : CustomTagSupport
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string command = null;
    private string storeName = null;
    private HashMap<object, object> propertiesHashMap = null;
    public ShippingTag()
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
    private string setShippingType()
    {
        try {
            object anyType = new ShippingHelperFactory().getInstance(this.propertiesHashMap, this.pageContext);
            Type addressHelperClass = anyType.GetType();
            Method method = addressHelperClass.getMethod("setShippingType", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to view Shipping Type";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "setShippingType()", e);
            }
            return error;
        }
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            if (this.command != null) {
                this.propertiesHashMap = StdUtil.getInstance().createHashMap();
                this.propertiesHashMap.put(StoreFrontData.getInstance().NAME, this.storeName);
                if (string.CompareOrdinal(this.command, org.allbinary.globals.GLOBALS2.SETSHIPPINGTYPE) == 0) {
                    this.setShippingType();
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

