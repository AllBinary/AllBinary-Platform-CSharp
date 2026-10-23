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
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.thread;

//This is mainly for network communications.
public class ImageThreadPool : ThreadPool
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ThreadPool instance = new ImageThreadPool("ImageLoader", 1, ThreadPool.NORMAL_PRIORITY);
    public static ThreadPool getInstance()
    {
        return ImageThreadPool.instance;
    }

    public ImageThreadPool(string poolName, int numThreads, int priority) : base(poolName, numThreads, priority)
    {
        // base(poolName, numThreads, priority) is called from the constructor declaration
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void runTask(global::java.lang.Runnable task)
    {
        base.runTask(task);
    }

    public override void startTask(global::java.lang.Runnable task)
    {
    }

    public override void completedTask(global::java.lang.Runnable task)
    {
    }

}

