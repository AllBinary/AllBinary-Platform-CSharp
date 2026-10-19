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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using Attr = org.w3c.dom.Attr;
using NamedNodeMap = org.w3c.dom.NamedNodeMap;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.logic.visual.transform.info;

public class TransformInfoDomNode
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private TransformInfoInterface transformInfoInterface;
    private string mappedName;
    public TransformInfoDomNode(Node node)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Constructing TransformInfo From TransformInfoDomNode: " + node.getNodeName(), this, "TransformInfoDomNode(Node node)");
        }
        TransformInfoData transformInfoData = TransformInfoData.getInstance();
        NamedNodeMap attributes = node.getAttributes();
        Attr attrNode = ((Attr) attributes.getNamedItem(transformInfoData.NAME));
        string name = attrNode.getValue();
        NodeList nodeList = node.getChildNodes();
        if (nodeList.getLength() > 1) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Constructing Complete TransformInfo Node For: ");
                stringBuffer.append(name);
                stringBuffer.append(" with ");
                stringBuffer.appendint(((int) nodeList.getLength()));
                stringBuffer.append(" children");
                this.logUtil.putF(stringBuffer.ToString(), this, "TransformInfoObjectConfigComponent(Node node)");
            }
            Node objectFileNameNode = DomSearchHelper.getNode(transformInfoData.OBJECTFILENAME, nodeList);
            string objectFileName = DomNodeHelper.getTextNodeValue(objectFileNameNode);
            Node objectConfigFileNameNode = DomSearchHelper.getNode(transformInfoData.OBJECTCONFIGFILENAME, nodeList);
            string objectConfigFileName = DomNodeHelper.getTextNodeValue(objectConfigFileNameNode);
            Node templateFileNameNode = DomSearchHelper.getNode(transformInfoData.TEMPLATEFILENAME, nodeList);
            string templateFileName = DomNodeHelper.getTextNodeValue(templateFileNameNode);
            Node dataFileNameNode = DomSearchHelper.getNode(transformInfoData.DATAFILENAME, nodeList);
            string dataFileName = DomNodeHelper.getTextNodeValue(dataFileNameNode);
            this.transformInfoInterface = ((TransformInfoInterface) new TransformInfo(name, objectFileName, objectConfigFileName, templateFileName, dataFileName));
        } else {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Constructing Partial TransformInfo Node For: ");
                stringBuffer.append(name);
                stringBuffer.append(" with ");
                stringBuffer.appendint(((int) nodeList.getLength()));
                stringBuffer.append(" children");
                this.logUtil.putF(stringBuffer.ToString(), this, "TransformInfoObjectConfigComponent(Node node)");
            }
            this.transformInfoInterface = ((TransformInfoInterface) new TransformInfo(name));
        }
        Attr templateAttrNode = ((Attr) attributes.getNamedItem(transformInfoData.MAPPED));
        if (templateAttrNode != null) {
            this.mappedName = templateAttrNode.getValue();
        } else {
            this.mappedName = this.getTransformInfoInterface().getName();
        }
    }

    public TransformInfoDomNode(TransformInfoInterface transformInfoInterface)
    {
        this.transformInfoInterface = transformInfoInterface;
        this.mappedName = transformInfoInterface.getName();
    }

    public TransformInfoDomNode(TransformInfoInterface transformInfoInterface, string mappedName)
    {
        this.transformInfoInterface = transformInfoInterface;
        this.mappedName = mappedName;
    }

    public TransformInfoDomNode(string name, string mappedName)
    {
        this.transformInfoInterface = new TransformInfo(name);
        this.mappedName = mappedName;
    }

    public virtual TransformInfoInterface getTransformInfoInterface()
    {
        return this.transformInfoInterface;
    }

    public virtual string getMappedName()
    {
        return this.mappedName;
    }

    public virtual string getReplaceKey()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("<transform:component name=\"");
        stringBuffer.append("body");
        stringBuffer.append("\"/>");
        string key = stringBuffer.ToString();
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Component Key: " + key, this, "getReplaceKey()");
        }
        return key;
    }

}

