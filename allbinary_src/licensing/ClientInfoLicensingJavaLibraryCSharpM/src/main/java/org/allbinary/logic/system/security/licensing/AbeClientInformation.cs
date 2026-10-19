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
using LicenseInitInfo = org.allbinary.business.init.LicenseInitInfo;
using LicenseInitInfoUtil = org.allbinary.business.init.LicenseInitInfoUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using OperatingSystemFactory = org.allbinary.logic.system.os.OperatingSystemFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.security.licensing;

// This is the information sent to the license server
public class AbeClientInformation : ClientInformation
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public AbeClientInformation(string name, string version, string specialName, string shortName) : base(name, version, specialName, shortName)
    {
        // base(name, version, specialName, shortName) is called from the constructor declaration
    }

    public override void init()
    {
        try {
            this.setOperatingSystemInterface(OperatingSystemFactory.getInstance().getOperatingSystemInstance());
            LicenseInitInfo licenseInitInfo = LicenseInitInfoUtil.getInstance().read();
            this.setLicenseId(licenseInitInfo.getLicenseId());
            this.setLicenseServers(licenseInitInfo.getServerList());
            StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
            if (stringValidationUtil.isEmpty(this.getLicenseId())) {
                string NONE = "No License Id";
                this.setLicenseId(NONE);
            }
            CommonStrings commonStrings = CommonStrings.getInstance();
            PreLogUtil.put(new StringMaker().append("Special Name: ").append(this.getSpecialName()).ToString(), this, commonStrings.CONSTRUCTOR);
        } catch (Exception e) {
            LogUtil logUtil = LogUtil.getInstance();
            CommonStrings commonStrings = CommonStrings.getInstance();
            logUtil.put(commonStrings.EXCEPTION, this, commonStrings.CONSTRUCTOR, e);
        }
    }

}

