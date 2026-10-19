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
using TimeCreatedView = org.allbinary.business.time.created.TimeCreatedView;
using TimeLastModifiedView = org.allbinary.business.time.modified.TimeLastModifiedView;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using UserEmailConfigurationData = org.allbinary.logic.communication.smtp.configuration.user.UserEmailConfigurationData;
using UserEmailConfigurationInterface = org.allbinary.logic.communication.smtp.configuration.user.UserEmailConfigurationInterface;
using UserEmailConfigurationView = org.allbinary.logic.communication.smtp.configuration.user.UserEmailConfigurationView;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.business.user.modules.configuration;

public class UserConfigurationView : DomNodeInterface
{
    private UserConfigurationInterface userConfigurationInterface;
    public UserConfigurationView(Node node)
    {
        this.userConfigurationInterface = ((UserConfigurationInterface) new UserConfiguration());
        NodeList childNodeList = node.getChildNodes();
        Node emailConfigurationNode = DomSearchHelper.getNode(UserEmailConfigurationData.NAME, childNodeList);
        UserEmailConfigurationView userEmailConfigurationView = new UserEmailConfigurationView(emailConfigurationNode);
        UserEmailConfigurationInterface userEmailConfigurationInterface = ((UserEmailConfigurationInterface) userEmailConfigurationView.getEmailConfigurationInterface());
        this.userConfigurationInterface.setUserEmailConfigurationInterface(userEmailConfigurationInterface);
        Node timeCreatedNode = DomSearchHelper.getNode(EntryData.getInstance().TIMECREATED, childNodeList);
        TimeCreatedView timeCreatedView = new TimeCreatedView(timeCreatedNode);
        this.userConfigurationInterface.setTimeCreated(timeCreatedView.getTimeCreated());
        Node timeLastModifiedNode = DomSearchHelper.getNode(EntryData.getInstance().LASTMODIFIED, childNodeList);
        TimeLastModifiedView timeLastModifiedView = new TimeLastModifiedView(timeLastModifiedNode);
        this.userConfigurationInterface.setTimeLastModified(timeLastModifiedView.getTimeLastModified());
    }

    public UserConfigurationView(UserConfigurationInterface userConfigurationInterface)
    {
        this.userConfigurationInterface = userConfigurationInterface;
    }

    public virtual UserConfigurationInterface getUserConfigurationInterface()
    {
        return this.userConfigurationInterface;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = document.createElement(UserConfigurationData.NAME);
        UserEmailConfigurationView userEmailConfigurationView = new UserEmailConfigurationView(this.userConfigurationInterface.getUserEmailConfigurationInterface());
        node.appendChild(userEmailConfigurationView.toXmlNode(document));
        TimeCreatedView timeCreatedView = new TimeCreatedView(this.userConfigurationInterface.getTimeCreated());
        node.appendChild(timeCreatedView.toXmlNode(document));
        TimeLastModifiedView timeLastModifiedView = new TimeLastModifiedView(this.userConfigurationInterface.getTimeLastModified());
        node.appendChild(timeLastModifiedView.toXmlNode(document));
        return node;
    }

}

