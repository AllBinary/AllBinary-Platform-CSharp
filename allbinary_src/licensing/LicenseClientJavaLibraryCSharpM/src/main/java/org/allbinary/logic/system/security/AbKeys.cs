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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using AbeLicenseInterfaceFactory = org.allbinary.logic.system.security.licensing.AbeLicenseInterfaceFactory;
using LicensingException = org.allbinary.logic.system.security.licensing.LicensingException;

namespace org.allbinary.logic.system.security;

public class AbKeys
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly AbKeys instance = new AbKeys();
    public static AbKeys getInstance()
    {
        return AbKeys.instance;
    }

    private AbKeys()
    {
    }

    // throws LicensingException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual string getKey(AbeClientInformationInterface abeClientInformation, string keyName)
    {
        try {
            this.logUtil.putF("Getting Key: " + keyName, this, "getKey");
            if (string.CompareOrdinal(keyName, "DirectX 8") == 0 || string.CompareOrdinal(keyName, "DirectX") == 0 || string.CompareOrdinal(keyName, "Low Level") == 0 || string.CompareOrdinal(keyName, "System Drivers") == 0) {
                return "Temp For Input Library";
            }
            return AbeLicenseInterfaceFactory.getInstance().getLicenseInstance(abeClientInformation).getKey(keyName);
        } catch (LicensingException e) {
            throw e;
        } catch (Exception e) {
            this.logUtil.put("Licensing Failure", this, "getKey()", e);
            throw new LicensingException("Unknown License Failure");
        }
    }

}

