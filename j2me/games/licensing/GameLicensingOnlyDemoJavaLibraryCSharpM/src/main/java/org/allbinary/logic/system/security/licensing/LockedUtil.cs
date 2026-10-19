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

namespace org.allbinary.logic.system.security.licensing;

public class LockedUtil : LockedUtilInterface
{
    private static readonly LockedUtil instance = new LockedUtil();
    public static LockedUtil getInstance()
    {
        return LockedUtil.instance;
    }

    public virtual bool isLocked()
    {
        return true;
    }

    public virtual bool isLockedFeature(LockableFeature lockableFeatrue)
    {
        return true;
    }

}

