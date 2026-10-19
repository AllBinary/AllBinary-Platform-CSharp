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
using System.Runtime.CompilerServices;
using LicenseInitInfo = org.allbinary.business.init.LicenseInitInfo;
using LicenseInitInfoUtil = org.allbinary.business.init.LicenseInitInfoUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using XmlRpcAbeClient = org.allbinary.logic.communication.xmlrpc.XmlRpcAbeClient;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using AbeLicenseInterface = org.allbinary.logic.system.security.licensing.AbeLicenseInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.logic.system.security.licensing.client;

public class AbeLicenseClient
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly int MINSERVERS = 3;
    public AbeLicenseClient()
    {
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual AbeLicenseInterface get(AbeClientInformationInterface abeClientInformation)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.GET);
            XmlRpcAbeClient xmlRpcAbeLicenseClient = new XmlRpcAbeLicenseRetrievalClient(abeClientInformation);
            AbeLicenseInterface abeLicenseInterface = ((AbeLicenseInterface) xmlRpcAbeLicenseClient.get(null));
            string licenseId = abeLicenseInterface.getLicenseId();
            BasicArrayList servers = abeLicenseInterface.getServers();
            bool isNewLicenseId = false;
            bool isBetterServerList = false;
            StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
            if (stringValidationUtil.isEmpty(abeClientInformation.getLicenseId()) && !abeClientInformation.isSameId(licenseId)) {
                isNewLicenseId = true;
            }
            if (servers.size() >= this.MINSERVERS && abeClientInformation.isLargerOrDifferentServerList(servers)) {
                isBetterServerList = true;
            }
            if (isBetterServerList || isNewLicenseId) {
                LicenseInitInfo initInfo = LicenseInitInfoUtil.getInstance().read();
                initInfo.setLicenseId(licenseId);
                initInfo.setServerList(servers);
                LicenseInitInfoUtil.getInstance().write(initInfo);
                abeClientInformation.init();
            }
            this.logUtil.putF(this.commonStrings.END, this, this.commonStrings.GET);
            return abeLicenseInterface;
        } catch (Exception e) {
            throw e;
        }
    }

}

