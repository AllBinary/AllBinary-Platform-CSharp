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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.data.tree.dom;

public class DomNodeHelper
{
    private DomNodeHelper()
    {
    }

    public static Node getFirstChildElement(Node parentNode)
    {
        Node node = parentNode.getFirstChild();
        if (node != null && node.getNodeType() != Node.ELEMENT_NODE) {
            NodeList nodeList = parentNode.getChildNodes();
            for (int index = 0; index < nodeList.getLength(); index++) {
                node = nodeList.item(index);
                if (node.getNodeType() == 1) {
                    break;
                }
            }
        }
        return node;
    }

    public static string getTextNodeValue(Node node)
    {
        Node nodeTextNode = node.getFirstChild();
        if (nodeTextNode != null) {
            return nodeTextNode.getNodeValue();
        } else {
            return StringUtil.getInstance().EMPTY_STRING;
        }
    }

    // throws Exception
    public static string getTextNodeValue(string nodeName, NodeList nodeList)
    {
        Node node = DomSearchHelper.getNode(nodeName, nodeList);
        return DomNodeHelper.getTextNodeValue(node);
    }

    public static string getTextNodesValue(Node node)
    {
        StringMaker stringBuffer = new StringMaker();
        NodeList nodeList = node.getChildNodes();
        for (int index = 0; index < nodeList.getLength(); index++) {
            Node nodeTextNode = nodeList.item(index);
            if (nodeTextNode.getNodeType() == Node.TEXT_NODE) {
                if (nodeTextNode != null) {
                    stringBuffer.append(nodeTextNode.getNodeValue());
                }
            }
        }
        return stringBuffer.ToString();
    }

}

