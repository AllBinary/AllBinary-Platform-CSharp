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
//using PageContext = javax.servlet.jsp.PageContext;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace taghelpers;

public class ValidationViewHelper : ViewHelper, ValidationComponentInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private ValidationComponentInterface viewInterface;
    public ValidationViewHelper(HashMap<object, object> hashMap, PageContext pageContext) : base(hashMap, pageContext)
    {
        // base(hashMap, pageContext) is called from the constructor declaration
        this.viewInterface = ((ValidationComponentInterface) this.getViewObject());
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        }
    }

    public virtual bool? isValid()
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPER)) {
                this.logUtil.putF("Started", this, this.commonStrings.IS_VALID);
            }
            return this.viewInterface.isValid();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public virtual string validationInfo()
    {
        try {
            return this.viewInterface.validationInfo();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "validationInfo()", e);
            }
            return "Unknown Validation Error";
        }
    }

    public virtual Document toValidationInfoDoc()
    {
        try {
            return this.viewInterface.toValidationInfoDoc();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "toValidationInfoDoc()", e);
            }
            return null;
        }
    }

    public virtual Node toValidationInfoNode(Document document)
    {
        try {
            return this.viewInterface.toValidationInfoNode(document);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "toValidationInfoNode()", e);
            }
            return null;
        }
    }

}

