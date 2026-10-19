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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.data.tree.dom;

public class DomSearchHelper
{
    private DomSearchHelper()
    {
    }

    public static Node getNodeNoThrow(string nodeName, NodeList nodeList)
    {
        int numberOfNodes = nodeList.getLength();
        for (int index = 0; index < numberOfNodes; index++) {
            Node node = nodeList.item(index);
            if (node.getNodeName().compareTo(nodeName) == 0) {
                return node;
            }
        }
        return null;
    }

    // throws Exception
    public static Node getNode(string nodeName, NodeList nodeList)
    {
        Node node = DomSearchHelper.getNodeNoThrow(nodeName, nodeList);
        if (node != null) {
            return node;
        } else {
            throw new Exception(nodeName + " Node Not Found in search");
        }
    }

    // throws Exception
    public static NodeList getChildNodeList(string nodeName, NodeList nodeList)
    {
        Node node = DomSearchHelper.getNode(nodeName, nodeList);
        return node.getChildNodes();
    }

    // throws Exception
    public static BasicArrayList getAllNodes(string nodeName, NodeList nodeList)
    {
        BasicArrayList vector = DomSearchHelper.getAllNodesNoThrow(nodeName, nodeList);
        if (vector == null) {
            throw new Exception(nodeName + " Node Not Found in search");
        } else {
            return vector;
        }
    }

    public static BasicArrayList getAllNodesNoThrow(string nodeName, NodeList nodeList)
    {
        BasicArrayList nodeVector = new BasicArrayListD();
        int numberOfNodes = nodeList.getLength();
        for (int index = 0; index < numberOfNodes; index++) {
            Node node = nodeList.item(index);
            if (node.getNodeName().compareTo(nodeName) == 0) {
                nodeVector.add(node);
            }
        }
        return nodeVector;
    }

}

