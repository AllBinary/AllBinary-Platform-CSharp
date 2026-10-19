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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.business.user.role;

public class StoreRoleFactory
{
    private static readonly StoreRoleFactory instance = new StoreRoleFactory();
    public static StoreRoleFactory getInstance()
    {
        return StoreRoleFactory.instance;
    }

    private readonly BasicArrayList roles = new BasicArrayListD();
    private readonly BasicArrayList subscriberRoles = new BasicArrayListD();
    private readonly BasicArrayList wholesaleRoles = new BasicArrayListD();
    private StoreRoleFactory()
    {
        BasicUserRoleFactory basicUserRoleFactory = BasicUserRoleFactory.getInstance();
        this.roles.add(basicUserRoleFactory.CUSTOMER);
        this.roles.add(basicUserRoleFactory.SUBSCRIBERCUSTOMER);
        this.roles.add(basicUserRoleFactory.WHOLESALECUSTOMER);
        this.subscriberRoles.add(basicUserRoleFactory.SUBSCRIBERCUSTOMER);
        this.wholesaleRoles.add(basicUserRoleFactory.WHOLESALECUSTOMER);
    }

    public virtual BasicArrayList getRoles()
    {
        return this.roles;
    }

    public virtual BasicArrayList getSubscriberRoles()
    {
        return this.subscriberRoles;
    }

    public virtual BasicArrayList getWholesaleRoles()
    {
        return this.wholesaleRoles;
    }

}

