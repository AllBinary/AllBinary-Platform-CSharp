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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.thread;

public class ThreadPool
{
    private static readonly string ROOT_NAME = "-PooledThread-";
    public static readonly int NORMAL_PRIORITY = Thread.NORM_PRIORITY;
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly NullRunnable NULL_RUNNABLE = NullRunnable.getInstance();
    public readonly ThreadPoolStrings threadPoolStrings = ThreadPoolStrings.getInstance();
    public readonly ThreadObjectUtil threadObjectUtil = ThreadObjectUtil.getInstance();
    private readonly string poolName;
    private readonly int priority;
    private bool isAlive = false;
    private BasicArrayList taskQueue = BasicArrayListUtil.getInstance().getImmutableInstance();
    private int threadID = 0;
    private int numThreads;
    public bool runningTask = false;
    public ThreadPool(string poolName, int numThreads, int priority)
    {
        this.poolName = poolName;
        this.priority = priority;
        this.numThreads = numThreads;
    }

    public virtual void init()
    {
        if (!this.isAlive) {
            this.isAlive = true;
            this.taskQueue = new BasicArrayListD();
            PooledThread pooledThread = null;
            for (int i = 0; i < this.numThreads; i++) {
                pooledThread = new PooledThread(this);
                pooledThread.setPriority(this.priority);
                pooledThread.start();
            }
        }
    }

    // throws Exception
    public virtual void runAPriorityTask()
    {
        throw new SystemException();
    }

    public virtual void runTaskWithPriority(PriorityRunnable task)
    {
        lock (this) {
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
                System.Threading.Monitor.Pulse(this);
            }
        }
    }

    public virtual void runTask(global::java.lang.Runnable task)
    {
        lock (this) {
            if (!this.isAlive) {
                this.init();
            }
            if (task != null) {
                this.taskQueue.add(task);
                System.Threading.Monitor.Pulse(this);
            }
        }
    }

    // throws InterruptedException
    protected virtual global::java.lang.Runnable getTask()
    {
        lock (this) {
            while (this.taskQueue.size() == 0) {
                if (!this.isAlive) {
                    return this.NULL_RUNNABLE;
                }
                System.Threading.Monitor.Wait(this);
            }
            global::java.lang.Runnable runnable = ((global::java.lang.Runnable) this.taskQueue.removeAt(0));
            return runnable;
        }
    }

    public virtual void clear()
    {
        lock (this) {
            if (this.isAlive) {
                this.taskQueue.clear();
            }
        }
    }

    public virtual void close()
    {
        lock (this) {
            if (this.isAlive) {
                this.isAlive = false;
                this.taskQueue.clear();
            }
        }
    }

    public virtual void join()
    {
        lock (this) {
            this.isAlive = false;
            this.taskQueue.clear();
            System.Threading.Monitor.PulseAll(this);
        }
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
        }
    }

    protected virtual void startTask(global::java.lang.Runnable task)
    {
    }

    protected virtual void completedTask(global::java.lang.Runnable task)
    {
    }

    public virtual string createName()
    {
        return new StringMaker().append(this.poolName).append(ThreadPool.ROOT_NAME).appendint(this.threadID++).ToString();
    }

}

