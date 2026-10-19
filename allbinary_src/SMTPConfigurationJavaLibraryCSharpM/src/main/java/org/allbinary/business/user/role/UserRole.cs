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
//using Serializable = java.io.Serializable;
using UserFactoryInterface = org.allbinary.business.user.UserFactoryInterface;

namespace org.allbinary.business.user.role;

public class UserRole : Serializable
{
    private BasicUserRole basicUserRole;
    private UserFactoryInterface userFactoryInterface;
    protected UserRole(BasicUserRole aBasicUserRole, UserFactoryInterface aUserFactoryInterface)
    {
        this.basicUserRole = aBasicUserRole;
        this.userFactoryInterface = aUserFactoryInterface;
    }

    public override string ToString()
    {
        return this.basicUserRole.ToString();
    }

    public virtual BasicUserRole getBasicUserRole()
    {
        return this.basicUserRole;
    }

    // throws Exception
    public virtual UserFactoryInterface getUserFactory()
    {
        return this.userFactoryInterface;
    }

    public virtual long getSessionTimeout()
    {
        return this.basicUserRole.getSessionTimeout();
    }

    public virtual long getSessionInactivityTimeout()
    {
        return this.basicUserRole.getSessionInactivityTimeout();
    }

}

