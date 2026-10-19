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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using EmailServerConfigurationInterface = org.allbinary.logic.communication.smtp.configuration.server.EmailServerConfigurationInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.smtp.info;

public class BasicEmailInfo
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private string subject;
    private string textBody;
    public EmailServerConfigurationInterface emailServerConfigurationInterface = null;
    public BasicEmailInfo(string subject, string textBody)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF(commonStrings.START, this, commonStrings.CONSTRUCTOR);
        }
        this.subject = subject;
        this.textBody = textBody;
    }

    public virtual string getSubject()
    {
        return this.subject;
    }

    public virtual string getTextBody()
    {
        return this.textBody;
    }

    public virtual EmailServerConfigurationInterface getEmailServerConfigurationInterface()
    {
        return this.emailServerConfigurationInterface;
    }

    public virtual void setEmailServerConfigurationInterface(EmailServerConfigurationInterface emailServerConfigurationInterface)
    {
        this.emailServerConfigurationInterface = emailServerConfigurationInterface;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.getEmailServerConfigurationInterface().ToString());
        stringBuffer.append(CommonSeps.getInstance().NEW_LINE);
        stringBuffer.append("Subject: \n");
        stringBuffer.append(this.getSubject());
        stringBuffer.append("\nText Body: \n");
        stringBuffer.append(this.getTextBody());
        return stringBuffer.ToString();
    }

    // throws Exception
    protected virtual void init()
    {
        throw new SystemException();
    }

}

