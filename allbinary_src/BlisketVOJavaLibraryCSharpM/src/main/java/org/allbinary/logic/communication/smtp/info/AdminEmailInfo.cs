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
using ContextConfigurationInterface = org.allbinary.business.context.configuration.ContextConfigurationInterface;
using AdminConfiguration = org.allbinary.business.user.modules.admin.configuration.AdminConfiguration;
using AdminConfigurationInterface = org.allbinary.business.user.modules.admin.configuration.AdminConfigurationInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using EmailServerConfigurationInterface = org.allbinary.logic.communication.smtp.configuration.server.EmailServerConfigurationInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace org.allbinary.logic.communication.smtp.info;

public class AdminEmailInfo : BasicEmailInfo
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public AdminEmailInfo(string subject, string textBody) : base(subject, textBody)
    {
        // Constructor invocation emitted in the initializer.
        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF(commonStrings.START, this, commonStrings.CONSTRUCTOR);
        }
        this.init();
    }

    // throws Exception
    public override void init()
    {
        AdminConfigurationInterface adminConfigurationInterface = ((AdminConfigurationInterface) new AdminConfiguration());
        ContextConfigurationInterface contextConfigurationInterface = adminConfigurationInterface.getContextConfigurationInterface();
        EmailServerConfigurationInterface emailServerConfigurationInterface = contextConfigurationInterface.getEmailServerConfigurationInterface();
        this.setEmailServerConfigurationInterface(emailServerConfigurationInterface);
    }

}

