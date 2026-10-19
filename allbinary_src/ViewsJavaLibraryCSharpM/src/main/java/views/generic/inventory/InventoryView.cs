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
using InventoryData = org.allbinary.business.user.commerce.inventory.InventoryData;
using BasicItemView = org.allbinary.business.user.commerce.inventory.item.BasicItemView;
using ItemInterface = org.allbinary.business.user.commerce.inventory.item.ItemInterface;
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

namespace views.generic.inventory;

public class InventoryView : HttpStoreComponentView, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public InventoryView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Starting", this, "toXmlNode");
            }
            InventoryEntity inventoryEntityInterface = InventoryEntityFactory.getInstance().getInventoryEntityInstance();
            Node inventoryNode = document.createElement(InventoryData.INVENTORY);
            BasicArrayList itemVector = inventoryEntityInterface.getItems(StoreFrontFactory.getInstance(this.getTransformInfoInterface().getStoreName()));
            inventoryNode.appendChild(ModDomHelper.createNameValueNodes(document, SearchData.TOTAL_NUMBER_ITEMS_ON_THIS_PAGE, itemVector.size().ToString()));
            int size = itemVector.size();
            for (int index = 0; index < size; index++) {
                ItemInterface itemInterface = ((ItemInterface) itemVector.get(index));
                if (itemInterface != null) {
                    Node node = new BasicItemView(itemInterface, new BasicArrayListD()).toXmlNode(document);
                    inventoryNode.appendChild(node);
                } else {
                    this.logUtil.putF("Inventory", this, "toXmlNode");
                }
            }
            return inventoryNode;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
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
            string error = "Failed to view Inventory";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            return error;
        }
    }

}

