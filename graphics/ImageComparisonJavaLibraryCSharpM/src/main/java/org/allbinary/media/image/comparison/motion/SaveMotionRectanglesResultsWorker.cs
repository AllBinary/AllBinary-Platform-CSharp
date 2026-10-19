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
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.media.image.comparison.motion;

public class SaveMotionRectanglesResultsWorker : MotionRectanglesResultsListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private bool running = false;
    private BasicArrayList motionRectanglesVector;
    public SaveMotionRectanglesResultsWorker()
    {
        this.motionRectanglesVector = new BasicArrayListD();
    }

    public virtual BasicArrayList getMotionRectanglesVector()
    {
        return this.motionRectanglesVector;
    }

    public virtual void onMotionRectanglesImageComparisonResultsEvent(MotionRectanglesResultsEvent motionRectanglesResultsEvent)
    {
        this.getMotionRectanglesVector().add(motionRectanglesResultsEvent);
        this.run();
    }

    public virtual void onEvent(AllBinaryEventObject allBinaryEventObject)
    {
        this.onMotionRectanglesImageComparisonResultsEvent(((MotionRectanglesResultsEvent) allBinaryEventObject));
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
            MotionRectanglesResultsEvent motionRectanglesResultsEvent = ((MotionRectanglesResultsEvent) this.getMotionRectanglesVector().get(0));
            MotionRectangles motionRectangles = motionRectanglesResultsEvent.getMotionRectangles();
            new MotionRectanglesImageInputOutput().save(motionRectangles, motionRectanglesResultsEvent.getFrame());
            this.getMotionRectanglesVector().remove(motionRectangles);
            this.logUtil.putF(CommonLabels.getInstance().ELAPSED + timeHelper.getElapsedTNT(), this, this.commonStrings.RUN);
            this.logUtil.putF(this.commonStrings.END, this, this.commonStrings.RUN);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.RUN, e);
        }
    }

}

