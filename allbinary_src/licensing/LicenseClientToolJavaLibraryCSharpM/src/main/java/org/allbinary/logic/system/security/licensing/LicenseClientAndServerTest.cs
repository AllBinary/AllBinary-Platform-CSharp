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
//using File = java.io.File;
//using FileReader = java.io.FileReader;
//using LineNumberReader = java.io.LineNumberReader;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using LicenseInitInfo = org.allbinary.business.init.LicenseInitInfo;
using LicenseInitInfoUtil = org.allbinary.business.init.LicenseInitInfoUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using XmlRpcAbeLicenseRetrievalClient = org.allbinary.logic.system.security.licensing.client.XmlRpcAbeLicenseRetrievalClient;
using PATH_GLOBALS = org.allbinary.globals.PATH_GLOBALS;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.logic.system.security.licensing;

public class LicenseClientAndServerTest
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private BasicArrayList vector = new BasicArrayListD();
    public LicenseClientAndServerTest(string[] options)
    {
        LicenseInitInfoUtil.getInstance().setFilePath(PrintLicenseInitInfo.PATH + PATH_GLOBALS.getInstance().INIT_PATH);
        for (int index = 1; index < options.Length; index++) {
            this.vector.add(options[index]);
        }
        if (options.Length < 2) {
            File file = new File(PrintLicenseInitInfo.PATH + "testlicenseservers.txt");
            FileReader reader = new FileReader(file);
            LineNumberReader lineNumberReader = new LineNumberReader(reader);
            while (true) {
                string line = lineNumberReader.readLine();
                if (line != null) {
                    this.vector.add(line);
                } else {
                    break;
                }
            }
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void test()
    {
        StringMaker stringBuffer = new StringMaker();
        try {
            BasicArrayList list = new BasicArrayListD();
            string TESTING = "Testing with new licence:<br/>";
            string PROCESSING = "Processing: <br/>";
            string END = "<br/>End<br/>";
            string RESULT = "Test Result: ";
            int size = this.vector.size();
            for (int index = 0; index < size; index++) {
                stringBuffer.append(TESTING);
                string serverName = ((string) this.vector.get(index));
                try {
                    LicenseInitInfo licenseInitInfo = new LicenseInitInfo();
                    licenseInitInfo.addServer(serverName);
                    LicenseInitInfoUtil.getInstance().write(licenseInitInfo);
                    AbeClientInformationInterface abeClientInformation = AbeClientInformationInterfaceFactory.getInstance();
                    XmlRpcAbeLicenseRetrievalClient xmlRpcAbeLicenseClient = new XmlRpcAbeLicenseRetrievalClient(abeClientInformation);
                    AbeLicenseInterface abeLicenseInterface = ((AbeLicenseInterface) xmlRpcAbeLicenseClient.get(null));
                    if (abeLicenseInterface != null) {
                        stringBuffer.append(PROCESSING);
                        stringBuffer.append(abeLicenseInterface.ToString());
                    }
                    stringBuffer.append(END);
                    this.logUtil.putF(RESULT + stringBuffer.ToString(), this, "test");
                    stringBuffer.delete(0, stringBuffer.length());
                } catch (Exception e) {
                    list.add(serverName);
                    this.logUtil.put("Test Error: " + stringBuffer.ToString(), this, "test", e);
                }
            }
            this.logUtil.putF("Total Servers Failed: " + list.size() + " Failed Servers: " + list.ToString(), this, "test");
        } catch (Exception e) {
            this.logUtil.put("Test Error: " + stringBuffer.ToString(), this, "test", e);
        }
    }

    public static void main(string[] args)
    {
        try {
            LicenseClientAndServerTest licensingTest = new LicenseClientAndServerTest(args);
            licensingTest.test();
        } catch (Exception e) {
            LogUtil logUtil = LogUtil.getInstance();
            this.logUtil.put(this.commonStrings.EXCEPTION, "main()", "main()", e);
        }
    }

}

