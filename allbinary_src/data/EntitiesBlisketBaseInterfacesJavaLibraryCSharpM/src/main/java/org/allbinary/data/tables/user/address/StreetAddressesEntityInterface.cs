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
using StreetAddress = org.allbinary.business.user.address.StreetAddress;
using BasicDataTableInterface = org.allbinary.data.tables.BasicDataTableInterface;

namespace org.allbinary.data.tables.user.address;

public interface StreetAddressesEntityInterface : BasicDataTableInterface
{
    void remove(int? index);

    void add(StreetAddress address);

    void update(StreetAddress address);

    string getLastId();

    StreetAddress getDefault();

    void setDefault(string value);

}

