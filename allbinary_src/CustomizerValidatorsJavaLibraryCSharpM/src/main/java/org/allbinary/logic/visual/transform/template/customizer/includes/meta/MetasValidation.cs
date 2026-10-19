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
 * II
 * Created By: Travis Berthelot
 *  
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using Validation = org.allbinary.logic.control.validate.Validation;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using HtmlMetaAttributeDataFactory = org.allbinary.logic.visual.dhtml.html.head.meta.HtmlMetaAttributeDataFactory;
using HtmlMetaAttributeValuesData = org.allbinary.logic.visual.dhtml.html.head.meta.HtmlMetaAttributeValuesData;
using HtmlMetasData = org.allbinary.logic.visual.dhtml.html.head.meta.HtmlMetasData;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.transform.template.customizer.includes.meta;

public class MetasValidation : Validation, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private StoreFrontInterface storeFrontInterface;
    private BasicArrayList metaValidationVector;
    public MetasValidation(string storeName)
    {
        this.storeFrontInterface = StoreFrontFactory.getInstance(storeName);
        this.metaValidationVector = new BasicArrayListD();
        string contentValue = this.storeFrontInterface.getName() + " E-Commerce Site";
        MetaValidation keywordsMetaValidation = new MetaValidation(HtmlMetaAttributeDataFactory.getInstance().NAME, "Keywords", HtmlMetaAttributeValuesData.getInstance().KEYWORDS, contentValue);
        MetaValidation abstractMetaValidation = new MetaValidation(HtmlMetaAttributeDataFactory.getInstance().NAME, "Abstract", HtmlMetaAttributeValuesData.getInstance().ABSTRACT, contentValue);
        MetaValidation descriptionMetaValidation = new MetaValidation(HtmlMetaAttributeDataFactory.getInstance().NAME, "Description", HtmlMetaAttributeValuesData.getInstance().DESCRIPTION, contentValue);
        this.metaValidationVector.add(keywordsMetaValidation);
        this.metaValidationVector.add(abstractMetaValidation);
        this.metaValidationVector.add(descriptionMetaValidation);
    }

    public MetasValidation(Document document)
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

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = document.createElement(HtmlMetasData.getInstance().NAME);
        MetaValidation[] metaArray = ((MetaValidation[]) this.metaValidationVector.toArrayType(new MetaValidation[this.metaValidationVector.size()]));
        int size = metaArray.Length;
        for (int i = 0; i < size; i++) {
            MetaValidation metaValidation = metaArray[i];
            node.appendChild(metaValidation.toXmlNode(document));
        }
        return node;
    }

}

