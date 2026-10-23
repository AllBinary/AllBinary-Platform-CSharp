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
using Serializable = java.io.Serializable;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.business.user.role;

public class BasicUserRole : Serializable
{
    private static readonly BasicArrayList roleVector = new BasicArrayListD();
    private readonly int m_int_RoleId;
    private readonly string role;
    private readonly string displayValue;
    private readonly long sessionTimeout;
    private readonly long sessionInactivityTimeout;
    public BasicUserRole(string aRole, int a_int_RoleId, long aSessionTimeout, long aSessionInactivityTimeout) : this(aRole, aRole, a_int_RoleId, aSessionTimeout, aSessionInactivityTimeout)
    {
        // this(aRole, aRole, a_int_RoleId, aSessionTimeout, aSessionInactivityTimeout) is called from the constructor declaration
    }

    public BasicUserRole(string aRole, string aDisplayValue, int a_int_RoleId, long aSessionTimeout, long aSessionInactivityTimeout)
    {
        this.m_int_RoleId = a_int_RoleId;
        this.role = aRole;
        this.displayValue = aDisplayValue;
        this.sessionTimeout = aSessionTimeout;
        this.sessionInactivityTimeout = aSessionInactivityTimeout;
        BasicUserRole.roleVector.add(this);
    }

    private int getRoleId()
    {
        return this.m_int_RoleId;
    }

    public virtual string getRole()
    {
        return this.role;
    }

    public virtual long getSessionTimeout()
    {
        return this.sessionTimeout;
    }

    public virtual long getSessionInactivityTimeout()
    {
        return this.sessionInactivityTimeout;
    }

    public virtual bool Equals(BasicUserRole basicUserRole)
    {
        if (this.getRoleId() == basicUserRole.getRoleId()) {
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return this.getRole();
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static BasicUserRole getRole(string role)
    {
        BasicArrayList roleVector = BasicUserRole.getAll();
        int size = roleVector.size();
        for (int index = 0; index < size; index++) {
            BasicUserRole userRole = ((BasicUserRole) roleVector.get(index));
            if (string.CompareOrdinal(role, userRole.ToString()) == 0) {
                return userRole;
            }
        }
        throw new Exception("Unable to get role - Unknown Role");
    }

    public static BasicArrayList getAll()
    {
        return BasicUserRole.roleVector;
    }

}

