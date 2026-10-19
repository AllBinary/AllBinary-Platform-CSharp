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
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;
using ImageComparisonResult = org.allbinary.media.image.comparison.ImageComparisonResult;
using ImageComparisonResultsEvent = org.allbinary.media.image.comparison.ImageComparisonResultsEvent;
using ImageComparisonResultsListener = org.allbinary.media.image.comparison.ImageComparisonResultsListener;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.media.image.comparison.motion;

public class MotionRectanglesWorker : BasicEventHandler, ImageComparisonResultsListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly BasicArrayList imageComparisonInfoVector = new BasicArrayListD();
    private readonly MotionRectangleConstraintsInterface motionRectangleConstraintsInterface;
    private long index = 0L;
    private bool running = false;
    public MotionRectanglesWorker(MotionRectangleConstraintsInterface motionRectangleConstraintsInterface)
    {
        this.motionRectangleConstraintsInterface = motionRectangleConstraintsInterface;
    }

    public virtual void onImageComparisonResultsEvent(ImageComparisonResultsEvent imageComparisonResultsEvent)
    {
        this.imageComparisonInfoVector.add(imageComparisonResultsEvent);
        this.run();
    }

    public virtual void onEvent(AllBinaryEventObject allBinaryEventObject)
    {
        this.onImageComparisonResultsEvent(((ImageComparisonResultsEvent) allBinaryEventObject));
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

    public virtual void run()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.RUN);
            this.setRunning(true);
            TimeDelayHelper timeHelper = new TimeDelayHelper(1000);
            timeHelper.setStartTimeTNT();
            ImageComparisonResultsEvent imageComparisonResultsEvent = ((ImageComparisonResultsEvent) this.imageComparisonInfoVector.get(0));
            ImageComparisonResult imageComparisonInfo = ((ImageComparisonResult) imageComparisonResultsEvent.getImageComparisonResult());
            this.logUtil.putF(imageComparisonInfo.ToString(), this, this.commonStrings.RUN);
            AllMotionRectangles allMotionRectangles = new AllMotionRectangles(imageComparisonInfo);
            AllMotionRectanglesResultsCacheSingleton.getInstance().add(new MotionRectanglesResultsFrameCacheable(allMotionRectangles, imageComparisonInfo.getFrameTwo()));
            ConsolidateMotionRectangles consolidatedMotionRectangles = new ConsolidateMotionRectangles(allMotionRectangles);
            ConsolidatedMotionRectanglesResultsCacheSingleton.getInstance().add(new MotionRectanglesResultsFrameCacheable(consolidatedMotionRectangles, imageComparisonInfo.getFrameTwo()));
            ConstrainedMotionRectangles constrainedMotionRectangles = new ConstrainedMotionRectangles(this.motionRectangleConstraintsInterface, consolidatedMotionRectangles);
            constrainedMotionRectangles.applyMotionRectangleConstraints(consolidatedMotionRectangles);
            ConstrainedMotionRectanglesResultsCacheSingleton.getInstance().add(new MotionRectanglesResultsFrameCacheable(constrainedMotionRectangles, imageComparisonInfo.getFrameTwo()));
            this.fireEvent(new MotionRectanglesResultsEvent(this, imageComparisonInfo.getFrameTwo(), ((MotionRectangles) constrainedMotionRectangles)));
            this.imageComparisonInfoVector.remove(imageComparisonResultsEvent);
            this.index++;
            this.logUtil.putF(CommonLabels.getInstance().ELAPSED + timeHelper.getElapsedTNT(), this, this.commonStrings.RUN);
            this.setRunning(false);
            this.logUtil.putF(this.commonStrings.END, this, this.commonStrings.RUN);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.RUN, e);
        }
    }

}

