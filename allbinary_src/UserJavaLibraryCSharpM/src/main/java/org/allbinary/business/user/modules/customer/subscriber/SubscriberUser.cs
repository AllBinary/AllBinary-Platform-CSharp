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
using User = org.allbinary.business.user.modules.User;
using Subscription = org.allbinary.business.user.subscription.Subscription;
using WeblisketSessionInterface = org.allbinary.logic.communication.http.request.session.WeblisketSessionInterface;

namespace org.allbinary.business.user.modules.customer.subscriber;

public class SubscriberUser : User
{
    private Subscription subscription;
    public SubscriberUser() : base()
    {
        // base() is called from the constructor declaration
        this.subscription = new Subscription();
    }

    public SubscriberUser(HashMap userHashMap) : base(userHashMap)
    {
        // base(userHashMap) is called from the constructor declaration
        this.subscription = new Subscription();
    }

    public virtual void validateSession(WeblisketSessionInterface weblisketSession)
    {
        base.validateSession(weblisketSession);
        this.updateSession(weblisketSession);
    }

    public virtual void updateSession(WeblisketSessionInterface weblisketSession)
    {
        weblisketSession.setStoreName(this.getPermissions());
    }

    public virtual bool? isSessionValid()
    {
        return this.subscription.isSubscribed();
    }

}

