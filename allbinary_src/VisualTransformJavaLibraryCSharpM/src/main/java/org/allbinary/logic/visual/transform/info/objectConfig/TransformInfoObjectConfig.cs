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
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using InputOutputTypeData = org.allbinary.logic.io.InputOutputTypeData;
using OutputTypeData = org.allbinary.logic.io.OutputTypeData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using TransformInfoData = org.allbinary.logic.visual.transform.info.TransformInfoData;
using TransformInfoDomNode = org.allbinary.logic.visual.transform.info.TransformInfoDomNode;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformInfosData = org.allbinary.logic.visual.transform.info.TransformInfosData;
using XslData = org.allbinary.logic.visual.transform.template.XslData;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Attr = org.w3c.dom.Attr;
using Document = org.w3c.dom.Document;
using NamedNodeMap = org.w3c.dom.NamedNodeMap;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.logic.visual.transform.info.objectConfig;

public class TransformInfoObjectConfig : TransformInfoObjectConfigInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly TransformInfoInterface ownerTransformInfoInterface;
    private Document document;
    private string outputTypeName = null;
    public TransformInfoObjectConfig(TransformInfoInterface transformInfoInterface)
    {
        this.ownerTransformInfoInterface = transformInfoInterface;
        this.createDocument();
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("TransformInfo: ");
            if (this.ownerTransformInfoInterface != null) {
                stringBuffer.append(this.ownerTransformInfoInterface.getName());
            } else {
                stringBuffer.append("No Owner!?#@");
            }
            stringBuffer.append("\nConstructed with document: ");
            stringBuffer.append(this.ToString());
            this.logUtil.putF(stringBuffer.ToString(), this, "Constructor(TransformInfoInterface)");
        }
    }

    public TransformInfoObjectConfig(TransformInfoInterface transformInfoInterface, Document document)
    {
        this.ownerTransformInfoInterface = transformInfoInterface;
        this.document = document;
        Node node = DomSearchHelper.getNodeNoThrow(OutputTypeData.getInstance().NAME, this.getRootNode().getChildNodes());
        if (node != null) {
            this.setOutputTypeName(DomNodeHelper.getTextNodeValue(node));
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("TransformInfo: ");
            if (this.ownerTransformInfoInterface != null) {
                stringBuffer.append(this.ownerTransformInfoInterface.getName());
            } else {
                stringBuffer.append("No Owner!?#@");
            }
            stringBuffer.append("\nConstructed with document: ");
            stringBuffer.append(this.ToString());
            this.logUtil.putF(stringBuffer.ToString(), this, "Constructor(TransformInfoInterface, Document)");
        }
    }

    public TransformInfoObjectConfig(TransformInfoInterface transformInfoInterface, string name, string type)
    {
        this.ownerTransformInfoInterface = transformInfoInterface;
        this.createDocument();
        Attr configNameAttr = this.document.createAttribute(TransformInfoObjectConfigData.getInstance().NAME);
        configNameAttr.setValue(name);
        Node objectConfigNode = this.document.getElementsByTagName(TransformInfoObjectConfigData.getInstance().NAME).item(0);
        objectConfigNode.appendChild(configNameAttr);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("TransformInfo: ");
            if (this.ownerTransformInfoInterface != null) {
                stringBuffer.append(this.ownerTransformInfoInterface.getName());
            } else {
                stringBuffer.append("No Owner!?#@");
            }
            stringBuffer.append("\nConstructed with document: ");
            stringBuffer.append(this.ToString());
            this.logUtil.putF(stringBuffer.ToString(), this, "Constructor(TransformInfoInterface, name, type)");
        }
    }

    private void createDocument()
    {
        this.document = DomDocumentHelper.create();
        Node objectConfigNode = this.document.createElement(TransformInfoObjectConfigData.getInstance().NAME);
        this.document.appendChild(objectConfigNode);
    }

    protected virtual TransformInfoInterface getTransformInfoInterface()
    {
        return this.ownerTransformInfoInterface;
    }

    // throws Exception
    public virtual Document toXmlDoc()
    {
        return this.document;
    }

    protected virtual void setDocument(Document document)
    {
        this.document = document;
    }

    public virtual bool containsView(TransformInfoInterface transformInfoInterface)
    {
        Node objectConfigNode = this.document.getElementsByTagName(TransformInfoObjectConfigData.getInstance().NAME).item(0);
        NodeList viewNodeList = objectConfigNode.getChildNodes();
        int numberOfViews = viewNodeList.getLength();
        for (int index = 0; index < numberOfViews; index++) {
            Node viewNode = viewNodeList.item(index);
            NamedNodeMap viewAttributes = viewNode.getAttributes();
            Attr attrNode = ((Attr) viewAttributes.getNamedItem(TransformInfoData.getInstance().NAME));
            if (transformInfoInterface.getName().compareTo(attrNode.getValue()) == 0) {
                return true;
            }
        }
        return false;
    }

    // throws Exception
    private NamedNodeMap getTemplateAttributes()
    {
        Node componentNode = this.document.getElementsByTagName(TransformInfoObjectConfigData.getInstance().NAME).item(0);
        return componentNode.getAttributes();
    }

    // throws Exception
    public virtual string getName()
    {
        Attr attrNode = ((Attr) this.getTemplateAttributes().getNamedItem(TransformInfoObjectConfigData.getInstance().NAME));
        return attrNode.getValue();
    }

    // throws Exception
    public virtual void setName(string name)
    {
        Attr attrNode = ((Attr) this.getTemplateAttributes().getNamedItem(TransformInfoObjectConfigData.getInstance().NAME));
        attrNode.setValue(name);
    }

    // throws Exception
    private BasicArrayList getNodeVector(string nodeName)
    {
        NodeList componentsNodeList = this.document.getElementsByTagName(nodeName);
        if (componentsNodeList != null && componentsNodeList.getLength() > 0) {
            BasicArrayList viewNodeVector = DomSearchHelper.getAllNodes(TransformInfoData.getInstance().NAME, componentsNodeList.item(0).getChildNodes());
            int numberOfViews = viewNodeVector.size();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Number Of ");
                stringBuffer.append(nodeName);
                stringBuffer.append(" Nodes: ");
                stringBuffer.appendint(numberOfViews);
                this.logUtil.putF(stringBuffer.ToString(), this, "getNodeVector(nodename)");
            }
            return viewNodeVector;
        }
        return new BasicArrayListD();
    }

    // throws Exception
    private BasicArrayList getTransformDomNodes(string nodeName)
    {
        BasicArrayList viewVector = new BasicArrayListD();
        BasicArrayList viewNodeVector = this.getNodeVector(nodeName);
        int size = viewNodeVector.size();
        for (int index = 0; index < size; index++) {
            Node viewNode = ((Node) viewNodeVector.get(index));
            viewVector.add(new TransformInfoDomNode(viewNode));
        }
        return viewVector;
    }

    // throws Exception
    public virtual BasicArrayList getTransforms(string nodeName)
    {
        BasicArrayList viewVector = new BasicArrayListD();
        BasicArrayList viewNodeVector = this.getNodeVector(nodeName);
        int size = viewNodeVector.size();
        for (int index = 0; index < size; index++) {
            Node viewNode = ((Node) viewNodeVector.get(index));
            viewVector.add(new TransformInfoDomNode(viewNode).getTransformInfoInterface());
        }
        return viewVector;
    }

    // throws Exception
    public virtual BasicArrayList getTransformsGroup(string group)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Started: " + group, this, "getTransformsGroup()");
        }
        BasicArrayList viewVector = new BasicArrayListD();
        string GROUP = TransformInfosData.getInstance().GROUP;
        NodeList componentsNodeList = this.document.getElementsByTagName(GROUP);
        if (componentsNodeList != null && componentsNodeList.getLength() > 0) {
            Node componentsNode = componentsNodeList.item(0);
            int length = componentsNodeList.getLength();
            for (int index = 0; index < length; index++) {
                Node node = componentsNodeList.item(index);
                NamedNodeMap attributes = node.getAttributes();
                Attr attrNode = ((Attr) attributes.getNamedItem(GROUP));
                string value = attrNode.getValue();
                if (string.CompareOrdinal(value, group) == 0) {
                    componentsNode = node;
                    break;
                }
            }
            BasicArrayList viewNodeVector = DomSearchHelper.getAllNodes(TransformInfoData.getInstance().NAME, componentsNode.getChildNodes());
            int numberOfViews = viewNodeVector.size();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Number Of Nodes: " + numberOfViews, this, "getTransformsGroup()");
            }
            int size = viewNodeVector.size();
            for (int index = 0; index < size; index++) {
                Node viewNode = ((Node) viewNodeVector.get(index));
                viewVector.add(new TransformInfoDomNode(viewNode));
            }
        } else {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                if (componentsNodeList == null) {
                    this.logUtil.putF("Number Of Nodes: NULL", this, "getTransformsGroup()");
                } else {
                    this.logUtil.putF("Number Of Nodes: 0", this, "getTransformsGroup()");
                }
            }
        }
        return viewVector;
    }

    // throws Exception
    public virtual BasicArrayList getTransformDomNodes()
    {
        return this.getTransformDomNodes(TransformInfosData.getInstance().GROUP);
    }

    // throws Exception
    public virtual BasicArrayList getTransforms()
    {
        return this.getTransforms(TransformInfosData.getInstance().NAME);
    }

    // throws Exception
    public virtual BasicArrayList getGroupTransforms()
    {
        return this.getTransforms(TransformInfosData.getInstance().GROUP);
    }

    // throws Exception
    public virtual BasicArrayList getParentTransforms()
    {
        return this.getTransforms(TransformInfoData.getInstance().PARENT);
    }

    private Node getRootNode()
    {
        return this.document.getElementsByTagName(TransformInfoObjectConfigData.getInstance().NAME).item(0);
    }

    public virtual void setOutputTypeName(string outputTypeName)
    {
        this.outputTypeName = outputTypeName;
    }

    // throws Exception
    public virtual string getOutputTypeName()
    {
        return this.outputTypeName;
    }

    // throws Exception
    public virtual string getInputOutputTypeName()
    {
        Node node = DomSearchHelper.getNode(InputOutputTypeData.getInstance().NAME, this.getRootNode().getChildNodes());
        return DomNodeHelper.getTextNodeValue(node);
    }

    // throws Exception
    public virtual string getInputOutputTypeFile()
    {
        Node node = DomSearchHelper.getNode(InputOutputTypeData.getInstance().FILE, this.getRootNode().getChildNodes());
        return DomNodeHelper.getTextNodeValue(node);
    }

    // throws Exception
    public virtual string getImportUriPath()
    {
        Node node = DomSearchHelper.getNode(XslData.getInstance().ROOT_IMPORT_URI, this.getRootNode().getChildNodes());
        return DomNodeHelper.getTextNodeValue(node);
    }

    public override string ToString()
    {
        try {
            if (this.document != null) {
                return XmlDocumentHelper.toString(this.document);
            } else {
                return null;
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.putF("DOM Document error", this, this.commonStrings.TOSTRING);
            }
            return null;
        }
    }

}

