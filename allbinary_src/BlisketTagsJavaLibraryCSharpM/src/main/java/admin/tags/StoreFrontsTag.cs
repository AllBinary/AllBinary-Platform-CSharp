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
//using TagSupport = javax.servlet.jsp.tagext.TagSupport;
using StoreFrontsHelperFactory = admin.taghelpers.StoreFrontsHelperFactory;
using StoreFrontsRequestHelperFactory = admin.taghelpers.StoreFrontsRequestHelperFactory;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;

namespace admin.tags;

public class StoreFrontsTag : TableTag
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public StoreFrontsTag()
    {
        this.setTagHelperFactory(new StoreFrontsHelperFactory());
        this.setTagRequestHelperFactory(new StoreFrontsRequestHelperFactory());
    }

    // throws LicensingException
    private string generateSelect()
    {
        try {
            object anyType = this.getTagHelperFactoryInterface().getInstance(this.getPropertiesHashMap(), pageContext);
            Method method = anyType.GetType().getMethod("generateSelect", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to generate storefronts select";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "generateSelect()", e);
            }
            return error;
        }
    }

    // throws LicensingException
    private string install()
    {
        try {
            object anyType = this.getTagRequestHelperFactoryInterface().getInstance(this.getPropertiesHashMap(), pageContext);
            Method method = anyType.GetType().getMethod("install", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to generate storefronts select";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "generateSelect()", e);
            }
            return error;
        }
    }

    // throws LicensingException
    private string sendStoreCreatedEmails()
    {
        try {
            object anyType = this.getTagRequestHelperFactoryInterface().getInstance(this.getPropertiesHashMap(), pageContext);
            Method method = anyType.GetType().getMethod("sendStoreCreatedEmails", null);
            string result = ((string) method.invoke(anyType, null));
            return result;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to send email";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "sendStoreCreatedEmails()", e);
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
                    StoreFrontData storeFrontData = StoreFrontData.getInstance();
                    if (this.getCommand().compareTo(storeFrontData.SELECT) == 0) {
                        this.pageContext.getOut().print(this.generateSelect());
                    } else if (this.getCommand().compareTo(storeFrontData.INSTALL) == 0) {
                        this.getPropertiesHashMap().put("current", this.getCurrent());
                        this.getPropertiesHashMap().put("total", this.getTotal());
                        if (((int) this.getCurrent()) == ((int) this.getTotal())) {
                            return TagSupport.EVAL_BODY_INCLUDE;
                        }
                        this.install();
                    } else if (this.getCommand().compareTo(storeFrontData.INSTALL_COMPLETE) == 0) {
                        this.sendStoreCreatedEmails();
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

