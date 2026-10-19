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
using System.Runtime.CompilerServices;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;
using EmailEvent = org.allbinary.logic.communication.smtp.@event.EmailEvent;
using UserEmailEventListenerInterface = org.allbinary.logic.communication.smtp.@event.UserEmailEventListenerInterface;
using UserEmailEventNameData = org.allbinary.logic.communication.smtp.@event.UserEmailEventNameData;
using EmailInfo = org.allbinary.logic.communication.smtp.info.EmailInfo;

namespace org.allbinary.logic.communication.smtp.@event.handler;

public class UserEmailEventHandler
{
    private BasicArrayList emailVector;
    private EmailInfo emailInfo = null;
    private UserEmailEventNameData userEmailEventNameData = null;
    public UserEmailEventHandler()
    {
        this.emailVector = new BasicArrayListD();
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void receiveEmailInfo(UserEmailEventNameData userEmailEventNameData, EmailInfo emailInfo)
    {
        this.userEmailEventNameData = userEmailEventNameData;
        this.emailInfo = emailInfo;
        this.fireEmailEvent();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void addListener(BasicArrayList vector)
    {
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            UserEmailEventListenerInterface userEmailEventListenerInterface = ((UserEmailEventListenerInterface) vector.get(index));
            this.addListener(userEmailEventListenerInterface);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void addListener(UserEmailEventListenerInterface emailEventListenerInterface)
    {
        this.emailVector.add(emailEventListenerInterface);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void removeListener(UserEmailEventListenerInterface emailEventListenerInterface)
    {
        this.emailVector.remove(emailEventListenerInterface);
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void fireEmailEvent()
    {
        EmailEvent emailEvent = new EmailEvent(this, this.userEmailEventNameData, this.emailInfo, 0);
        int size = this.emailVector.size();
        for (int index = 0; index < size; index++) {
            UserEmailEventListenerInterface emailEventListenerInterface = ((UserEmailEventListenerInterface) this.emailVector.get(index));
            emailEventListenerInterface.onEmailSendRequest(emailEvent);
        }
    }

}

