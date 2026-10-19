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

namespace org.allbinary.thread;

//This is mainly for network communications.
public class PathFindingThreadPool : ThreadPool
{
    private static readonly ThreadPool instance = new PathFindingThreadPool("PathFinding", 1, 1);
    public static ThreadPool getInstance()
    {
        return PathFindingThreadPool.instance;
    }

    public PathFindingThreadPool(string poolName, int numThreads, int priority) : base(poolName, numThreads, ThreadPool.NORMAL_PRIORITY)
    {
        // base(poolName, numThreads, ThreadPool.NORMAL_PRIORITY) is called from the constructor declaration
    }

    public override void runTaskWithPriority(PriorityRunnable task)
    {
        base.runTaskWithPriority(task);
    }

    public override void runTask(Runnable task)
    {
        base.runTask(task);
    }

    protected override void startTask(Runnable task)
    {
    }

    protected override void completedTask(Runnable task)
    {
    }

}

