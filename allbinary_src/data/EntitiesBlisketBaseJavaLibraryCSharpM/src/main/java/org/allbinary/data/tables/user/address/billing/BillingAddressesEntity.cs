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
using StreetAddressesEntity = org.allbinary.data.tables.user.address.StreetAddressesEntity;

namespace org.allbinary.data.tables.user.address.billing;

public class BillingAddressesEntity : StreetAddressesEntity
{
    private readonly string TABLENAME = "billing";
    public BillingAddressesEntity(string userName) : base(userName)
    {
        // base(userName) is called from the constructor declaration
        setTableName(this.TABLENAME);
    }

}

