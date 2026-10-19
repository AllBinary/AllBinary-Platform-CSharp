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
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using UserEmailEventsConfigurationData = org.allbinary.logic.communication.smtp.configuration.user.@event.UserEmailEventsConfigurationData;
using UserEmailEventsConfigurationInterface = org.allbinary.logic.communication.smtp.configuration.user.@event.UserEmailEventsConfigurationInterface;
using UserEmailEventsConfigurationView = org.allbinary.logic.communication.smtp.configuration.user.@event.UserEmailEventsConfigurationView;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.logic.communication.smtp.configuration.user;

public class UserEmailConfigurationView : DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private UserEmailConfigurationInterface userEmailConfigurationInterface;
    public UserEmailConfigurationView(Node node)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            this.logUtil.putF(this.commonStrings.CONSTRUCTOR, this, this.commonStrings.CONSTRUCTOR);
        }
        this.userEmailConfigurationInterface = ((UserEmailConfigurationInterface) new UserEmailConfiguration());
        NodeList childNodeList = node.getChildNodes();
        Node userEmailEventsConfigurationNode = DomSearchHelper.getNodeNoThrow(UserEmailEventsConfigurationData.NAME, childNodeList);
        UserEmailEventsConfigurationView userEmailEventsConfigurationView = new UserEmailEventsConfigurationView(userEmailEventsConfigurationNode);
        this.userEmailConfigurationInterface.setUserEmailEventsConfigurationInterface(userEmailEventsConfigurationView.getUserEmailEventsConfigurationInterface());
    }

    public UserEmailConfigurationView(UserEmailConfigurationInterface userEmailConfigurationInterface)
    {
        this.userEmailConfigurationInterface = userEmailConfigurationInterface;
    }

    public virtual UserEmailConfigurationInterface getEmailConfigurationInterface()
    {
        return this.userEmailConfigurationInterface;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        UserEmailConfigurationMapping emailConfigurationMapping = new UserEmailConfigurationMapping(this.userEmailConfigurationInterface);
        HashMap hashMap = emailConfigurationMapping.toHashMap();
        Node node = ModDomHelper.createNameValueNodes(document, UserEmailConfigurationData.NAME, hashMap);
        UserEmailConfigurationInterface userEmailConfigurationInterface = this.getEmailConfigurationInterface();
        UserEmailEventsConfigurationInterface userEmailEventsConfigurationInterface = userEmailConfigurationInterface.getUserEmailEventsConfigurationInterface();
        UserEmailEventsConfigurationView userEmailEventsConfigurationView = new UserEmailEventsConfigurationView(userEmailEventsConfigurationInterface);
        node.appendChild(userEmailEventsConfigurationView.toXmlNode(document));
        return node;
    }

}

