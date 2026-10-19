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

namespace org.allbinary.logic.system.security.licensing;

public class LockableFeatureFactory
{
    private static readonly LockableFeatureFactory instance = new LockableFeatureFactory();
    public static LockableFeatureFactory getInstance()
    {
        return LockableFeatureFactory.instance;
    }

    private readonly BasicArrayList list = new BasicArrayListD();
    public virtual BasicArrayList getList()
    {
        return this.list;
    }

}

