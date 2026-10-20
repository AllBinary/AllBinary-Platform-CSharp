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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
using BasketData = org.allbinary.business.user.commerce.inventory.basket.BasketData;
using BasketInterface = org.allbinary.business.user.commerce.inventory.basket.BasketInterface;
using BasicItemView = org.allbinary.business.user.commerce.inventory.item.BasicItemView;
using ItemInterface = org.allbinary.business.user.commerce.inventory.item.ItemInterface;
using Money = org.allbinary.business.user.commerce.money.Money;
using InventoryEntity = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntity;
using InventoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntityFactory;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SearchData = org.allbinary.logic.control.search.SearchData;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;

namespace views.generic.basket;

public class BasketView : HttpStoreComponentView, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly HttpServletRequest request;
    public BasketView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.request = ((HttpServletRequest) this.getPageContext().getRequest());
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        try {
            InventoryEntity inventoryEntity = InventoryEntityFactory.getInstance().getInventoryEntityInstance();
            BasketInterface basketInterface = this.getWeblisketSession().getOrder().getBasket();
            Node basketNode = document.createElement(BasketData.BASKET);
            HashMap<object, object> itemsAndNumberInBasket = basketInterface.getItems();
            int numberOfResults = 1;
            Set<object> items = itemsAndNumberInBasket.keySet();
            object[] productArray = items.toArray();
            int size = productArray.Length;
            for (int index = 0; index < size; index++) {
                string product = new string((((string) productArray[index])).ToCharArray());
                ItemInterface itemInterface = inventoryEntity.getItem(product);
                if (itemInterface != null) {
                    BasicItemView basicItemView = new BasicItemView(itemInterface, new BasicArrayListD());
                    Node node = basicItemView.toXmlNode(document);
                    string numberInBasket = basketInterface.getNumberOf(product).ToString();
                    node.appendChild(ModDomHelper.createNameValueNodes(document, BasketData.ITEMTOTALINBASKET, numberInBasket));
                    Money itemPrice = itemInterface.getPrice();
                    Money itemTotal = new Money(itemPrice);
                    itemTotal.multiply(((int) basketInterface.getNumberOf(product)));
                    node.appendChild(ModDomHelper.createNameValueNodes(document, BasketData.ITEMTOTAL, itemTotal.ToString()));
                    basketNode.appendChild(node);
                } else {
                    this.logUtil.putF("Product Failed: " + product, this, "toXmlNode");
                }
                numberOfResults++;
            }
            Node totalNumberNode = document.createElement(SearchData.TOTAL_NUMBER_ITEMS);
            Node totalNumberTextNode = document.createTextNode(basketInterface.getNumberOfItems().ToString());
            totalNumberNode.appendChild(totalNumberTextNode);
            Node totalWeightNode = document.createElement(BasketData.TOTALWEIGHT);
            Node totalWeightTextNode = document.createTextNode(basketInterface.getTotalWeight().ToString());
            totalWeightNode.appendChild(totalWeightTextNode);
            Node subTotalNode = document.createElement(BasketData.SUBTOTAL);
            Node subTotalTextNode = document.createTextNode(basketInterface.getSubTotal().ToString());
            subTotalNode.appendChild(subTotalTextNode);
            basketNode.appendChild(totalNumberNode);
            basketNode.appendChild(totalWeightNode);
            basketNode.appendChild(subTotalNode);
            return basketNode;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().XSLLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "toXmlNode", e);
            }
            throw e;
        }
    }

    public virtual void addDomNodeInterfaces()
    {
        this.addDomNodeInterface(((DomNodeInterface) this));
    }

    // throws Exception
    public virtual string view()
    {
        try {
            this.addDomNodeInterfaces();
            return base.view();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

}

