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
//using BufferedImage = java.awt.image.BufferedImage;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;
using BufferedImageFrameCacheable = org.allbinary.media.image.cache.BufferedImageFrameCacheable;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.input.media.image.capture;

public class ScreenCaptureImagesWorker : BasicEventHandler, CaptureWorkerInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private static long index;
    private bool running = false;
    private ScreenScavangerRobot screenScavangerRobot;
    public ScreenCaptureImagesWorker()
    {
        screenScavangerRobot = new ScreenScavangerRobot();
        ScreenCaptureImagesWorker.index = ProcessingFrameIndexFactory.next();
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

    // throws Exception
    public virtual void setThread(global::org.allbinary.thread.NullThread thread)
    {
    }

    public virtual void run()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.RUN);
            this.setRunning(true);
            TimeDelayHelper timeHelper = new TimeDelayHelper(1000);
            while (isRunning()) {
                timeHelper.setStartTimeTNT();
                BufferedImage bufferedImage = this.screenScavangerRobot.getScreenAsBufferedImages()[0];
                long? frame = index;
                ScreenCaptureImagesWorker.index++;
                CapturedBufferedImagesCacheSingleton.getInstance().add(new BufferedImageFrameCacheable(bufferedImage, frame));
                CapturedImageWorkerResultsEvent capturedImageEvent = new CapturedImageWorkerResultsEvent(this, frame, bufferedImage);
                fireEvent(capturedImageEvent);
                this.logUtil.putF(CommonLabels.getInstance().ELAPSED + timeHelper.getElapsedTNT(), this, this.commonStrings.RUN);
                this.setRunning(false);
            }
            this.logUtil.putF(this.commonStrings.END, this, this.commonStrings.RUN);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.RUN, e);
        }
    }

}

