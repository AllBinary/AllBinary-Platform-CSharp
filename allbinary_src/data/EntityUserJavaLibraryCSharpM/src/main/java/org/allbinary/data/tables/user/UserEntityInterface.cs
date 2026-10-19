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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StoreFrontInterface = org.allbinary.business.context.modules.storefront.StoreFrontInterface;
using UserInterface = org.allbinary.business.user.UserInterface;
using UserRole = org.allbinary.business.user.role.UserRole;
using BasicDataTableInterface = org.allbinary.data.tables.BasicDataTableInterface;

namespace org.allbinary.data.tables.user;

public interface UserEntityInterface : BasicDataTableInterface
{
    // throws Exception
    BasicArrayList getAdministrators();

    // throws Exception
    BasicArrayList getStoreManagers(StoreFrontInterface storeFrontInterface);

    // throws Exception
    BasicArrayList getCustomers();

    // throws Exception
    BasicArrayList getUsersWithRole(UserRole userRole);

    // throws Exception
    BasicArrayList getUsers(StoreFrontInterface storeFrontInterface);

    // throws Exception
    UserInterface getUser(string userName);

    string login(string userName, string password);

    void deleteWhere(string key, string value);

    void insert(BasicArrayList values);

    void update(string userName, HashMap updatedValues);

}

