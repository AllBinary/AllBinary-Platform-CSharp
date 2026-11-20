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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using UserInterface = org.allbinary.business.user.UserInterface;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using UserEmailEventNameData = org.allbinary.logic.communication.smtp.@event.UserEmailEventNameData;
using EmailEventHandlerUtil = org.allbinary.logic.communication.smtp.@event.handler.EmailEventHandlerUtil;
using UserEmailEventHandler = org.allbinary.logic.communication.smtp.@event.handler.UserEmailEventHandler;
using LogUserEmailEventListenerModule = org.allbinary.logic.communication.smtp.@event.modules.log.LogUserEmailEventListenerModule;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace org.allbinary.logic.communication.smtp.@event.handler.factory;

public class UserEmailEventHandlerSingletons
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly UserEmailEventHandlerSingletons instance = new UserEmailEventHandlerSingletons();
    public static UserEmailEventHandlerSingletons getInstance()
    {
        return UserEmailEventHandlerSingletons.instance;
    }

    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly HashMap<object, object> userEmailEventHandlerHashMap = StdUtil.getInstance().createHashMap();
    private UserEmailEventHandlerSingletons()
    {
        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        }
    }

    // throws Exception
    public virtual UserEmailEventHandler getInstance(AbeClientInformationInterface abeClientInformation, UserEmailEventNameData userEmailEventNameData, UserInterface userInterface)
    {
        if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.GET_INSTANCE);
        }
        UserEmailEventHandler userEmailEventHandler = ((UserEmailEventHandler) this.userEmailEventHandlerHashMap.get(userEmailEventNameData));
        if (userEmailEventHandler == null) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
                this.logUtil.putF("Creating New Named UserEmailEventHandler", this, this.commonStrings.GET_INSTANCE);
            }
            UserEmailEventHandler newUserEmailEventHandler = new UserEmailEventHandler();
            BasicArrayList vector = EmailEventHandlerUtil.getUserEmailEventListenerVector(abeClientInformation, userEmailEventNameData, userInterface);
            newUserEmailEventHandler.addListener(vector);
            newUserEmailEventHandler.addListener(new LogUserEmailEventListenerModule());
            this.userEmailEventHandlerHashMap.put(userEmailEventNameData, newUserEmailEventHandler);
            return newUserEmailEventHandler;
        } else {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
                this.logUtil.putF("Returning existing UserEmailEventHandler", this, this.commonStrings.GET_INSTANCE);
            }
            return userEmailEventHandler;
        }
    }

}

