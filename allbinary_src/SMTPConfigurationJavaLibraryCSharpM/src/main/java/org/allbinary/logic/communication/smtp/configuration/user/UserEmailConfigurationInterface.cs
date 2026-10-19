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
using UserEmailEventsConfigurationInterface = org.allbinary.logic.communication.smtp.configuration.user.@event.UserEmailEventsConfigurationInterface;

namespace org.allbinary.logic.communication.smtp.configuration.user;

public interface UserEmailConfigurationInterface
{
    UserEmailEventsConfigurationInterface getUserEmailEventsConfigurationInterface();

    void setUserEmailEventsConfigurationInterface(UserEmailEventsConfigurationInterface emailEventsConfigurationInterface);

}

