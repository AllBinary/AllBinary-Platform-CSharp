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
//using IOException = java.io.IOException;
//using Calendar = java.util.Calendar;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbeLicenseClient = org.allbinary.logic.system.security.licensing.client.AbeLicenseClient;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.system.security.licensing;

public class AbeLicenseInterfaceFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly AbeLicenseInterfaceFactory SINGLETON = new AbeLicenseInterfaceFactory();
    public static AbeLicenseInterfaceFactory getInstance()
    {
        return AbeLicenseInterfaceFactory.SINGLETON;
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private long time = 0L;
    private bool check = false;
    private int checkPeriod = 36000000;
    private AbeLicenseInterface abeLicenseInterface = null;
    private AbeLicenseInterfaceFactory()
    {
    }

    // throws LicensingException
    public virtual AbeLicenseInterface getLicenseInstance(AbeClientInformationInterface abeClientInformation)
    {
        if (isTimeToGetKey()) {
            return this.get(abeClientInformation);
        } else {
            return this.abeLicenseInterface;
        }
    }

    // throws LicensingException
    private AbeLicenseInterface get(AbeClientInformationInterface abeClientInformation)
    {
        try {
            this.logUtil.putF("Getting Keys", this, this.commonStrings.GET);
            this.abeLicenseInterface = AbeNoLicense.getInstance();
            AbeLicenseClient licenseClient = new AbeLicenseClient();
            this.abeLicenseInterface = licenseClient.get(abeClientInformation);
            if (this.abeLicenseInterface != null) {
                this.logUtil.putF("Default Key: " + this.abeLicenseInterface.getKey(AbeClientInformationData.getInstance().KEY), this, this.commonStrings.GET);
            }
            return this.abeLicenseInterface;
        } catch (IOException e) {
            this.logUtil.put("Licensing IO Error", this, this.commonStrings.GET, e);
            throw new LicensingException("License Server Connection Error");
        } catch (Exception e) {
            this.logUtil.put("Licensing Failure", this, this.commonStrings.GET, e);
            throw new LicensingException("Unknown License Failure: " + this.GetType().FullName);
        }
    }

    private bool isTimeToGetKey()
    {
        Calendar calendar = Calendar.getInstance();
        long currentTime = calendar.getTimeInMillis();
        if (this.abeLicenseInterface == null || this.abeLicenseInterface == AbeNoLicense.getInstance() || !this.abeLicenseInterface.hasKey() || isCheck() || currentTime - ((long) checkPeriod) > time) {
            this.abeLicenseInterface = null;
            this.time = currentTime;
            return true;
        } else {
            return false;
        }
    }

    public virtual void setCheck(bool check)
    {
        this.check = check;
    }

    private bool isCheck()
    {
        return this.check;
    }

}

