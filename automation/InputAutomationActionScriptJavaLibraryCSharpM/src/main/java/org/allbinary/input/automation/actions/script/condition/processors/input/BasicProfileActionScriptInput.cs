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
//using Iterator = java.util.Iterator;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using BasicProfileActionScriptProcessor = org.allbinary.input.automation.actions.script.condition.processors.BasicProfileActionScriptProcessor;
using InputRobotFactory = org.allbinary.input.automation.robot.InputRobotFactory;
using InputRobotInterface = org.allbinary.input.automation.robot.InputRobotInterface;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using org.allbinary.util;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.input.automation.actions.script.condition.processors.input;

public class BasicProfileActionScriptInput : BasicProfileActionScriptProcessor, ProfileActionScriptInputInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private InputRobotInterface inputRobotInterface = null;
    private int time = 0;
    public BasicProfileActionScriptInput(string label, Node node) : base(label, node)
    {
        // base(label, node) is called from the constructor declaration
        this.logUtil.putF(this.commonStrings.START + label, this, this.commonStrings.CONSTRUCTOR);
        Node actionNode = DomSearchHelper.getNode(GenericProfileActionScriptInputData.TYPE, node.getChildNodes());
        string inputTypeString = DomNodeHelper.getTextNodeValue(actionNode);
        Node timeNode = DomSearchHelper.getNodeNoThrow(GenericProfileActionScriptInputData.DELAY, node.getChildNodes());
        if (timeNode != null) {
            string delayString = DomNodeHelper.getTextNodeValue(timeNode);
            this.setTime(((int) (delayString).ToString()));
        } else {
            this.setTime(0);
        }
        this.setInputRobotInterface(InputRobotFactory.getInstance().get(inputTypeString));
    }

    public BasicProfileActionScriptInput(string label) : base(label)
    {
        // base(label) is called from the constructor declaration
        this.logUtil.putF(this.commonStrings.START + label, this, this.commonStrings.CONSTRUCTOR);
        InputRobotFactory inputRobotFactory = InputRobotFactory.getInstance();
        ABHashtable<object, object> hashtable = ((ABHashtable<object, object>) inputRobotFactory.get());
        Set<object> set = hashtable.keySet();
        Iterator iterator = set.iterator();
        this.setInputRobotInterface(inputRobotFactory.get(((string) iterator.next())));
        this.setTime(0);
    }

    public virtual int getTime()
    {
        return this.time;
    }

    public virtual void setTime(int time)
    {
        this.time = time;
    }

    public virtual HashMap<object, object> BasicProfileActionScriptInput_toHashMap()
    {
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(GenericProfileActionScriptInputData.TYPE, this.getInputRobotInterface().getName());
        hashMap.put(GenericProfileActionScriptInputData.DELAY, (this.getTime()).ToString());
        this.logUtil.putF("HashMap: " + hashMap.ToString(), this, "toHashMap()");
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = ModDomHelper.createNodeWithValueNodes(document, GenericProfileActionScriptInputData.NAME, this.BasicProfileActionScriptInput_toHashMap());
        return node;
    }

    public virtual void setInputRobotInterface(InputRobotInterface inputRobotInterface)
    {
        this.inputRobotInterface = inputRobotInterface;
    }

    public virtual InputRobotInterface getInputRobotInterface()
    {
        return this.inputRobotInterface;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(base.ToString());
        stringBuffer.append(" Input Type: ");
        if (this.getInputRobotInterface() != null) {
            stringBuffer.append(this.getInputRobotInterface().getName());
        } else {
            stringBuffer.append(StringUtil.getInstance().NULL_STRING);
        }
        stringBuffer.append(" Time: ");
        stringBuffer.appendlong(((long) this.getTime()));
        return stringBuffer.ToString();
    }

}

