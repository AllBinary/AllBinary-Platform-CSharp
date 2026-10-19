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

namespace org.allbinary.logic.visual.transform.template.customizer.widgets.title;

public class TitleNotRequiredValidation : TitleView, ValidationInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public TitleNotRequiredValidation() : base()
    {
        // base() is called from the constructor declaration
    }

    public TitleNotRequiredValidation(Node node) : base(node)
    {
        // base(node) is called from the constructor declaration
    }

    public TitleNotRequiredValidation(HashMap hashMap) : base(hashMap)
    {
        // base(hashMap) is called from the constructor declaration
    }

    public virtual bool? isValid()
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.IS_VALID);
            }
            bool? valid = true;
            if (!StringValidationUtil.getInstance().isValidNotRequired(this.getTitle(), 0, TitleData.getInstance().MAXLEN)) {
                valid = false;
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Title: ");
                stringBuffer.append(this.getTitle());
                stringBuffer.append("End: ");
                stringBuffer.appendboolean(valid);
                this.logUtil.putF(stringBuffer.ToString(), this, this.commonStrings.IS_VALID);
            }
            return valid;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
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

}

