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
using UserEmailEventsConfiguration = org.allbinary.logic.communication.smtp.configuration.user.@event.UserEmailEventsConfiguration;
using UserEmailEventsConfigurationInterface = org.allbinary.logic.communication.smtp.configuration.user.@event.UserEmailEventsConfigurationInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.smtp.configuration.user;

public class UserEmailConfiguration : UserEmailConfigurationInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private UserEmailEventsConfigurationInterface userEmailEventsConfigurationInterface = null;
    public UserEmailConfiguration()
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            this.logUtil.putF(this.commonStrings.CONSTRUCTOR, this, this.commonStrings.CONSTRUCTOR);
        }
        this.setUserEmailEventsConfigurationInterface(new UserEmailEventsConfiguration());
    }

    public UserEmailConfiguration(HashMap<object, object> hashMap)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            this.logUtil.putF(this.commonStrings.CONSTRUCTOR, this, this.commonStrings.CONSTRUCTOR);
        }
        this.setUserEmailEventsConfigurationInterface(new UserEmailEventsConfiguration(hashMap));
    }

    public virtual UserEmailEventsConfigurationInterface getUserEmailEventsConfigurationInterface()
    {
        return this.userEmailEventsConfigurationInterface;
    }

    public virtual void setUserEmailEventsConfigurationInterface(UserEmailEventsConfigurationInterface userEmailEventsConfigurationInterface)
    {
        this.userEmailEventsConfigurationInterface = userEmailEventsConfigurationInterface;
    }

}

