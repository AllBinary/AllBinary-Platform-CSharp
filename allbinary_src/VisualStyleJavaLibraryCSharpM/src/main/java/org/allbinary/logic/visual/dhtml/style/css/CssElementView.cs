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
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CssPropertiesValidationFactory = org.allbinary.logic.visual.dhtml.style.css.property.CssPropertiesValidationFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.logic.visual.dhtml.style.css;

public class CssElementView : DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly string TITLE = "title";
    private readonly string DESCRIPTION = "description";
    private string value;
    private string title;
    private string description;
    public BasicArrayList cssElementVector = null;
    public BasicArrayList cssPropertyVector;
    public CssElementView()
    {
        this.cssPropertyVector = new BasicArrayListD();
        StringUtil stringUtil = StringUtil.getInstance();
        this.title = stringUtil.EMPTY_STRING;
        this.description = stringUtil.EMPTY_STRING;
        this.value = stringUtil.EMPTY_STRING;
    }

    public CssElementView(Node node)
    {
        try {
            Node valueNode = DomSearchHelper.getNode(DomData.VALUE, node.getChildNodes());
            this.value = DomNodeHelper.getTextNodeValue(valueNode);
            Node titleValueNode = DomSearchHelper.getNodeNoThrow(this.TITLE, node.getChildNodes());
            if (titleValueNode != null) {
                this.title = DomNodeHelper.getTextNodeValue(titleValueNode);
            } else {
                StringUtil stringUtil = StringUtil.getInstance();
                this.title = stringUtil.EMPTY_STRING;
            }
            Node descriptionValueNode = DomSearchHelper.getNodeNoThrow(this.DESCRIPTION, node.getChildNodes());
            if (descriptionValueNode != null) {
                this.description = DomNodeHelper.getTextNodeValue(descriptionValueNode);
            } else {
                this.description = StringUtil.getInstance().EMPTY_STRING;
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF(new StringMaker().append("Value: ").append(this.value).append("\nTitle: ").append(this.title).append("\nDescription: ").append(this.description).ToString(), this, this.commonStrings.CONSTRUCTOR);
            }
            BasicArrayList cssElementStyleNodeVector = DomSearchHelper.getAllNodes(CssElementData.getInstance().NAME, node.getChildNodes());
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Child Css Elements: " + cssElementStyleNodeVector.size(), this, "CssElementView()");
            }
            this.cssElementVector = CssElementsValidationFactory.getInstance(cssElementStyleNodeVector);
            NodeList nodeList = node.getChildNodes();
            this.cssPropertyVector = CssPropertiesValidationFactory.getInstance(nodeList);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put(new StringMaker().append("Value: ").append(this.value).append("\nTitle: ").append(this.title).append("\nDescription: ").append(this.description).ToString(), this, this.commonStrings.CONSTRUCTOR, e);
            }
            throw new Exception("CssElementView");
        }
    }

    public virtual string getValue()
    {
        return this.value;
    }

    public virtual HashMap toHashMap()
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(DomData.VALUE, this.value);
        hashMap.put(this.TITLE, this.title);
        hashMap.put(this.DESCRIPTION, this.description);
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        HashMap hashMap = this.toHashMap();
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("CssView HashMap: " + hashMap.ToString(), this, "toXmlNode");
        }
        Node node = ModDomHelper.createNodeWithValueNodes(document, CssElementData.getInstance().NAME, hashMap);
        int size = this.cssPropertyVector.size();
        for (int index = 0; index < size; index++) {
            DomNodeInterface cssPropertyDomNodeInterface = ((DomNodeInterface) this.cssPropertyVector.get(index));
            node.appendChild(cssPropertyDomNodeInterface.toXmlNode(document));
        }
        int size2 = this.cssElementVector.size();
        for (int index = 0; index < size2; index++) {
            DomNodeInterface cssElementDomNodeInterface = ((DomNodeInterface) this.cssElementVector.get(index));
            node.appendChild(cssElementDomNodeInterface.toXmlNode(document));
        }
        return node;
    }

}

