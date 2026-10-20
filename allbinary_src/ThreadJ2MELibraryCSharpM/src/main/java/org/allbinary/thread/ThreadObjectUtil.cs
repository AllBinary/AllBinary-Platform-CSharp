// Generated Code Do Not Modify

using System;
using System.Linq;
using TsUtil = org.allbinary.TsUtil;

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
        System.Threading.Monitor.Pulse(anyType);
    }

    // throws Exception
    public virtual void waitObject(object anyType)
    {
        System.Threading.Monitor.Wait(anyType);
    }

    // throws Exception
    public virtual void waitObjectFor(object anyType, long delay)
    {
        TsUtil.getInstance().waitFor(anyType, delay);
    }

    public virtual void processThread(global::java.lang.Runnable runnable)
    {
        Thread thread = new Thread(runnable);
        thread.start();
    }

}

