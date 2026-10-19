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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.input.media.image.capture;

public class SaveCapturedImageWorker : BasicEventHandler, CapturedImageWorkerResultsListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private bool running = false;
    private BasicArrayList capturedImageWorkerResultsEventVector = new BasicArrayListD();
    public SaveCapturedImageWorker()
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

    public virtual void onCaptureEvent(CapturedImageWorkerResultsEvent capturedImageEvent)
    {
        this.capturedImageWorkerResultsEventVector.add(capturedImageEvent);
        this.run();
    }

    public virtual void onEvent(AllBinaryEventObject allBinaryEventObject)
    {
        this.onCaptureEvent(((CapturedImageWorkerResultsEvent) allBinaryEventObject));
    }

    public virtual void run()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.RUN);
            this.setRunning(true);
            TimeDelayHelper timeHelper = new TimeDelayHelper(1000);
            timeHelper.setStartTimeTNT();
            CapturedImageWorkerResultsEvent capturedImageWorkerResultsEvent = (((CapturedImageWorkerResultsEvent) this.capturedImageWorkerResultsEventVector.get(0)));
            BufferedImage screenBufferedImage = capturedImageWorkerResultsEvent.getBufferedImage();
            new CapturedImageInputOutput().save(screenBufferedImage, capturedImageWorkerResultsEvent.getFrame());
            this.capturedImageWorkerResultsEventVector.remove(capturedImageWorkerResultsEvent);
            this.logUtil.putF(CommonLabels.getInstance().ELAPSED + timeHelper.getElapsedTNT(), this, this.commonStrings.RUN);
            this.setRunning(false);
            this.logUtil.putF(this.commonStrings.END, this, this.commonStrings.RUN);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.RUN, e);
        }
    }

}

