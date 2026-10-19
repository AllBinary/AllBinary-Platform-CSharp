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
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.logic.communication.smtp.configuration.user.@event;

public class UserEmailEventConfigurationView : DomNodeInterface
{
    private UserEmailEventConfigurationInterface userEmailEventConfigurationInterface = null;
    public UserEmailEventConfigurationView(Node node)
    {
        NodeList childNodeList = node.getChildNodes();
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        string name = DomNodeHelper.getTextNodeValue(UserEmailEventConfigurationData.NAME, childNodeList);
        hashMap.put(UserEmailEventConfigurationData.NAME, name);
        string eventListenerClassPath = DomNodeHelper.getTextNodeValue(UserEmailEventConfigurationData.LISTENER_CLASSPATH, childNodeList);
        hashMap.put(UserEmailEventConfigurationData.LISTENER_CLASSPATH, eventListenerClassPath);
        this.setUserEmailEventConfigurationInterface(((UserEmailEventConfigurationInterface) new UserEmailEventConfiguration(hashMap)));
    }

    public UserEmailEventConfigurationView(UserEmailEventConfigurationInterface userEmailEventConfigurationInterface)
    {
        this.setUserEmailEventConfigurationInterface(userEmailEventConfigurationInterface);
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        UserEmailEventConfigurationMapping userEmailEventConfigurationMapping = new UserEmailEventConfigurationMapping(this.getUserEmailEventConfigurationInterface());
        HashMap hashMap = userEmailEventConfigurationMapping.toHashMap();
        Node node = ModDomHelper.createNameValueNodes(document, UserEmailEventConfigurationData.NAME, hashMap);
        return node;
    }

    public virtual UserEmailEventConfigurationInterface getUserEmailEventConfigurationInterface()
    {
        return this.userEmailEventConfigurationInterface;
    }

    public virtual void setUserEmailEventConfigurationInterface(UserEmailEventConfigurationInterface userEmailEventConfigurationInterface)
    {
        this.userEmailEventConfigurationInterface = userEmailEventConfigurationInterface;
    }

}

