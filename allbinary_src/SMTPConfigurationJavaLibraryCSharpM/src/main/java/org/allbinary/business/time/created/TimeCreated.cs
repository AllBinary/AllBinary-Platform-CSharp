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
using Time = org.allbinary.business.time.Time;

namespace org.allbinary.business.time.created;

public class TimeCreated : Time
{
    public TimeCreated(string time) : base(long.Parse(time))
    {
        // Constructor invocation emitted in the initializer.
    }

    public TimeCreated(long time) : base(time)
    {
        // Constructor invocation emitted in the initializer.
    }

}

