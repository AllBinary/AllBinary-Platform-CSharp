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
//using HashMap = java.util.HashMap;
using UserFactoryInterface = org.allbinary.business.user.UserFactoryInterface;
using UserInterface = org.allbinary.business.user.UserInterface;

namespace org.allbinary.business.user.modules.admin.store.order.review;

public class ReviewOrderStoreAdminUserFactory : UserFactoryInterface
{
    public ReviewOrderStoreAdminUserFactory()
    {
    }

    // throws Exception
    public virtual UserInterface getInstance()
    {
        return new ReviewOrderStoreAdminUser();
    }

    // throws Exception
    public virtual UserInterface getInstance(HashMap hashMap)
    {
        return new ReviewOrderStoreAdminUser(hashMap);
    }

}

