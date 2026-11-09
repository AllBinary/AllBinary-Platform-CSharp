/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2026 AllBinary 
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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.business.user.role;

public class BasicUserRoles
{
    private static readonly BasicUserRoles instance = new BasicUserRoles();
    public static BasicUserRoles getInstance()
    {
        return BasicUserRoles.instance;
    }

    public readonly BasicArrayList roleVector = new BasicArrayListD();
    // throws Exception
    public virtual BasicUserRole getRole(string role)
    {
        BasicArrayList roleVector = this.getAll();
        int size = roleVector.size();
        for (int index = 0; index < size; index++) {
            BasicUserRole userRole = ((BasicUserRole) roleVector.get(index));
            if (string.CompareOrdinal(role, userRole.ToString()) == 0) {
                return userRole;
            }
        }
        throw new Exception("Unable to get role - Unknown Role");
    }

    public virtual BasicArrayList getAll()
    {
        return this.roleVector;
    }

}

