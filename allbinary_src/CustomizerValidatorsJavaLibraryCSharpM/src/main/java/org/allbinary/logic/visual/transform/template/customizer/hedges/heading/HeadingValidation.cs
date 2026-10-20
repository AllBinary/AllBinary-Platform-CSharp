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
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using Validation = org.allbinary.logic.control.validate.Validation;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using LogoData = org.allbinary.logic.visual.transform.template.customizer.widgets.logo.LogoData;
using LogoValidation = org.allbinary.logic.visual.transform.template.customizer.widgets.logo.LogoValidation;
using TitleData = org.allbinary.logic.visual.transform.template.customizer.widgets.title.TitleData;
using TitleValidation = org.allbinary.logic.visual.transform.template.customizer.widgets.title.TitleValidation;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.logic.visual.transform.template.customizer.hedges.heading;

public class HeadingValidation : Validation, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private TitleValidation title;
    private LogoValidation logo;
    public HeadingValidation()
    {
        this.title = new TitleValidation();
        this.logo = new LogoValidation();
    }

    public HeadingValidation(Document document)
    {
        NodeList headingNodeList = document.getElementsByTagName(HeadingData.NAME);
        Node titleNode = DomSearchHelper.getNode(TitleData.getInstance().NAME, headingNodeList.item(0).getChildNodes());
        Node logoNode = DomSearchHelper.getNode(LogoData.getInstance().NAME, headingNodeList.item(0).getChildNodes());
        this.title = new TitleValidation(titleNode);
        this.logo = new LogoValidation(logoNode);
    }

    public HeadingValidation(HashMap<object, object> hashMap)
    {
        this.getFormData(hashMap);
    }

    // throws Exception
    public virtual void getFormData(HashMap<object, object> hashMap)
    {
        this.title = new TitleValidation(hashMap);
        this.logo = new LogoValidation(hashMap);
    }

    public virtual bool? isValid()
    {
        try {
            bool? valid = true;
            bool? titleValid = true;
            bool? logoValid = true;
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.IS_VALID);
            }
            if (!this.title.isValid()) {
                titleValid = false;
            }
            if (!this.logo.isValid()) {
                logoValid = false;
            } else {
                this.logo.processLogoFile();
            }
            if (!titleValid && !logoValid) {
                valid = false;
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("HeadingValidation: " + valid, this, this.commonStrings.IS_VALID);
            }
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
            bool? valid = true;
            bool? titleValid = true;
            bool? logoValid = true;
            StringMaker stringBuffer = new StringMaker();
            if (!this.title.isValid()) {
                titleValid = false;
            }
            if (!this.logo.isValid()) {
                logoValid = false;
            }
            if (!titleValid && !logoValid) {
                valid = false;
            }
            if (!valid) {
                stringBuffer.append("Include a title and/or logo for the header.");
            }
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
        Node node = document.createElement(HeadingData.NAME);
        node.appendChild(this.logo.toXmlNode(document));
        node.appendChild(this.title.toXmlNode(document));
        return node;
    }

}

