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
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using GenericProfileActionScript = org.allbinary.input.automation.module.generic.configuration.profile.actions.script.GenericProfileActionScript;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.input.automation.module.generic.configuration.profile.actions;

public class GenericProfileAction : DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string name;
    private GenericProfileActionScript genericProfileActionScript = null;
    private GenericProfileActionJPanel genericProfileActionJPanel = null;
    public GenericProfileAction(GenericProfileActionJPanel genericProfileActionJPanel, Node node)
    {
        Node actionNameNode = DomSearchHelper.getNode(GenericProfileActionData.NAME, node.getChildNodes());
        if (actionNameNode != null) {
            this.name = DomNodeHelper.getTextNodeValue(actionNameNode);
        } else {
            throw new Exception("Profile Action Name Node Null");
        }
        this.setGenericProfileActionScript(new GenericProfileActionScript(this.genericProfileActionJPanel, node));
    }

    public GenericProfileAction(string name)
    {
        this.name = name;
        this.setGenericProfileActionScript(new GenericProfileActionScript(this.genericProfileActionJPanel));
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual void setName(string name)
    {
        this.name = name;
    }

    public virtual HashMap<object, object> toHashMap()
    {
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(GenericProfileActionData.NAME, this.name);
        this.logUtil.putF("HashMap: " + hashMap.ToString(), this, "toHashMap()");
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = ModDomHelper.createNodeWithValueNodes(document, GenericProfileActionData.NAME, this.toHashMap());
        node.appendChild(getGenericProfileActionScript().toXmlNode(document));
        return node;
    }

    public virtual GenericProfileActionScript getGenericProfileActionScript()
    {
        return this.genericProfileActionScript;
    }

    public virtual void setGenericProfileActionScript(GenericProfileActionScript genericProfileActionScript)
    {
        this.genericProfileActionScript = genericProfileActionScript;
    }

}

