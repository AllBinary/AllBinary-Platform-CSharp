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
using TsUtil = org.allbinary.TsUtil;
using PATH_GLOBALS = org.allbinary.globals.PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbDataInputStream = org.allbinary.logic.io.AbDataInputStream;
using AbDataOutputStream = org.allbinary.logic.io.AbDataOutputStream;
using AbFileInputStream = org.allbinary.logic.io.AbFileInputStream;
using DataOutputStreamFactory = org.allbinary.logic.io.DataOutputStreamFactory;
using FileStreamFactory = org.allbinary.logic.io.FileStreamFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using DatabaseEncoder = org.allbinary.logic.system.security.crypt.DatabaseEncoder;
using WeakCrypt = org.allbinary.logic.system.security.crypt.WeakCrypt;
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace org.allbinary.business.init;

public class LicenseInitInfoUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly LicenseInitInfoUtil instance = new LicenseInitInfoUtil();
    public static LicenseInitInfoUtil getInstance()
    {
        return LicenseInitInfoUtil.instance;
    }

    private readonly StringUtil stringUtil = StringUtil.getInstance();
    public readonly string INITFILENAME = "licenseinitdata.dat";
    public readonly string ABOUT = "about";
    public readonly string PRIVACY_POLICY = "privacy_policy";
    private string filePath;
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void setFilePath(string filePath)
    {
        this.filePath = filePath;
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void write(LicenseInitInfo initData)
    {
        if (this.filePath == this.stringUtil.EMPTY_STRING) {
            this.filePath = URLGLOBALS.getMainPath() + PATH_GLOBALS.getInstance().INIT_PATH;
        }
        try {
            TsUtil tsUtil = TsUtil.getInstance();
            AbDataOutputStream dataOutputStream = DataOutputStreamFactory.getInstance().getInstance(this.filePath, this.INITFILENAME);
            sbyte[] licenseIdCrypted = tsUtil.getByteArray(new WeakCrypt(1).encrypt(initData.getLicenseId()));
            dataOutputStream.writeUTF(DatabaseEncoder.encode(licenseIdCrypted));
            int numberOfLicenseServers = initData.getNumberOfServers();
            dataOutputStream.writeInt(numberOfLicenseServers);
            sbyte[] licenseServerCrypted = null;
            for (int index = 0; index < numberOfLicenseServers; index++) {
                licenseServerCrypted = tsUtil.getByteArray(new WeakCrypt(3).encrypt(initData.getServer(index)));
                dataOutputStream.writeUTF(DatabaseEncoder.encode(licenseServerCrypted));
            }
        } catch (Exception e) {
            this.logUtil.put("Command Failed: " + this.INITFILENAME, this, "write", e);
            FileStreamFactory.getInstance().delete(this.filePath, this.INITFILENAME);
            throw e;
        }
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
        string METHOD_NAME = "readAgain";
        if (this.filePath == this.stringUtil.EMPTY_STRING) {
            this.filePath = URLGLOBALS.getMainPath() + PATH_GLOBALS.getInstance().INIT_PATH;
        }
        try {
            this.logUtil.putF("LicenseInitInfo File: " + this.INITFILENAME, this, METHOD_NAME);
            FileStreamFactory fileStreamFactory = FileStreamFactory.getInstance();
            AbFileInputStream iFile = fileStreamFactory.getFileInputStreamInstance(this.filePath, this.INITFILENAME);
            if (iFile != null) {
                AbDataInputStream iData = new AbDataInputStream(iFile);
                LicenseInitInfo initInfo = new LicenseInitInfo();
                sbyte[] decodedByteArray = DatabaseEncoder.decode(iData.readUTF());
                string licenseIdDecoded = System.Text.Encoding.UTF8.GetString((byte[]) (Array) decodedByteArray);
                initInfo.setLicenseId(new WeakCrypt(1).decrypt(licenseIdDecoded));
                int numberOfLicenseServers = iData.readInt();
                string NEXT_FILE = new StringMaker().append(CommonLabels.getInstance().NEXT).append(" License Server From File: ").ToString();
                string licenseServerDecoded = null;
                for (int index = 0; index < numberOfLicenseServers; index++) {
                    decodedByteArray = DatabaseEncoder.decode(iData.readUTF());
                    licenseServerDecoded = System.Text.Encoding.UTF8.GetString((byte[]) (Array) decodedByteArray);
                    initInfo.setServer(new WeakCrypt(3).decrypt(licenseServerDecoded), index);
                    this.logUtil.putF(NEXT_FILE + initInfo.getServer(index), this, METHOD_NAME);
                }
                return initInfo;
            } else {
                throw new Exception("Could Not Load License InitInfo: " + this.INITFILENAME);
            }
        } catch (Exception e) {
            try {
                this.logUtil.put("Command Failed: " + this.INITFILENAME, this, METHOD_NAME, e);
            } catch (Exception e2) {
                this.logUtil.put("LicenseInitInfo Read Retry: " + this.INITFILENAME, this, "readAgain()", e2);
            }
            throw new Exception("LicenseInitInfo Read Error: " + this.INITFILENAME);
        }
    }

    public virtual string getFilePath()
    {
        return this.filePath;
    }

    public LicenseInitInfoUtil()
    {
        this.filePath = this.stringUtil.EMPTY_STRING;
    }

}

