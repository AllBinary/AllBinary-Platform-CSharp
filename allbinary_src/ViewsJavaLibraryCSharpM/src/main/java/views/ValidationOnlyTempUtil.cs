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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationComponentInterface = org.allbinary.logic.control.validate.ValidationComponentInterface;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace views;

//Replace when validation node is added
public class ValidationOnlyTempUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ValidationOnlyTempUtil instance = new ValidationOnlyTempUtil();
    public static ValidationOnlyTempUtil getInstance()
    {
        return ValidationOnlyTempUtil.instance;
    }

    private ValidationOnlyTempUtil()
    {
    }

    // throws Exception
    public virtual string view(ValidationComponentInterface validationComponentInterface)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEW)) {
                this.logUtil.putF("View Name: " + validationComponentInterface.getTransformInfoInterface().getName(), this, "view()");
            }
            return StringUtil.getInstance().EMPTY_STRING;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

}

