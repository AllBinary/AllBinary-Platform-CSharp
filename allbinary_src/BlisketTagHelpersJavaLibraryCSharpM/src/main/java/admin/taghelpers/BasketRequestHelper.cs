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
using StoreFront = org.allbinary.business.context.modules.storefront.StoreFront;
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using BasketData = org.allbinary.business.user.commerce.inventory.basket.BasketData;
using BasketInterface = org.allbinary.business.user.commerce.inventory.basket.BasketInterface;
using BasicItemData = org.allbinary.business.user.commerce.inventory.item.BasicItemData;
using InventoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntityFactory;
using WeblisketSession = org.allbinary.logic.communication.http.request.session.WeblisketSession;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace admin.taghelpers;

public class BasketRequestHelper : TagHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    private readonly WeblisketSession weblisketSession;
    private readonly StoreFrontInterface storeFrontInterface = null;
    private readonly HashMap propertiesHashMap;
    private readonly PageContext pageContext;
    private readonly HttpServletRequest request;
    private string id = null;
    private string num = null;
    private readonly int MAX = 200;
    public BasketRequestHelper(HashMap propertiesHashMap, PageContext pageContext)
    {
        this.propertiesHashMap = propertiesHashMap;
        this.pageContext = pageContext;
        this.request = ((HttpServletRequest) pageContext.getRequest());
        string storeName = ((string) propertiesHashMap.get(StoreFrontData.getInstance().NAME));
        if (storeName != null) {
            this.storeFrontInterface = StoreFrontFactory.getInstance(storeName);
        } else {
            this.storeFrontInterface = new StoreFront();
        }
        this.weblisketSession = new WeblisketSession(propertiesHashMap, pageContext);
        this.getFormData();
    }

    private void getFormData()
    {
        this.id = this.request.getParameter(basicItemData.ID);
        this.num = this.request.getParameter(BasketData.ITEMTOTALINBASKET);
    }

    public virtual bool? addItemToBasket()
    {
        try {
            if (this.id != null && this.num != null) {
                BasketInterface basket = this.weblisketSession.getOrder().getBasket();
                if (InventoryEntityFactory.getInstance().getInventoryEntityInstance().getItem(this.id) == null) {
                    return false;
                }
                basket.addItem(this.id, num);
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF("Successfully added item to Basket", this, "addItemToBasket()");
            }
            return true;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "addItemToBasket()", e);
            }
            return false;
        }
    }

    public virtual bool? removeItemFromBasket()
    {
        try {
            if (this.id != null) {
                BasketInterface basket = this.weblisketSession.getOrder().getBasket();
                basket.removeItem(this.id);
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF("Successfully removed item from Basket", this, "removeItemFromBasket()");
            }
            return true;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "removeItemFromBasket()", e);
            }
            return false;
        }
    }

    public virtual bool? adjustBasket()
    {
        try {
            BasketInterface basket = this.weblisketSession.getOrder().getBasket();
            if (this.id != null && this.num != null) {
                basket.adjustItem(this.id, this.num);
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF("Successfull Adjusted Basket", this, "adjustBasket()");
            }
            return true;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "adjustBasket()", e);
            }
            return false;
        }
    }

}

