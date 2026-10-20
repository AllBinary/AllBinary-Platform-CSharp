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
using J2MEUtil = org.allbinary.J2MEUtil;
using RunnableCanvas = org.allbinary.canvas.RunnableCanvas;
using AllBinaryGameCanvas = org.allbinary.game.displayable.canvas.AllBinaryGameCanvas;
using DemoCanvas = org.allbinary.game.displayable.canvas.DemoCanvas;
using GameCanvasRunnableInterface = org.allbinary.game.displayable.canvas.GameCanvasRunnableInterface;
using RunnableCanvasSingleThreadStartRunnable = org.allbinary.game.displayable.canvas.RunnableCanvasSingleThreadStartRunnable;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.thread;

public class ThreadFactoryUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly ThreadFactoryUtil instance = new ThreadFactoryUtil();
    public static ThreadFactoryUtil getInstance()
    {
        return ThreadFactoryUtil.instance;
    }

    public virtual Thread getInstanceGameCanvasRunnable(GameCanvasRunnableInterface runnable)
    {
        return this.getInstanceType(runnable, runnable.getType());
    }

    public virtual Thread getInstanceForRunnable(ABRunnable runnable)
    {
        return this.getInstanceType(runnable, runnable.getType());
    }

    private Thread getInstanceType(global::java.lang.Runnable runnable, int type)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        if (J2MEUtil.isHTML()) {
            if (type == DemoCanvas.TYPE || type == AllBinaryGameCanvas.TYPE) {
                RunnableCanvasSingleThreadStartRunnable demoGameSingleThreadStartRunnable = new RunnableCanvasSingleThreadStartRunnable(((RunnableCanvas) runnable));
                PreLogUtil.put(new StringMaker().append("Using Pseudo Thread for DemoCanvas/AllBinaryGameCanvas under PlayN/HTML5: ").append(StringUtil.getInstance().toString(runnable)).ToString(), this, commonStrings.CONSTRUCTOR);
                ThreadPool primaryThreadPool = PrimaryThreadPool.getInstance();
                primaryThreadPool.runTask(demoGameSingleThreadStartRunnable);
            } else {
                PreLogUtil.put(new StringMaker().append("Using Pseudo Thread for Runnable under PlayN/HTML5: ").append(StringUtil.getInstance().toString(runnable)).ToString(), this, commonStrings.CONSTRUCTOR);
                ThreadPool primaryThreadPool = PrimaryThreadPool.getInstance();
                primaryThreadPool.runTask(runnable);
            }
        }
        Thread thread = new Thread(runnable, runnable.ToString());
        this.logUtil.putF(thread.ToString(), this, commonStrings.CONSTRUCTOR);
        return thread;
    }

    public virtual void start(Thread thread)
    {
        thread.start();
    }

}

