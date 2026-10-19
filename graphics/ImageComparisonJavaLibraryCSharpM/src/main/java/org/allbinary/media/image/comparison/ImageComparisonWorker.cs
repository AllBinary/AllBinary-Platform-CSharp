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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using CapturedImageWorkerResultsEvent = org.allbinary.input.media.image.capture.CapturedImageWorkerResultsEvent;
using CapturedImageWorkerResultsListener = org.allbinary.input.media.image.capture.CapturedImageWorkerResultsListener;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.media.image.comparison;

public class ImageComparisonWorker : BasicEventHandler, CapturedImageWorkerResultsListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly BasicArrayList bufferedImageVector = new BasicArrayListD();
    private readonly ImageComparatorConstraintsInterface imageComparatorConstraintsInterface;
    private readonly ImageComparator imageComparator;
    private bool running = false;
    private int index2 = 0;
    public ImageComparisonWorker(ImageComparatorConstraintsInterface imageComparatorConstraintsInterface)
    {
        this.imageComparatorConstraintsInterface = imageComparatorConstraintsInterface;
        this.imageComparator = new ImageComparator(imageComparatorConstraintsInterface);
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
    public virtual void onCaptureEvent(CapturedImageWorkerResultsEvent capturedImageWorkerResultsEvent)
    {
        this.bufferedImageVector.add(capturedImageWorkerResultsEvent);
        if (this.bufferedImageVector.size() > 1) {
            this.run();
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
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
            if (this.imageComparatorConstraintsInterface.isFrameAllowed(this.index2)) {
                CapturedImageWorkerResultsEvent[] capturedImageWorkerResultsEvent = new CapturedImageWorkerResultsEvent[2];
                capturedImageWorkerResultsEvent[0] = ((CapturedImageWorkerResultsEvent) this.bufferedImageVector.get(0));
                capturedImageWorkerResultsEvent[1] = ((CapturedImageWorkerResultsEvent) this.bufferedImageVector.get(1));
                if (this.imageComparatorConstraintsInterface.isImageValid(capturedImageWorkerResultsEvent[0].getBufferedImage()) && this.imageComparatorConstraintsInterface.isImageValid(capturedImageWorkerResultsEvent[1].getBufferedImage())) {
                    ImageComparisonResult imageComparisonResult = this.imageComparator.compare(capturedImageWorkerResultsEvent[0].getBufferedImage(), capturedImageWorkerResultsEvent[1].getBufferedImage(), capturedImageWorkerResultsEvent[0].getFrame(), capturedImageWorkerResultsEvent[1].getFrame(), 0);
                    long? frame = capturedImageWorkerResultsEvent[1].getFrame();
                    ImageComparisonResultFrameCacheable imageComparisonResultFrameCacheable = new ImageComparisonResultFrameCacheable(imageComparisonResult, frame);
                    ImageComparisonResultCacheSingleton.getInstance().add(imageComparisonResultFrameCacheable);
                    this.fireEvent(new ImageComparisonResultsEvent(this, imageComparisonResult));
                    this.logUtil.putF(new StringMaker().append("Image Comparison Result: ").append(imageComparisonResult.ToString()).append(" for frame: ").appendlong(frame).ToString(), this, this.commonStrings.RUN);
                } else {
                    this.logUtil.putF("An Image Was Not Valid: Image Worker Event Processing terminated", this, this.commonStrings.RUN);
                }
            }
            this.bufferedImageVector.remove(0);
            this.index2++;
            string message = new StringMaker().append("Frame: ").appendint(this.index2).append(CommonLabels.getInstance().ELAPSED).appendlong(((long) timeHelper.getElapsedTNT())).ToString();
            this.logUtil.putF(message, this, this.commonStrings.RUN);
            this.setRunning(false);
            this.logUtil.putF(this.commonStrings.END, this, this.commonStrings.RUN);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.RUN, e);
        }
    }

}

