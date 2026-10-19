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
using LongArrayIdentifierInterface = org.allbinary.thirdparty.store.LongArrayIdentifierInterface;

namespace org.allbinary.logic.system.security.licensing;

public class StoreAppClientInformation : AbeClientInformation, LongArrayIdentifierInterface
{
    private readonly long[] longArrayIdentifier;
    public StoreAppClientInformation(string name, string version, string specialName, string shortName, long[] longArrayIdentifier) : base(name, version, specialName, shortName)
    {
        // base(name, version, specialName, shortName) is called from the constructor declaration
        this.longArrayIdentifier = longArrayIdentifier;
    }

    public override long[] getLongArrayIdentifier()
    {
        return this.longArrayIdentifier;
    }

}

