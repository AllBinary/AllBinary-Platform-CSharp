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
using EntryData = org.allbinary.business.entry.EntryData;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using PATH_GLOBALS = org.allbinary.globals.PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using LogConfigType = org.allbinary.logic.communication.log.config.type.LogConfigType;
using LogConfigTypeData = org.allbinary.logic.communication.log.config.type.LogConfigTypeData;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;
using LogConfigTypesData = org.allbinary.logic.communication.log.config.type.LogConfigTypesData;
using AbFileLocalInputStream = org.allbinary.logic.io.AbFileLocalInputStream;
using AbFile = org.allbinary.logic.io.file.AbFile;
using BooleanUtil = org.allbinary.logic.java.@bool.BooleanUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.logic.communication.log.config;

public class LogConfig
{
    private bool isEnabled;
    private string name;
    private string description;
    private string path;
    private string fileName;
    public LogConfig(string aName, string aDescription, string aPath, string aFileName)
    {
        this.isEnabled = false;
        this.name = aName;
        this.description = aDescription;
        this.path = aPath;
        this.fileName = aFileName;
    }

    public LogConfig(Node node)
    {
        Node enabledValueNode = DomSearchHelper.getNode(EntryData.getInstance().ENABLE, node.getChildNodes());
        string isEnabledString = DomNodeHelper.getTextNodeValue(enabledValueNode);
        this.isEnabled = BooleanUtil.getInstance().getFromString(isEnabledString);
        LogConfigData logConfigData = LogConfigData.getInstance();
        Node nameValueNode = DomSearchHelper.getNode(logConfigData.NAME, node.getChildNodes());
        this.name = DomNodeHelper.getTextNodeValue(nameValueNode);
        Node descriptionValueNode = DomSearchHelper.getNode(logConfigData.DESCRIPTION, node.getChildNodes());
        this.description = DomNodeHelper.getTextNodeValue(descriptionValueNode);
        Node fileValueNode = DomSearchHelper.getNode(logConfigData.FILE, node.getChildNodes());
        this.fileName = DomNodeHelper.getTextNodeValue(fileValueNode);
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual bool isEnabled()
    {
        return this.isEnabled;
    }

    public virtual void enable()
    {
        this.isEnabled = true;
    }

    public virtual void disable()
    {
        this.isEnabled = false;
    }

    public virtual string getDescription()
    {
        return this.description;
    }

    public virtual string getFileName()
    {
        return this.fileName;
    }

    public virtual void setName(string value)
    {
        this.name = value;
    }

    public virtual void setDescription(string value)
    {
        this.description = value;
    }

    public virtual void setPath(string value)
    {
        this.path = value;
    }

    public virtual void setFileName(string value)
    {
        this.fileName = value;
    }

    // throws Exception
    private Document getDoc()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(URLGLOBALS.getWebappPath());
        stringBuffer.append(PATH_GLOBALS.getInstance().INIT_PATH);
        stringBuffer.append(this.getFileName());
        AbFile file = AbFile.createAbFile(stringBuffer.ToString());
        Document document = DomDocumentHelper.create(new AbFileLocalInputStream(file));
        return document;
    }

    // throws Exception
    public virtual BasicArrayList getTypeVector()
    {
        BasicArrayList logKeyVector = new BasicArrayListD();
        Document document = this.getDoc();
        NodeList logConfigTypesNodeList = document.getElementsByTagName(LogConfigTypesData.getInstance().NAME);
        Node logConfigTypesNode = logConfigTypesNodeList.item(0);
        BasicArrayList logConfigTypeNodeVector = DomSearchHelper.getAllNodes(LogConfigTypeData.getInstance().NAME, logConfigTypesNode.getChildNodes());
        int size = logConfigTypeNodeVector.size();
        for (int i = 0; i < size; i++) {
            Node node = ((Node) logConfigTypeNodeVector.get(i));
            LogConfigType logType = LogConfigTypes.getInstance(node);
            logKeyVector.add(logType);
        }
        return logKeyVector;
    }

}

