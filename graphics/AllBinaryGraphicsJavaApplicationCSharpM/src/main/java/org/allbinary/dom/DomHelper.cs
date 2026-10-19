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
//using ByteArrayOutputStream = java.io.ByteArrayOutputStream;
//using File = java.io.File;
//using DocumentBuilder = javax.xml.parsers.DocumentBuilder;
//using DocumentBuilderFactory = javax.xml.parsers.DocumentBuilderFactory;
//using Transformer = javax.xml.transform.Transformer;
//using TransformerFactory = javax.xml.transform.TransformerFactory;
//using DOMSource = javax.xml.transform.dom.DOMSource;
//using StreamResult = javax.xml.transform.stream.StreamResult;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.dom;

public class DomHelper
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly DomHelper instance = new DomHelper();
    public static DomHelper getInstance()
    {
        return DomHelper.instance;
    }

    private DomHelper()
    {
    }

    public virtual Document createDocument()
    {
        try {
            DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
            DocumentBuilder builder = factory.newDocumentBuilder();
            Document document = builder.newDocument();
            return document;
        } catch (Exception e) {
            return null;
        }
    }

    // throws Exception
    public virtual Document createDocument(File xmlFile)
    {
        try {
            DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
            DocumentBuilder builder = factory.newDocumentBuilder();
            Document document = builder.parse(xmlFile);
            return document;
        } catch (Exception e) {
            throw e;
        }
    }

    // throws Exception
    public virtual string toString(Document document)
    {
        try {
            DOMSource domSource = new DOMSource(document);
            System.IO.MemoryStream byteArrayOutputStream = new System.IO.MemoryStream();
            StreamResult streamResult = new StreamResult(byteArrayOutputStream);
            TransformerFactory copyTransformerFactory = TransformerFactory.newInstance();
            Transformer copyTransformer = copyTransformerFactory.newTransformer();
            copyTransformer.transform(domSource, streamResult);
            return System.Text.Encoding.UTF8.GetString(byteArrayOutputStream.ToArray());
        } catch (Exception e) {
            throw e;
        }
    }

    // throws Exception
    public virtual void save(File file, Document document)
    {
        try {
            TransformerFactory copyTransformerFactory = TransformerFactory.newInstance();
            Transformer copyTransformer = copyTransformerFactory.newTransformer();
            DOMSource domSource = new DOMSource(document);
            file.createNewFile();
            StreamResult streamResult = new StreamResult(file);
            copyTransformer.transform(domSource, streamResult);
        } catch (Exception e) {
            throw e;
        }
    }

    // throws Exception
    public virtual NodeList getChildNodeList(string nodeName, NodeList nodeList)
    {
        int numberOfNodes = nodeList.getLength();
        for (int index = 0; index < numberOfNodes; index++) {
            Node node = nodeList.item(index);
            if (node.getNodeName().compareTo(nodeName) == 0) {
                return node.getChildNodes();
            }
        }
        throw new Exception(nodeName + " Node Not Found");
    }

    // throws Exception
    public virtual BasicArrayList getChildrenWithoutTextNodes(string nodeName, NodeList nodeList)
    {
        BasicArrayList list = new BasicArrayListD();
        NodeList childNodeList = this.getChildNodeList(nodeName, nodeList);
        int numberOfChildren = childNodeList.getLength();
        for (int index = 0; index < numberOfChildren; index++) {
            Node node = childNodeList.item(index);
            if (node.getNodeType() != Node.TEXT_NODE) {
                list.add(node);
            }
        }
        return list;
    }

    // throws Exception
    public virtual BasicArrayList getWithoutTextNodes(NodeList nodeList)
    {
        BasicArrayList list = new BasicArrayListD();
        int numberOfChildren = nodeList.getLength();
        for (int index = 0; index < numberOfChildren; index++) {
            Node node = nodeList.item(index);
            if (node.getNodeType() != Node.TEXT_NODE) {
                list.add(node);
            }
        }
        return list;
    }

    // throws Exception
    public virtual Node searchNodeList(string nodeName, NodeList nodeList)
    {
        int numberOfNodes = nodeList.getLength();
        for (int index = 0; index < numberOfNodes; index++) {
            Node node = nodeList.item(index);
            this.logUtil.putF("NodeName: " + node.getNodeName(), this, "searchNodeList");
            if (node.getNodeName().compareTo(nodeName) == 0) {
                return node;
            }
        }
        throw new Exception(nodeName + " Node Not Found in search");
    }

    // throws Exception
    public virtual Node searchNodeList(string nodeName, BasicArrayList nodeList)
    {
        int numberOfNodes = nodeList.size();
        for (int index = 0; index < numberOfNodes; index++) {
            Node node = ((Node) nodeList.get(index));
            this.logUtil.putF("NodeName: " + node.getNodeName(), this, "searchNodeList");
            if (node.getNodeName().compareTo(nodeName) == 0) {
                return node;
            }
        }
        throw new Exception(nodeName + " Node Not Found in search");
    }

}

