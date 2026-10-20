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
//using KeyEvent = java.awt.@event.KeyEvent;
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using KeySingletonFactory = org.allbinary.input.KeySingletonFactory;
using KeyUtil = org.allbinary.input.KeyUtil;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.input.automation.actions.script.condition.processors.input;

public class KeyboardActionScriptInput : BasicProfileActionScriptInput, KeyboardActionScriptInputInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private int?[] keyArray = new int?[] { KeySingletonFactory.getInstance(KeyEvent.VK_0) };
    private static readonly string NAME = "Keyboard";
    private KeyboardActionScriptInputJPanel keyboardActionScriptInputJPanel;
    private bool press = false;
    private bool release = false;
    private int delayBetweenKeys = 0;
    public KeyboardActionScriptInput(Node node) : base(NAME, node)
    {
        // base(NAME, node) is called from the constructor declaration
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        Node actionNode = DomSearchHelper.getNode(KeyboardActionScriptInputData.NAME, node.getChildNodes());
        if (actionNode != null) {
            NodeList nodeList = actionNode.getChildNodes();
            BasicArrayList vector = new BasicArrayListD();
            for (int index = 0; index < nodeList.getLength(); index++) {
                Node childNode = nodeList.item(index);
                if (childNode.getNodeName().startsWith(KeyboardActionScriptInputData.KEY)) {
                    string keyString = DomNodeHelper.getTextNodeValue(childNode);
                    vector.add((keyString).ToString());
                } else if (childNode.getNodeName().compareTo(KeyboardActionScriptInputData.DELAY_BETWEEN_KEYS) == 0) {
                    string time = DomNodeHelper.getTextNodeValue(childNode);
                    this.setDelayBetweenKeys(((int) (time).ToString()));
                } else if (childNode.getNodeName().compareTo(KeyboardActionScriptInputData.PRESS) == 0) {
                    string value = DomNodeHelper.getTextNodeValue(childNode);
                    this.setPress((value).ToString());
                } else if (childNode.getNodeName().compareTo(KeyboardActionScriptInputData.RELEASE) == 0) {
                    string value = DomNodeHelper.getTextNodeValue(childNode);
                    this.setRelease((value).ToString());
                } else {
                    throw new Exception("Action Script Input Unknown Node");
                }
            }
            this.setKeyArray(((int?[]) vector.toArrayType(new int?[vector.size()])));
        } else {
            throw new Exception("Action Script Input Node Null");
        }
        this.setAllowsChildren(false);
        if (!this.isPress() && !this.isRelease()) {
            this.setNormal();
        }
        this.keyboardActionScriptInputJPanel = new KeyboardActionScriptInputJPanel(this);
    }

    public KeyboardActionScriptInput() : base(NAME)
    {
        // base(NAME) is called from the constructor declaration
        if (!this.isPress() && !this.isRelease()) {
            this.setNormal();
        }
        this.setAllowsChildren(false);
        this.setTime(120);
        this.keyboardActionScriptInputJPanel = new KeyboardActionScriptInputJPanel(this);
    }

    public virtual int getDelayBetweenKeys()
    {
        return this.delayBetweenKeys;
    }

    public virtual void setDelayBetweenKeys(int delayBetweenKeys)
    {
        this.delayBetweenKeys = delayBetweenKeys;
    }

    public virtual bool isPress()
    {
        return this.press;
    }

    public virtual void setPress(bool press)
    {
        this.press = press;
    }

    public virtual bool isRelease()
    {
        return this.release;
    }

    public virtual void setRelease(bool release)
    {
        this.release = release;
    }

    public virtual bool isNormal()
    {
        return this.isRelease() && this.isPress();
    }

    public virtual void setNormal()
    {
        this.setPress(true);
        this.setRelease(true);
    }

    public virtual int?[] getKeyArray()
    {
        return this.keyArray;
    }

    public virtual void setKeyArray(int?[] keyArray)
    {
        if (keyArray != null) {
            this.logUtil.putF(CommonLabels.getInstance().START + keyArray.Length, this, "setKeyArray");
        }
        this.keyArray = keyArray;
    }

    public virtual void showDialog()
    {
        this.keyboardActionScriptInputJPanel.getKeyActionJDialog().setVisible(true);
    }

    public virtual string getText()
    {
        return this.getText(this.getKeyArray());
    }

    public virtual void setText(string text)
    {
        this.logUtil.putF(CommonLabels.getInstance().START + text, this, "setText");
        int?[] integerArray = this.integerArrayValue(text);
        this.setKeyArray(integerArray);
    }

    private static string getText(int?[] integerArray)
    {
        int index = 0;
        StringMaker stringBuffer = new StringMaker();
        while (index < integerArray.Length) {
            int? nextInteger = integerArray[index];
            if (KeyUtil.isNormallyDisplayed(nextInteger)) {
                stringBuffer.append(KeyEvent.getKeyText(nextInteger));
            } else {
                stringBuffer.append("&#" + nextInteger + ";");
            }
            index++;
        }
        return stringBuffer.ToString();
    }

    private int?[] integerArrayValue(string text)
    {
        this.logUtil.putF(CommonLabels.getInstance().START + text, this, "integerArrayValue");
        BasicArrayList vector = new BasicArrayListD();
        int index = 0;
        while (index < text.Length) {
            char aChar = text[index];
            if (aChar == '&') {
                if (text[index + 1] == '#') {
                    int endIndex = text.IndexOf(';', index + 1);
                    if (endIndex != -1) {
                        string nextCharString = text.Substring(index + 2, (endIndex) - (index + 2));
                        this.logUtil.putF(CommonLabels.getInstance().NEXT + " Char String: " + nextCharString, this, "integerArrayValue");
                        vector.add((nextCharString.Substring(index, (nextCharString.Length) - (index))).ToString());
                        index = index + nextCharString.Length + 3;
                        continue;
                    }
                }
            }
            vector.add(KeySingletonFactory.getHashtable().get((aChar).ToString()));
            index++;
        }
        int?[] integerArray = ((int?[]) vector.toArrayType(new int?[vector.size()]));
        return integerArray;
    }

    public virtual HashMap<object, object> toHashMap()
    {
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        for (int index = 0; index < this.getKeyArray().Length; index++) {
            hashMap.put(KeyboardActionScriptInputData.KEY + index, (this.getKeyArray()[index]).ToString());
        }
        hashMap.put(KeyboardActionScriptInputData.DELAY_BETWEEN_KEYS, (this.getDelayBetweenKeys()).ToString());
        hashMap.put(KeyboardActionScriptInputData.PRESS, (this.isPress()).ToString());
        hashMap.put(KeyboardActionScriptInputData.RELEASE, (this.isRelease()).ToString());
        this.logUtil.putF("HashMap: " + hashMap.ToString(), this, "toHashMap()");
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = base.toXmlNode(document);
        node.appendChild(ModDomHelper.createNodeWithValueNodes(document, KeyboardActionScriptInputData.NAME, this.toHashMap()));
        return node;
    }

    // throws Exception
    public virtual void process(long? frame)
    {
        KeyboardInputAutomationProcessor.process(this);
    }

    public virtual void log()
    {
        this.logUtil.putF(this.ToString(), this, "log");
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(base.ToString());
        stringBuffer.append(" Text: ");
        stringBuffer.append(this.getText());
        stringBuffer.append(" isPress: ");
        stringBuffer.appendboolean(this.isPress());
        stringBuffer.append(" isRelease: ");
        stringBuffer.appendboolean(this.isRelease());
        stringBuffer.append(" Between Key Delay: ");
        stringBuffer.appendint(this.getDelayBetweenKeys());
        return stringBuffer.ToString();
    }

}

