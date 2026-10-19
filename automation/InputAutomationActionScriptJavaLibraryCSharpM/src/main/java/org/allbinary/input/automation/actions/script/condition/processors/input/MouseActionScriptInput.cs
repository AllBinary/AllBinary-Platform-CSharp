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
//using java.awt;
//using InputEvent = java.awt.@event.InputEvent;
using java.util;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.input.automation.actions.script.condition.processors.input;

public class MouseActionScriptInput : BasicProfileActionScriptInput, MouseActionScriptInputInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private Point point;
    private int buttons = 0;
    private static readonly string NAME = "Mouse";
    private MouseActionScriptInputJPanel mouseActionScriptInputJPanel;
    public MouseActionScriptInput(Node node) : base(NAME, node)
    {
        // base(NAME, node) is called from the constructor declaration
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.point = new Point();
        Node actionNode = DomSearchHelper.getNode(MouseActionScriptInputData.NAME, node.getChildNodes());
        if (actionNode != null) {
            NodeList nodeList = actionNode.getChildNodes();
            for (int index = 0; index < nodeList.getLength(); index++) {
                Node childNode = nodeList.item(index);
                if (childNode.getNodeName().compareTo(MouseActionScriptInputData.BUTTONS) == 0) {
                    string buttons = DomNodeHelper.getTextNodeValue(childNode);
                    this.setButtonClicks(((int) (buttons).ToString()));
                } else if (childNode.getNodeName().compareTo(MouseActionScriptInputData.MOVE) == 0) {
                    Node mouseXNode = DomSearchHelper.getNode(MouseActionScriptInputData.MOVE_X, childNode.getChildNodes());
                    string mouseXString = DomNodeHelper.getTextNodeValue(mouseXNode);
                    int? mouseXInteger = (mouseXString).ToString();
                    Node mouseYNode = DomSearchHelper.getNode(MouseActionScriptInputData.MOVE_Y, childNode.getChildNodes());
                    string mouseYString = DomNodeHelper.getTextNodeValue(mouseYNode);
                    int? mouseYInteger = (mouseYString).ToString();
                    Point newPoint = new Point(((int) mouseXInteger), ((int) mouseYInteger));
                    this.setPoint(newPoint);
                } else {
                    throw new Exception("Action Script Input Unknown Node");
                }
            }
        } else {
            throw new Exception("Action Script Input Node Null");
        }
        this.setAllowsChildren(false);
        this.mouseActionScriptInputJPanel = new MouseActionScriptInputJPanel(this);
    }

    public MouseActionScriptInput() : base(NAME)
    {
        // base(NAME) is called from the constructor declaration
        this.point = new Point();
        this.setAllowsChildren(false);
        this.mouseActionScriptInputJPanel = new MouseActionScriptInputJPanel(this);
    }

    public virtual void setPoint(Point point)
    {
        this.point = point;
    }

    public virtual Point getPoint()
    {
        return this.point;
    }

    public virtual int getButtonClicks()
    {
        return this.buttons;
    }

    public virtual void setButtonClicks(int buttons)
    {
        this.buttons = buttons;
    }

    public virtual void showDialog()
    {
        this.mouseActionScriptInputJPanel.getMouseActionJDialog().setVisible(true);
    }

    public virtual HashMap toHashMap()
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(MouseActionScriptInputData.BUTTONS, (this.getButtonClicks()).ToString());
        this.logUtil.putF("HashMap: " + hashMap.ToString(), this, "toHashMap()");
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = base.toXmlNode(document);
        Node mouseNode = ModDomHelper.createNodeWithValueNodes(document, MouseActionScriptInputData.NAME, this.toHashMap());
        node.appendChild(mouseNode);
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(MouseActionScriptInputData.MOVE_X, (this.getPoint().x).ToString());
        hashMap.put(MouseActionScriptInputData.MOVE_Y, (this.getPoint().y).ToString());
        mouseNode.appendChild(ModDomHelper.createNodeWithValueNodes(document, MouseActionScriptInputData.MOVE, hashMap));
        return node;
    }

    // throws Exception
    public virtual void process(long? frame)
    {
        MouseInputAutomationProcessor.process(this);
    }

    public virtual void log()
    {
        StringMaker buttonStringBuffer = new StringMaker();
        buttonStringBuffer.append("1: ");
        BooleanFactory booleanFactory = BooleanFactory.getInstance();
        if ((this.getButtonClicks() & InputEvent.BUTTON1_MASK) != 0) {
            buttonStringBuffer.append(booleanFactory.TRUE_STRING);
        } else {
            buttonStringBuffer.append(booleanFactory.FALSE_STRING);
        }
        buttonStringBuffer.append(" 2: ");
        if ((this.getButtonClicks() & InputEvent.BUTTON2_MASK) != 0) {
            buttonStringBuffer.append(booleanFactory.TRUE_STRING);
        } else {
            buttonStringBuffer.append(booleanFactory.FALSE_STRING);
        }
        buttonStringBuffer.append(" 3: ");
        if ((this.getButtonClicks() & InputEvent.BUTTON3_MASK) != 0) {
            buttonStringBuffer.append(booleanFactory.TRUE_STRING);
        } else {
            buttonStringBuffer.append(booleanFactory.FALSE_STRING);
        }
        this.logUtil.putF("Input Type: " + this.getInputRobotInterface().getName() + " Point: " + this.getPoint() + " Buttons Clicked: " + buttonStringBuffer.ToString(), this, "log");
    }

}

