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
using UserData = org.allbinary.business.user.UserData;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.user.username;

public class UserName
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly UserName instance = new UserName();
    public static UserName getInstance()
    {
        return UserName.instance;
    }

    private string userName;
    private UserName()
    {
    }

    public UserName(HashMap<object, object> hashMap)
    {
        this.userName = ((string) hashMap.get(UserData.USERNAME));
    }

    public virtual bool? isValid()
    {
        try {
            return this.isValid(this.userName);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put("Failed to validate form", this, "isUserNameValid()", e);
            }
            return false;
        }
    }

    public virtual string get()
    {
        return this.userName;
    }

    public virtual bool? isValid(string aUserName)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        try {
            BooleanFactory booleanFactory = BooleanFactory.getInstance();
            bool? valid = booleanFactory.TRUE;
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VALIDATION)) {
                this.logUtil.putF("UserName: " + aUserName, this, commonStrings.IS_VALID);
            }
            if (!StringValidationUtil.getInstance().isValidRequired(aUserName, 5, UserData.MAXLEN)) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VALIDATION)) {
                    this.logUtil.putF("UserName is invalid", this, commonStrings.IS_VALID);
                }
                valid = booleanFactory.FALSE;
            }
            return valid;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put("Failed to validate form", this, commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public static string getValidationInfo(string aUserName)
    {
        if (!StringValidationUtil.getInstance().isValidRequired(aUserName, 5, UserData.MAXLEN)) {
            return "Please enter a User Name with more than 5 characters.<br/>";
        }
        return StringUtil.getInstance().EMPTY_STRING;
    }

}

