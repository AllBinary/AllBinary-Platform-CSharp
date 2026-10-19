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
using Replace = org.allbinary.logic.@string.regex.replace.Replace;
using TransformInfoData = org.allbinary.logic.visual.transform.info.TransformInfoData;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using TransformInfoObjectConfig = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfig;
using TransformInfoObjectConfigData = org.allbinary.logic.visual.transform.info.objectConfig.TransformInfoObjectConfigData;
using TransformTemplateCustomizerUtil = org.allbinary.logic.visual.transform.template.util.TransformTemplateCustomizerUtil;
using Document = org.w3c.dom.Document;

namespace views.business.context.modules.storefront.customizer.template.objectConfig;

public class NoTemplateTransformInfoObjectConfig : TransformInfoObjectConfig
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public NoTemplateTransformInfoObjectConfig(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    public NoTemplateTransformInfoObjectConfig(TransformInfoInterface transformInfoInterface, Document document) : base(transformInfoInterface, document)
    {
        // base(transformInfoInterface, document) is called from the constructor declaration
        this.setDocument(this.generate(this.toXmlDoc()));
    }

    public NoTemplateTransformInfoObjectConfig(TransformInfoInterface transformInfoInterface, string name, string type) : base(transformInfoInterface, name, type)
    {
        // base(transformInfoInterface, name, type) is called from the constructor declaration
        this.setDocument(this.generate(this.toXmlDoc()));
    }

    // throws Exception
    protected virtual Document generate(Document objectConfigDocument)
    {
        string docString = XmlDocumentHelper.toString(objectConfigDocument);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Initial ObjectConfig: " + docString, this, "generate()");
        }
        string storeName = this.getTransformInfoInterface().getStoreName();
        string viewName = this.getTransformInfoInterface().getName();
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        string VARKEY = TransformInfoObjectConfigData.getInstance().VARKEY;
        hashMap.put(VARKEY + StoreFrontData.getInstance().NAME, storeName);
        hashMap.put(VARKEY + TransformInfoData.getInstance().OWNER, viewName);
        string pageName = TransformTemplateCustomizerUtil.getInstance().getPageNameHack(this.getTransformInfoInterface().getName(), this.getTransformInfoInterface().getStoreName());
        hashMap.put(VARKEY + TransformInfoData.getInstance().PARTIAL, pageName);
        Replace replace = new Replace(hashMap);
        Document newObjectConfigDocument = DomDocumentHelper.create(replace.all(docString));
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Final ObjectConfig: " + XmlDocumentHelper.toString(newObjectConfigDocument), this, "generate()");
        }
        return newObjectConfigDocument;
    }

}

