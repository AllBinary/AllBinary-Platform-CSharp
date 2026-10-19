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
using OrderItemsHelperFactory = admin.taghelpers.OrderItemsHelperFactory;
using OrderItemsRequestHelperFactory = admin.taghelpers.OrderItemsRequestHelperFactory;
using OrderHistoryData = org.allbinary.business.user.commerce.inventory.order.OrderHistoryData;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;

namespace admin.tags;

public class OrderItemsTag : TableTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string status = null;
    public OrderItemsTag()
    {
        this.setTagHelperFactory(new OrderItemsHelperFactory());
        this.setTagRequestHelperFactory(new OrderItemsRequestHelperFactory());
    }

    public virtual void setStatus(string value)
    {
        this.status = value;
    }

    // throws LicensingException
    private string setOrderStatus()
    {
        try {
            object anyType = new OrderItemsRequestHelperFactory().getInstance(this.getPropertiesHashMap(), this.pageContext);
            if (this.status == null) {
                Type helperClass = anyType.GetType();
                Method method = helperClass.getMethod("setOrderStatus", null);
                string result = ((string) method.invoke(anyType, null));
                return result;
            } else {
                Type helperClass = anyType.GetType();
                Type[] methodParams = new Type[] { this.status.GetType() };
                Method method = helperClass.getMethod("setOrderStatus", methodParams);
                object[] methodArgs = new object[] { this.status };
                string result = ((string) method.invoke(anyType, methodArgs));
                return result;
            }
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to set Order status to: " + this.status;
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
            if (this.isEnabled()) {
                if (this.getCommand() != null) {
                    this.getPropertiesHashMap().put(OrderHistoryData.STATUS, this.status);
                    if (this.getCommand().compareTo(OrderHistoryData.SETSTATUS) == 0) {
                        this.pageContext.getOut().print(this.setOrderStatus());
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

