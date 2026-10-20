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
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using Validation = org.allbinary.logic.control.validate.Validation;
using ValidationInterface = org.allbinary.logic.control.validate.ValidationInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StyleData = org.allbinary.logic.visual.dhtml.style.StyleData;
using StylesData = org.allbinary.logic.visual.dhtml.style.StylesData;
using StylesValidationFactory = org.allbinary.logic.visual.dhtml.style.StylesValidationFactory;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.visual.transform.template.customizer.includes.style.css.template.retail;

public class CssStyleValidation : Validation, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public BasicArrayList cssStyleElementVector;
    public CssStyleValidation()
    {
        this.cssStyleElementVector = new BasicArrayListD();
    }

    public CssStyleValidation(Document document)
    {
        this.cssStyleElementVector = StylesValidationFactory.getInstance().getInstance(document);
    }

    public CssStyleValidation(HashMap<object, object> hashMap)
    {
        this.cssStyleElementVector = StylesValidationFactory.getInstance(hashMap);
    }

    public virtual bool? isValid()
    {
        try {
            bool? isValid = true;
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.IS_VALID);
            }
            int size = this.cssStyleElementVector.size();
            for (int i = 0; i < size; i++) {
                ValidationInterface styleValidationInterface = ((ValidationInterface) this.cssStyleElementVector.get(i));
                if (!styleValidationInterface.isValid()) {
                    isValid = false;
                }
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("End: " + isValid, this, this.commonStrings.IS_VALID);
            }
            return isValid;
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
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
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
        Node node = document.createElement(StylesData.getInstance().NAME);
        Node styleNode = document.createElement(StyleData.getInstance().NAME);
        node.appendChild(styleNode);
        int size = this.cssStyleElementVector.size();
        for (int i = 0; i < size; i++) {
            DomNodeInterface styleDomNodeInterface = ((DomNodeInterface) this.cssStyleElementVector.get(i));
            styleNode.appendChild(styleDomNodeInterface.toXmlNode(document));
        }
        return node;
    }

}

