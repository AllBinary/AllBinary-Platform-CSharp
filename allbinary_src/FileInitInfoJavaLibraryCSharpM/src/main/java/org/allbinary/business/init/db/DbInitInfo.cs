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
using FREEBLISKET_PATH_GLOBALS = org.allbinary.globals.FREEBLISKET_PATH_GLOBALS;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using HttpData = org.allbinary.logic.communication.http.HttpData;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;
using AbDataInputStream = org.allbinary.logic.io.AbDataInputStream;
using AbDataOutputStream = org.allbinary.logic.io.AbDataOutputStream;
using AbFileInputStream = org.allbinary.logic.io.AbFileInputStream;
using DataOutputStreamFactory = org.allbinary.logic.io.DataOutputStreamFactory;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using Directory = org.allbinary.logic.io.file.directory.Directory;
using AbPath = org.allbinary.logic.io.path.AbPath;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using DatabaseEncoder = org.allbinary.logic.system.security.crypt.DatabaseEncoder;
using WeakCrypt = org.allbinary.logic.system.security.crypt.WeakCrypt;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.init.db;

public class DbInitInfo : DbConnectionInfo
{
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly Directory directory = Directory.getInstance();
    private readonly HttpData httpData = HttpData.getInstance();
    private readonly string GET_URL = "getUrl";
    private readonly string PACKAGE = FREEBLISKET_PATH_GLOBALS.getInstance().DBINITPATH;
    private string initFileName;
    private bool hasRead = false;
    public DbInitInfo(string initFileName, bool read) : base()
    {
        // base() is called from the constructor declaration
        this.initFileName = initFileName;
        if (read) {
            this.updateIfNeeded();
        } else {
            this.setHasRead(true);
        }
    }

    public virtual string getUrl()
    {
        string url = base.getUrl();
        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADER)) {
            PreLogUtil.put(this.httpData.URL_LABEL + url, this, GET_URL);
        }
        return url;
    }

    // throws Exception
    public virtual void write()
    {
        AbPath PATH = new AbPath(URLGLOBALS.getWebappPath() + this.PACKAGE, StringUtil.getInstance().EMPTY_STRING);
        this.directory.create(PATH);
        AbPath FILEABPATH = new AbPath(URLGLOBALS.getWebappPath() + this.PACKAGE, this.initFileName);
        try {
            AbFile newFile = AbFile.createAbFileFromAbPath(FILEABPATH);
            newFile.createNewFile();
            AbDataOutputStream dataOutputStream = DataOutputStreamFactory.getInstance().getInstanceForAbFile(newFile);
            try {
                sbyte[] cryptedJdbcDriver = new WeakCrypt(1).encrypt(this.getJdbcDriver()).getBytes();
                sbyte[] cryptedName = new WeakCrypt(2).encrypt(this.getName()).getBytes();
                sbyte[] cryptedUserName = new WeakCrypt(3).encrypt(this.getUserName()).getBytes();
                sbyte[] cryptedPassword = new WeakCrypt(4).encrypt(this.getPassword()).getBytes();
                sbyte[] cryptedSchema = new WeakCrypt(5).encrypt(this.getSchema()).getBytes();
                sbyte[] cryptedServer = new WeakCrypt(6).encrypt(this.getServer()).getBytes();
                sbyte[] cryptedPort = new WeakCrypt(7).encrypt(this.getPort()).getBytes();
                dataOutputStream.writeUTF(DatabaseEncoder.encode(cryptedJdbcDriver));
                dataOutputStream.writeUTF(DatabaseEncoder.encode(cryptedName));
                dataOutputStream.writeUTF(DatabaseEncoder.encode(cryptedUserName));
                dataOutputStream.writeUTF(DatabaseEncoder.encode(cryptedPassword));
                dataOutputStream.writeUTF(DatabaseEncoder.encode(cryptedSchema));
                dataOutputStream.writeUTF(DatabaseEncoder.encode(cryptedServer));
                dataOutputStream.writeUTF(DatabaseEncoder.encode(cryptedPort));
                this.hasRead = false;
            } finally {
                StreamUtil.getInstance().close(dataOutputStream);
            }
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADERERROR)) {
                PreLogUtil.putOE("Failed Write: " + FILEABPATH.ToString(), this, "write", e);
            }
        }
    }

    // throws Exception
    private void load()
    {
        AbPath FILEABPATH = new AbPath(URLGLOBALS.getWebappPath() + this.PACKAGE, this.initFileName);
        try {
            AbFile file = AbFile.createAbFileFromAbPath(FILEABPATH);
            if (file.isFile()) {
                AbFileInputStream iFile = new AbFileInputStream(file);
                AbDataInputStream iData = new AbDataInputStream(iFile);
                try {
                    string decryptedJdbcDriver = new string((DatabaseEncoder.decode(iData.readUTF())).ToCharArray());
                    string decryptedName = new string((DatabaseEncoder.decode(iData.readUTF())).ToCharArray());
                    string decryptedUserName = new string((DatabaseEncoder.decode(iData.readUTF())).ToCharArray());
                    string decryptedPassword = new string((DatabaseEncoder.decode(iData.readUTF())).ToCharArray());
                    string decryptedSchema = new string((DatabaseEncoder.decode(iData.readUTF())).ToCharArray());
                    string decryptedServer = new string((DatabaseEncoder.decode(iData.readUTF())).ToCharArray());
                    string decryptedPort = new string((DatabaseEncoder.decode(iData.readUTF())).ToCharArray());
                    this.setJdbcDriver(new WeakCrypt(1).decrypt(decryptedJdbcDriver));
                    this.setName(new WeakCrypt(2).decrypt(decryptedName));
                    this.setUserName(new WeakCrypt(3).decrypt(decryptedUserName));
                    this.setPassword(new WeakCrypt(4).decrypt(decryptedPassword));
                    this.setSchema(new WeakCrypt(5).decrypt(decryptedSchema));
                    this.setServer(new WeakCrypt(6).decrypt(decryptedServer));
                    this.setPort(new WeakCrypt(7).decrypt(decryptedPort));
                    StringUtil stringUtil = StringUtil.getInstance();
                } finally {
                    StreamUtil.getInstance().close(iData);
                }
            } else {
                this.hasRead = false;
                if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADER)) {
                    PreLogUtil.put("Not a File - Failed Loading: " + FILEABPATH.ToString(), this, this.commonStrings.LOAD);
                }
            }
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADERERROR)) {
                PreLogUtil.putOE("Failed Loading: " + FILEABPATH.ToString(), this, this.commonStrings.LOAD, e);
            }
        }
    }

    public virtual void setHasRead(bool value)
    {
        this.hasRead = value;
    }

    private void updateIfNeeded()
    {
        try {
            if (!this.hasRead) {
                this.hasRead = true;
                this.load();
            }
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADERERROR)) {
                PreLogUtil.putOE(this.commonStrings.EXCEPTION, this, "updateIfNeeded", e);
            }
        }
    }

    public virtual string getName()
    {
        this.updateIfNeeded();
        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADER)) {
            PreLogUtil.put("Name: " + base.getName(), this, "getName");
        }
        return base.getName();
    }

    public virtual string getUserName()
    {
        this.updateIfNeeded();
        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().PRELOADER)) {
            PreLogUtil.put("Name: " + base.getUserName(), this, "getUserName");
        }
        return base.getUserName();
    }

    public virtual string getPassword()
    {
        this.updateIfNeeded();
        return base.getPassword();
    }

    public virtual string getSchema()
    {
        this.updateIfNeeded();
        return base.getSchema();
    }

    public virtual string getServer()
    {
        this.updateIfNeeded();
        return base.getServer();
    }

    public virtual string getPort()
    {
        this.updateIfNeeded();
        return base.getPort();
    }

}

