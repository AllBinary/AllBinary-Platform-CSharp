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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using EntryData = org.allbinary.business.entry.EntryData;
using StreetAddress = org.allbinary.business.user.address.StreetAddress;
using BasketInterface = org.allbinary.business.user.commerce.inventory.basket.BasketInterface;
using OrderInterface = org.allbinary.business.user.commerce.inventory.order.OrderInterface;
using Money = org.allbinary.business.user.commerce.money.Money;
using TaxFactory = org.allbinary.business.user.commerce.money.tax.TaxFactory;
using ShippingMethods = org.allbinary.business.user.commerce.shipping.ShippingMethods;
using ShippingMethodsData = org.allbinary.business.user.commerce.shipping.ShippingMethodsData;
using ShippingInterface = org.allbinary.business.user.commerce.shipping.modules.ShippingInterface;
using StreetAddressesEntityInterface = org.allbinary.data.tables.user.address.StreetAddressesEntityInterface;
using ShippingAddressesEntityFactory = org.allbinary.data.tables.user.address.shipping.ShippingAddressesEntityFactory;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;

namespace views.generic.shipping;

public class ShippingMethodsView : HttpStoreComponentView, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private ShippingMethods shippingMethods;
    private StoreFrontInterface storeFrontInterface;
    public ShippingMethodsView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.storeFrontInterface = StoreFrontFactory.getInstance(this.getTransformInfoInterface().getStoreName());
        this.shippingMethods = new ShippingMethods(this.abeClientInformation, this.storeFrontInterface);
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        try {
            Node shippingMethodsNode = document.createElement(ShippingMethodsData.SHIPPINGMETHODSORDERSUMMARIES);
            OrderInterface order = this.getWeblisketSession().getOrder();
            BasketInterface basket = this.getWeblisketSession().getOrder().getBasket();
            StreetAddressesEntityInterface shippingAddressesEntityInterface = ShippingAddressesEntityFactory.getInstance().getInstance(this.getWeblisketSession().getUserName());
            StreetAddress streetAddress = shippingAddressesEntityInterface.getDefault();
            BasicArrayList shippingVector = this.shippingMethods.get();
            int size = shippingVector.size();
            for (int index = 0; index < size; index++) {
                Node shippingMethodNode = document.createElement(ShippingMethodsData.SHIPPINGMETHODORDERSUMMARY);
                ShippingInterface shipping = ((ShippingInterface) shippingVector.get(index));
                DomNodeInterface shippingView = ((DomNodeInterface) shipping);
                shippingMethodNode.appendChild(shippingView.toXmlNode(document));
                Money shippingCost = shipping.getCost(order);
                Money subTotal = basket.getSubTotal();
                float? taxRate = TaxFactory.getInstance().getInstance(this.abeClientInformation, storeFrontInterface).getTaxRate(streetAddress, storeFrontInterface);
                Money tax = new Money();
                Money total = new Money();
                total.add(shippingCost.ToString());
                total.add(subTotal.ToString());
                tax.add(total.ToString());
                tax.multiply(taxRate);
                total.add(tax.ToString());
                shippingMethodNode.appendChild(ModDomHelper.createNameValueNodes(document, ShippingMethodsData.SHIPPINGCOST, shippingCost.ToString()));
                shippingMethodNode.appendChild(ModDomHelper.createNameValueNodes(document, ShippingMethodsData.TAXRATE, taxRate.ToString()));
                shippingMethodNode.appendChild(ModDomHelper.createNameValueNodes(document, ShippingMethodsData.SUBTOTAL, subTotal.ToString()));
                shippingMethodNode.appendChild(ModDomHelper.createNameValueNodes(document, ShippingMethodsData.TAX, tax.ToString()));
                shippingMethodNode.appendChild(ModDomHelper.createNameValueNodes(document, ShippingMethodsData.TOTAL, total.ToString()));
                shippingMethodNode.appendChild(ModDomHelper.createNameValueNodes(document, EntryData.getInstance().DEFAULT, this.shippingMethods.getDefault().getName()));
                shippingMethodsNode.appendChild(shippingMethodNode);
            }
            return shippingMethodsNode;
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

    public virtual string view()
    {
        try {
            this.addDomNodeInterfaces();
            return base.view();
        } catch (Exception e) {
            string error = "Failed to view ShippingMethods";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            return error;
        }
    }

}

