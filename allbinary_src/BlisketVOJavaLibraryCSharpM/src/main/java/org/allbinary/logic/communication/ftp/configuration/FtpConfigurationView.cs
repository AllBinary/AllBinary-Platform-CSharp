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

namespace org.allbinary.logic.communication.ftp.configuration;

public class FtpConfigurationView : DomNodeInterface
{
    private FtpConfigurationInterface ftpConfigurationInterface = null;
    public FtpConfigurationView(Node node)
    {
        this.setFtpConfigurationInterface(((FtpConfigurationInterface) new FtpConfiguration()));
        NodeList chileNodeList = node.getChildNodes();
        string server = DomNodeHelper.getTextNodeValue(FtpConfigurationData.SERVER, chileNodeList);
        this.getFtpConfigurationInterface().setServer(server);
        string userName = DomNodeHelper.getTextNodeValue(FtpConfigurationData.USERNAME, chileNodeList);
        this.getFtpConfigurationInterface().setUserName(userName);
        string password = DomNodeHelper.getTextNodeValue(FtpConfigurationData.PASSWORD, chileNodeList);
        this.getFtpConfigurationInterface().setPassword(password);
        string path = DomNodeHelper.getTextNodeValue(FtpConfigurationData.PATH, chileNodeList);
        this.getFtpConfigurationInterface().setPath(path);
    }

    public FtpConfigurationView(FtpConfigurationInterface ftpConfigurationInterface)
    {
        this.setFtpConfigurationInterface(ftpConfigurationInterface);
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        FtpConfigurationMapping ftpConfigurationMapping = new FtpConfigurationMapping(this.getFtpConfigurationInterface());
        HashMap hashMap = ftpConfigurationMapping.toHashMap();
        Node node = ModDomHelper.createNameValueNodes(document, FtpConfigurationData.NAME, hashMap);
        return node;
    }

    public virtual FtpConfigurationInterface getFtpConfigurationInterface()
    {
        return this.ftpConfigurationInterface;
    }

    public virtual void setFtpConfigurationInterface(FtpConfigurationInterface ftpConfigurationInterface)
    {
        this.ftpConfigurationInterface = ftpConfigurationInterface;
    }

}

