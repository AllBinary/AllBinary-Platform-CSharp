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
//using ByteArrayInputStream = java.io.ByteArrayInputStream;
//using InputStream = java.io.InputStream;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using DocumentToNode = org.allbinary.data.tree.dom.document.DocumentToNode;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Replace = org.allbinary.logic.@string.regex.replace.Replace;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using TransformFactory = org.allbinary.logic.visual.transform.TransformFactory;
using TransformInterface = org.allbinary.logic.visual.transform.TransformInterface;
using RootTransformInfoData = org.allbinary.logic.visual.transform.info.RootTransformInfoData;
using TransformInfoData = org.allbinary.logic.visual.transform.info.TransformInfoData;
using TransformInfoDomNode = org.allbinary.logic.visual.transform.info.TransformInfoDomNode;
using TransformInfoHttpInterface = org.allbinary.logic.visual.transform.info.TransformInfoHttpInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using GenericStoreTransformInfoObjectConfig = org.allbinary.logic.visual.transform.info.objectConfig.GenericStoreTransformInfoObjectConfig;
using CommonSeps = org.allbinary.@string.CommonSeps;
using Document = org.w3c.dom.Document;

namespace views.compound.objectConfig;

public class CompoundContextTransformInfoObjectConfig : GenericStoreTransformInfoObjectConfig
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public CompoundContextTransformInfoObjectConfig(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface) : base(abeClientInformation, transformInfoInterface)
    {
        // base(abeClientInformation, transformInfoInterface) is called from the constructor declaration
    }

    public CompoundContextTransformInfoObjectConfig(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface, Document document) : base(abeClientInformation, transformInfoInterface, document)
    {
        // base(abeClientInformation, transformInfoInterface, document) is called from the constructor declaration
        this.setDocument(this.generate(this.toXmlDoc()));
    }

    public CompoundContextTransformInfoObjectConfig(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface, string name, string type) : base(abeClientInformation, transformInfoInterface, name, type)
    {
        // base(abeClientInformation, transformInfoInterface, name, type) is called from the constructor declaration
        this.setDocument(this.generate(this.toXmlDoc()));
    }

    // throws Exception
    public virtual string get()
    {
        string storeName = this.getTransformInfoInterface().getStoreName();
        TransformInfoHttpInterface httpTransformInfoInterface = ((TransformInfoHttpInterface) this.getTransformInfoInterface());
        string templateNameOverride = StringUtil.getInstance().getNonNull(((string) httpTransformInfoInterface.getPropertiesHashMap().get(TransformInfoData.getInstance().PARTIAL)));
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(storeName);
        stringBuffer.append(templateNameOverride);
        stringBuffer.append(CommonSeps.getInstance().SPACE);
        stringBuffer.append(RootTransformInfoData.NAME);
        TransformInterface rootComponentInterface = TransformFactory.getInstance().getInstance(abeClientInformation, stringBuffer.ToString(), this.getTransformInfoInterface());
        BasicArrayList viewVector = this.getTransformDomNodes();
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Root View Called with: " + viewVector.size(), this, "get(transformInfoInterface)");
        }
        string rootView = rootComponentInterface.view();
        string startXMLHeader = "<xsl:text disable-output-escaping=\"yes\" ><![CDATA[";
        string endXMLHeader = "]]></xsl:text>";
        int size = viewVector.size();
        for (int index = 0; index < size; index++) {
            TransformInfoDomNode objectConfigTransformInfoDomNode = ((TransformInfoDomNode) viewVector.get(index));
            string templateKey = objectConfigTransformInfoDomNode.getReplaceKey();
            TransformInterface componentInterface = TransformFactory.getInstance().getInstance(abeClientInformation, objectConfigTransformInfoDomNode.getTransformInfoInterface().getName(), this.getTransformInfoInterface());
            string replacementViewString = componentInterface.view();
            replacementViewString = DocumentToNode.convertDocumentToNodeString(replacementViewString);
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append(startXMLHeader);
            stringBuffer.append(replacementViewString);
            stringBuffer.append(endXMLHeader);
            string templateValue = stringBuffer.ToString();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                stringBuffer.delete(0, stringBuffer.length());
                stringBuffer.append("Replacing: ");
                stringBuffer.append(templateKey);
                stringBuffer.append(" with ");
                stringBuffer.append(templateValue);
                this.logUtil.putF(stringBuffer.ToString(), this, "get()");
            }
            Replace replace = new Replace(templateKey, templateValue);
            rootView = replace.all(rootView);
        }
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("End: Result of a compound view: " + rootView, this, "get()");
        }
        return rootView;
    }

    // throws Exception
    public virtual InputStream createInputStream()
    {
        sbyte[] completeTemplateViewBytes = this.get().getBytes();
        ByteArrayInputStream bais = new ByteArrayInputStream(completeTemplateViewBytes);
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Template: " + System.Text.Encoding.UTF8.GetString((byte[]) (Array) completeTemplateViewBytes).ToString(), this, "createInputStream()");
        }
        return bais;
    }

}

