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
using StoreFrontFactory = org.allbinary.business.context.modules.storefront.StoreFrontFactory;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using StoreFrontView = org.allbinary.business.context.modules.storefront.StoreFrontView;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using Validation = org.allbinary.logic.control.validate.Validation;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace org.allbinary.logic.visual.transform.template.customizer.includes.globals;

public class GlobalsValidation : Validation, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private StoreFrontInterface storeFrontInterface;
    public GlobalsValidation(string storeName)
    {
        this.storeFrontInterface = StoreFrontFactory.getInstance(storeName);
    }

    public GlobalsValidation(Document document)
    {
        throw new Exception(CommonStrings.getInstance().NOT_IMPLEMENTED);
    }

    public override bool? isValid()
    {
        try {
            bool? valid = true;
            return valid;
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
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
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
        Node node = document.createElement(GlobalsData.NAME);
        node.appendChild(new StoreFrontView(this.storeFrontInterface).toXmlNode(document));
        return node;
    }

}

