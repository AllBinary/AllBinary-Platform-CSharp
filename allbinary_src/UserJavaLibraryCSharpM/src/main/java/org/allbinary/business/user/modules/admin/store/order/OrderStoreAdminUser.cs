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
using WeblisketSessionInterface = org.allbinary.logic.communication.http.request.session.WeblisketSessionInterface;

namespace org.allbinary.business.user.modules.admin.store.order;

public class OrderStoreAdminUser : User
{
    public OrderStoreAdminUser() : base()
    {
        // Constructor invocation emitted in the initializer.
    }

    public OrderStoreAdminUser(HashMap<object, object> userHashMap) : base(userHashMap)
    {
        // Constructor invocation emitted in the initializer.
    }

    public override void validateSession(WeblisketSessionInterface weblisketSession)
    {
        base.validateSession(weblisketSession);
        this.updateSession(weblisketSession);
    }

    public override void updateSession(WeblisketSessionInterface weblisketSession)
    {
        weblisketSession.setStoreName(this.getPermissions());
    }

}

