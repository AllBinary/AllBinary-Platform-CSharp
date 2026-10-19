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
//using CommandListener = javax.microedition.lcdui.CommandListener;
using TsUtil = org.allbinary.TsUtil;
using NullWaitGameRunnable = org.allbinary.game.displayable.canvas.NullWaitGameRunnable;
using MyCanvas = org.allbinary.graphics.displayable.MyCanvas;
using ABSystemWrapper = org.allbinary.logic.ABSystemWrapper;
using NullUtil = org.allbinary.logic.NullUtil;
using StdUtil = org.allbinary.logic.StdUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using NullThread = org.allbinary.thread.NullThread;
using RunnableInterface = org.allbinary.thread.RunnableInterface;
using ThreadObjectUtil = org.allbinary.thread.ThreadObjectUtil;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.canvas;

public class RunnableCanvas : MyCanvas, RunnableInterface
{
    public readonly NullUtil nullUtil = NullUtil.getInstance();
    public readonly StdUtil stdUtil = StdUtil.getInstance();
    public readonly ABSystemWrapper systemWrapper = ABSystemWrapper.getInstance();
    public readonly TsUtil tsUtil = TsUtil.getInstance();
    private Thread thread = NullThread.NULL_THREAD;
    private Thread currentThread = NullThread.NULL_THREAD;
    private bool running = false;
    public readonly TimeDelayHelper loopTimeHelper = new TimeDelayHelper(NullWaitGameRunnable.getInstance().WAIT);
    public Processor runnableCanvasRefreshHelper = Processor.getInstance();
    public readonly CommonLabels commonLabels = CommonLabels.getInstance();
    public readonly ThreadObjectUtil threadObjectUtil = ThreadObjectUtil.getInstance();
    public readonly string SET_RUNNING = "setRunning";
    private readonly string IS_RUNNING = "isRunning";
    private readonly string THREAD = "Thread: ";
    private readonly string NOT_EQUAL = " != ";
    private readonly string PAUSE_SLEEP = "pause sleep";
    private readonly string START_PAUSE = "start pause - game thread sleep at: ";
    private readonly string END_PAUSE = "end pause - game thread sleep at: ";
    private readonly string PROCESS_LOOP_SLEEP = "processLoopSleep";
    public RunnableCanvas(CommandListener commandListener, BasicArrayList childNameList, bool hasParam) : base(CommonStrings.getInstance().UNKNOWN, childNameList)
    {
        // base(CommonStrings.getInstance().UNKNOWN, childNameList) is called from the constructor declaration
        this.logUtil.putF(new StringMaker().append("RunnableCanvas delay: ").appendint(((int) this.loopTimeHelper.delay)).ToString(), this, this.commonStrings.CONSTRUCTOR);
        this.runnableCanvasRefreshHelper = new RunnableCanvasRefreshHelper(this);
        if (commandListener != null) {
            this.initCommands(commandListener);
        } else if (hasParam) {
            this.logUtil.putF("commandListener was null", this, "initCommands");
        }
    }

    public virtual void initCommands(CommandListener cmdListener)
    {
        this.logUtil.putF(this.commonStrings.NOT_IMPLEMENTED, this, "initCommands");
    }

    public virtual bool isMainCanvas()
    {
        if (this.getCustomCommandListener() != null) {
            return true;
        } else {
            return false;
        }
    }

    public override void setThread(Thread thread)
    {
        this.thread = thread;
    }

    public override void setRunning(bool running)
    {
        this.running = running;
        if (!this.running) {
            this.thread = NullThread.NULL_THREAD;
            lock (this) {
                this.threadObjectUtil.notifyObject(this);
            }
        }
        this.logUtil.putF(new StringMaker().append(this.IS_RUNNING).appendboolean(this.running).ToString(), this, this.SET_RUNNING);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override bool isRunning()
    {
        if (this.thread == this.currentThread) {
            return this.running;
        } else {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(this.THREAD);
            if (this.thread != null) {
                stringBuffer.append(this.thread.ToString());
            }
            stringBuffer.append(this.NOT_EQUAL);
            if (this.currentThread != null) {
                stringBuffer.append(StringUtil.getInstance().toString(this.currentThread));
            }
            this.logUtil.putF(stringBuffer.ToString(), this, this.IS_RUNNING);
            return false;
        }
    }

    public virtual TimeDelayHelper getLoopTimeHelperP()
    {
        return this.loopTimeHelper;
    }

    private long pauseWait = 0L;
    protected virtual void setWait(int wait)
    {
        this.loopTimeHelper.delay = wait;
        this.pauseWait = ((long) wait) * 3L;
        this.logUtil.putF(new StringMaker().append("setWait - delay: ").appendint(((int) this.loopTimeHelper.delay)).ToString(), this, this.commonStrings.CONSTRUCTOR);
    }

    protected virtual int getWait()
    {
        return this.loopTimeHelper.delay;
    }

    public virtual void setCurrentThread()
    {
        this.currentThread = Thread.currentThread();
    }

    protected virtual void setCurrentThreadFake()
    {
        this.currentThread = this.thread;
    }

    protected override void showNotify()
    {
        try {
            this.stopWaiting();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "showNotify", e);
        }
    }

    private bool notified = false;
    // throws Exception
    private void stopWaiting()
    {
        this.notified = true;
        lock (this) {
            this.threadObjectUtil.notifyObject(this);
        }
        this.repaint();
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void waitOnNotify(long wait)
    {
        if (!this.notified) {
            if (wait > 0L) {
                this.threadObjectUtil.waitObjectFor(this, wait);
            } else {
                this.threadObjectUtil.waitObject(this);
            }
        }
    }

    // throws Exception
    public virtual void processSleep()
    {
        System.Threading.Thread.Sleep((int) (this.pauseWait));
    }

    public virtual bool isPausable()
    {
        return false;
    }

    // throws Exception
    public virtual void processGameSleep(long sleep)
    {
        System.Threading.Thread.Sleep((int) (sleep));
    }

    // throws Exception
    public virtual void processLoopSleep()
    {
        this.runnableCanvasRefreshHelper.process();
        if (this.isPaused()) {
            StringMaker stringMaker = new StringMaker();
            if (this.isRunning() && !this.isSingleThread()) {
                stringMaker.delete(0, stringMaker.length());
                long currentTimeMillis = this.systemWrapper.currentTimeMillis();
                this.logUtil.putF(stringMaker.append(this.START_PAUSE).appendlong(currentTimeMillis).append(this.PAUSE_SLEEP).appendlong(this.pauseWait).ToString(), this, this.PROCESS_LOOP_SLEEP);
                while (this.isPaused() && this.isRunning() && !this.isSingleThread()) {
                    this.processSleep();
                    if (!this.isPausable()) {
                        stringMaker.delete(0, stringMaker.length());
                        this.logUtil.putF(stringMaker.append(this.END_PAUSE).appendlong(currentTimeMillis).ToString(), this, this.PROCESS_LOOP_SLEEP);
                        return;
                    }
                }
            }
        }
        long elapsedTime = this.loopTimeHelper.getElapsedTNT();
        long wait = ((long) this.loopTimeHelper.delay);
        if (elapsedTime > wait) {
            elapsedTime = wait;
        } else {
            this.processGameSleep(wait - elapsedTime);
        }
    }

    public virtual bool isSingleThread()
    {
        return false;
    }

    public override void run()
    {
        this.setCurrentThread();
    }

    // throws Exception
    public virtual void end2()
    {
    }

    public virtual int getType()
    {
        return -1;
    }

}

