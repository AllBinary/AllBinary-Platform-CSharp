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

namespace org.allbinary.debug;

public class NoDebug : DebugInterface
{
    private static DebugInterface SINGLETON = new NoDebug();
    public static DebugInterface getInstance()
    {
        return NoDebug.SINGLETON;
    }

    public virtual void start()
    {
    }

    public virtual void stop()
    {
    }

    public virtual long getMaxTime()
    {
        return 10000L;
    }

    public virtual long getStartTime()
    {
        return 0L;
    }

    public virtual bool isRunning()
    {
        return false;
    }

}

