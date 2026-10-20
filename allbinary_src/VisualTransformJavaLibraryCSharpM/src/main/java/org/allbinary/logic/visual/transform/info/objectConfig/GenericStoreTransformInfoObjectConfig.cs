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
using StoreFrontData = org.allbinary.business.context.modules.storefront.StoreFrontData;
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Replace = org.allbinary.logic.@string.regex.replace.Replace;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using RootTransformInfoData = org.allbinary.logic.visual.transform.info.RootTransformInfoData;
using TransformInfoData = org.allbinary.logic.visual.transform.info.TransformInfoData;
using TransformInfoHttp = org.allbinary.logic.visual.transform.info.TransformInfoHttp;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformTemplateFactory = org.allbinary.logic.visual.transform.template.TransformTemplateFactory;
using TransformTemplateInterface = org.allbinary.logic.visual.transform.template.TransformTemplateInterface;
using TransformTemplateCustomizerUtil = org.allbinary.logic.visual.transform.template.util.TransformTemplateCustomizerUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using Document = org.w3c.dom.Document;

namespace org.allbinary.logic.visual.transform.info.objectConfig;

public class GenericStoreTransformInfoObjectConfig : TransformInfoObjectConfig
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly AbeClientInformationInterface abeClientInformation;
    public GenericStoreTransformInfoObjectConfig(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
        this.abeClientInformation = abeClientInformation;
    }

    public GenericStoreTransformInfoObjectConfig(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface, Document document) : base(transformInfoInterface, document)
    {
        // base(transformInfoInterface, document) is called from the constructor declaration
        this.abeClientInformation = abeClientInformation;
        this.setDocument(this.generate(this.toXmlDoc()));
    }

    public GenericStoreTransformInfoObjectConfig(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface, string name, string type) : base(transformInfoInterface, name, type)
    {
        // base(transformInfoInterface, name, type) is called from the constructor declaration
        this.abeClientInformation = abeClientInformation;
        this.setDocument(this.generate(this.toXmlDoc()));
    }

    // throws Exception
    protected virtual Document generate(Document objectConfigDocument)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("TransformInfo: ");
            if (this.getTransformInfoInterface() != null) {
                stringBuffer.append(this.getTransformInfoInterface().getName());
            } else {
                stringBuffer.append("No Owner!?#@");
            }
            this.logUtil.putF(stringBuffer.ToString(), this, "generate()");
        }
        TransformInfoHttp transformInfoHttpStoreInterface = ((TransformInfoHttp) this.getTransformInfoInterface());
        string objectConfigDocumentString = XmlDocumentHelper.toString(objectConfigDocument);
        HashMap<object, object> replaceHashMap = this.createReplaceHashMap(transformInfoHttpStoreInterface, objectConfigDocumentString);
        return this.generate(objectConfigDocumentString, replaceHashMap);
    }

    // throws Exception
    private HashMap<object, object> createReplaceHashMap(TransformInfoHttp transformInfoHttpStoreInterface, string objectConfigDocumentString)
    {
        string storeName = transformInfoHttpStoreInterface.getStoreName();
        HashMap<object, object> hashMap = this.createHashMap(transformInfoHttpStoreInterface, objectConfigDocumentString);
        TransformInfoObjectConfigData transformInfoObjectConfigData = TransformInfoObjectConfigData.getInstance();
        hashMap.put(transformInfoObjectConfigData.VARKEY + StoreFrontData.getInstance().NAME, storeName);
        string pageName = TransformTemplateCustomizerUtil.getInstance().getPageNameHack(this.getTransformInfoInterface().getName(), storeName);
        hashMap.put(transformInfoObjectConfigData.VARKEY + TransformInfoData.getInstance().PARTIAL, pageName);
        return hashMap;
    }

    // throws Exception
    private HashMap<object, object> createHashMap(TransformInfoHttp transformInfoHttpStoreInterface, string objectConfigDocumentString)
    {
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        string storeName = transformInfoHttpStoreInterface.getStoreName();
        HashMap<object, object> propertiesHashMap = transformInfoHttpStoreInterface.getPropertiesHashMap();
        string templateNameOverride = StringUtil.getInstance().getNonNull(((string) propertiesHashMap.get(TransformInfoData.getInstance().PARTIAL)));
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("TemplateNameOverride: " + templateNameOverride, this, "generate()");
        }
        StringMaker templateNameStringBuffer = new StringMaker();
        templateNameStringBuffer.append(storeName);
        templateNameStringBuffer.append(templateNameOverride);
        templateNameStringBuffer.append(CommonSeps.getInstance().SPACE);
        templateNameStringBuffer.append(RootTransformInfoData.NAME);
        string templateNameKey = TransformInfoObjectConfigData.getInstance().VARKEY + TransformInfoData.getInstance().OWNER;
        if (objectConfigDocumentString.IndexOf(templateNameKey) != -1) {
            TransformTemplateInterface templateInterface = TransformTemplateFactory.getInstance().getInstance(this.abeClientInformation, templateNameStringBuffer.ToString(), transformInfoHttpStoreInterface.getPropertiesHashMap(), transformInfoHttpStoreInterface.getPageContext());
            string selectedTemplate = templateInterface.getName();
            hashMap.put(templateNameKey, selectedTemplate);
        }
        return hashMap;
    }

    // throws Exception
    private Document generate(string objectConfigDocumentString, HashMap<object, object> hashMap)
    {
        Replace replace = new Replace(hashMap);
        Document newObjectConfigDocument = DomDocumentHelper.create(replace.all(objectConfigDocumentString));
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Final ObjectConfig: " + XmlDocumentHelper.toString(newObjectConfigDocument), this, "generate()");
        }
        return newObjectConfigDocument;
    }

}

