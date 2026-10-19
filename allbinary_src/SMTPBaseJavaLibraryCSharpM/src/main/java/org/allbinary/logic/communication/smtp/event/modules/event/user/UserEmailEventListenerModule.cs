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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BasicEmail = org.allbinary.logic.communication.smtp.BasicEmail;
using EmailInterface = org.allbinary.logic.communication.smtp.EmailInterface;
using EmailEvent = org.allbinary.logic.communication.smtp.@event.EmailEvent;
using UserEmailEventListenerInterface = org.allbinary.logic.communication.smtp.@event.UserEmailEventListenerInterface;
using EmailQueueFactory = org.allbinary.logic.communication.smtp.queue.EmailQueueFactory;

namespace org.allbinary.logic.communication.smtp.@event.modules.@event.user;

public class UserEmailEventListenerModule : UserEmailEventListenerInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private UserInterface userInterface;
    public UserEmailEventListenerModule(UserInterface userInterface)
    {
        this.userInterface = userInterface;
    }

    // throws Exception
    public virtual void onEmailSendFailure(EmailEvent emailEvent)
    {
        string to = this.userInterface.getSecondaryEmail();
        BasicEmail email = new BasicEmail(emailEvent.getEmailInfo(), to);
        EmailQueueFactory.getInstance().offer(((EmailInterface) email.getEmail()));
    }

    // throws Exception
    public virtual void onEmailSendRequest(EmailEvent emailEvent)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGING)) {
            this.logUtil.putF("Add Email To Que For Sending: " + emailEvent.ToString(), this, "onEmailSendRequest");
        }
        string to = this.userInterface.getMainEmail();
        BasicEmail email = new BasicEmail(emailEvent.getEmailInfo(), to);
        EmailQueueFactory.getInstance().offer(((EmailInterface) email.getEmail()));
    }

}

