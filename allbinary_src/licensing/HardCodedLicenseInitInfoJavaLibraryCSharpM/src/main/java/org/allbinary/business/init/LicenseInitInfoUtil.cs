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

namespace org.allbinary.business.init;

public class LicenseInitInfoUtil
{
    private static readonly LicenseInitInfoUtil instance = new LicenseInitInfoUtil();
    public static LicenseInitInfoUtil getInstance()
    {
        return LicenseInitInfoUtil.instance;
    }

    public readonly string INITFILENAME = "licenseinitdata.dat";
    public readonly string ABOUT = "about";
    public readonly string PRIVACY_POLICY = "privacy_policy";
    private readonly string OFFICIAL_ALLBINARY_SERVICES_SERVER = "https://services.allbinary.com/LicServ/serverssl.php";
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void setFilePath(string filePath)
    {
    }

    private LicenseInitInfoUtil()
    {
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void write(LicenseInitInfo initData)
    {
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual LicenseInitInfo read()
    {
        return this.readAgain(0);
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual LicenseInitInfo readAgain(int initializeCounter)
    {
        LicenseInitInfo licenseInitInfo = new LicenseInitInfo();
        licenseInitInfo.clearServers();
        licenseInitInfo.addServer(this.OFFICIAL_ALLBINARY_SERVICES_SERVER);
        return licenseInitInfo;
    }

}

