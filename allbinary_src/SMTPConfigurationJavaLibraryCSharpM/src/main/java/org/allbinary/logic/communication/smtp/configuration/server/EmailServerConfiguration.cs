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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.smtp.configuration.server;

public class EmailServerConfiguration : EmailServerConfigurationInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string accountName = null;
    private string password = null;
    private string smtpServer = null;
    public EmailServerConfiguration()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF(commonStrings.START, this, commonStrings.CONSTRUCTOR);
        }
        this.setSmtpServer(StringUtil.getInstance().EMPTY_STRING);
    }

    public EmailServerConfiguration(HashMap<object, object> hashMap)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF(commonStrings.START, this, "EmailServerConfiguration(HashMap)");
        }
        this.setAccountName(((string) hashMap.get(EmailServerConfigurationData.ACCOUNT)));
        this.setPassword(((string) hashMap.get(EmailServerConfigurationData.PASSWORD)));
        this.setSmtpServer(((string) hashMap.get(EmailServerConfigurationData.SERVER)));
        this.log();
    }

    public EmailServerConfiguration(string account, string password, string server)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF(commonStrings.START, this, "EmailServerConfiguration(HashMap)");
        }
        this.setAccountName(account);
        this.setPassword(password);
        this.setSmtpServer(server);
        this.log();
    }

    public virtual void setSmtpServer(string value)
    {
        this.smtpServer = value;
    }

    public virtual string getSmtpServer()
    {
        return this.smtpServer;
    }

    public virtual string getAccountName()
    {
        return this.accountName;
    }

    public virtual void setAccountName(string accountName)
    {
        this.accountName = accountName;
    }

    public virtual string getPassword()
    {
        return this.password;
    }

    public virtual void setPassword(string password)
    {
        this.password = password;
    }

    public virtual void log()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            this.logUtil.putF(this.ToString(), this, "EmailServerConfiguration");
        }
    }

    public override string ToString()
    {
        return "Email Server Configuration:\n" + "Smtp Server: \n" + this.getSmtpServer() + "\nAccount Name: " + this.getAccountName() + "\nPassword: " + this.getPassword();
    }

}

