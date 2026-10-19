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
using UserRole = org.allbinary.business.user.role.UserRole;
using UserRoleB = org.allbinary.business.user.role.UserRoleB;
using UserRoleData = org.allbinary.business.user.role.UserRoleData;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;

namespace org.allbinary.business.user;

public class CreateUserFactory
{
    private CreateUserFactory()
    {
    }

    // throws Exception
    public static UserInterface getInstance(HashMap hashMap)
    {
        if (hashMap != null) {
            string roleString = ((string) hashMap.get(UserRoleData.NAME.ToString()));
            if (!StringValidationUtil.getInstance().isEmpty(roleString)) {
                UserRole role = UserRoleB.getRole(roleString);
                return role.getUserFactory().getInstance(hashMap);
            } else {
                throw new Exception("No Role Specified");
            }
        } else {
            throw new Exception("Null HashMap");
        }
    }

}

