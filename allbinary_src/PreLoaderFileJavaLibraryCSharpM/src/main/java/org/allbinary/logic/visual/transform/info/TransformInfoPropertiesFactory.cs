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
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using Attr = org.w3c.dom.Attr;
using NamedNodeMap = org.w3c.dom.NamedNodeMap;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.logic.visual.transform.info;

public class TransformInfoPropertiesFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly TransformInfoPropertiesFactory instance = new TransformInfoPropertiesFactory();
    public static TransformInfoPropertiesFactory getInstance()
    {
        return TransformInfoPropertiesFactory.instance;
    }

    private TransformInfoPropertiesFactory()
    {
    }

    // throws Exception
    public virtual TransformInfoProperties getInstance(Node node)
    {
        NodeList transformInfoChildNodeList = node.getChildNodes();
        TransformInfoData transformInfoData = TransformInfoData.getInstance();
        NamedNodeMap attributes = node.getAttributes();
        Attr attrNode = ((Attr) attributes.getNamedItem(transformInfoData.NAME));
        string name = attrNode.getValue();
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF(CommonLabels.getInstance().NEXT + " View Name: " + name, this, "toTransformInfoPropertiesHashMap()");
        }
        Node labelNode = DomSearchHelper.getNodeNoThrow(transformInfoData.LABEL, transformInfoChildNodeList);
        string label = DomNodeHelper.getTextNodesValue(labelNode);
        if (label == null) {
            label = name;
        }
        Node descriptionNode = DomSearchHelper.getNode(transformInfoData.DESCRIPTION, transformInfoChildNodeList);
        string description = DomNodeHelper.getTextNodesValue(descriptionNode);
        Node objectFileNode = DomSearchHelper.getNode(transformInfoData.OBJECTFILENAME, transformInfoChildNodeList);
        string objectFileName = DomNodeHelper.getTextNodeValue(objectFileNode);
        Node objectConfigFileNode = DomSearchHelper.getNode(transformInfoData.OBJECTCONFIGFILENAME, transformInfoChildNodeList);
        string objectConfigFileName = DomNodeHelper.getTextNodeValue(objectConfigFileNode);
        Node templateFileNode = DomSearchHelper.getNode(transformInfoData.TEMPLATEFILENAME, transformInfoChildNodeList);
        string templateFileName = DomNodeHelper.getTextNodeValue(templateFileNode);
        TransformInfoProperties transformInfoProperties = new TransformInfoProperties(name, label, description, objectFileName, objectConfigFileName, templateFileName);
        return transformInfoProperties;
    }

}

