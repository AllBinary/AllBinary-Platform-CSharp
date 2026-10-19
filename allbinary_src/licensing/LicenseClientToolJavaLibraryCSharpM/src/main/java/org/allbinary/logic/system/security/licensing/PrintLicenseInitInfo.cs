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
using FileFactory = org.allbinary.logic.io.file.FileFactory;
using PATH_GLOBALS = org.allbinary.globals.PATH_GLOBALS;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.logic.system.security.licensing;

public class PrintLicenseInitInfo
{
    public static readonly string PATH = "G:\\mnt\\bc\\mydev\\work\\allbinary_src\\licensing\\data\\";
    public PrintLicenseInitInfo(string[] options)
    {
        LicenseInitInfoUtil.getInstance().setFilePath(PrintLicenseInitInfo.PATH + PATH_GLOBALS.getInstance().INIT_PATH);
    }

    // throws Exception
    public virtual LicenseInitInfo getLicenseInitInfo()
    {
        LicenseInitInfoUtil licenseInitInfoUtil = LicenseInitInfoUtil.getInstance();
        if (FileFactory.getInstance().isFile(licenseInitInfoUtil.getFilePath())) {
            return licenseInitInfoUtil.read();
        } else {
            Console.WriteLine("No Licence File at: " + licenseInitInfoUtil.getFilePath());
            return new LicenseInitInfo();
        }
    }

    public virtual void printInitInfo()
    {
        try {
            LicenseInitInfo licenseInitInfo = this.getLicenseInitInfo();
            Console.WriteLine("License ID: " + licenseInitInfo.getLicenseId());
            BasicArrayList list = licenseInitInfo.getServerList();
            int size = list.size();
            for (int index = 0; index < size; index++) {
                Console.WriteLine("Lic Serv: " + list.get(index));
            }
        } catch (Exception e) {
            Console.Write("Error: " + e);
            Console.WriteLine(e);
        }
    }

    // throws Exception
    public static void main(string[] args)
    {
        PrintLicenseInitInfo initInfo = new PrintLicenseInitInfo(args);
        initInfo.printInitInfo();
    }

}

