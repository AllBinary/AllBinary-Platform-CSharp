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

namespace org.allbinary.logic.communication.java.vm.stats;

public class JvmStatistics
{
    private Runtime runtime;
    public JvmStatistics()
    {
        this.runtime = Runtime.getRuntime();
    }

    public virtual long getFreeMemoryBytes()
    {
        return this.runtime.freeMemory();
    }

    public virtual long getFreeMemoryKilobytes()
    {
        return this.getFreeMemoryBytes() / 1024L;
    }

    public virtual long getFreeMemoryMegabytes()
    {
        return this.getFreeMemoryKilobytes() / 1024L;
    }

    public virtual long getMaxMemoryBytes()
    {
        return this.runtime.maxMemory();
    }

    public virtual long getMaxMemoryKilobytes()
    {
        return this.getMaxMemoryBytes() / 1024L;
    }

    public virtual long getMaxMemoryMegabytes()
    {
        return this.getMaxMemoryKilobytes() / 1024L;
    }

    public virtual long getTotalMemoryBytes()
    {
        return this.runtime.totalMemory();
    }

    public virtual long getTotalMemoryKilobytes()
    {
        return this.getTotalMemoryBytes() / 1024L;
    }

    public virtual long getTotalMemoryMegabytes()
    {
        return this.getTotalMemoryKilobytes() / 1024L;
    }

    public virtual long? getFreeMemoryBytesLong()
    {
        return this.getFreeMemoryBytes();
    }

    public virtual long? getFreeMemoryKilobytesLong()
    {
        return this.getFreeMemoryKilobytes();
    }

    public virtual long? getFreeMemoryMegabytesLong()
    {
        return this.getFreeMemoryMegabytes();
    }

    public virtual long? getMaxMemoryBytesLong()
    {
        return this.getMaxMemoryBytes();
    }

    public virtual long? getMaxMemoryKilobytesLong()
    {
        return this.getMaxMemoryKilobytes();
    }

    public virtual long? getMaxMemoryMegabytesLong()
    {
        return this.getMaxMemoryMegabytes();
    }

    public virtual long? getTotalMemoryBytesLong()
    {
        return this.getTotalMemoryBytes();
    }

    public virtual long? getTotalMemoryKilobytesLong()
    {
        return this.getTotalMemoryKilobytes();
    }

    public virtual long? getTotalMemoryMegabytesLong()
    {
        return this.getTotalMemoryMegabytes();
    }

    public virtual string getFreeMemoryBytesString()
    {
        return this.getFreeMemoryBytesLong().ToString();
    }

    public virtual string getFreeMemoryKilobytesString()
    {
        return this.getFreeMemoryKilobytesLong().ToString();
    }

    public virtual string getFreeMemoryMegabytesString()
    {
        return this.getFreeMemoryMegabytesLong().ToString();
    }

    public virtual string getMaxMemoryBytesString()
    {
        return this.getMaxMemoryBytesLong().ToString();
    }

    public virtual string getMaxMemoryKilobytesString()
    {
        return this.getMaxMemoryKilobytesLong().ToString();
    }

    public virtual string getMaxMemoryMegabytesString()
    {
        return this.getMaxMemoryMegabytesLong().ToString();
    }

    public virtual string getTotalMemoryBytesString()
    {
        return this.getTotalMemoryBytesLong().ToString();
    }

    public virtual string getTotalMemoryKilobytesString()
    {
        return this.getTotalMemoryKilobytesLong().ToString();
    }

    public virtual string getTotalMemoryMegabytesString()
    {
        return this.getTotalMemoryMegabytesLong().ToString();
    }

    public virtual long getNumberOfThreads()
    {
        return Thread.activeCount();
    }

    public virtual long? getNumberOfThreadsLong()
    {
        return this.getNumberOfThreads();
    }

    public virtual string getNumberOfThreadsString()
    {
        return this.getNumberOfThreadsLong().ToString();
    }

    public virtual void collectGarbage()
    {
        this.runtime.gc();
    }

}

