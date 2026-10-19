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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.thread;

public class PooledThread : Thread
{
    private readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly ThreadObjectUtil threadObjectUtil = ThreadObjectUtil.getInstance();
    private readonly ThreadPool threadPool;
    public PooledThread(ThreadPool threadPool) : base(threadPool.createName())
    {
        // base(threadPool.createName()) is called from the constructor declaration
        this.logUtil.putF(this.commonStrings.CONSTRUCTOR, this, this.commonStrings.CONSTRUCTOR);
        this.threadPool = threadPool;
    }

    private readonly string INTERRUPT_EXCEPTION = "Exit InterruptedException";
    public override void run()
    {
        this.threadPool.threadStarted();
        while (true) {
            Runnable task2 = this.threadObjectUtil.NULL_PRIORITY_RUNNABLE;
            try {
                task2 = this.threadPool.getTask();
                this.threadPool.runningTask = true;
                this.threadPool.startTask(task2);
            } catch (System.Threading.ThreadInterruptedException ex) {
                LogUtil logUtil = LogUtil.getInstance();
                logUtil.putF(this.INTERRUPT_EXCEPTION, this, this.commonStrings.RUN);
                break;
            }
            if (task2 == this.threadObjectUtil.NULL_PRIORITY_RUNNABLE) {
                break;
            }
            try {
                task2.run();
                this.threadPool.completedTask(task2);
                this.threadPool.runningTask = false;
            } catch (Exception e) {
                LogUtil logUtil = LogUtil.getInstance();
                logUtil.put(new StringMaker().append(this.commonStrings.EXCEPTION_LABEL).append(StringUtil.getInstance().toString(task2)).ToString(), this, this.commonStrings.RUN, e);
            }
        }
        this.threadPool.threadStopped();
    }

}

