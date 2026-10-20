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
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.input.automation.actions.script.condition;

public class AlwaysActionScriptCondition : BasicProfileActionScriptCondition, AlwaysActionScriptConditionInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private AlwaysActionScriptConditionJPanel alwaysActionScriptConditionJPanel = null;
    private bool isOn = false;
    private static readonly string NAME = "Always On/Off";
    public AlwaysActionScriptCondition(Node node) : base(AlwaysActionScriptCondition.NAME, node)
    {
        // base(AlwaysActionScriptCondition.NAME, node) is called from the constructor declaration
        Node actionNode = DomSearchHelper.getNode(AlwaysActionScriptConditionData.NAME, node.getChildNodes());
        if (actionNode != null) {
            NodeList nodeList = actionNode.getChildNodes();
            for (int index = 0; index < nodeList.getLength(); index++) {
                Node childNode = nodeList.item(index);
                if (childNode.getNodeName().compareTo(AlwaysActionScriptConditionData.IS_ON) == 0) {
                    string booleanString = DomNodeHelper.getTextNodeValue(childNode);
                    this.setIsOn(booleanString);
                } else {
                    throw new Exception("Action Script Condition Unknown Node");
                }
            }
        } else {
            throw new Exception("Action Script Condition Node Null");
        }
        this.init();
    }

    public AlwaysActionScriptCondition() : base(AlwaysActionScriptCondition.NAME)
    {
        // base(AlwaysActionScriptCondition.NAME) is called from the constructor declaration
        this.init();
    }

    private void init()
    {
        this.alwaysActionScriptConditionJPanel = new AlwaysActionScriptConditionJPanel(this);
    }

    public virtual bool isIsOn()
    {
        return this.isOn;
    }

    public virtual void setIsOn(bool isOn)
    {
        this.isOn = isOn;
    }

    public virtual void showDialog()
    {
        this.alwaysActionScriptConditionJPanel.getAlwaysActionJDialog().setVisible(true);
    }

    public virtual HashMap<object, object> toHashMap()
    {
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(AlwaysActionScriptConditionData.IS_ON, (this.isIsOn()).ToString());
        this.logUtil.putF("HashMap: " + hashMap.ToString(), this, "toHashMap()");
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = base.toXmlNode(document);
        node.appendChild(ModDomHelper.createNodeWithValueNodes(document, AlwaysActionScriptConditionData.NAME, this.toHashMap()));
        return node;
    }

    // throws Exception
    public virtual bool shouldProcess(long? frame)
    {
        if (this.isIsOn()) {
            return base.shouldProcess(frame);
        }
        return false;
    }

    public virtual void log()
    {
        this.logUtil.putF("Is On: " + this.isIsOn(), this, "log");
    }

}

