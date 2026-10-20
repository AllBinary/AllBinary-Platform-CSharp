/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2011 AllBinary
 * 
 * By agreeing to this license you and any business entity you represent are
 * legally bound to the AllBinary Open License Version 1 leIIgal agreement.
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
using DomData = org.allbinary.data.tree.dom.DomData;
using DomNodeHelper = org.allbinary.data.tree.dom.DomNodeHelper;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbSqlData = org.allbinary.logic.communication.sql.AbSqlData;
using Validation = org.allbinary.logic.control.validate.Validation;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using BodyData = org.allbinary.logic.visual.transform.template.customizer.bodies.BodyData;
using TitleData = org.allbinary.logic.visual.transform.template.customizer.widgets.title.TitleData;
using TitleNotRequiredValidation = org.allbinary.logic.visual.transform.template.customizer.widgets.title.TitleNotRequiredValidation;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.logic.visual.transform.template.customizer.bodies.title;

public class TitleBodyValidation : Validation, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string body;
    private TitleNotRequiredValidation titleValidation;
    public TitleBodyValidation()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        }
        StringUtil stringUtil = StringUtil.getInstance();
        this.body = stringUtil.EMPTY_STRING;
        this.titleValidation = new TitleNotRequiredValidation();
    }

    public TitleBodyValidation(Document document)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF(this.commonStrings.CONSTRUCTOR, this, "Constructor(document)");
        }
        NodeList nodeList = document.getElementsByTagName(BodyData.getInstance().NAME);
        for (int index = 0; index < nodeList.getLength(); index++) {
            Node aBodyNode = nodeList.item(index);
            Node aBodyValueNode = DomSearchHelper.getNode(DomData.VALUE, aBodyNode.getChildNodes());
            this.body = DomNodeHelper.getTextNodeValue(aBodyValueNode);
            Node titleNode = DomSearchHelper.getNode(TitleData.getInstance().NAME, aBodyNode.getChildNodes());
            this.titleValidation = new TitleNotRequiredValidation(titleNode);
            if (index > 1) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                    this.logUtil.putF("To Many Body Nodes", this, this.commonStrings.CONSTRUCTOR);
                }
            }
        }
    }

    public TitleBodyValidation(HashMap<object, object> hashMap)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF(this.commonStrings.START, this, "Constructor(hashmap)");
        }
        this.getFormData(hashMap);
    }

    // throws Exception
    public virtual void getFormData(HashMap<object, object> hashMap)
    {
        this.body = ((string) hashMap.get(BodyData.getInstance().NAME));
        this.titleValidation = new TitleNotRequiredValidation(hashMap);
    }

    public virtual bool? isValid()
    {
        try {
            bool? isValid = true;
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("TitleBodyValidation", this, this.commonStrings.IS_VALID);
            }
            if (!StringValidationUtil.getInstance().isValidNotRequired(this.body, BodyData.getInstance().MIN, AbSqlData.MAXBLOB)) {
                isValid = false;
            }
            if (!this.titleValidation.isValid()) {
                isValid = false;
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("TitleBodyValidation: " + isValid, this, this.commonStrings.IS_VALID);
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
            {
                stringBuffer.append("Error: Data submitted is < ");
                stringBuffer.appendint(((int) BodyData.getInstance().MIN));
                stringBuffer.append(" or > ");
                stringBuffer.appendint(((int) AbSqlData.MAXBLOB));
            }
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
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
            this.logUtil.putF("Title Body: " + this.body, this, "toXmlNode(document)");
        }
        Node node = ModDomHelper.createNameValueNodes(document, BodyData.getInstance().NAME, this.body);
        node.appendChild(this.titleValidation.toXmlNode(document));
        return node;
    }

}

