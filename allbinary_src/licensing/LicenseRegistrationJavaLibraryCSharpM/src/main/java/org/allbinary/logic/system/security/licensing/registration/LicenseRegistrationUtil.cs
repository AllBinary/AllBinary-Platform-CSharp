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
using CommonStrings = org.allbinary.@string.CommonStrings;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using SpecialMessageUtil = org.allbinary.canvas.SpecialMessageUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using org.allbinary.util;

namespace org.allbinary.logic.system.security.licensing.registration;

public class LicenseRegistrationUtil
{
    private LicenseRegistrationUtil()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void process(AbeClientInformationInterface abeClientInformation, string registrationId)
    {
        try {
            CommonStrings commonStrings = CommonStrings.getInstance();
            PreLogUtil.put(CommonLabels.getInstance().START_LABEL + "License Registration", "LicenseRegistrationUtil", commonStrings.PROCESS);
            RegistrationConfiguration registrationConfiguration = RegistrationConfiguration.getInstance();
            registrationConfiguration.setRegistrationCode(registrationId);
            registrationConfiguration.write();
            ABHashtable<object, object> hashtable = abeClientInformation.toHashtable();
            hashtable.put(RegistrationConfiguration.getInstance().NAME, registrationId);
            hashtable.put("message", SpecialMessageUtil.getInstance().get());
            new XmlRpcRemoteLicenseRegistrationClient(abeClientInformation).get(hashtable);
        } catch (Exception e) {
            PreLogUtil.putOE("License Registration Exception", "LicenseRegistrationUtil", "License Registration", e);
        }
    }

}

