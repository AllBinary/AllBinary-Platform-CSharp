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
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using Validation = org.allbinary.logic.control.validate.Validation;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StylesData = org.allbinary.logic.visual.dhtml.style.StylesData;
using BodyData = org.allbinary.logic.visual.transform.template.customizer.bodies.BodyData;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace org.allbinary.logic.visual.transform.template.customizer.includes.style.css;

public class GenericCssStyleValidation : Validation, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public GenericCssStyleValidation()
    {
    }

    public GenericCssStyleValidation(Document document)
    {
        NodeList nodeList = document.getElementsByTagName(StylesData.getInstance().NAME);
    }

    public GenericCssStyleValidation(HashMap<object, object> hashMap)
    {
        this.getFormData(hashMap);
    }

    // throws Exception
    public virtual void getFormData(HashMap<object, object> hashMap)
    {
    }

    public override bool? isValid()
    {
        try {
            bool? isValid = true;
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.IS_VALID);
            }
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("End: " + isValid, this, this.commonStrings.IS_VALID);
            }
            return isValid;
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put("Failed to validate form", this, this.commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public override string validationInfo()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to generate validation error info", this, "validationInfo()", e);
            }
            return "Error Validating Form";
        }
    }

    public override Document toValidationInfoDoc()
    {
        return null;
    }

    public override Node toValidationInfoNode(Document document)
    {
        return null;
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = ModDomHelper.createNameValueNodes(document, BodyData.getInstance().NAME, StringUtil.getInstance().EMPTY_STRING);
        return node;
    }

}

