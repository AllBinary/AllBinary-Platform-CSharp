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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using RegistrationConfiguration = org.allbinary.logic.system.security.licensing.registration.RegistrationConfiguration;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;

namespace org.allbinary.logic.system.security.licensing;

public class MobileClientInformation : AbeClientInformation
{
    public static readonly string DESC = "Mobile";
    public static readonly string ANDROID_DESC = "Android" + MobileClientInformation.DESC;
    public MobileClientInformation(string name, string version, string specialName, string shortName) : base(name, version, new StringMaker().append(specialName).append(CommonSeps.getInstance().SPACE).append(PartnerIdentifierFileUtil.getInstance().get()).ToString(), shortName)
    {
        // base(name, version, new StringMaker().append(specialName).append(CommonSeps.getInstance().SPACE).append(PartnerIdentifierFileUtil.getInstance().get()).ToString(), shortName) is called from the constructor declaration
        string @string = this.getSpecialName();
        string number = @string.Substring(@string.Length - 1);
        if (Integer.getInteger(number) == null) {
            this.setHardSale(false);
        }
        CommonStrings commonStrings = CommonStrings.getInstance();
        if (this.isHardSale()) {
            this.logUtil.putF("Use Hard Coded Selling", this, commonStrings.CONSTRUCTOR);
        } else {
            this.logUtil.putF("Don't Use Hard Coded Selling", this, commonStrings.CONSTRUCTOR);
        }
    }

    public override ABHashtable<object, object> toHashtable()
    {
        ABHashtable<object, object> hashtable = base.toHashtable();
        RegistrationConfiguration registrationConfiguration = RegistrationConfiguration.getInstance();
        hashtable.put(registrationConfiguration.NAME, registrationConfiguration.getRegistrationCode());
        return hashtable;
    }

}

