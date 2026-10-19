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
//using Set = java.util.Set;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.logic.communication.smtp.configuration.user.@event;

public class UserEmailEventsConfigurationView : DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private UserEmailEventsConfigurationInterface userEmailEventsConfigurationInterface;
    public UserEmailEventsConfigurationView(Node node)
    {
        this.userEmailEventsConfigurationInterface = ((UserEmailEventsConfigurationInterface) new UserEmailEventsConfiguration());
        NodeList childNodeList = node.getChildNodes();
        BasicArrayList emailEventConfigurationNodeVector = DomSearchHelper.getAllNodesNoThrow(UserEmailEventConfigurationData.NAME, childNodeList);
        int size = emailEventConfigurationNodeVector.size();
        for (int index = 0; index < size; index++) {
            Node userEmailConfigurationNode = ((Node) emailEventConfigurationNodeVector.get(index));
            UserEmailEventConfigurationView userEmailEventConfigurationView = new UserEmailEventConfigurationView(userEmailConfigurationNode);
            this.userEmailEventsConfigurationInterface.addUserEmailEventConfiguration(userEmailEventConfigurationView.getUserEmailEventConfigurationInterface());
        }
    }

    public UserEmailEventsConfigurationView(UserEmailEventsConfigurationInterface userEmailEventsConfigurationInterface)
    {
        this.userEmailEventsConfigurationInterface = userEmailEventsConfigurationInterface;
    }

    public virtual UserEmailEventsConfigurationInterface getUserEmailEventsConfigurationInterface()
    {
        return this.userEmailEventsConfigurationInterface;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        UserEmailEventsConfigurationMapping userEmailConfigurationMapping = new UserEmailEventsConfigurationMapping(this.userEmailEventsConfigurationInterface);
        Node node = document.createElement(UserEmailEventsConfigurationData.NAME);
        HashMap emailEventHashMap = this.getUserEmailEventsConfigurationInterface().getEventConfigurationHashMap();
        Set set = emailEventHashMap.keySet();
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            this.logUtil.putF("Number Of Email Events Specified in file: " + set.size(), this, this.commonStrings.CONSTRUCTOR);
        }
        object[] eventNameArray = set.toArray();
        int size = eventNameArray.Length;
        for (int index = 0; index < size; index++) {
            string eventName = ((string) eventNameArray[index]);
            UserEmailEventConfigurationInterface userEmailEventsConfigurationInterface = ((UserEmailEventConfigurationInterface) emailEventHashMap.get(eventName));
            UserEmailEventConfigurationView userEmailEventConfigurationView = new UserEmailEventConfigurationView(userEmailEventsConfigurationInterface);
            node.appendChild(userEmailEventConfigurationView.toXmlNode(document));
        }
        return node;
    }

}

