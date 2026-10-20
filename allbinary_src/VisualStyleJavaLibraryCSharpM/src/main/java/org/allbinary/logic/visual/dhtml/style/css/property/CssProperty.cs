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
using DomData = org.allbinary.data.tree.dom.DomData;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.dhtml.style.css.property;

public class CssProperty : DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string propertyName;
    private CssPropertyValues cssPropertyValues;
    public CssProperty(string name)
    {
        this.propertyName = name;
        this.cssPropertyValues = new CssPropertyValues();
    }

    public CssProperty(Node node)
    {
        Node propertyNode = DomSearchHelper.getNode(DomData.VALUE, node.getChildNodes());
        this.propertyName = DomNodeHelper.getTextNodeValue(propertyNode);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().STYLE)) {
            this.logUtil.putF("Name: " + this.getName(), this, "CssProperty()");
        }
        Node propertyValuesNode = DomSearchHelper.getNode(CssPropertyData.getInstance().VALUES, node.getChildNodes());
        this.cssPropertyValues = new CssPropertyValues(propertyValuesNode);
    }

    public virtual string getName()
    {
        return this.propertyName;
    }

    public virtual HashMap<object, object> toHashMap()
    {
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(CssPropertyData.getInstance().NAME, this.propertyName);
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        HashMap<object, object> hashMap = this.toHashMap();
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("CssView HashMap: " + hashMap.ToString(), this, "toXmlNode()");
        }
        Node node = ModDomHelper.createNameValueNodes(document, CssPropertyData.getInstance().NAME, this.propertyName);
        node.appendChild(this.cssPropertyValues.toXmlNode(document));
        return node;
    }

}

