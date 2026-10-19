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
using BasketData = org.allbinary.business.user.commerce.inventory.basket.BasketData;
using BasketInterface = org.allbinary.business.user.commerce.inventory.basket.BasketInterface;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SearchData = org.allbinary.logic.control.search.SearchData;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;

namespace views.generic.basket.mini;

public class MiniBasketView : HttpStoreComponentView, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public MiniBasketView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        try {
            BasketInterface basketInterface = this.getWeblisketSession().getOrder().getBasket();
            Node basketNode = document.createElement(BasketData.BASKET);
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

