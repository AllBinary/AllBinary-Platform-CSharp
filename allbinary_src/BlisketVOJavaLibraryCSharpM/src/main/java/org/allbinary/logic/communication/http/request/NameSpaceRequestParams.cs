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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using HttpServletRequest = javax.servlet.http.HttpServletRequest;
//using PageContext = javax.servlet.jsp.PageContext;
using DomData = org.allbinary.data.tree.dom.DomData;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.communication.http.request;

//containing string values and other hashmaps of the like
public class NameSpaceRequestParams : RequestParams
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public NameSpaceRequestParams() : base()
    {
        // base() is called from the constructor declaration
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
            this.logUtil.putF("Constructing empty", this, this.commonStrings.CONSTRUCTOR);
        }
    }

    public NameSpaceRequestParams(HttpServletRequest httpServletRequest) : base(httpServletRequest)
    {
        // base(httpServletRequest) is called from the constructor declaration
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
            this.logUtil.putF("Constructing from HttpServletRequest", this, this.commonStrings.CONSTRUCTOR);
        }
    }

    public NameSpaceRequestParams(PageContext pageContext) : base(pageContext)
    {
        // base(pageContext) is called from the constructor declaration
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
            this.logUtil.putF("Constructing from PageContext", this, this.commonStrings.CONSTRUCTOR);
        }
    }

    // throws Exception
    private Node createPackageNode(Document document, string packageName, HashMap<object, object> packagePropertiesHashMap)
    {
        Node node = document.createElement(packageName);
        Set<object> propertyKeySet = packagePropertiesHashMap.keySet();
        object[] propertyKeySetArray = propertyKeySet.toArray();
        int size = propertyKeySetArray.Length;
        for (int index = 0; index < size; index++) {
            string propertyName = ((string) propertyKeySetArray[index]);
            string propertyValue = ((string) packagePropertiesHashMap.get(propertyName));
            Node propertyNode = ModDomHelper.createTextNode(document, propertyName, propertyValue);
            node.appendChild(propertyNode);
        }
        return node;
    }

    // throws Exception
    private Node createPackageMultiNode(Document document, NameSpaceRequestParam nameSpaceRequestParam, string packageName, HashMap<object, object> packagePropertiesHashMap)
    {
        int beginIndex = packageName.IndexOf('[');
        string indexValue = packageName.Substring(beginIndex + 1, (packageName.Length - 1) - (beginIndex + 1));
        string multiElementPackage = packageName.Substring(0, (beginIndex) - (0));
        string selectedValue = nameSpaceRequestParam.getValue();
        string propertyValue = ((string) packagePropertiesHashMap.get(DomData.VALUE));
        if (string.CompareOrdinal(propertyValue, NameSpaceRequestParamData.VALUE) != 0) {
            selectedValue = propertyValue;
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
            this.logUtil.putF("\nAppending Multinode Element: " + multiElementPackage + "[" + indexValue + "] " + selectedValue, this, "createPackageMultiNode");
        }
        Node nextNode = ModDomHelper.createNameValueNodes(document, multiElementPackage, selectedValue);
        Node indexNode = ModDomHelper.createTextNode(document, DomData.INDEX, indexValue);
        nextNode.appendChild(indexNode);
        return nextNode;
    }

    // throws Exception
    private Node getRootNode(string rootElementPackage, HashMap<object, object> packagePropertiesHashMap, Document document)
    {
        Node rootNode = DomSearchHelper.getNodeNoThrow(rootElementPackage, document.getChildNodes());
        if (rootNode == null) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                this.logUtil.putF("\nAppending Document Root: " + "\nElementName: " + rootElementPackage + "\nProperties: " + packagePropertiesHashMap.ToString(), this, "getRootNode");
            }
            Node node = this.createPackageNode(document, rootElementPackage, packagePropertiesHashMap);
            document.appendChild(node);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                this.logUtil.putF("\nAppended Document Created: " + XmlDocumentHelper.toString(document), this, "getRootNode");
            }
            return node;
        } else {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                this.logUtil.putF("\nUsing Existing Root Node", this, "getRootNode");
            }
            return rootNode;
        }
    }

    // throws Exception
    private Node addNewProperties(Document document, Node node, HashMap<object, object> nextPackagePropertiesHashMap)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
            this.logUtil.putF(new StringMaker().append("\nAdding Any New Properties: ").append(nextPackagePropertiesHashMap.ToString()).append("\nto node: ").append(node.getNodeName()).ToString(), this, "addNewProperties");
        }
        Set<object> propertyNameSet = nextPackagePropertiesHashMap.keySet();
        object[] propertyNameSetArray = propertyNameSet.toArray();
        int size = propertyNameSetArray.Length;
        for (int index = 0; index < size; index++) {
            string nextPropertyName = ((string) propertyNameSetArray[index]);
            string propertyValue = StringUtil.getInstance().getNonNull(((string) nextPackagePropertiesHashMap.get(nextPropertyName)));
            Node valueNode = DomSearchHelper.getNodeNoThrow(nextPropertyName, node.getChildNodes());
            if (valueNode != null) {
                string existingElementNodeTextNodeValue = DomNodeHelper.getTextNodeValue(valueNode);
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                    this.logUtil.putF("\nIf property: \"" + nextPropertyName + " is the same as:\n" + "Node: " + node.getNodeName() + " then: " + propertyValue + "==" + existingElementNodeTextNodeValue, this, "addNewProperties");
                }
                if (string.CompareOrdinal(propertyValue, existingElementNodeTextNodeValue) != 0) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                        this.logUtil.putF("At least one Property from NameSpaceRequest Package was different from Node", this, "addNewProperties");
                    }
                    throw new Exception("Property Modifications Should Not Occur");
                }
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                    this.logUtil.putF("Adding a new Property: " + nextPropertyName + "=" + propertyValue, this, "addNewProperties");
                }
                Node newPropertyNode = ModDomHelper.createTextNode(document, nextPropertyName, propertyValue);
                node.appendChild(newPropertyNode);
            }
        }
        return node;
    }

    // throws Exception
    private bool isElementValueTextNodeEqual(HashMap<object, object> nextPackagePropertiesHashMap, Node node)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
            this.logUtil.putF("\nComparing the value property in: " + nextPackagePropertiesHashMap.ToString() + "\nto node child leaves of node: " + node.getNodeName(), this, "isElementValueTextNodeEqual");
        }
        string propertyValue = ((string) nextPackagePropertiesHashMap.get(DomData.VALUE));
        Node valueNode = DomSearchHelper.getNodeNoThrow(DomData.VALUE, node.getChildNodes());
        if (valueNode != null) {
            string existingElementNodeTextNodeValue = DomNodeHelper.getTextNodeValue(valueNode);
            if (string.CompareOrdinal(propertyValue, existingElementNodeTextNodeValue) == 0) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                    this.logUtil.putF("Value Node is the same", this, "isElementValueTextNodeEqual");
                }
                return true;
            }
        } else {
            return true;
        }
        return false;
    }

    // throws Exception
    private int isElementValueTextNodeUnique(HashMap<object, object> nextPackagePropertiesHashMap, BasicArrayList elementNodeVector)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
            this.logUtil.putF("\nComparing Properties of: " + elementNodeVector.size() + " Nodes", this, "isElementValueTextNodeUnique");
        }
        int size = elementNodeVector.size();
        for (int index = 0; index < size; index++) {
            Node existingElementNode = ((Node) elementNodeVector.get(index));
            if (this.isElementValueTextNodeEqual(nextPackagePropertiesHashMap, existingElementNode)) {
                return index;
            }
        }
        return -1;
    }

    // throws Exception
    private Document addChildren(Document document, Node rootNode, NameSpaceRequestParam nameSpaceRequestParam)
    {
        Node node = rootNode;
        BasicArrayList packageVector = nameSpaceRequestParam.getPackages();
        int size = packageVector.size();
        for (int index = 1; index < size; index++) {
            string nextPackageName = ((string) packageVector.get(index));
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                this.logUtil.putF(new StringMaker().append("\nTrying to Add Child to Node: ").append(node.getNodeName()).append("\nwith new PackageName: ").append(nextPackageName).ToString(), this, "addChildren");
            }
            HashMap<object, object> nextPackagePropertiesHashMap = nameSpaceRequestParam.getPackageProperties(index);
            BasicArrayList elementNodeVector = DomSearchHelper.getAllNodesNoThrow(nextPackageName, node.getChildNodes());
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                this.logUtil.putF("\nDocument Contains " + elementNodeVector.size() + " Node(s) With Same Name", this, "addChildren");
            }
            int isElementValueTextNodeUniqueIndex = this.isElementValueTextNodeUnique(nextPackagePropertiesHashMap, elementNodeVector);
            if ((elementNodeVector.size() == 0 || isElementValueTextNodeUniqueIndex == -1) && !nextPackageName.EndsWith(CommonSeps.getInstance().BRACKET_CLOSE)) {
                Node nextNode = this.createPackageNode(document, nextPackageName, nextPackagePropertiesHashMap);
                node.appendChild(nextNode);
                node = nextNode;
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                    this.logUtil.putF("\nAppended Package: " + node.getNodeName(), this, "addChildren");
                    this.logUtil.putF("\nAppended Document Created: " + XmlDocumentHelper.toString(document), this, "addChildren");
                }
            } else if (nextPackageName.EndsWith(CommonSeps.getInstance().BRACKET_CLOSE)) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                    this.logUtil.putF("Package is MultiNode: just append", this, "addChildren");
                }
                Node nextNode = this.createPackageMultiNode(document, nameSpaceRequestParam, nextPackageName, nextPackagePropertiesHashMap);
                node.appendChild(nextNode);
                node = nextNode;
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                    this.logUtil.putF("\nAppended Multinode Element: " + XmlDocumentHelper.toString(document), this, "addChildren");
                }
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                    this.logUtil.putF("Value Node already exists: Now compare (properties to leaf nodes)", this, "addChildren");
                }
                Node nodeNameDuplicateNode = ((Node) elementNodeVector.get(isElementValueTextNodeUniqueIndex));
                node = this.addNewProperties(document, nodeNameDuplicateNode, nextPackagePropertiesHashMap);
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                    this.logUtil.putF("\nDuplicate Node Found: Moving to next child ^", this, "addChildre");
                }
            }
        }
        return document;
    }

    // throws Exception
    private Document addNameSpace(string key, string value, Document document)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
            this.logUtil.putF(new StringMaker().append("NameSpace key: ").append(key).append(" Value: ").append(value).ToString(), this, "addNameSpace");
        }
        NameSpaceRequestParam nameSpaceRequestParam = new NameSpaceRequestParam(key, value);
        BasicArrayList packageVector = nameSpaceRequestParam.getPackages();
        int size = packageVector.size();
        for (int index = 0; index < size; index++) {
            string packageName = ((string) packageVector.get(index));
            HashMap<object, object> packagePropertiesHashMap = nameSpaceRequestParam.getPackageProperties(packageVector.indexOf(packageName));
            Node rootNode = this.getRootNode(packageName, packagePropertiesHashMap, document);
            if (index < size - 1) {
                return this.addChildren(document, ((Node) rootNode), nameSpaceRequestParam);
            }
        }
        return document;
    }

    // throws Exception
    public virtual HashMap<object, object> toHashMap()
    {
        Document document = DomDocumentHelper.create();
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        Set<object> keys = this.getMap().keySet();
        object[] keyArray = keys.toArray();
        int keySize = keyArray.Length;
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
            this.logUtil.putF("NameSpace Request Size: " + keys.size(), this, "toHashMap");
        }
        for (int i = 0; i < keySize; i++) {
            string key = ((string) keyArray[i]);
            object anyType = this.getMap().get(key);
            string className = ((string) anyType.GetType().FullName);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                this.logUtil.putF("Request Param Class: " + className, this, "toHashMap");
            }
            if (this.getMap().get(key) is string) {
                string value = ((string) this.getMap().get(key));
                if (key.IndexOf(NameSpaceRequestParamData.NAME) < 0) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                        this.logUtil.putF("Not NameSpace key: " + key + " Value: " + value, this, "toHashMap()");
                    }
                    hashMap.put(new string((key).ToCharArray()), new string((value).ToCharArray()));
                } else {
                    document = this.addNameSpace(new string((key).ToCharArray()), new string((value).ToCharArray()), document);
                }
            } else if (this.getMap().get(key) is string[]) {
                string[] values = ((string[]) this.getMap().get(key));
                if (key.IndexOf(NameSpaceRequestParamData.NAME) < 0) {
                    if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
                        this.logUtil.putF("Not NameSpace key: " + key + " Value: " + values[0], this, "toHashMap()");
                    }
                    hashMap.put(new string((key).ToCharArray()), new string((values[0]).ToCharArray()));
                } else {
                    document = this.addNameSpace(new string((key).ToCharArray()), new string((values[0]).ToCharArray()), document);
                }
            }
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().HTTPREQUEST)) {
            this.logUtil.putF("NameSpaceRequestParams: " + this.getMap().ToString() + "\ntoHashMap(): " + hashMap.ToString() + "\nDocument Created: " + XmlDocumentHelper.toString(document), this, "toHashMap()");
        }
        hashMap.put(NameSpaceRequestParamData.DOCUMENT, document);
        return hashMap;
    }

}

