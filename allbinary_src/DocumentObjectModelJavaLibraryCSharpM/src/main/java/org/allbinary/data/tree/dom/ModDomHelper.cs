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
using ClassUtil = org.allbinary.logic.java.anyType.clazz.ClassUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.data.tree.dom;

public class ModDomHelper
{
    private ModDomHelper()
    {
    }

    // throws Exception
    public static Node createTextNode(Document document, string name, string text)
    {
        Node newValueNode = document.createElement(name);
        Node newValueTextNode = document.createTextNode(text);
        newValueNode.appendChild(newValueTextNode);
        return newValueNode;
    }

    // throws Exception
    public static Node createValueNode(Document document, string text)
    {
        return ModDomHelper.createTextNode(document, DomData.VALUE, text);
    }

    // throws Exception
    public static Node createNameNode(Document document, string text)
    {
        return ModDomHelper.createTextNode(document, DomData.NAME, text);
    }

    // throws Exception
    public static Node createIndexNode(Document document, int index)
    {
        return ModDomHelper.createTextNode(document, DomData.INDEX, index.ToString());
    }

    // throws Exception
    public static Node createNameValueNodes(Document document, string elementName, string nameText, string valueText)
    {
        Node newNode = document.createElement(elementName);
        newNode.appendChild(ModDomHelper.createNameNode(document, nameText));
        newNode.appendChild(ModDomHelper.createValueNode(document, valueText));
        return newNode;
    }

    // throws Exception
    public static Node createNameValueNodes(Document document, string elementNameAndNameText, string valueText)
    {
        Node newNode = ModDomHelper.createNameValueNodes(document, elementNameAndNameText, elementNameAndNameText, valueText);
        return newNode;
    }

    // throws Exception
    public static Node createNameValueIndexNodes(Document document, string elementNameAndNameText, int index, string valueText)
    {
        Node newNode = ModDomHelper.createNameValueNodes(document, elementNameAndNameText, valueText);
        newNode.appendChild(ModDomHelper.createIndexNode(document, index));
        return newNode;
    }

    // throws Exception
    public static Node createNameValueNodes(Document document, string rootNode, HashMap hashMap)
    {
        Node node = document.createElement(rootNode);
        return ModDomHelper.createNameValueNodes(document, node, hashMap);
    }

    // throws Exception
    public static Node createNameValueNodes(Document document, Node node, HashMap hashMap)
    {
        StringUtil stringUtil = StringUtil.getInstance();
        Set keySet = hashMap.keySet();
        object[] keyArray = keySet.toArray();
        int size = keyArray.Length;
        for (int i = 0; i < size; i++) {
            object objectKey = keyArray[i];
            string name = ((string) objectKey);
            object anyType = ((object) hashMap.get(objectKey));
            if (anyType == null) {
                string value = stringUtil.EMPTY_STRING;
                node.appendChild(ModDomHelper.createNameValueNodes(document, name, value));
            } else if (anyType is string) {
                string value = stringUtil.getNonNull(((string) anyType));
                node.appendChild(ModDomHelper.createNameValueNodes(document, name, value));
            } else if (anyType is HashMap) {
                node.appendChild(ModDomHelper.createNameValueNodes(document, name, hashMap));
            } else {
                throw new Exception("HashMap value is the wrong instance and is: " + ClassUtil.viewAll(anyType, CommonSeps.getInstance().NEW_LINE));
            }
        }
        return node;
    }

    // throws Exception
    public static Node createNameValueNodes(Document document, string rootNodeName, string duplicateNodeName, BasicArrayList valueVector)
    {
        StringUtil stringUtil = StringUtil.getInstance();
        Node node = document.createElement(rootNodeName);
        int size = valueVector.size();
        for (int i = 0; i < size; i++) {
            string value = stringUtil.getNonNull(((string) valueVector.get(i)));
            node.appendChild(ModDomHelper.createNameValueNodes(document, duplicateNodeName, value));
        }
        return node;
    }

    // throws Exception
    public static Node createNameValueIndexNodes(Document document, string rootNodeName, string duplicateNodeName, BasicArrayList valueVector)
    {
        StringUtil stringUtil = StringUtil.getInstance();
        Node node = document.createElement(rootNodeName);
        int size = valueVector.size();
        for (int index = 0; index < size; index++) {
            string value = stringUtil.getNonNull(((string) valueVector.get(index)));
            node.appendChild(ModDomHelper.createNameValueIndexNodes(document, duplicateNodeName, index, value));
        }
        return node;
    }

    // throws Exception
    public static Node createNodeWithValueNodes(Document document, string rootNode, HashMap hashMap)
    {
        Node node = document.createElement(rootNode);
        return ModDomHelper.createNodeWithValueNodes(document, node, hashMap);
    }

    // throws Exception
    public static Node createNodeWithValueNodes(Document document, Node node, HashMap hashMap)
    {
        StringUtil stringUtil = StringUtil.getInstance();
        Set keySet = hashMap.keySet();
        object[] keyArray = keySet.toArray();
        int size = keyArray.Length;
        for (int i = 0; i < size; i++) {
            string name = ((string) keyArray[i]);
            object anyType = ((object) hashMap.get(name));
            string value = stringUtil.getNonNull(((string) anyType));
            node.appendChild(ModDomHelper.createTextNode(document, name, value));
        }
        return node;
    }

}

