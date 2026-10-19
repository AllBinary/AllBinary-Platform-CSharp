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
//using Set = java.util.Set;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using UserInterface = org.allbinary.business.user.UserInterface;
using UserRole = org.allbinary.business.user.role.UserRole;
using UserEntityFactory = org.allbinary.data.tables.user.UserEntityFactory;
using UserEntityInterface = org.allbinary.data.tables.user.UserEntityInterface;
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.business.context.modules.storefront.statistics.users;

public class StoreFrontUsersStatistics : StoreFrontUsersStatisticsInterface
{
    private long? totalNumberOfUsers;
    private HashMap totalUsersByRoleHashMap;
    public StoreFrontUsersStatistics(StoreFrontInterface storeFrontInterface)
    {
        this.totalUsersByRoleHashMap = StdUtil.getInstance().createHashMap();
        UserEntityInterface userEntityInterface = UserEntityFactory.getInstance();
        BasicArrayList userVector = userEntityInterface.getCustomers();
        this.totalNumberOfUsers = userVector.size();
        int size = userVector.size();
        for (int index = 0; index < size; index++) {
            UserInterface userInterface = ((UserInterface) userVector.get(index));
            UserRole nextUserRole = userInterface.getRole();
            long? currentNumberOfUsersForRole = this.getNewTotal(nextUserRole);
            this.totalUsersByRoleHashMap.put(nextUserRole, currentNumberOfUsersForRole);
        }
    }

    private long? getNewTotal(UserRole userRole)
    {
        long? numberOfUsersForRoleLong = ((long?) this.totalUsersByRoleHashMap.get(userRole));
        if (numberOfUsersForRoleLong == null) {
            numberOfUsersForRoleLong = 0;
        }
        return ((long) numberOfUsersForRoleLong) + 1;
    }

    public virtual long? getNumberOfUsers()
    {
        return this.totalNumberOfUsers;
    }

    public virtual long? getNumberOfUsersByRole(string role)
    {
        long? totalForRole = ((long?) this.totalUsersByRoleHashMap.get(role));
        return totalForRole;
    }

    public virtual HashMap toHashMap()
    {
        HashMap hashMap = StdUtil.getInstance().createHashMap();
        hashMap.put(StoreFrontUsersStatisticsData.getInstance().NUMBEROFUSERS, this.getNumberOfUsers().ToString());
        Set setOfUserRoles = this.totalUsersByRoleHashMap.keySet();
        UserRole nextUserRole = null;
        object[] userRoleArray = setOfUserRoles.toArray();
        int size = userRoleArray.Length;
        for (int index = 0; index < size; index++) {
            nextUserRole = ((UserRole) userRoleArray[index]);
            long? totalForRole = ((long?) this.totalUsersByRoleHashMap.get(nextUserRole));
            hashMap.put(nextUserRole.ToString(), totalForRole.ToString());
        }
        return hashMap;
    }

    public virtual BasicArrayList toVector()
    {
        return null;
    }

    public virtual object getKey()
    {
        return null;
    }

}

