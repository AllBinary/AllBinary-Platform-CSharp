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
using Debug = android.os.Debug;

namespace org.allbinary.debug;

public class AndroidDebug : DebugInterface
{
    private long startTime = long.MaxValue;
    private bool running = false;
    private int bufferSize = 32 * 1024 * 1024;
    public virtual void start()
    {
        this.setStartTime(DateTimeOffset.Now.ToUnixTimeMilliseconds());
        Debug.startMethodTracing("trace", this.bufferSize);
        this.setRunning(true);
    }

    public virtual void stop()
    {
        this.startTime = long.MaxValue;
        Debug.stopMethodTracing();
        this.setRunning(false);
    }

    public virtual long getMaxTime()
    {
        return 120000L;
    }

    private void setStartTime(long startTime)
    {
        this.startTime = startTime;
    }

    public virtual long getStartTime()
    {
        return this.startTime;
    }

    private void setRunning(bool running)
    {
        this.running = running;
    }

    public virtual bool isRunning()
    {
        return this.running;
    }

}

