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
using UserInterface = org.allbinary.business.user.UserInterface;
using UserEmailEventListenerInterface = org.allbinary.logic.communication.smtp.@event.UserEmailEventListenerInterface;
using UserEmailEventNameData = org.allbinary.logic.communication.smtp.@event.UserEmailEventNameData;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;

namespace org.allbinary.logic.communication.smtp.configuration.user.@event;

public interface UserEmailEventsConfigurationInterface
{
    HashMap getEventConfigurationHashMap();

    void addUserEmailEventConfiguration(UserEmailEventConfigurationInterface userEmailEventConfigurationInterface);

    // throws Exception
    UserEmailEventListenerInterface getEventListener(AbeClientInformationInterface abeClientInformation, UserEmailEventNameData userEmailEventNameData, UserInterface userInterface);

}

