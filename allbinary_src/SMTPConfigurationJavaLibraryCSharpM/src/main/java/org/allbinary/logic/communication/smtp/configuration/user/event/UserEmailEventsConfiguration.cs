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
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using UserEmailEventListenerInterface = org.allbinary.logic.communication.smtp.@event.UserEmailEventListenerInterface;
using UserEmailEventNameData = org.allbinary.logic.communication.smtp.@event.UserEmailEventNameData;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.smtp.configuration.user.@event;

public class UserEmailEventsConfiguration : UserEmailEventsConfigurationInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private HashMap<object, object> emailEventHashMap = null;
    public UserEmailEventsConfiguration()
    {
        this.init();
    }

    public UserEmailEventsConfiguration(HashMap<object, object> hashMap)
    {
        this.init();
    }

    private void init()
    {
        this.emailEventHashMap = StdUtil.getInstance().createHashMap();
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            this.logUtil.putF(this.commonStrings.CONSTRUCTOR, this, " Constructor");
        }
    }

    public virtual HashMap<object, object> getEventConfigurationHashMap()
    {
        return this.emailEventHashMap;
    }

    public virtual void addUserEmailEventConfiguration(UserEmailEventConfigurationInterface userEmailEventConfigurationInterface)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            this.logUtil.putF("Adding: " + userEmailEventConfigurationInterface.log(), this, "addUserEmailEventConfiguration");
        }
        this.emailEventHashMap.put(userEmailEventConfigurationInterface.getName(), userEmailEventConfigurationInterface);
    }

    // throws Exception
    public virtual UserEmailEventListenerInterface getEventListener(AbeClientInformationInterface abeClientInformation, UserEmailEventNameData userEmailEventNameData, UserInterface userInterface)
    {
        UserEmailEventConfigurationInterface userEmailEventConfigurationInterface = ((UserEmailEventConfigurationInterface) this.emailEventHashMap.get(userEmailEventNameData.ToString()));
        return UserEmailEventListenerFactory.getInstance(abeClientInformation, userEmailEventConfigurationInterface, userInterface);
    }

}

