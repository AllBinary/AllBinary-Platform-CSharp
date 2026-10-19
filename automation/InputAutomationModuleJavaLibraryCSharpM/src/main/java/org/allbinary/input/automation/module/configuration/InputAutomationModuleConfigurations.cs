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
//using File = java.io.File;
//using FileInputStream = java.io.FileInputStream;
using java.util;
//using java.util;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using InputAutomationModuleData = org.allbinary.input.automation.module.InputAutomationModuleData;
using NewInputAutomationModulesData = org.allbinary.input.automation.module.NewInputAutomationModulesData;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.input.automation.module.configuration;

public class InputAutomationModuleConfigurations
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private HashMap hashMap = null;
    public InputAutomationModuleConfigurations(AbeClientInformationInterface abeClientInformation, File file)
    {
        this.setHashMap(new HashMap());
        sbyte[] bytes = new sbyte[100000];
        FileInputStream idFile = new FileInputStream(file);
        int length = idFile.read(bytes);
        string data = System.Text.Encoding.UTF8.GetString((byte[]) (Array) bytes);
        int endIndex = data.LastIndexOf('>');
        Document document = DomDocumentHelper.create(data.Substring(0, (endIndex + 1) - (0)));
        NodeList nodeList = document.getElementsByTagName(NewInputAutomationModulesData.NAME);
        if (nodeList.getLength() > 0) {
            NodeList nameNodeList = document.getElementsByTagName(InputAutomationModuleData.NAME);
            this.logUtil.putF("Number Of Module(s) Specified: " + nameNodeList.getLength(), this, "Contructor");
            for (int index = 0; index < nameNodeList.getLength(); index++) {
                Node node = nameNodeList.item(index);
                this.add(new InputAutomationModuleConfiguration(abeClientInformation, node));
            }
        }
    }

    public InputAutomationModuleConfigurations(AbeClientInformationInterface abeClientInformation, Document document)
    {
        this.setHashMap(new HashMap());
        NodeList nameNodeList = document.getElementsByTagName(InputAutomationModuleData.NAME);
        this.logUtil.putF("Number Of Module(s) Specified: " + nameNodeList.getLength(), this, "Contructor");
        for (int index = 0; index < nameNodeList.getLength(); index++) {
            Node node = nameNodeList.item(index);
            this.add(new InputAutomationModuleConfiguration(abeClientInformation, node));
        }
    }

    public InputAutomationModuleConfigurations(List<InputAutomationModuleConfiguration> inputAutomationModuleConfigurationList)
    {
        this.setHashMap(new HashMap());
        int size = inputAutomationModuleConfigurationList.size();
        InputAutomationModuleConfiguration inputAutomationModuleConfiguration = null;
        for (int index = 0; index < size; index++) {
            inputAutomationModuleConfiguration = inputAutomationModuleConfigurationList.get(index);
            this.add(inputAutomationModuleConfiguration);
        }
    }

    public InputAutomationModuleConfigurations()
    {
        this.setHashMap(new HashMap());
    }

    public virtual void add(InputAutomationModuleConfiguration inputAutomationModuleConfiguration)
    {
        this.getHashMap().put(inputAutomationModuleConfiguration.getClassName(), inputAutomationModuleConfiguration);
    }

    public virtual void remove(InputAutomationModuleConfiguration inputAutomationModuleConfiguration)
    {
        this.getHashMap().remove(inputAutomationModuleConfiguration.getClassName());
    }

    public virtual HashMap getHashMap()
    {
        return this.hashMap;
    }

    public virtual void setHashMap(HashMap hashMap)
    {
        this.hashMap = hashMap;
    }

}

