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
using PATH_GLOBALS = org.allbinary.globals.PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbDataInputStream = org.allbinary.logic.io.AbDataInputStream;
using AbDataOutputStream = org.allbinary.logic.io.AbDataOutputStream;
using AbFileLocalInputStream = org.allbinary.logic.io.AbFileLocalInputStream;
using DataOutputStreamFactory = org.allbinary.logic.io.DataOutputStreamFactory;
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbPath = org.allbinary.logic.io.path.AbPath;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using DatabaseEncoder = org.allbinary.logic.system.security.crypt.DatabaseEncoder;
using WeakCrypt = org.allbinary.logic.system.security.crypt.WeakCrypt;

namespace org.allbinary.business.init;

public class InstallerInfo
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly InstallerInfo instance = new InstallerInfo();
    private static readonly string INITFILENAME = "installerdata.dat";
    private static readonly string PACKAGE = PATH_GLOBALS.getInstance().INIT_PATH;
    private static string userName = StringUtil.getInstance().EMPTY_STRING;
    private static string password = StringUtil.getInstance().EMPTY_STRING;
    private static bool hasRead = false;
    public InstallerInfo()
    {
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void write()
    {
        AbPath FILEABPATH = new AbPath(URLGLOBALS.getMainPath() + InstallerInfo.PACKAGE, InstallerInfo.INITFILENAME);
        try {
            AbFile newFile = AbFile.createAbFileFromAbPath(FILEABPATH);
            newFile.createNewFile();
            AbDataOutputStream dataOutputStream = DataOutputStreamFactory.getInstance().getInstanceForAbFile(newFile);
            sbyte[] cryptedUserName = new WeakCrypt(1).encrypt(this.getUserName()).getBytes();
            sbyte[] cryptedPassword = new WeakCrypt(2).encrypt(this.getPassword()).getBytes();
            dataOutputStream.writeUTF(DatabaseEncoder.encode(cryptedUserName));
            dataOutputStream.writeUTF(DatabaseEncoder.encode(cryptedPassword));
            InstallerInfo.hasRead = false;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRELOADERERROR)) {
                this.logUtil.putF("Failed", this, "write");
            }
            throw e;
        }
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    private void read()
    {
        AbPath FILEABPATH = new AbPath(URLGLOBALS.getMainPath() + InstallerInfo.PACKAGE, InstallerInfo.INITFILENAME);
        try {
            AbFile file = AbFile.createAbFileFromAbPath(FILEABPATH);
            if (file.isFile()) {
                AbFileLocalInputStream iFile = new AbFileLocalInputStream(file);
                AbDataInputStream iData = new AbDataInputStream(iFile);
                string decryptedUserName = new string((DatabaseEncoder.decode(iData.readUTF())).ToCharArray());
                string decryptedPassword = new string((DatabaseEncoder.decode(iData.readUTF())).ToCharArray());
                this.setUserName(new WeakCrypt(1).decrypt(decryptedUserName));
                this.setPassword(new WeakCrypt(2).decrypt(decryptedPassword));
            } else {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRELOADER)) {
                    this.logUtil.putF("Not a File - Failed Loading: " + FILEABPATH.ToString(), this, "read");
                }
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRELOADERERROR)) {
                this.logUtil.putF("Failed", this, "read");
            }
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void setHasRead(bool value)
    {
        InstallerInfo.hasRead = value;
    }

    public virtual void setUserName(string userName)
    {
        InstallerInfo.userName = userName;
    }

    public virtual void setPassword(string password)
    {
        InstallerInfo.password = password;
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    private void updateIfNeeded()
    {
        if (!InstallerInfo.hasRead) {
            InstallerInfo.hasRead = true;
            this.read();
            if (InstallerInfo.userName == null || InstallerInfo.password == null) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PRELOADER)) {
                    this.logUtil.putF("Failed", this, "updateIfNeeded");
                }
            }
        }
    }

    // throws Exception
    public virtual string getUserName()
    {
        this.updateIfNeeded();
        return InstallerInfo.userName;
    }

    // throws Exception
    public virtual string getPassword()
    {
        this.updateIfNeeded();
        return InstallerInfo.password;
    }

    // throws Exception
    public virtual bool isValid(string userName, string password)
    {
        this.updateIfNeeded();
        if (this.userName != null && string.CompareOrdinal(this.userName, userName) == 0 && this.password != null && string.CompareOrdinal(this.password, password) == 0) {
            return true;
        }
        return false;
    }

}

