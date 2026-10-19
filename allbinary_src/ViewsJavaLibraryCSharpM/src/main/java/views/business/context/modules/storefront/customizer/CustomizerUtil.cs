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
using TransformInfoEntity = org.allbinary.data.tables.transform.info.TransformInfoEntity;
using TransformInfoEntityBuilder = org.allbinary.data.tables.transform.info.TransformInfoEntityBuilder;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using TransformInfo = org.allbinary.logic.visual.transform.info.TransformInfo;
using TransformInfoHttpInterface = org.allbinary.logic.visual.transform.info.TransformInfoHttpInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformInfoObjectConfigInterface = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigInterface;
using Document = org.w3c.dom.Document;

namespace views.business.context.modules.storefront.customizer;

public class CustomizerUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly CustomizerUtil instance = new CustomizerUtil();
    public static CustomizerUtil getInstance()
    {
        return CustomizerUtil.instance;
    }

    private CustomizerUtil()
    {
    }

    // throws Exception
    public virtual TransformInfoInterface getTransformInfoInterfaceToCustomize(TransformInfoInterface customizerTransformInfoInterface, TransformInfoInterface transformInfoInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("View Name: " + customizerTransformInfoInterface.getName(), this, "getTransformInfoInterfaceToCustomize()");
        }
        TransformInfoEntity transformInfoEntityInterface = TransformInfoEntityBuilder.getInstance();
        string viewName = transformInfoInterface.getName();
        TransformInfoHttpInterface httpTransformInfoInterface = ((TransformInfoHttpInterface) customizerTransformInfoInterface);
        TransformInfoInterface customizedTransformInfoInterface = transformInfoEntityInterface.get(viewName, httpTransformInfoInterface.getPropertiesHashMap(), httpTransformInfoInterface.getPageContext());
        return customizedTransformInfoInterface;
    }

    // throws Exception
    public virtual BasicArrayList getTransformInfoObjectConfigComponentNodesToCustomize(TransformInfoInterface customizerTransformInfoInterface, TransformInfoInterface transformInfoInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("View Name: " + customizerTransformInfoInterface.getName(), this, "getTransformInfoObjectConfigComponentNodesToCustomize()");
        }
        TransformInfoEntity transformInfoEntityInterface = TransformInfoEntityBuilder.getInstance();
        string viewName = transformInfoInterface.getName();
        TransformInfoHttpInterface httpTransformInfoInterface = ((TransformInfoHttpInterface) customizerTransformInfoInterface);
        TransformInfoInterface customizedTransformInfoInterface = transformInfoEntityInterface.get(viewName, httpTransformInfoInterface.getPropertiesHashMap(), httpTransformInfoInterface.getPageContext());
        return this.getTransformInfoObjectConfigComponentNodes(customizedTransformInfoInterface);
    }

    // throws Exception
    public virtual BasicArrayList getTransformInfoObjectConfigComponentNodes(TransformInfoInterface transformInfoInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("View Name: " + transformInfoInterface.getName(), this, "getTransformInfoObjectConfigComponentNodes()");
        }
        TransformInfoObjectConfigInterface transformInfoObjectConfigInterface = transformInfoInterface.getObjectConfigInterface();
        return transformInfoObjectConfigInterface.getTransforms();
    }

    // throws Exception
    public virtual BasicArrayList getTransformInfoObjectConfigGroupComponentNodes(TransformInfoInterface transformInfoInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("View Name: " + transformInfoInterface.getName(), this, "getTransformInfoObjectConfigComponentNodes()");
        }
        TransformInfoObjectConfigInterface transformInfoObjectConfigInterface = transformInfoInterface.getObjectConfigInterface();
        return transformInfoObjectConfigInterface.getGroupTransforms();
    }

    // throws Exception
    public virtual void insert(TransformInfoInterface transformInfoInterface, DomNodeInterface domNodeInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("View Name: " + transformInfoInterface.getName(), this, "insert()");
        }
        TransformInfoEntity transformInfoEntityInterface = TransformInfoEntityBuilder.getInstance();
        BasicArrayList allViewsToBeModified = this.getTransformInfoObjectConfigGroupComponentNodes(transformInfoInterface);
        Document document = DomDocumentHelper.create();
        document.appendChild(domNodeInterface.toXmlNode(document));
        string documentString = XmlDocumentHelper.toString(document);
        StringMaker stringBuffer = new StringMaker();
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            stringBuffer.append("Total Views For Modification: ");
            stringBuffer.appendint(allViewsToBeModified.size());
            stringBuffer.append(" New Xml/Data: ");
            stringBuffer.append(documentString);
            this.logUtil.putF(stringBuffer.ToString(), this, "insert()");
        }
        transformInfoInterface.setData(documentString);
        int size = allViewsToBeModified.size();
        for (int index = 0; index < size; index++) {
            TransformInfo transformInfo = ((TransformInfo) allViewsToBeModified.get(index));
            string viewNameOfViewToBeModified = transformInfo.getName();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append(transformInfoInterface.getName());
                stringBuffer.append(" is modifying view: ");
                stringBuffer.append(viewNameOfViewToBeModified);
                this.logUtil.putF(stringBuffer.ToString(), this, "insert()");
            }
            TransformInfoHttpInterface httpTransformInfoInterface = ((TransformInfoHttpInterface) transformInfoInterface);
            TransformInfoInterface specifiedTransformInfoInterface = transformInfoEntityInterface.get(viewNameOfViewToBeModified, httpTransformInfoInterface.getPropertiesHashMap(), httpTransformInfoInterface.getPageContext());
            if (specifiedTransformInfoInterface == null) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    stringBuffer.delete(0, stringBuffer.length());
                    stringBuffer.append(transformInfoInterface.getName());
                    stringBuffer.append(" is unable to add data to view: ");
                    stringBuffer.append(viewNameOfViewToBeModified);
                    stringBuffer.append(" since it does not exist");
                    this.logUtil.putF(stringBuffer.ToString(), this, "insert()");
                }
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF(transformInfoInterface.getName() + " is adding data to view: " + viewNameOfViewToBeModified, this, "insert()");
                }
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    stringBuffer.delete(0, stringBuffer.length());
                    stringBuffer.append(viewNameOfViewToBeModified);
                    stringBuffer.append(" is changing data in ");
                    stringBuffer.append(specifiedTransformInfoInterface.getDataFilePath().ToString());
                    stringBuffer.append(" to the following data:\n");
                    stringBuffer.append(documentString);
                    this.logUtil.putF(stringBuffer.ToString(), this, "insert()");
                }
                this.write(specifiedTransformInfoInterface, documentString);
            }
        }
    }

    // throws Exception
    public virtual void write(TransformInfoInterface specifiedTransformInfoInterface, string documentString)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("View Name: " + specifiedTransformInfoInterface.getName(), this, "write()");
        }
        TransformInfoEntity transformInfoEntityInterface = TransformInfoEntityBuilder.getInstance();
        specifiedTransformInfoInterface.setData(documentString);
        transformInfoEntityInterface.update(specifiedTransformInfoInterface.toHashMap());
    }

    // throws Exception
    public virtual Document getViewDataForComponentsInObjectConfig(TransformInfoInterface transformInfoInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("View Name: " + transformInfoInterface.getName(), this, "getViewDataForComponentsInObjectConfig()");
        }
        TransformInfoObjectConfigInterface transformInfoObjectConfigInterface = transformInfoInterface.getObjectConfigInterface();
        BasicArrayList allViewsToBeModified = transformInfoObjectConfigInterface.getGroupTransforms();
        TransformInfoEntity transformInfoEntityInterface = TransformInfoEntityBuilder.getInstance();
        int size = allViewsToBeModified.size();
        for (int index = 0; index < size; index++) {
            TransformInfo nextTransformInfoInterface = ((TransformInfo) allViewsToBeModified.get(index));
            string viewNameOfViewToBeModified = nextTransformInfoInterface.getName();
            TransformInfoHttpInterface httpTransformInfoInterface = ((TransformInfoHttpInterface) transformInfoInterface);
            TransformInfoInterface specifiedTransformInfoInterface = transformInfoEntityInterface.get(viewNameOfViewToBeModified, httpTransformInfoInterface.getPropertiesHashMap(), httpTransformInfoInterface.getPageContext());
            return specifiedTransformInfoInterface.getDataDocument();
        }
        throw new Exception("No Components Specified in ObjectConfig");
    }

}

