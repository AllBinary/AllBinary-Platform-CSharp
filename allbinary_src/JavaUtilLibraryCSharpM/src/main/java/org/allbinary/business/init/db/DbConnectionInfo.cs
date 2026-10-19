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
using AbPathData = org.allbinary.logic.io.path.AbPathData;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.business.init.db;

public class DbConnectionInfo : DatabaseConnectionInfoInterface
{
    private string jdbcDriver = null;
    private string name = null;
    private string userName = null;
    private string password = null;
    private string schema = null;
    private string server = null;
    private string port = null;
    private string url = null;
    private string host = null;
    private readonly string SCHEMA_SEP = "://";
    private readonly string USER_NAME_KEY = "?user=";
    private readonly string PASSWORD_KEY = "&password=";
    public DbConnectionInfo()
    {
    }

    private void updateUrl()
    {
        this.updateHost();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.getHost());
        stringBuffer.append(this.getName());
        stringBuffer.append(this.getUserNameKey());
        stringBuffer.append(this.getUserName());
        stringBuffer.append(this.getPasswordKey());
        stringBuffer.append(this.getPassword());
        this.url = stringBuffer.ToString();
    }

    public virtual string getUrl()
    {
        return this.url;
    }

    public virtual string getJdbcDriver()
    {
        return this.jdbcDriver;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual string getUserName()
    {
        return this.userName;
    }

    public virtual string getPassword()
    {
        return this.password;
    }

    private void updateHost()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.getSchema());
        stringBuffer.append(this.SCHEMA_SEP);
        stringBuffer.append(this.getServer());
        if (this.getPort() != null && this.getPort().length() > 1) {
            stringBuffer.append(CommonSeps.getInstance().COLON);
            stringBuffer.append(this.getPort());
        }
        stringBuffer.append(AbPathData.getInstance().SEPARATOR);
        this.host = stringBuffer.ToString();
    }

    public virtual string getHost()
    {
        return this.host;
    }

    public virtual string getSchema()
    {
        return this.schema;
    }

    public virtual string getServer()
    {
        return this.server;
    }

    public virtual string getPort()
    {
        return this.port;
    }

    public virtual void setJdbcDriver(string value)
    {
        this.jdbcDriver = value;
    }

    public virtual void setName(string value)
    {
        this.name = value;
        this.updateUrl();
    }

    public virtual void setUserName(string value)
    {
        this.userName = value;
        this.updateUrl();
    }

    public virtual void setPassword(string value)
    {
        this.password = value;
        this.updateUrl();
    }

    public virtual void setSchema(string value)
    {
        this.schema = value;
        this.updateUrl();
    }

    public virtual void setServer(string value)
    {
        this.server = value;
        this.updateUrl();
    }

    public virtual void setPort(string value)
    {
        this.port = value;
        this.updateUrl();
    }

    public string getUserNameKey()
    {
        return this.USER_NAME_KEY;
    }

    public string getPasswordKey()
    {
        return this.PASSWORD_KEY;
    }

}

