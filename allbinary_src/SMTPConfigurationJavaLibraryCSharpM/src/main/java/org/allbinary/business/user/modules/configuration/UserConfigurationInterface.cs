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
using TimeCreated = org.allbinary.business.time.created.TimeCreated;
using TimeLastModified = org.allbinary.business.time.modified.TimeLastModified;
using UserEmailConfigurationInterface = org.allbinary.logic.communication.smtp.configuration.user.UserEmailConfigurationInterface;

namespace org.allbinary.business.user.modules.configuration;

public interface UserConfigurationInterface
{
    UserEmailConfigurationInterface getUserEmailConfigurationInterface();

    void setUserEmailConfigurationInterface(UserEmailConfigurationInterface userEmailConfigurationInterface);

    TimeCreated getTimeCreated();

    TimeLastModified getTimeLastModified();

    void setTimeCreated(TimeCreated timeCreated);

    void setTimeLastModified(TimeLastModified timeLastModified);

}

