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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using DefaultMutableTreeNode = javax.swing.tree.DefaultMutableTreeNode;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using ProfileActionScriptNodeInterface = org.allbinary.input.automation.actions.script.ProfileActionScriptNodeInterface;
using ProfileActionScriptConditionFactory = org.allbinary.input.automation.actions.script.condition.ProfileActionScriptConditionFactory;
using ProfileActionScriptConditionInterface = org.allbinary.input.automation.actions.script.condition.ProfileActionScriptConditionInterface;
using GenericProfileActionData = org.allbinary.input.automation.module.generic.configuration.profile.actions.GenericProfileActionData;
using GenericProfileActionJPanel = org.allbinary.input.automation.module.generic.configuration.profile.actions.GenericProfileActionJPanel;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.input.automation.module.generic.configuration.profile.actions.script;

public class GenericProfileActionScript : DefaultMutableTreeNode, ProfileActionScriptNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private GenericProfileActionJPanel genericProfileActionJPanel;
    private BasicArrayList profileActionConditionInterfaceVector = null;
    private static readonly string NAME = "Root";
    public GenericProfileActionScript(GenericProfileActionJPanel genericProfileActionJPanel, Node node) : base(NAME)
    {
        // base(NAME) is called from the constructor declaration
        this.genericProfileActionJPanel = genericProfileActionJPanel;
        this.setProfileActionConditionInterfaceVector(new BasicArrayListD());
        Node actionScriptNode = DomSearchHelper.getNode(GenericProfileActionData.SCRIPT, node.getChildNodes());
        if (actionScriptNode != null) {
            NodeList nodeList = actionScriptNode.getChildNodes();
            for (int index = 0; index < nodeList.getLength(); index++) {
                Node actionConditionNode = nodeList.item(index);
                if (actionConditionNode.getNodeType() == Node.ELEMENT_NODE) {
                    this.addCondition(ProfileActionScriptConditionFactory.getInstance(actionConditionNode));
                }
            }
        } else {
            throw new Exception("Profile Action Script Node Null");
        }
    }

    public GenericProfileActionScript(GenericProfileActionJPanel genericProfileActionJPanel)
    {
        this.genericProfileActionJPanel = genericProfileActionJPanel;
        this.setProfileActionConditionInterfaceVector(new BasicArrayListD());
    }

    public virtual void addCondition(ProfileActionScriptNodeInterface profileActionScriptNodeInterface)
    {
        this.logUtil.putF(this.commonStrings.START, this, "addCondition");
        this.getProfileActionConditionInterfaceVector().add(profileActionScriptNodeInterface);
        this.add(profileActionScriptNodeInterface);
    }

    public virtual void removeCondition(ProfileActionScriptNodeInterface profileActionScriptNodeInterface)
    {
        this.logUtil.putF(this.commonStrings.START, this, "removeCondition");
        this.getProfileActionConditionInterfaceVector().remove(profileActionScriptNodeInterface);
        this.remove(profileActionScriptNodeInterface);
    }

    public virtual HashMap<object, object> toHashMap()
    {
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        this.logUtil.putF("HashMap: " + hashMap.ToString(), this, "toHashMap()");
        return hashMap;
    }

    public virtual BasicArrayList getProfileActionConditionInterfaceVector()
    {
        return this.profileActionConditionInterfaceVector;
    }

    public virtual void setProfileActionConditionInterfaceVector(BasicArrayList profileActionConditionInterfaceVector)
    {
        this.profileActionConditionInterfaceVector = profileActionConditionInterfaceVector;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = document.createElement(GenericProfileActionData.SCRIPT);
        BasicArrayList vector = this.getProfileActionConditionInterfaceVector();
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            ProfileActionScriptConditionInterface profileActionConditionInterface = ((ProfileActionScriptConditionInterface) vector.get(index));
            node.appendChild(profileActionConditionInterface.toXmlNode(document));
        }
        return node;
    }

}

