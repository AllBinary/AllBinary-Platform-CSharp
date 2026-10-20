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
using java.util;

namespace org.allbinary.logic.communication.ftp.configuration;

public class FtpConfiguration : FtpConfigurationInterface
{
    private string ftpServer;
    private string ftpPath;
    private string ftpUserName;
    private string ftpPassword;
    public FtpConfiguration()
    {
    }

    public FtpConfiguration(HashMap<object, object> hashMap)
    {
        this.ftpServer = ((string) hashMap.get(FtpConfigurationData.SERVER));
        this.ftpPath = ((string) hashMap.get(FtpConfigurationData.PATH));
        this.ftpUserName = ((string) hashMap.get(FtpConfigurationData.USERNAME));
        this.ftpPassword = ((string) hashMap.get(FtpConfigurationData.PASSWORD));
    }

    public virtual string getServer()
    {
        return this.ftpServer;
    }

    public virtual string getPath()
    {
        return this.ftpPath;
    }

    public virtual string getUserName()
    {
        return this.ftpUserName;
    }

    public virtual string getPassword()
    {
        return this.ftpPassword;
    }

    public virtual void setServer(string value)
    {
        this.ftpServer = value;
    }

    public virtual void setPath(string value)
    {
        this.ftpPath = value;
    }

    public virtual void setUserName(string value)
    {
        this.ftpUserName = value;
    }

    public virtual void setPassword(string value)
    {
        this.ftpPassword = value;
    }

}

