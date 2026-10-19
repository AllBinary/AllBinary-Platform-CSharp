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
//using BufferedReader = java.io.BufferedReader;
//using InputStreamReader = java.io.InputStreamReader;
using LicenseInitInfo = org.allbinary.business.init.LicenseInitInfo;
using LicenseInitInfoUtil = org.allbinary.business.init.LicenseInitInfoUtil;
using FileFactory = org.allbinary.logic.io.file.FileFactory;
using PATH_GLOBALS = org.allbinary.globals.PATH_GLOBALS;
//using File = java.io.File;
//using FileReader = java.io.FileReader;
//using LineNumberReader = java.io.LineNumberReader;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.logic.system.security.licensing;

public class SetLicenseInitInfo
{
    private static BufferedReader stdinput = new BufferedReader(new InputStreamReader(System.@in));
    private BasicArrayList vector = new BasicArrayListD();
    public SetLicenseInitInfo(string[] options)
    {
        LicenseInitInfoUtil.getInstance().setFilePath(PrintLicenseInitInfo.PATH + PATH_GLOBALS.getInstance().INIT_PATH);
        for (int index = 1; index < options.Length; index++) {
            this.vector.add(options[index]);
        }
    }

    // throws Exception
    public virtual LicenseInitInfo getLicenseInitInfo()
    {
        LicenseInitInfoUtil licenseInitInfoUtil = LicenseInitInfoUtil.getInstance();
        if (FileFactory.getInstance().isFile(licenseInitInfoUtil.INITFILENAME)) {
            return licenseInitInfoUtil.read();
        } else {
            return new LicenseInitInfo();
        }
    }

    public virtual void createNewLicenseInitInfo(BasicArrayList licenceServerVector)
    {
        try {
            if (licenceServerVector == null) {
                throw new Exception("null BasicArrayList Passed - Just Make Empty if you want");
            }
            LicenseInitInfo licenseInitInfo = this.getLicenseInitInfo();
            Console.WriteLine("License Serv Example: http://www.dartstatistics.com/LicServ/serverssl.php");
            licenseInitInfo.clearServers();
            File file = new File(PrintLicenseInitInfo.PATH + "licenseservers.txt");
            FileReader reader = new FileReader(file);
            LineNumberReader lineNumberReader = new LineNumberReader(reader);
            while (true) {
                string line = lineNumberReader.readLine();
                if (line != null) {
                    licenseInitInfo.addServer(line);
                } else {
                    break;
                }
            }
            LicenseInitInfoUtil.getInstance().write(licenseInitInfo);
            LicenseInitInfoUtil.getInstance().read();
        } catch (Exception e) {
            Console.Write("Error: " + e);
            Console.WriteLine(e);
        }
    }

    // throws Exception
    public static void main(string[] args)
    {
        SetLicenseInitInfo initInfo = new SetLicenseInitInfo(args);
        initInfo.createNewLicenseInitInfo(new BasicArrayListD());
    }

}

