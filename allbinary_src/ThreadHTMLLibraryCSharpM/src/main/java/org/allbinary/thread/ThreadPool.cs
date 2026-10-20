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
using System.Runtime.CompilerServices;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.thread;

public class ThreadPool
{
    public static readonly int NORMAL_PRIORITY = 5;
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly NullRunnable NULL_RUNNABLE = NullRunnable.getInstance();
    public readonly ThreadPoolStrings threadPoolStrings = ThreadPoolStrings.getInstance();
    public readonly ThreadObjectUtil threadObjectUtil = ThreadObjectUtil.getInstance();
    private bool isAlive = false;
    private BasicArrayList taskQueue = new BasicArrayListD();
    private int numThreads = 0;
    private bool runningTask = false;
    public ThreadPool(string poolName, int numThreads, int priority)
    {
        this.currentPriorityRunnable = this.threadObjectUtil.NULL_PRIORITY_RUNNABLE;
    }

    private PriorityRunnable currentPriorityRunnable;
    // throws Exception
    public virtual void runAPriorityTask()
    {
        if (!this.currentPriorityRunnable.isDone()) {
            this.currentPriorityRunnable.run();
        } else {
            global::java.lang.Runnable runnable = this.getTask();
            if (runnable == this.NULL_RUNNABLE) {
                return;
            }
            this.currentPriorityRunnable = ((PriorityRunnable) runnable);
            if (!(this.currentPriorityRunnable == this.threadObjectUtil.NULL_PRIORITY_RUNNABLE)) {
                this.currentPriorityRunnable.reset();
                this.currentPriorityRunnable.run();
            }
        }
    }

    // throws Exception
    public virtual void runATask()
    {
        global::java.lang.Runnable runnable = this.getTask();
        if (runnable != null) {
            runnable.run();
        }
    }

    public virtual void init()
    {
        if (!this.isAlive) {
            this.isAlive = true;
            this.taskQueue = new BasicArrayListD();
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void runTaskWithPriority(PriorityRunnable task)
    {
        if (!this.isAlive) {
            this.init();
        }
        if (task != null) {
            int size = this.taskQueue.size();
            PriorityRunnable runnable = null;
            PriorityRunnable lowerPriorityRunnable = this.threadObjectUtil.NULL_PRIORITY_RUNNABLE;
            for (int index = 0; index < size; index++) {
                runnable = ((PriorityRunnable) this.taskQueue.get(index));
                if (runnable.getPriority() > task.getPriority()) {
                    lowerPriorityRunnable = runnable;
                    break;
                }
            }
            if (lowerPriorityRunnable == this.threadObjectUtil.NULL_PRIORITY_RUNNABLE) {
                this.taskQueue.add(task);
            } else {
                int index = this.taskQueue.indexOf(lowerPriorityRunnable);
                this.taskQueue.addAt(index, task);
            }
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void runTask(global::java.lang.Runnable task)
    {
        if (!this.isAlive) {
            this.init();
        }
        if (task != null) {
            this.taskQueue.add(task);
        }
    }

    // throws InterruptedException
    [MethodImpl(MethodImplOptions.Synchronized)]
    protected virtual global::java.lang.Runnable getTask()
    {
        if (this.taskQueue.isEmpty()) {
            return this.NULL_RUNNABLE;
        }
        return ((global::java.lang.Runnable) this.taskQueue.removeAt(0));
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void clear()
    {
        this.taskQueue.clear();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void close()
    {
        if (this.isAlive) {
            this.isAlive = false;
            this.taskQueue.clear();
            this.currentPriorityRunnable = this.threadObjectUtil.NULL_PRIORITY_RUNNABLE;
        }
    }

    public virtual void join()
    {
        this.isAlive = false;
        this.taskQueue.clear();
        this.currentPriorityRunnable = this.threadObjectUtil.NULL_PRIORITY_RUNNABLE;
    }

    public virtual bool isBusy()
    {
        if (!this.isAlive) {
            return false;
        }
        if (this.taskQueue.size() > 0) {
            return true;
        }
        if (this.runningTask) {
            return true;
        }
        return false;
    }

    protected virtual void threadStarted()
    {
    }

    protected virtual void threadStopped()
    {
        if (this.numThreads == 1) {
            this.isAlive = false;
            this.taskQueue.clear();
            this.currentPriorityRunnable = this.threadObjectUtil.NULL_PRIORITY_RUNNABLE;
        }
    }

    protected virtual void startTask(global::java.lang.Runnable task)
    {
    }

    protected virtual void completedTask(global::java.lang.Runnable task)
    {
    }

}

