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
using UserFactoryInterface = org.allbinary.business.user.UserFactoryInterface;
using StdUtil = org.allbinary.logic.StdUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;

namespace org.allbinary.business.user.role;

public class UserRoleB : UserRole
{
    public static BasicArrayList roleVector = new BasicArrayListD();
    protected UserRoleB(BasicUserRole aBasicUserRole, UserFactoryInterface aUserFactoryInterface) : base(aBasicUserRole, aUserFactoryInterface)
    {
        // base(aBasicUserRole, aUserFactoryInterface) is called from the constructor declaration
        UserRoleB.roleVector.add(this);
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static UserRole getRole(string role)
    {
        UserRoleFactory.getInstance();
        if (!StringValidationUtil.getInstance().isEmpty(role)) {
            BasicArrayList roleVector = UserRoleB.getAll();
            int size = roleVector.size();
            for (int index = 0; index < size; index++) {
                UserRole userRole = ((UserRole) roleVector.get(index));
                if (string.CompareOrdinal(role, userRole.ToString()) == 0) {
                    return userRole;
                }
            }
        }
        throw new Exception("Unable to get role - Unknown Role = " + role);
    }

    public static BasicArrayList getAll()
    {
        UserRoleFactory.getInstance();
        return UserRoleB.roleVector;
    }

}

