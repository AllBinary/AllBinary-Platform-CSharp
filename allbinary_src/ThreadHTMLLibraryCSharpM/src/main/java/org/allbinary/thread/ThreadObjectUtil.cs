// Generated Code Do Not Modify

using System;
using System.Linq;

namespace org.allbinary.thread;

public class ThreadObjectUtil
{
    private static readonly ThreadObjectUtil instance = new ThreadObjectUtil();
    public static ThreadObjectUtil getInstance()
    {
        return ThreadObjectUtil.instance;
    }

    public readonly PriorityRunnable NULL_PRIORITY_RUNNABLE = new NullPriorityRunnable();
    public virtual void notifyObject(object anyType)
    {
    }

    // throws Exception
    public virtual void waitObject(object anyType)
    {
    }

    // throws Exception
    public virtual void waitObjectFor(object anyType, long delay)
    {
    }

    public virtual void processThread(global::java.lang.Runnable runnable)
    {
        runnable.run();
    }

}

