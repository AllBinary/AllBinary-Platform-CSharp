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
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.input.automation.actions.script.condition;

public class TimeIntervalActionScriptCondition : BasicProfileActionScriptCondition, TimeIntervalActionScriptConditionInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private TimeIntervalActionScriptConditionJPanel timeIntervalActionScriptConditionJPanel = null;
    private TimeDelayHelper timeHelper = null;
    private static readonly string NAME = "Time Interval";
    public TimeIntervalActionScriptCondition(Node node) : base(TimeIntervalActionScriptCondition.NAME, node)
    {
        // base(TimeIntervalActionScriptCondition.NAME, node) is called from the constructor declaration
        Node actionNode = DomSearchHelper.getNode(TimeIntervalActionScriptConditionData.NAME, node.getChildNodes());
        if (actionNode != null) {
            NodeList nodeList = actionNode.getChildNodes();
            for (int index = 0; index < nodeList.getLength(); index++) {
                Node childNode = nodeList.item(index);
                if (childNode.getNodeName().compareTo(TimeIntervalActionScriptConditionData.TIME) == 0) {
                    string interval = DomNodeHelper.getTextNodeValue(childNode);
                    this.setTimeDelayHelper(new TimeDelayHelper((interval).ToString()));
                } else {
                    throw new Exception("Time Interval Action Script Condition Unknown Node");
                }
            }
        } else {
            throw new Exception("Time Interval Action Script Condition Node Null");
        }
        this.init();
    }

    public TimeIntervalActionScriptCondition() : base(TimeIntervalActionScriptCondition.NAME)
    {
        // base(TimeIntervalActionScriptCondition.NAME) is called from the constructor declaration
        this.setTimeDelayHelper(new TimeDelayHelper(0));
        this.init();
    }

    private void init()
    {
        this.timeIntervalActionScriptConditionJPanel = new TimeIntervalActionScriptConditionJPanel(this);
    }

    public virtual void showDialog()
    {
        this.timeIntervalActionScriptConditionJPanel.getTimeIntervalActionJDialog().setVisible(true);
    }

    public virtual HashMap<object, object> toHashMap()
    {
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(TimeIntervalActionScriptConditionData.TIME, (this.timeHelper.delay).ToString());
        this.logUtil.putF("HashMap: " + hashMap.ToString(), this, "toHashMap()");
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = base.toXmlNode(document);
        node.appendChild(ModDomHelper.createNodeWithValueNodes(document, TimeIntervalActionScriptConditionData.NAME, this.toHashMap()));
        return node;
    }

    public virtual void log()
    {
        this.logUtil.putF("Time Interval: " + this.timeHelper.delay, this, "log");
    }

    public virtual TimeDelayHelper getTimeDelayHelper()
    {
        return this.timeHelper;
    }

    public virtual void setTimeDelayHelper(TimeDelayHelper timeHelper)
    {
        this.timeHelper = timeHelper;
    }

    // throws Exception
    public virtual bool shouldProcess(long? frame)
    {
        TimeDelayHelper timeHelper = this.getTimeDelayHelper();
        if (timeHelper.isTimeTNT()) {
            timeHelper.setStartTimeTNT();
            return base.shouldProcess(frame);
        }
        return false;
    }

}

