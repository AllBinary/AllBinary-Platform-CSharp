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
using TouchButtonRecognizer = org.allbinary.input.motion.button.TouchButtonRecognizer;
using MotionGestureRecognizer = org.allbinary.input.motion.gesture.MotionGestureRecognizer;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.input.motion;

public class AllMotionRecognizer : MotionRecognizer
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly MotionGestureRecognizer motionGestureRecognizer;
    private bool touchButtonProcessing = false;
    private readonly TouchButtonRecognizer touchButtonRecognizer;
    private readonly int id;
    private static int index = 0;
    private static readonly GPointCircularPool pointCircularPool = new GPointCircularPool(40);
    public AllMotionRecognizer()
    {
        this.id = AllMotionRecognizer.index++;
        this.motionGestureRecognizer = new MotionGestureRecognizer(this.id);
        this.touchButtonRecognizer = new TouchButtonRecognizer();
    }

    // throws Exception
    public override void processStartMotionEvent(int x, int y, int deviceId, int modifiers)
    {
        if (this.touchButtonRecognizer.pressTouchButtonInput(x, y, deviceId)) {
            this.touchButtonProcessing = true;
        }
        if (!this.touchButtonProcessing) {
            CustomGPoint point = ((CustomGPoint) AllMotionRecognizer.pointCircularPool.getNextInstance());
            point.setX(x);
            point.setY(y);
            this.motionGestureRecognizer.processPressedMotionEvent(point, deviceId, modifiers);
        }
    }

    // throws Exception
    public override void processEndMotionEvent(int x, int y, int deviceId, int modifiers)
    {
        if (this.touchButtonRecognizer.releaseTouchButtonInput(x, y, deviceId)) {
        }
        if (!this.touchButtonProcessing) {
            CustomGPoint point = ((CustomGPoint) AllMotionRecognizer.pointCircularPool.getNextInstance());
            point.setX(x);
            point.setY(y);
            this.motionGestureRecognizer.processReleasedMotionEvent(point, deviceId, modifiers);
        }
        if (this.touchButtonProcessing) {
            this.touchButtonProcessing = false;
        }
    }

    // throws Exception
    public override void processDraggedMotionEvent(int x, int y, int deviceId, int modifiers)
    {
        if (this.touchButtonProcessing) {
            this.touchButtonRecognizer.pressTouchButtonInput(x, y, deviceId);
        }
        if (!this.touchButtonProcessing) {
            CustomGPoint point = ((CustomGPoint) AllMotionRecognizer.pointCircularPool.getNextInstance());
            point.setX(x);
            point.setY(y);
            this.motionGestureRecognizer.processDraggedMotionEvent(point, deviceId, modifiers);
        }
    }

    private int lastX = 0;
    private int lastY = 0;
    // throws Exception
    public virtual void processMovedMotionEvent(int x, int y, int deviceId, int modifiers)
    {
        if (x != this.lastX || y != this.lastY) {
            this.lastX = x;
            this.lastY = y;
            CustomGPoint point = ((CustomGPoint) AllMotionRecognizer.pointCircularPool.getNextInstance());
            point.setX(x);
            point.setY(y);
            this.motionGestureRecognizer.processMovedMotionEvent(point, deviceId, modifiers);
        }
    }

    // throws Exception
    public virtual void processScrolledMotionEvent(int x, int y, int deviceId, int modifiers)
    {
        CustomGPoint point = ((CustomGPoint) AllMotionRecognizer.pointCircularPool.getNextInstance());
        point.setX(x);
        point.setY(y);
        this.motionGestureRecognizer.processScrolledMotionEvent(point, deviceId, modifiers);
    }

    public MotionGestureRecognizer getMotionGestureRecognizer()
    {
        return this.motionGestureRecognizer;
    }

}

