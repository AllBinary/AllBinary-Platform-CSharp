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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.thread;

public class PrimaryThreadPool : ThreadPool
{
    private static readonly ThreadPool THREAD_POOL = new ThreadPool("Primary", 1, ThreadPool.NORMAL_PRIORITY);
    public static ThreadPool getInstance()
    {
        return PrimaryThreadPool.THREAD_POOL;
    }

    public PrimaryThreadPool(string poolName, int numThreads, int priority) : base(poolName, numThreads, priority)
    {
        // base(poolName, numThreads, priority) is called from the constructor declaration
    }

    public override void runTask(global::java.lang.Runnable task)
    {
        this.logUtil.putF(new StringMaker().append(StringUtil.getInstance().toString(task)).appendlong(((long) DateTimeOffset.Now.ToUnixTimeMilliseconds())).ToString(), this, this.threadPoolStrings.ADD_TASK);
        base.runTask(task);
    }

    protected override void startTask(global::java.lang.Runnable task)
    {
        this.logUtil.putF(new StringMaker().append(this.threadPoolStrings.START_TASK).append(StringUtil.getInstance().toString(task)).ToString(), this, this.commonStrings.RUN);
    }

    protected override void completedTask(global::java.lang.Runnable task)
    {
        this.logUtil.putF(new StringMaker().append(this.threadPoolStrings.COMPLETE_TASK).append(StringUtil.getInstance().toString(task)).ToString(), this, this.commonStrings.RUN);
    }

}

