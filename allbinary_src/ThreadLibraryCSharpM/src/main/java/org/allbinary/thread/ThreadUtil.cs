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

namespace org.allbinary.thread;

public class ThreadUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ThreadUtil instance = new ThreadUtil();
    public static ThreadUtil getInstance()
    {
        return ThreadUtil.instance;
    }

    public readonly string JOIN = "join";
    public virtual bool isRunning(Thread thread)
    {
        if (thread != null && thread.isAlive()) {
            return true;
        } else {
            return false;
        }
    }

    // throws Exception
    public virtual void join(Thread thread)
    {
        if (ThreadUtil.getInstance().isRunning(thread)) {
            this.logUtil.putF("Waiting for Thread To Join/End", this, this.JOIN);
            thread.join();
        }
    }

}

