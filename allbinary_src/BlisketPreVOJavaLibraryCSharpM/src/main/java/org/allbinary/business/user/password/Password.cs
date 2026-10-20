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
using Random = java.util.Random;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using EntryData = org.allbinary.business.entry.EntryData;
using UserData = org.allbinary.business.user.UserData;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SuperCrypt = org.allbinary.logic.control.crypt.SuperCrypt;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.user.password;

public class Password
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string password;
    public Password(string password)
    {
        this.password = password;
    }

    public virtual void set(string value)
    {
        this.password = value;
    }

    public virtual string get()
    {
        return this.password;
    }

    public virtual bool? isValid()
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        try {
            bool? valid = true;
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VALIDATION)) {
                this.logUtil.putF("Password: " + this.password, this, commonStrings.IS_VALID);
            }
            if (!StringValidationUtil.getInstance().isValidRequired(this.password, 6, UserData.MAXLEN)) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VALIDATION)) {
                    this.logUtil.putF("Password is invalid", this, commonStrings.IS_VALID);
                }
                valid = false;
            }
            return valid;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VALIDATIONERROR)) {
                this.logUtil.put("Failed to validate form", "Password", commonStrings.IS_VALID, e);
            }
            return false;
        }
    }

    public virtual string getValidationInfo()
    {
        if (!StringValidationUtil.getInstance().isValidRequired(this.password, 6, UserData.MAXLEN)) {
            return "Please enter a Password with more than 6 characters.<br />";
        }
        StringUtil stringUtil = StringUtil.getInstance();
        return stringUtil.EMPTY_STRING;
    }

    public virtual BasicArrayList toVector(string secret)
    {
        this.password = StringUtil.getInstance().getNonNull(this.password);
        int random = new Random().nextInt(SuperCrypt.KEYMAX);
        BasicArrayList vector = new BasicArrayListD();
        vector.add(random.ToString());
        vector.add(secret);
        vector.add(new SuperCrypt(random).encrypt(this.password));
        return vector;
    }

    public virtual HashMap<object, object> toHashMap(string secret)
    {
        this.password = StringUtil.getInstance().getNonNull(this.password);
        HashMap<object, object> values = StdUtil.getInstance().createHashMap();
        int random = new Random().nextInt(SuperCrypt.KEYMAX);
        values.put(EntryData.getInstance().ENCRYPTION, random.ToString());
        values.put(UserData.SECRET, secret);
        values.put(UserData.PASSWORD, new SuperCrypt(random).encrypt(this.password));
        return values;
    }

}

