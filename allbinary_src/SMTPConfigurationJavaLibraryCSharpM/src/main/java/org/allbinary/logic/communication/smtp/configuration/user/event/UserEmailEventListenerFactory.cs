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
using UserInterface = org.allbinary.business.user.UserInterface;
using UserEmailEventListenerInterface = org.allbinary.logic.communication.smtp.@event.UserEmailEventListenerInterface;
using AbeFactory = org.allbinary.logic.system.loader.AbeFactory;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;

namespace org.allbinary.logic.communication.smtp.configuration.user.@event;

public class UserEmailEventListenerFactory
{
    private UserEmailEventListenerFactory()
    {
    }

    // throws Exception
    public static UserEmailEventListenerInterface getInstance(AbeClientInformationInterface abeClientInformation, UserEmailEventConfigurationInterface userEmailEventConfigurationInterface, UserInterface userInterface)
    {
        object[] @params = new object[1];
        Type[] classes = new Type[1];
        classes[0] = typeof(UserInterface);
        @params[0] = ((object) userInterface);
        return ((UserEmailEventListenerInterface) AbeFactory.getInstance().getInstance(abeClientInformation, userEmailEventConfigurationInterface.getEventListenerClassPath(), classes, @params));
    }

}

