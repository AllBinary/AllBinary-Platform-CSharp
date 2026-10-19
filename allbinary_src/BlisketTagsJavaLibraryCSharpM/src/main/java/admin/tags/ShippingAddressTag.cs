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
using ShippingAddressHelperFactory = admin.taghelpers.ShippingAddressHelperFactory;
using ShippingAddressData = org.allbinary.business.user.address.ShippingAddressData;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;

namespace admin.tags;

public class ShippingAddressTag : TableTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string value = null;
    public ShippingAddressTag()
    {
        this.setTagHelperFactory(new ShippingAddressHelperFactory());
        this.setTagRequestHelperFactory(new ShippingAddressHelperFactory());
    }

    public virtual void setValue(string value)
    {
        this.value = value;
    }

    // throws LicensingException
    private string set()
    {
        try {
            object anyType = new ShippingAddressHelperFactory().getInstance(this.getPropertiesHashMap(), this.pageContext);
            Type addressHelperClass = anyType.GetType();
            Method method = addressHelperClass.getMethod("set", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to set Shipping Address";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "set()", e);
            }
            return error;
        }
    }

    // throws LicensingException
    private string setToBillingAddress()
    {
        try {
            object anyType = new ShippingAddressHelperFactory().getInstance(this.getPropertiesHashMap(), this.pageContext);
            Type addressHelperClass = anyType.GetType();
            Method method = addressHelperClass.getMethod("setToBillingAddress", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed Setting Shipping address to Billing Address";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "setShippingAddressToBillingAddress()", e);
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
                    if (this.getCommand().compareTo(ShippingAddressData.SELECT) == 0) {
                        this.set();
                        return this.EVAL_BODY_INCLUDE;
                    } else if (this.getCommand().compareTo(ShippingAddressData.SETTOBILLINGADDRESS) == 0) {
                        this.setToBillingAddress();
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

