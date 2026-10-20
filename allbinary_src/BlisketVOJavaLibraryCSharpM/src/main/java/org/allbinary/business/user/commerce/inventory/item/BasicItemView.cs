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
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.user.commerce.inventory.item;

public class BasicItemView : DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly BasicItemData basicItemData = BasicItemData.getInstance();
    private readonly ItemInterface itemInterface;
    private readonly BasicArrayList vector;
    public BasicItemView(ItemInterface itemInterface, BasicArrayList vector)
    {
        this.itemInterface = itemInterface;
        this.vector = vector;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRODUCTSEARCHLOGGING)) {
            this.logUtil.putF(this.commonStrings.START, this, "toXmlNode");
        }
        HashMap<object, object> hashMap = this.itemInterface.toHashMap();
        string EMPTY_STRING = StringUtil.getInstance().EMPTY_STRING;
        hashMap.put(this.basicItemData.IMAGE, EMPTY_STRING);
        StringUtil stringUtil = StringUtil.getInstance();
        Set<object> keySet = hashMap.keySet();
        Node node = document.createElement(this.basicItemData.ITEM);
        object[] nameArray = keySet.toArray();
        int size2 = nameArray.Length;
        for (int index = 0; index < size2; index++) {
            string name = ((string) nameArray[index]);
            string value = ((string) hashMap.get(name));
            value = stringUtil.getNonNull(value);
            node.appendChild(ModDomHelper.createNameValueNodes(document, name, value));
        }
        Node totalNode = ModDomHelper.createNameValueNodes(document, this.basicItemData.TOTAL, this.itemInterface.getTotal().ToString());
        node.appendChild(totalNode);
        int size = this.vector.size();
        for (int index = 0; index < size; index++) {
            DomNodeInterface domNodeInterface = ((DomNodeInterface) this.vector.get(index));
            Node customNode = domNodeInterface.toXmlNode(document);
            node.appendChild(customNode);
        }
        return node;
    }

    public virtual Document toXmlDoc()
    {
        return null;
    }

    public virtual string view()
    {
        return null;
    }

}

