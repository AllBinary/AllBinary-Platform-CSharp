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
using EmailServerConfiguration = org.allbinary.logic.communication.smtp.configuration.server.EmailServerConfiguration;
using EmailServerConfigurationInterface = org.allbinary.logic.communication.smtp.configuration.server.EmailServerConfigurationInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.business.context.configuration;

public class ContextConfiguration : ContextConfigurationInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private EmailServerConfigurationInterface emailServerConfigurationInterface = null;
    public ContextConfiguration()
    {
        this.logUtil.putF(this.commonStrings.START, this, "ContextConfiguration");
        this.setEmailServerConfigurationInterface(((EmailServerConfigurationInterface) new EmailServerConfiguration()));
    }

    public ContextConfiguration(HashMap<object, object> hashMap)
    {
        this.logUtil.putF(this.commonStrings.START, this, "ContextConfiguration(HashMap)");
        this.setEmailServerConfigurationInterface(((EmailServerConfigurationInterface) new EmailServerConfiguration(hashMap)));
    }

    public virtual EmailServerConfigurationInterface getEmailServerConfigurationInterface()
    {
        return this.emailServerConfigurationInterface;
    }

    public virtual void setEmailServerConfigurationInterface(EmailServerConfigurationInterface emailServerConfigurationInterface)
    {
        this.emailServerConfigurationInterface = emailServerConfigurationInterface;
    }

}

