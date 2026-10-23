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
using CaptureWorkerInterface = org.allbinary.input.media.image.capture.CaptureWorkerInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ImageComparisonWorker = org.allbinary.media.image.comparison.ImageComparisonWorker;
using MotionRectanglesWorker = org.allbinary.media.image.comparison.motion.MotionRectanglesWorker;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using RunnableInterface = org.allbinary.thread.RunnableInterface;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.input.automation.module;

public class AbstractInputAutomationWorker : RunnableInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private long index = 0L;
    private bool running = false;
    private InputAutomationActionInterface inputAutomationActionInterface = null;
    private CaptureWorkerInterface captureWorkerInterface = null;
    private ImageComparisonWorker imageComparisonWorker = null;
    private MotionRectanglesWorker motionRectanglesWorker = null;
    private global::org.allbinary.thread.NullThread captureThread = null;
    public AbstractInputAutomationWorker(InputAutomationActionInterface inputAutomationActionInterface)
    {
    }

    // throws Exception
    public virtual void setThread(global::org.allbinary.thread.NullThread thread)
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool isRunning()
    {
        return this.running;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void setRunning(bool running)
    {
        this.running = running;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool isAnyDataWorkerRunning()
    {
        if (this.captureThread != null && (this.captureThread.isAlive() || this.getCaptureWorker().isRunning() || this.getMotionRectanglesWorker().isRunning() || this.getImageComparisonWorker().isRunning())) {
            return true;
        }
        return false;
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void startDataWorkers()
    {
        if (!isAnyDataWorkerRunning()) {
            this.captureThread = new global::org.allbinary.thread.NullThread(this.getCaptureWorker());
            this.logUtil.putF("Starting CaptureWorkers - Need more images - Thread State: " + this.captureThread.getState().ToString(), this, "startCaptureWorkers");
            this.captureThread.start();
        }
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void waitForDataWorkers()
    {
        while (isAnyDataWorkerRunning()) {
            this.logUtil.putF("Waiting", this, this.commonStrings.RUN);
            System.Threading.Thread.Sleep((int) (250));
        }
    }

    // throws Exception
    public virtual void stopDataWorkers()
    {
        this.getCaptureWorker().setRunning(false);
    }

    // throws Exception
    public virtual void process()
    {
        throw new SystemException();
    }

    public virtual void run()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.RUN);
            this.setRunning(true);
            TimeDelayHelper timeHelper = new TimeDelayHelper(1000);
            while (this.isRunning()) {
                timeHelper.setStartTimeTNT();
                this.process();
                this.index++;
                this.logUtil.putF(CommonLabels.getInstance().ELAPSED + timeHelper.getElapsedTNT() + " Index: " + this.index, this, this.commonStrings.RUN);
            }
            this.stopDataWorkers();
            this.waitForDataWorkers();
            this.logUtil.putF(this.commonStrings.END, this, this.commonStrings.RUN);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.RUN, e);
        }
    }

    public virtual InputAutomationActionInterface getInputAutomationActionInterface()
    {
        return this.inputAutomationActionInterface;
    }

    public virtual void setInputAutomationActionInterface(InputAutomationActionInterface inputAutomationActionInterface)
    {
        this.inputAutomationActionInterface = inputAutomationActionInterface;
    }

    public virtual CaptureWorkerInterface getCaptureWorker()
    {
        return this.captureWorkerInterface;
    }

    public virtual void setCaptureWorker(CaptureWorkerInterface captureWorkerInterface)
    {
        this.captureWorkerInterface = captureWorkerInterface;
    }

    public virtual ImageComparisonWorker getImageComparisonWorker()
    {
        return this.imageComparisonWorker;
    }

    public virtual void setImageComparisonWorker(ImageComparisonWorker imageComparisonWorker)
    {
        this.imageComparisonWorker = imageComparisonWorker;
    }

    public virtual MotionRectanglesWorker getMotionRectanglesWorker()
    {
        return this.motionRectanglesWorker;
    }

    public virtual void setMotionRectanglesWorker(MotionRectanglesWorker motionRectanglesWorker)
    {
        this.motionRectanglesWorker = motionRectanglesWorker;
    }

}

