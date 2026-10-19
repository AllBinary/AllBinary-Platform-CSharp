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
using BasketData = org.allbinary.business.user.commerce.inventory.basket.BasketData;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.context.modules.storefront;

public class StoreFrontView : DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private StoreFrontInterface storeFrontInterface;
    public StoreFrontView(StoreFrontInterface storeFrontInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF("Constructing: StoreFrontView for: " + storeFrontInterface.getName(), this, commonStrings.GET_INSTANCE);
        }
        this.storeFrontInterface = storeFrontInterface;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        HashMap hashMap = this.storeFrontInterface.toHashMap();
        StoreFrontData storeFrontData = StoreFrontData.getInstance();
        hashMap.put(storeFrontData.CURRENTHOMEHOSTNAME, this.storeFrontInterface.getCurrentHomeHostName());
        hashMap.put(storeFrontData.CURRENTHOMEHOSTNAMEPATH, this.storeFrontInterface.getCurrentHomeHostNamePath());
        hashMap.put(storeFrontData.CURRENTHOSTNAME, this.storeFrontInterface.getCurrentHostName());
        hashMap.put(storeFrontData.CURRENTHOSTNAMEPATH, this.storeFrontInterface.getCurrentHostNamePath());
        hashMap.put(BasketData.NAME, this.storeFrontInterface.getBasketName());
        Node node = ModDomHelper.createNameValueNodes(document, storeFrontData.NAME, hashMap);
        return node;
    }

}

