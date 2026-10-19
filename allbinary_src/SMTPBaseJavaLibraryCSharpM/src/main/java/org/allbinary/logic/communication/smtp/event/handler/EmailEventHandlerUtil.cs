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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using UserInterface = org.allbinary.business.user.UserInterface;
using UserConfigurationInterface = org.allbinary.business.user.modules.configuration.UserConfigurationInterface;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using UserEmailConfigurationInterface = org.allbinary.logic.communication.smtp.configuration.user.UserEmailConfigurationInterface;
using UserEmailEventsConfigurationInterface = org.allbinary.logic.communication.smtp.configuration.user.@event.UserEmailEventsConfigurationInterface;
using UserEmailEventListenerInterface = org.allbinary.logic.communication.smtp.@event.UserEmailEventListenerInterface;
using UserEmailEventNameData = org.allbinary.logic.communication.smtp.@event.UserEmailEventNameData;
using LogUserEmailEventListenerModule = org.allbinary.logic.communication.smtp.@event.modules.log.LogUserEmailEventListenerModule;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;

namespace org.allbinary.logic.communication.smtp.@event.handler;

public class EmailEventHandlerUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly EmailEventHandlerUtil instance = new EmailEventHandlerUtil();
    public static EmailEventHandlerUtil getInstance()
    {
        return EmailEventHandlerUtil.instance;
    }

    private EmailEventHandlerUtil()
    {
    }

    // throws Exception
    public virtual UserEmailEventHandler getEventHandler(AbeClientInformationInterface abeClientInformation, UserEmailEventNameData userEmailEventNameData, BasicArrayList userVector)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append("Returning UserEmailEventHandler for ");
            stringBuffer.appendint(userVector.size());
            stringBuffer.append(" users.");
            this.logUtil.putF(stringBuffer.ToString(), this, "getEventHandler");
        }
        UserEmailEventHandler userEmailEventHandler = new UserEmailEventHandler();
        userEmailEventHandler.addListener(new LogUserEmailEventListenerModule());
        int size = userVector.size();
        for (int index = 0; index < size; index++) {
            UserInterface userInterface = ((UserInterface) userVector.get(index));
            BasicArrayList vector = EmailEventHandlerUtil.getUserEmailEventListenerVector(abeClientInformation, userEmailEventNameData, userInterface);
            userEmailEventHandler.addListener(vector);
        }
        return userEmailEventHandler;
    }

    // throws Exception
    public static BasicArrayList getUserEmailEventListenerVector(AbeClientInformationInterface abeClientInformation, UserEmailEventNameData userEmailEventNameData, UserInterface userInterface)
    {
        UserConfigurationInterface userConfigurationInterface = userInterface.getUserConfigurationInterface();
        UserEmailConfigurationInterface userEmailConfigurationInterface = userConfigurationInterface.getUserEmailConfigurationInterface();
        UserEmailEventsConfigurationInterface userEmailEventsConfigurationInterface = userEmailConfigurationInterface.getUserEmailEventsConfigurationInterface();
        UserEmailEventListenerInterface userEmailEventListenerInterface = userEmailEventsConfigurationInterface.getEventListener(abeClientInformation, userEmailEventNameData, userInterface);
        BasicArrayList vector = new BasicArrayListD();
        vector.add(userEmailEventListenerInterface);
        return vector;
    }

}

