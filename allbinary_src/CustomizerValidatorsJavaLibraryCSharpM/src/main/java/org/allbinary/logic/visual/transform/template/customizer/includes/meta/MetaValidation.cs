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
 * III
 * Created By: Travis Berthelot
 *  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
using java.util;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using Validation = org.allbinary.logic.control.validate.Validation;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using HtmlMetaAttributeData = org.allbinary.logic.visual.dhtml.html.head.meta.HtmlMetaAttributeData;
using HtmlMetaAttributeDataFactory = org.allbinary.logic.visual.dhtml.html.head.meta.HtmlMetaAttributeDataFactory;
using HtmlMetaData = org.allbinary.logic.visual.dhtml.html.head.meta.HtmlMetaData;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.transform.template.customizer.includes.meta;

public class MetaValidation : Validation, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string label;
    private string name = null;
    private string httpEquiv = null;
    private string content;
    public MetaValidation(HtmlMetaAttributeData htmlMetaAttributeData, string label, string attributeValue, string contentValue)
    {
        this.label = label;
        if (htmlMetaAttributeData.Equals(HtmlMetaAttributeDataFactory.getInstance().HTTP_EQUIV)) {
            this.httpEquiv = attributeValue;
        } else if (htmlMetaAttributeData.Equals(HtmlMetaAttributeDataFactory.getInstance().NAME)) {
            this.name = attributeValue;
        }
        this.content = contentValue;
    }

    public MetaValidation(Document document)
    {
        throw new Exception(CommonStrings.getInstance().NOT_IMPLEMENTED);
    }

    public virtual bool? isValid()
    {
        try {
            bool? valid = true;
            return valid;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put("Failed to validate form", this, this.commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public virtual string validationInfo()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put("Failed to generate validation error info", this, "validationInfo()", e);
            }
            return "Error Validating Form";
        }
    }

    public virtual Document toValidationInfoDoc()
    {
        return null;
    }

    public virtual Node toValidationInfoNode(Document document)
    {
        return null;
    }

    public virtual HashMap<object, object> toHashMap()
    {
        HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
        HtmlMetaAttributeDataFactory htmlMetaAttributeDataFactory = HtmlMetaAttributeDataFactory.getInstance();
        hashMap.put(HtmlMetaData.getInstance().LABEL.ToString(), this.label);
        hashMap.put(htmlMetaAttributeDataFactory.NAME.ToString(), this.name);
        hashMap.put(htmlMetaAttributeDataFactory.HTTP_EQUIV.ToString(), this.httpEquiv);
        hashMap.put(htmlMetaAttributeDataFactory.CONTENT.ToString(), this.content);
        return hashMap;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = ModDomHelper.createNameValueNodes(document, HtmlMetaData.getInstance().NAME.ToString(), this.toHashMap());
        return node;
    }

}

