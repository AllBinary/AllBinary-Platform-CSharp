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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using EmailEvent = org.allbinary.logic.communication.smtp.@event.EmailEvent;
using UserEmailEventListenerInterface = org.allbinary.logic.communication.smtp.@event.UserEmailEventListenerInterface;

namespace org.allbinary.logic.communication.smtp.@event.modules.log;

public class LogUserEmailEventListenerModule : UserEmailEventListenerInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public LogUserEmailEventListenerModule()
    {
    }

    // throws Exception
    public virtual void onEmailSendRequest(EmailEvent userEmailInfoEvent)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            string message = "Logging EmailEvent - Temporary Listener for debugging.\n\n" + userEmailInfoEvent.ToString();
            this.logUtil.putF(message, this, "onEmailSendRequest");
        }
    }

}

