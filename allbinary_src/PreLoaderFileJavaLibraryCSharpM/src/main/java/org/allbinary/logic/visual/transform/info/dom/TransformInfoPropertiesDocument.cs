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
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using DomDocumentFileHelper = org.allbinary.data.tree.dom.document.DomDocumentFileHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using TransformInfoData = org.allbinary.logic.visual.transform.info.TransformInfoData;
using TransformInfoProperties = org.allbinary.logic.visual.transform.info.TransformInfoProperties;
using TransformInfoPropertiesFactory = org.allbinary.logic.visual.transform.info.TransformInfoPropertiesFactory;
using TransformInfosData = org.allbinary.logic.visual.transform.info.TransformInfosData;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.logic.visual.transform.info.dom;

public class TransformInfoPropertiesDocument
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly Document document;
    public TransformInfoPropertiesDocument(string filePath)
    {
        AbFile xmlFile = AbFile.createAbFile(filePath);
        this.document = DomDocumentFileHelper.createDocument(xmlFile);
    }

    public virtual HashMap<object, object> toTransformInfoPropertiesHashMap()
    {
        try {
            HashMap<object, object> transformInfoPropertiesHashMap = StdUtil.getInstance().createHashMap();
            Node transformInfosNode = this.document.getElementsByTagName(TransformInfosData.getInstance().NAME).item(0);
            NodeList transformInfosChildNodeList = transformInfosNode.getChildNodes();
            BasicArrayList transformInfoNodeVector = DomSearchHelper.getAllNodes(TransformInfoData.getInstance().NAME, transformInfosChildNodeList);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("Size: " + transformInfoNodeVector.size(), this, "toTransformInfoPropertiesHashMap()");
            }
            int size = transformInfoNodeVector.size();
            Node node = null;
            TransformInfoProperties transformInfoProperties = null;
            for (int index = 0; index < size; index++) {
                node = ((Node) transformInfoNodeVector.get(index));
                transformInfoProperties = TransformInfoPropertiesFactory.getInstance().getInstance(node);
                transformInfoPropertiesHashMap.put(transformInfoProperties.getName(), transformInfoProperties);
            }
            return transformInfoPropertiesHashMap;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, "toTransformInfoPropertiesHashMap()", e);
            }
            return null;
        }
    }

}

