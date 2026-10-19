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
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.input.automation.module.actions.script.condition.processors.output;

public class ImageActionScriptOutput : BasicProfileActionScriptOutput, ImageActionScriptOutputInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly string NAME = "Captures";
    private bool saved = false;
    private bool display = false;
    private ImageTypes imageTypes = null;
    private ImageActionScriptOutputJPanel actionScriptOutputJPanel;
    public ImageActionScriptOutput(Node node) : base(NAME, node)
    {
        // base(NAME, node) is called from the constructor declaration
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        Node actionNode = DomSearchHelper.getNode(ImageActionScriptOutputData.NAME, node.getChildNodes());
        if (actionNode != null) {
            NodeList nodeList = actionNode.getChildNodes();
            for (int index = 0; index < nodeList.getLength(); index++) {
                Node childNode = nodeList.item(index);
                if (childNode.getNodeName().compareTo(ImageActionScriptOutputData.SAVE) == 0) {
                    string booleanString = DomNodeHelper.getTextNodeValue(childNode);
                    this.setSaved(booleanString);
                } else if (childNode.getNodeName().compareTo(ImageActionScriptOutputData.DISPLAY) == 0) {
                    string booleanString = DomNodeHelper.getTextNodeValue(childNode);
                    this.setSaved(booleanString);
                } else if (childNode.getNodeName().compareTo(ImageActionScriptOutputData.TYPES) == 0) {
                    this.setImageTypes(new ImageTypes(childNode));
                } else {
                    throw new Exception("Action Script Output Unknown Node");
                }
            }
        } else {
            throw new Exception("Action Script Output Node Null");
        }
        this.setAllowsChildren(false);
        this.actionScriptOutputJPanel = new ImageActionScriptOutputJPanel(this);
    }

    public ImageActionScriptOutput() : base(NAME)
    {
        // base(NAME) is called from the constructor declaration
        this.setImageTypes(new ImageTypes());
        this.setAllowsChildren(false);
        this.actionScriptOutputJPanel = new ImageActionScriptOutputJPanel(this);
    }

    public virtual ImageActionScriptOutputJPanel getActionScriptOutputJPanel()
    {
        return this.actionScriptOutputJPanel;
    }

    public virtual HashMap toHashMap()
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(ImageActionScriptOutputData.DISPLAY, (this.isDisplay()).ToString());
        hashMap.put(ImageActionScriptOutputData.SAVE, (this.isSaved()).ToString());
        this.logUtil.putF("HashMap: " + hashMap.ToString(), this, "toHashMap()");
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = base.toXmlNode(document);
        Node newNode = ModDomHelper.createNodeWithValueNodes(document, ImageActionScriptOutputData.NAME, this.toHashMap());
        newNode.appendChild(this.getImageTypes().toXmlNode(document));
        node.appendChild(newNode);
        return node;
    }

    // throws Exception
    public virtual void process(long? frame)
    {
        ImageActionScriptOutputProcessor.process(this, frame);
    }

    public virtual void showDialog()
    {
        this.actionScriptOutputJPanel.getCapturedImageActionJDialog().setVisible(true);
    }

    public virtual bool isSaved()
    {
        return this.saved;
    }

    public virtual void setSaved(bool saved)
    {
        this.saved = saved;
    }

    public virtual bool isDisplay()
    {
        return this.display;
    }

    public virtual void setDisplay(bool display)
    {
        this.display = display;
    }

    public virtual string future_toString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(" Is Save: ");
        stringBuffer.appendboolean(this.isSaved());
        stringBuffer.append(" Is Display: ");
        stringBuffer.appendboolean(this.isDisplay());
        stringBuffer.append(" ");
        stringBuffer.append(this.getImageTypes().ToString());
        return stringBuffer.ToString();
    }

    public virtual void log()
    {
        this.logUtil.putF(this.future_toString(), this, "log");
    }

    public virtual ImageTypes getImageTypes()
    {
        return this.imageTypes;
    }

    public virtual void setImageTypes(ImageTypes imageTypes)
    {
        this.imageTypes = imageTypes;
    }

}

