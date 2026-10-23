/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.thread;

public class NullThread
{
    public static readonly global::org.allbinary.thread.NullThread NULL_THREAD = new global::org.allbinary.thread.NullThread(NullRunnable.getInstance(), StringUtil.getInstance().EMPTY_STRING);
    public const int MIN_PRIORITY = 1;
    public const int NORM_PRIORITY = 5;
    public const int MAX_PRIORITY = 10;
    private global::java.lang.Runnable threadTarget;
    private global::System.Threading.Thread systemThread;
    private string threadName;
    private int threadPriority = NORM_PRIORITY;

    public NullThread()
    {
    }

    public NullThread(global::java.lang.Runnable target)
    {
        this.threadTarget = target;
    }

    public NullThread(string name)
    {
        this.threadName = name;
    }

    public virtual void run()
    {
        if (this.threadTarget != null)
        {
            this.threadTarget.run();
        }
    }

    public virtual void start()
    {
        this.systemThread = new global::System.Threading.Thread(this.run);
        if (!string.IsNullOrEmpty(this.threadName))
        {
            this.systemThread.Name = this.threadName;
        }
        this.applyPriority();
        this.systemThread.Start();
    }

    public virtual void interrupt()
    {
        if (this.systemThread != null)
        {
            this.systemThread.Interrupt();
        }
    }

    public virtual void join()
    {
        if (this.systemThread != null)
        {
            this.systemThread.Join();
        }
    }

    public virtual bool isAlive()
    {
        return this.systemThread != null && this.systemThread.IsAlive;
    }

    public virtual void setPriority(int priority)
    {
        this.threadPriority = global::System.Math.Max(MIN_PRIORITY, global::System.Math.Min(MAX_PRIORITY, priority));
        if (this.systemThread != null)
        {
            this.applyPriority();
        }
    }

    public virtual int getPriority()
    {
        return this.threadPriority;
    }

    public virtual void setName(string name)
    {
        this.threadName = name;
        if (this.systemThread != null && this.systemThread.Name == null)
        {
            this.systemThread.Name = name;
        }
    }

    public virtual string getName()
    {
        return this.systemThread != null ? this.systemThread.Name : this.threadName;
    }

    private void applyPriority()
    {
        this.systemThread.Priority = this.threadPriority <= 2
            ? global::System.Threading.ThreadPriority.Lowest
            : this.threadPriority <= 4
                ? global::System.Threading.ThreadPriority.BelowNormal
                : this.threadPriority <= 6
                    ? global::System.Threading.ThreadPriority.Normal
                    : this.threadPriority <= 8
                        ? global::System.Threading.ThreadPriority.AboveNormal
                        : global::System.Threading.ThreadPriority.Highest;
    }

}

