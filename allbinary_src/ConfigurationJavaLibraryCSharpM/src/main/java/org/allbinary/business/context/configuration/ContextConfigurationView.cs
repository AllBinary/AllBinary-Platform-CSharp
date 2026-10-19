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
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using EmailServerConfigurationData = org.allbinary.logic.communication.smtp.configuration.server.EmailServerConfigurationData;
using EmailServerConfigurationInterface = org.allbinary.logic.communication.smtp.configuration.server.EmailServerConfigurationInterface;
using EmailServerConfigurationView = org.allbinary.logic.communication.smtp.configuration.server.EmailServerConfigurationView;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.business.context.configuration;

public class ContextConfigurationView : DomNodeInterface
{
    private ContextConfigurationInterface contextConfigurationInterface;
    public ContextConfigurationView(Node node)
    {
        NodeList childNodeList = node.getChildNodes();
        this.contextConfigurationInterface = new ContextConfiguration();
        Node emailConfigurationNode = DomSearchHelper.getNode(EmailServerConfigurationData.NAME, childNodeList);
        EmailServerConfigurationView emailServerConfigurationView = new EmailServerConfigurationView(emailConfigurationNode);
        this.contextConfigurationInterface.setEmailServerConfigurationInterface(((EmailServerConfigurationInterface) emailServerConfigurationView.getEmailConfigurationInterface()));
    }

    public ContextConfigurationView(ContextConfigurationInterface contextConfigurationInterface)
    {
        this.contextConfigurationInterface = contextConfigurationInterface;
    }

    public virtual ContextConfigurationInterface getContextConfigurationInterface()
    {
        return this.contextConfigurationInterface;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = document.createElement(ContextConfigurationData.getInstance().NAME);
        EmailServerConfigurationView emailServerConfigurationView = new EmailServerConfigurationView(this.getContextConfigurationInterface().getEmailServerConfigurationInterface());
        node.appendChild(emailServerConfigurationView.toXmlNode(document));
        return node;
    }

}

