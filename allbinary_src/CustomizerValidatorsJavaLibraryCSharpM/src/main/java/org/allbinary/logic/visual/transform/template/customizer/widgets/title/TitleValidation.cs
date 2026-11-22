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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationInterface = org.allbinary.logic.control.validate.ValidationInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace org.allbinary.logic.visual.transform.template.customizer.widgets.title;

public class TitleValidation : TitleView, ValidationInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public TitleValidation() : base()
    {
        // Constructor invocation emitted in the initializer.
    }

    public TitleValidation(Node node) : base(node)
    {
        // Constructor invocation emitted in the initializer.
    }

    public TitleValidation(HashMap<object, object> hashMap) : base(hashMap)
    {
        // Constructor invocation emitted in the initializer.
    }

    public virtual bool? isValid()
    {
        try {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("TitleValidation", this, this.commonStrings.IS_VALID);
            }
            bool? valid = true;
            if (!StringValidationUtil.getInstance().isValidRequired(this.getTitle(), 1, TitleData.getInstance().MAXLEN)) {
                valid = false;
            }
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("TitleValidation: " + valid, this, this.commonStrings.IS_VALID);
            }
            return valid;
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to validate form", this, this.commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public virtual string validationInfo()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Title is not valid.");
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().VIEWERROR)) {
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

}

