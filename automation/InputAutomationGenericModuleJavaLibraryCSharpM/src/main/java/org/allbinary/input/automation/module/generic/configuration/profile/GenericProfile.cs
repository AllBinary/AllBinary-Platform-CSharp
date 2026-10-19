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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using GenericProfileActions = org.allbinary.input.automation.module.generic.configuration.profile.actions.GenericProfileActions;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.input.automation.module.generic.configuration.profile;

public class GenericProfile
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string name = null;
    private BasicArrayList vector;
    private GenericProfileActions genericProfileActions = null;
    public GenericProfile(Node node)
    {
        this.setName(DomNodeHelper.getTextNodeValue(node));
        this.vector = new BasicArrayListD();
        NodeList nodeList = node.getChildNodes();
        this.logUtil.putF("Name: " + this.getName() + " Child Nodes: " + nodeList.getLength(), this, "Contructor");
        for (int index = 0; index < nodeList.getLength(); index++) {
            Node profileNode = nodeList.item(index);
            if (profileNode.getNodeName().compareTo(GenericProfileDataWorkerData.NAME) == 0) {
                GenericProfileDataWorkerType genericProfileDataWorkerType = GenericProfileDataWorkerType.getInstance(profileNode);
                this.logUtil.putF("Adding GenericProfileDataWorkerType: " + genericProfileDataWorkerType.ToString(), this, "Contructor");
                this.vector.add(genericProfileDataWorkerType);
            }
        }
    }

    public GenericProfile(string name)
    {
        this.setName(name);
        this.vector = new BasicArrayListD();
    }

    public virtual BasicArrayList getGenericProfileDataWorkerTypeVector()
    {
        return this.vector;
    }

    public virtual void add(GenericProfileDataWorkerType genericProfileDataWorkerType)
    {
        if (!this.vector.contains(genericProfileDataWorkerType)) {
            this.vector.add(genericProfileDataWorkerType);
        }
    }

    public virtual void remove(GenericProfileDataWorkerType genericProfileDataWorkerType)
    {
        this.vector.remove(genericProfileDataWorkerType);
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = ModDomHelper.createTextNode(document, GenericProfileData.NAME, this.name);
        int size = this.vector.size();
        for (int index = 0; index < size; index++) {
            GenericProfileDataWorkerType genericProfileDataWorkerType = ((GenericProfileDataWorkerType) this.vector.get(index));
            node.appendChild(genericProfileDataWorkerType.toXmlNode(document));
        }
        return node;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual void setName(string name)
    {
        this.name = name;
    }

    public virtual GenericProfileActions getGenericProfileActions()
    {
        return this.genericProfileActions;
    }

    public virtual void setGenericProfileActions(GenericProfileActions genericProfileActions)
    {
        this.genericProfileActions = genericProfileActions;
    }

}

