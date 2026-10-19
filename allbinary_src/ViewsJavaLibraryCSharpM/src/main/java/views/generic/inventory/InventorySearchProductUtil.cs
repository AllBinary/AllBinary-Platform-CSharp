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
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicItemView = org.allbinary.business.user.commerce.inventory.item.BasicItemView;
using ItemInterface = org.allbinary.business.user.commerce.inventory.item.ItemInterface;
using InventoryEntity = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntity;
using InventoryEntityFactory = org.allbinary.data.tables.user.commerce.inventory.item.InventoryEntityFactory;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SearchRequest = org.allbinary.logic.control.search.SearchRequest;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using StoreTransformer = org.allbinary.logic.visual.transform.StoreTransformer;
using TransformDocumentInterface = org.allbinary.logic.visual.transform.data.TransformDocumentInterface;
using TransformStoreDocumentFactory = org.allbinary.logic.visual.transform.data.TransformStoreDocumentFactory;
using TransformInfoHttpSearch = org.allbinary.logic.visual.transform.info.TransformInfoHttpSearch;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace views.generic.inventory;

public class InventorySearchProductUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly InventorySearchProductUtil instance = new InventorySearchProductUtil();
    public static InventorySearchProductUtil getInstance()
    {
        return InventorySearchProductUtil.instance;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly string ITEM_NOT_FOUND = "Item Not Found.";
    // throws Exception
    public virtual string getProduct(AbeClientInformationInterface abeClientInformation, SearchRequest searchRequest, string product)
    {
        try {
            InventoryEntity inventoryEntityInterface = InventoryEntityFactory.getInstance().getInventoryEntityInstance();
            ItemInterface itemInterface = inventoryEntityInterface.getItem(product);
            if (itemInterface != null) {
                TransformDocumentInterface viewDocumentInterface = TransformStoreDocumentFactory.getInstance(searchRequest);
                viewDocumentInterface.getBaseNode().appendChild(new BasicItemView(itemInterface, new BasicArrayListD()).toXmlNode(viewDocumentInterface.getDoc()));
                string success = XmlDocumentHelper.toString(viewDocumentInterface.getDoc());
                string outputStr = new StoreTransformer(abeClientInformation, ((TransformInfoInterface) new TransformInfoHttpSearch(searchRequest))).translate(success);
                return outputStr;
            } else {
                return this.ITEM_NOT_FOUND;
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRODUCTSEARCHLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "getProduct", e);
            }
            throw new Exception("Failed to getProduct");
        }
    }

}

