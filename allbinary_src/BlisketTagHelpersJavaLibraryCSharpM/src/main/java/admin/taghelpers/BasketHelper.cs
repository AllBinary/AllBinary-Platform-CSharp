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
//using PageContext = javax.servlet.jsp.PageContext;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using BasketInterface = org.allbinary.business.user.commerce.inventory.basket.BasketInterface;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace admin.taghelpers;

public class BasketHelper : TagHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private WeblisketSession weblisketSession;
    private StoreFrontInterface storeFrontInterface = null;
    private HashMap<object, object> propertiesHashMap;
    private PageContext pageContext;
    private readonly int MAX = 200;
    public BasketHelper(HashMap<object, object> hashMap, PageContext pageContext)
    {
        this.propertiesHashMap = hashMap;
        this.pageContext = pageContext;
        string storeName = ((string) this.propertiesHashMap.get(StoreFrontData.getInstance().NAME));
        if (storeName != null) {
            this.storeFrontInterface = StoreFrontFactory.getInstance(storeName);
        }
        this.weblisketSession = new WeblisketSession(hashMap, pageContext);
    }

    public virtual bool? isBasketEmpty()
    {
        try {
            BasketInterface basket = this.weblisketSession.getOrder().getBasket();
            if (((int) basket.getNumberOfItems()) <= 0) {
                return true;
            } else {
                return false;
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "isBasketEmpty()", e);
            }
            return true;
        }
    }

}

