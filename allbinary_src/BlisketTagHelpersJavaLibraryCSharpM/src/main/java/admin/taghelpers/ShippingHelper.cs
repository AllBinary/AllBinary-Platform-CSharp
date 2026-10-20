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
using java.util;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using PageContext = javax.servlet.jsp.PageContext;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using OrderInterface = org.allbinary.business.user.commerce.inventory.order.OrderInterface;
using ShippingMethodData = org.allbinary.business.user.commerce.shipping.ShippingMethodData;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace admin.taghelpers;

public class ShippingHelper : TagHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private WeblisketSession weblisketSession;
    private StoreFrontInterface storeFrontInterface = null;
    private HashMap<object, object> propertiesHashMap = null;
    private PageContext pageContext;
    private HttpServletRequest request;
    private string shippingType = null;
    public ShippingHelper(HashMap<object, object> hashMap, PageContext pageContext)
    {
        this.pageContext = pageContext;
        this.request = ((HttpServletRequest) pageContext.getRequest());
        string storeName = ((string) hashMap.get(StoreFrontData.getInstance().NAME));
        if (storeName != null) {
            this.storeFrontInterface = StoreFrontFactory.getInstance(storeName);
        }
        this.weblisketSession = new WeblisketSession(hashMap, pageContext);
        this.getFormData();
    }

    private void getFormData()
    {
        this.shippingType = this.request.getParameter(ShippingMethodData.NAME);
    }

    public virtual string setShippingType()
    {
        try {
            string success = "Successfully Set Shipping Type";
            OrderInterface order = this.weblisketSession.getOrder();
            order.setShippingMethod(this.shippingType);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "setShippingType()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to view Shipping Type";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "setShippingType()", e);
            }
            return error;
        }
    }

}

