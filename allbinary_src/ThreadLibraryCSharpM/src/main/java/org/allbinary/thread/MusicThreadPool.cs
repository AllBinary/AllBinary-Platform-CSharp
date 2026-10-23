/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.thread;

public class MusicThreadPool : ThreadPool
{
    private static readonly ThreadPool THREAD_POOL = new ThreadPool("Music", 2, ThreadPool.NORMAL_PRIORITY);
    public static ThreadPool getInstance()
    {
        return MusicThreadPool.THREAD_POOL;
    }

    public MusicThreadPool(string poolName, int numThreads, int priority) : base(poolName, numThreads, priority)
    {
        // base(poolName, numThreads, priority) is called from the constructor declaration
    }

    public override void runTask(global::java.lang.Runnable task)
    {
        this.logUtil.putF(new StringMaker().append(StringUtil.getInstance().toString(task)).appendlong(((long) DateTimeOffset.Now.ToUnixTimeMilliseconds())).ToString(), this, this.threadPoolStrings.ADD_TASK);
        base.runTask(task);
    }

    public override void startTask(global::java.lang.Runnable task)
    {
        this.logUtil.putF(new StringMaker().append(this.threadPoolStrings.START_TASK).append(StringUtil.getInstance().toString(task)).appendlong(((long) DateTimeOffset.Now.ToUnixTimeMilliseconds())).ToString(), this, this.commonStrings.RUN);
    }

    public override void completedTask(global::java.lang.Runnable task)
    {
        this.logUtil.putF(new StringMaker().append(this.threadPoolStrings.COMPLETE_TASK).append(StringUtil.getInstance().toString(task)).appendlong(((long) DateTimeOffset.Now.ToUnixTimeMilliseconds())).ToString(), this, this.commonStrings.RUN);
    }

}

