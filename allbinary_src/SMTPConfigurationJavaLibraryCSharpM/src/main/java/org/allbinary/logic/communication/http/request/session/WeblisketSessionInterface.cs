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
using OrderInterface = org.allbinary.business.user.commerce.inventory.order.OrderInterface;
using UserRole = org.allbinary.business.user.role.UserRole;

namespace org.allbinary.logic.communication.http.request.session;

public interface WeblisketSessionInterface
{
    void clear();

    int? getAttempts();

    string getAuthentication();

    long getCreationTime();

    string getId();

    long getLastAccessedTime();

    // throws Exception
    OrderInterface getOrder();

    string getPassword();

    string getPaymentMethod();

    // throws Exception
    UserRole getRole();

    string getStoreName();

    string getTimeout();

    string getUserName();

    string getWebAppPath();

    void removeBasket();

    void setAttempts(int? value);

    void setAuthenticated();

    void setAuthenticated(bool value);

    void setPassword(string password);

    void setPaymentMethod(string value);

    void setRole(UserRole aRole);

    void setStoreName(string value);

    void setTimeout(string value);

    void setUserName(string userName);

}

