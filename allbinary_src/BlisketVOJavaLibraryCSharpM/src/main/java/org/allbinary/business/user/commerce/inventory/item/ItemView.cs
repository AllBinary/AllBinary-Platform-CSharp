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
//using Set = java.util.Set;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StreetAddressData = org.allbinary.business.user.address.StreetAddressData;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.user.commerce.inventory.item;

public class ItemView
{
    private readonly OrderItemInterface itemInterface;
    private readonly BasicArrayList vector;
    public ItemView(OrderItemInterface itemInterface, BasicArrayList vector)
    {
        this.itemInterface = itemInterface;
        this.vector = vector;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        HashMap hashMap = this.itemInterface.toHashMap();
        Set keySet = hashMap.keySet();
        Node node = document.createElement(ItemData.ITEM);
        BasicItemView basicItemView = new BasicItemView(this.itemInterface, this.vector);
        node.appendChild(basicItemView.toXmlNode(document));
        StringUtil stringUtil = StringUtil.getInstance();
        object[] nameArray = keySet.toArray();
        int size = nameArray.Length;
        for (int index = 0; index < size; index++) {
            string name = ((string) nameArray[index]);
            string value = ((string) hashMap.get(name));
            value = stringUtil.getNonNull(value);
            node.appendChild(ModDomHelper.createNameValueNodes(document, name, value));
        }
        Node shippingAddressNode = document.createElement(StreetAddressData.NAME);
        shippingAddressNode.appendChild(this.itemInterface.getShippingAddress().toXmlNode(document));
        return node;
    }

}

