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
//using EventObject = java.util.EventObject;
using EmailInfo = org.allbinary.logic.communication.smtp.info.EmailInfo;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.logic.communication.smtp.@event;

public class EmailEvent : EventObject
{
    private EmailInfo emailInfo;
    private UserEmailEventNameData userEmailEventNameData;
    private int attempts = 0;
    public EmailEvent(object emailEventHandler, UserEmailEventNameData userEmailEventNameData, EmailInfo emailInfo, int attempts) : base(emailEventHandler)
    {
        // base(emailEventHandler) is called from the constructor declaration
        this.userEmailEventNameData = userEmailEventNameData;
        this.emailInfo = emailInfo;
    }

    public virtual EmailInfo getEmailInfo()
    {
        return this.emailInfo;
    }

    public virtual int getAttempts()
    {
        return this.attempts;
    }

    public virtual void setAttempts(int attempts)
    {
        this.attempts = attempts;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("EmailEvent Log: \n");
        stringBuffer.append("Event Name: ");
        stringBuffer.append(this.userEmailEventNameData.ToString());
        stringBuffer.append(this.getEmailInfo().ToString());
        stringBuffer.append("\nNumber of Attempts: ");
        stringBuffer.appendint(this.getAttempts());
        return stringBuffer.ToString();
    }

}

