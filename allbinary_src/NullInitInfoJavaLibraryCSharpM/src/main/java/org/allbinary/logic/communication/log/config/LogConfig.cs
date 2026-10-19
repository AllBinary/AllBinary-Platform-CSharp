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
using BooleanUtil = org.allbinary.logic.java.@bool.BooleanUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using Node = org.w3c.dom.Node;

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
    public virtual BasicArrayList getTypeVector()
    {
        BasicArrayList logKeyVector = new BasicArrayListD();
        return logKeyVector;
    }

}

