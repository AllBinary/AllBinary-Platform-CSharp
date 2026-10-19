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

namespace org.allbinary.business.init.db;

public class InventoryDbInitInfo : DbInitInfo
{
    private static readonly string INITFILE = "inventorydbinitdata.dat";
    public InventoryDbInitInfo() : base(INITFILE, true)
    {
        // base(INITFILE, true) is called from the constructor declaration
    }

    public InventoryDbInitInfo(bool read) : base(INITFILE, read)
    {
        // base(INITFILE, read) is called from the constructor declaration
    }

}

