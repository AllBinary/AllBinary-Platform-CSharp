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
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.context.modules.storefront.statistics.advertisements;

public class StoreFrontAdvertisementsStatisticsView : DomNodeInterface
{
    private StoreFrontAdvertisementsStatisticsInterface storeFrontAdvertisementsStatisticsInterface;
    public StoreFrontAdvertisementsStatisticsView(StoreFrontAdvertisementsStatisticsInterface storeFrontAdvertisementsStatisticsInterface)
    {
        this.storeFrontAdvertisementsStatisticsInterface = storeFrontAdvertisementsStatisticsInterface;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        HashMap hashMap = this.storeFrontAdvertisementsStatisticsInterface.toHashMap();
        Node node = ModDomHelper.createNameValueNodes(document, StoreFrontAdvertisementsStatisticsData.getInstance().NAME, hashMap);
        return node;
    }

}

