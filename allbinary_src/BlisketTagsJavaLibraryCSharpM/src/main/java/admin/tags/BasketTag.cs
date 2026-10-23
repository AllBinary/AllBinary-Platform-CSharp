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
using BasketHelperFactory = admin.taghelpers.BasketHelperFactory;
using BasketRequestHelperFactory = admin.taghelpers.BasketRequestHelperFactory;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using BasketData = org.allbinary.business.user.commerce.inventory.basket.BasketData;
using StdUtil = org.allbinary.logic.StdUtil;
using AbResponseHandler = org.allbinary.logic.communication.http.request.AbResponseHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;
using CustomTagSupport = tags.CustomTagSupport;

namespace admin.tags;

public class BasketTag : CustomTagSupport
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string command = null;
    private string storeName = null;
    private HashMap<object, object> propertiesHashMap = null;
    public BasketTag()
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
    private bool isBasketEmpty()
    {
        try {
            object anyType = new BasketHelperFactory().getInstance(this.propertiesHashMap, this.pageContext);
            Method method = anyType.GetType().getMethod("isBasketEmpty", null);
            bool? emptyBoolean = ((bool?) method.invoke(anyType, null));
            return emptyBoolean.Value;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "isBasketEmpty()", e);
            }
            return true;
        }
    }

    // throws LicensingException
    private bool addItemToBasket()
    {
        try {
            object anyType = new BasketRequestHelperFactory().getInstance(this.propertiesHashMap, this.pageContext);
            Method method = anyType.GetType().getMethod("addItemToBasket", null);
            bool? emptyBoolean = ((bool?) method.invoke(anyType, null));
            return emptyBoolean.Value;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to add item from Basket";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "addItemToBasket()", e);
            }
            return false;
        }
    }

    // throws LicensingException
    private bool removeItemFromBasket()
    {
        try {
            object anyType = new BasketRequestHelperFactory().getInstance(this.propertiesHashMap, this.pageContext);
            Method method = anyType.GetType().getMethod("removeItemFromBasket", null);
            bool? emptyBoolean = ((bool?) method.invoke(anyType, null));
            return emptyBoolean.Value;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to remove item from Basket";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "removeItemFromBasket()", e);
            }
            return false;
        }
    }

    // throws LicensingException
    private bool adjustBasket()
    {
        try {
            object anyType = new BasketRequestHelperFactory().getInstance(this.propertiesHashMap, this.pageContext);
            Method method = anyType.GetType().getMethod("adjustBasket", null);
            bool? emptyBoolean = ((bool?) method.invoke(anyType, null));
            return emptyBoolean.Value;
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            string error = "Failed to Adjust Basket";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "adjustBasket()", e);
            }
            return false;
        }
    }

    // throws JspTagException
    public virtual int doStartTag()
    {
        try {
            if (this.command != null) {
                this.propertiesHashMap = StdUtil.getInstance().createHashMap();
                this.propertiesHashMap.put(StoreFrontData.getInstance().NAME, this.storeName);
                if (string.CompareOrdinal(this.command, BasketData.INSERT) == 0) {
                    if (!this.addItemToBasket()) {
                        this.pageContext.getOut().println("Item is not currently being sold.<p/>");
                    }
                } else if (string.CompareOrdinal(this.command, BasketData.DELETE) == 0) {
                    this.removeItemFromBasket();
                } else if (string.CompareOrdinal(this.command, BasketData.ADJUST) == 0) {
                    this.adjustBasket();
                } else if (string.CompareOrdinal(this.command, BasketData.ISEMPTY) == 0) {
                    if (this.isBasketEmpty()) {
                        return this.EVAL_BODY_INCLUDE;
                    } else {
                        return SKIP_BODY;
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

