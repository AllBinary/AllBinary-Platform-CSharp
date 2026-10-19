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
using LicenseInitInfoUtil = org.allbinary.business.init.LicenseInitInfoUtil;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using PartnerIdentifierFileUtil = org.allbinary.logic.system.security.licensing.PartnerIdentifierFileUtil;

namespace org.allbinary;

public class AllBinaryAndroidGameInitializationUtil
{
    public static void init()
    {
        ResourceUtil resourceUtil = ResourceUtil.getInstance();
        AndroidResources androidResources = AndroidResources.getInstance();
        LicenseInitInfoUtil licenseInitInfoUtil = LicenseInitInfoUtil.getInstance();
        resourceUtil.addResource(licenseInitInfoUtil.INITFILENAME, (androidResources.raw.licenseinitdata).ToString());
        resourceUtil.addResource(PartnerIdentifierFileUtil.getInstance().FILE_NAME, (androidResources.raw.partner).ToString());
    }

}

