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
//using XmlAccessType = javax.xml.bind.annotation.XmlAccessType;
//using XmlAccessorType = javax.xml.bind.annotation.XmlAccessorType;
//using XmlElement = javax.xml.bind.annotation.XmlElement;
//using XmlRootElement = javax.xml.bind.annotation.XmlRootElement;
//using XmlType = javax.xml.bind.annotation.XmlType;
using DynamicObjectData = org.allbinary.business.DynamicObjectData;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using InputAutomationData = org.allbinary.input.automation.InputAutomationData;
using InputAutomationModuleData = org.allbinary.input.automation.module.InputAutomationModuleData;
using InputAutomationModuleFactoryInterface = org.allbinary.input.automation.module.InputAutomationModuleFactoryInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbeFactory = org.allbinary.logic.system.loader.AbeFactory;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.input.automation.module.configuration;

public class InputAutomationModuleConfiguration
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private string className = null;
    private string name = null;
    private InputAutomationModuleFactoryInterface inputAutomationModuleInterface = null;
    public InputAutomationModuleConfiguration()
    {
    }

    public InputAutomationModuleConfiguration(AbeClientInformationInterface abeClientInformation, Node node)
    {
        this.init(abeClientInformation, node);
    }

    public InputAutomationModuleConfiguration(AbeClientInformationInterface abeClientInformation, string name, string className)
    {
        this.setName(name);
        this.setClassName(className);
        this.init(abeClientInformation);
    }

    public InputAutomationModuleConfiguration(InputAutomationModuleFactoryInterface inputAutomationModuleInterface)
    {
        this.setInputAutomationModuleInterface(inputAutomationModuleInterface);
        this.setClassName(this.inputAutomationModuleInterface.GetType().FullName);
    }

    // throws Exception
    public virtual void init(AbeClientInformationInterface abeClientInformation, Node node)
    {
        NodeList nodeList = node.getChildNodes();
        if (nodeList != null) {
            Node classNameNode = DomSearchHelper.getNode(DynamicObjectData.NAME, nodeList);
            if (classNameNode != null) {
                this.setClassName(DomNodeHelper.getTextNodeValue(classNameNode));
                this.init(abeClientInformation);
            } else {
                this.logUtil.putF("Class Node Null", this, this.commonStrings.INIT);
            }
        } else {
            this.logUtil.putF(InputAutomationData.NAME + " Node Has No Children", this, "Contructor");
        }
    }

    public virtual void init(AbeClientInformationInterface abeClientInformation)
    {
        try {
            this.logUtil.putF("Name: " + getName(), this, this.commonStrings.INIT);
            this.logUtil.putF("ClassName: " + className, this, this.commonStrings.INIT);
            this.setInputAutomationModuleInterface(((InputAutomationModuleFactoryInterface) AbeFactory.getInstance().getInstance().getInstance(abeClientInformation, getClassName())));
        } catch (Exception e) {
            this.logUtil.put(commonStrings.EXCEPTION, this, this.commonStrings.INIT, e);
            throw new SystemException();
        }
    }

    // throws Exception
    public virtual Node toDomNode(Document document)
    {
        Node node = document.createElement(InputAutomationModuleData.NAME);
        Node classNameNode = ModDomHelper.createTextNode(document, DynamicObjectData.NAME, this.getClassName());
        node.appendChild(classNameNode);
        return node;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual void setName(string name)
    {
        this.logUtil.putF("Name: " + name, this, "setName");
        this.name = name;
    }

    public virtual string getClassName()
    {
        return this.className;
    }

    public virtual void setClassName(string className)
    {
        this.logUtil.putF("ClassName : " + className, this, "setClassName");
        this.className = className;
    }

    public virtual InputAutomationModuleFactoryInterface getInputAutomationModuleInterface()
    {
        return this.inputAutomationModuleInterface;
    }

    public virtual void setInputAutomationModuleInterface(InputAutomationModuleFactoryInterface inputAutomationModuleInterface)
    {
        this.logUtil.putF("InputAutomationModuleFactoryInterface : " + inputAutomationModuleInterface, this, "setInputAutomationModuleInterface");
        this.inputAutomationModuleInterface = inputAutomationModuleInterface;
        this.setName(this.inputAutomationModuleInterface.getName());
    }

}

