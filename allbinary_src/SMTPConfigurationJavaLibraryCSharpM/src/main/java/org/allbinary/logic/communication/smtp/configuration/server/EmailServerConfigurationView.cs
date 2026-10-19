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
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.logic.communication.smtp.configuration.server;

public class EmailServerConfigurationView : DomNodeInterface
{
    private EmailServerConfigurationInterface emailServerConfigurationInterface;
    public EmailServerConfigurationView(Node node)
    {
        NodeList childNodeList = node.getChildNodes();
        string server = DomNodeHelper.getTextNodeValue(EmailServerConfigurationData.SERVER, childNodeList);
        string accountName = DomNodeHelper.getTextNodeValue(EmailServerConfigurationData.ACCOUNT, childNodeList);
        string password = DomNodeHelper.getTextNodeValue(EmailServerConfigurationData.PASSWORD, childNodeList);
        this.emailServerConfigurationInterface = ((EmailServerConfigurationInterface) new EmailServerConfiguration(accountName, password, server));
    }

    public EmailServerConfigurationView(EmailServerConfigurationInterface emailServerConfigurationInterface)
    {
        this.emailServerConfigurationInterface = emailServerConfigurationInterface;
    }

    public virtual EmailServerConfigurationInterface getEmailConfigurationInterface()
    {
        return this.emailServerConfigurationInterface;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        EmailServerConfigurationMapping emailConfigurationMapping = new EmailServerConfigurationMapping(this.emailServerConfigurationInterface);
        HashMap hashMap = emailConfigurationMapping.toHashMap();
        Node node = ModDomHelper.createNodeWithValueNodes(document, EmailServerConfigurationData.NAME, hashMap);
        return node;
    }

}

