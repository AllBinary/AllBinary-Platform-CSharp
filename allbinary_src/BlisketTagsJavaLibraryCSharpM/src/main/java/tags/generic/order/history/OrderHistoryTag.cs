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
using OrderHistoryData = org.allbinary.business.user.commerce.inventory.order.OrderHistoryData;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using OrderHistoryHelperFactory = taghelpers.OrderHistoryHelperFactory;
using StoreValidationTransformTag = tags.StoreValidationTransformTag;

namespace tags.generic.order.history;

public class OrderHistoryTag : StoreValidationTransformTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string status = null;
    public OrderHistoryTag()
    {
    }

    public virtual void setStatus(string value)
    {
        this.status = value;
    }

    // throws LicensingException
    private string setOrderStatus()
    {
        try {
            Any anyType = new OrderHistoryHelperFactory().getInstance(this.getPropertiesHashMap(), pageContext);
            Type helperClass = anyType.GetType();
            Method method = helperClass.getMethod("setOrderStatus", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to view order table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "setOrderStatus()", e);
            }
            return error;
        }
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            this.setName("Basic Order History View");
            this.setObjectFile("views.generic.order.history.ValidationView");
            if (this.getCommand() != null) {
                if (this.getCommand().compareTo(OrderHistoryData.SETSTATUS) == 0) {
                    this.getPropertiesHashMap().put(OrderHistoryData.STATUS, this.status);
                    pageContext.getOut().print(this.setOrderStatus());
                } else if (this.getCommand().compareTo(org.allbinary.globals.GLOBALS2.VIEW) == 0) {
                } else {
                    throw new Exception("No Such View Command: " + this.getCommand());
                }
                return base.doStartTag();
            }
            throw new Exception("Command Null");
        } catch (LicensingException e) {
            AbResponseHandler.sendJspTagLicensingRedirect(this.pageContext, e);
            return SKIP_BODY;
        } catch (Exception e) {
            AbResponseHandler.sendJspTagRedirect(this.pageContext, e);
            return SKIP_BODY;
        }
    }

}

