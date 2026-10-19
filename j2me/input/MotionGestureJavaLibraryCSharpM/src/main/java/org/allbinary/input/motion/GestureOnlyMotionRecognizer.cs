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
using CustomGPoint = org.allbinary.graphics.CustomGPoint;
using GPointCircularPool = org.allbinary.graphics.GPointCircularPool;
using MotionGestureRecognizer = org.allbinary.input.motion.gesture.MotionGestureRecognizer;

namespace org.allbinary.input.motion;

public class GestureOnlyMotionRecognizer : MotionRecognizer
{
    private readonly MotionGestureRecognizer motionGestureRecognizer;
    private readonly int id;
    private static int index = 0;
    private static readonly GPointCircularPool pointCircularPool = new GPointCircularPool(40);
    public GestureOnlyMotionRecognizer()
    {
        this.id = GestureOnlyMotionRecognizer.index++;
        this.motionGestureRecognizer = new MotionGestureRecognizer(this.id);
    }

    // throws Exception
    public override void processStartMotionEvent(int x, int y, int deviceId, int modifiers)
    {
        CustomGPoint point = ((CustomGPoint) GestureOnlyMotionRecognizer.pointCircularPool.getNextInstance());
        point.setX(x);
        point.setY(y);
        this.motionGestureRecognizer.processPressedMotionEvent(point, deviceId, modifiers);
    }

    // throws Exception
    public override void processEndMotionEvent(int x, int y, int deviceId, int modifiers)
    {
        CustomGPoint point = ((CustomGPoint) GestureOnlyMotionRecognizer.pointCircularPool.getNextInstance());
        point.setX(x);
        point.setY(y);
        this.motionGestureRecognizer.processReleasedMotionEvent(point, deviceId, modifiers);
    }

    // throws Exception
    public override void processDraggedMotionEvent(int x, int y, int deviceId, int modifiers)
    {
        CustomGPoint point = ((CustomGPoint) GestureOnlyMotionRecognizer.pointCircularPool.getNextInstance());
        point.setX(x);
        point.setY(y);
        this.motionGestureRecognizer.processDraggedMotionEvent(point, deviceId, modifiers);
    }

}

