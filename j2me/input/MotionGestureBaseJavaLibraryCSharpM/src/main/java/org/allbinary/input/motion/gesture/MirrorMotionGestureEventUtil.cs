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
using GPoint = org.allbinary.graphics.GPoint;
using PointFactory = org.allbinary.graphics.PointFactory;
using MotionEventCircularPool = org.allbinary.input.motion.gesture.observer.MotionEventCircularPool;
using MotionGestureEvent = org.allbinary.input.motion.gesture.observer.MotionGestureEvent;

namespace org.allbinary.input.motion.gesture;

public class MirrorMotionGestureEventUtil
{
    private static readonly MirrorMotionGestureEventUtil instance = new MirrorMotionGestureEventUtil();
    private readonly MotionEventCircularPool motionEventCircularPool;
    private MirrorMotionGestureEventUtil()
    {
        this.motionEventCircularPool = MotionEventCircularPool.createPool(Integer.MAX_VALUE);
    }

    // throws Exception
    public virtual MotionGestureEvent mirrorVerticle(MotionGestureEvent motionGestureEvent, int halfWidth)
    {
        MotionGestureEvent @event = this.motionEventCircularPool.getInstance(motionGestureEvent.getMotionGesture());
        int previousNewX = this.getNewX(motionGestureEvent.getPreviousPoint().getX(), halfWidth);
        int currentNewX = this.getNewX(motionGestureEvent.getCurrentPoint().getX(), halfWidth);
        PointFactory pointFactory = PointFactory.getInstance();
        GPoint mirroredPreviousPoint = pointFactory.createXY(previousNewX, motionGestureEvent.getPreviousPoint().getY());
        GPoint mirroredCurrentPoint = pointFactory.createXY(currentNewX, motionGestureEvent.getCurrentPoint().getY());
        @event.setPreviousPoint(mirroredPreviousPoint);
        @event.setCurrentPoint(mirroredCurrentPoint);
        return @event;
    }

    public virtual int getNewX(int x, int halfWidth)
    {
        int newX = 0;
        if (x > halfWidth) {
            newX = halfWidth - (x - halfWidth);
        } else {
            newX = halfWidth + (halfWidth - x);
        }
        return newX;
    }

    public static MirrorMotionGestureEventUtil getInstance()
    {
        return MirrorMotionGestureEventUtil.instance;
    }

}

