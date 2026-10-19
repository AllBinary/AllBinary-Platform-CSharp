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
using DomData = org.allbinary.data.tree.dom.DomData;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.dhtml.style.css.property;

public class CssPropertyValues : DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private BasicArrayList propertyValueVector;
    public CssPropertyValues()
    {
        this.propertyValueVector = new BasicArrayListD();
    }

    public CssPropertyValues(Node node)
    {
        HashMap indexPropertyValueHashMap = StdUtil.getInstance().createHashMap();
        this.propertyValueVector = new BasicArrayListD();
        BasicArrayList cssPropertyNodeVector = DomSearchHelper.getAllNodes(CssPropertyValueData.getInstance().NAME, node.getChildNodes());
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().STYLE)) {
            this.logUtil.putF("Number Of Properties: " + cssPropertyNodeVector.size(), this, "CssProperties()");
        }
        int size = cssPropertyNodeVector.size();
        for (int index = 0; index < size; index++) {
            Node cssPropertyValueNode = ((Node) cssPropertyNodeVector.get(index));
            Node valueNode = DomSearchHelper.getNode(DomData.VALUE, cssPropertyValueNode.getChildNodes());
            string propertyValue = DomNodeHelper.getTextNodeValue(valueNode);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().STYLE)) {
                this.logUtil.putF("Property Value: " + propertyValue, this, "CssProperties()");
            }
            Node indexNode = DomSearchHelper.getNode(DomData.INDEX, cssPropertyValueNode.getChildNodes());
            string indexValue = DomNodeHelper.getTextNodeValue(indexNode);
            indexPropertyValueHashMap.put(indexValue, propertyValue);
        }
        int size2 = indexPropertyValueHashMap.keySet().size();
        for (int index = 0; index < size2; index++) {
            int? indexInt = index;
            string propertyValue = ((string) indexPropertyValueHashMap.get(indexInt.ToString()));
            this.propertyValueVector.add(propertyValue);
        }
    }

    public virtual HashMap toHashMap()
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        CssPropertyValueData cssPropertyValueData = CssPropertyValueData.getInstance();
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        StringMaker stringBuffer = new StringMaker();
        int size = this.propertyValueVector.size();
        for (int index = 0; index < size; index++) {
            string value = ((string) this.propertyValueVector.get(index));
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append(cssPropertyValueData.NAME);
            stringBuffer.append(commonSeps.BRACKET_OPEN);
            stringBuffer.appendint(index);
            stringBuffer.append(commonSeps.BRACKET_CLOSE);
            hashMap.put(stringBuffer.ToString(), value);
            index++;
        }
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            HashMap hashMap = this.toHashMap();
            this.logUtil.putF("CssPropertyValues HashMap: " + hashMap.ToString(), this, "toXmlNode()");
        }
        return ModDomHelper.createNameValueIndexNodes(document, CssPropertyData.getInstance().VALUES, CssPropertyValueData.getInstance().NAME, this.propertyValueVector);
    }

}

