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
using Line = org.allbinary.graphics.Line;
using PointFactory = org.allbinary.graphics.PointFactory;
using MotionGestureConfiguration = org.allbinary.input.motion.gesture.configuration.MotionGestureConfiguration;
using MotionGestureConfigurationFactory = org.allbinary.input.motion.gesture.configuration.MotionGestureConfigurationFactory;
using BasicMotionGesturesHandler = org.allbinary.input.motion.gesture.observer.BasicMotionGesturesHandler;
using MotionEventCircularPool = org.allbinary.input.motion.gesture.observer.MotionEventCircularPool;
using MotionGestureEvent = org.allbinary.input.motion.gesture.observer.MotionGestureEvent;
using MovedMotionGesturesHandler = org.allbinary.input.motion.gesture.observer.MovedMotionGesturesHandler;
using ScrolledMotionGesturesHandler = org.allbinary.input.motion.gesture.observer.ScrolledMotionGesturesHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using J2SEMath = org.allbinary.logic.math.J2SEMath;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.motion.gesture;

public class MotionGestureRecognizer
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly J2SEMath j2seMath = J2SEMath.getInstance();
    private readonly GPoint origin = PointFactory.getInstance().ZERO_ZERO;
    private GPoint previous;
    private GPoint intermediate;
    private readonly Line line;
    private readonly BasicMotionGesturesHandler motionGesturesHandler;
    private readonly BasicEventHandler movedMotionGesturesHandler;
    private readonly BasicEventHandler scrolledMotionGesturesHandler;
    private readonly MotionEventCircularPool motionEventCircularPool;
    public MotionGestureRecognizer(int id)
    {
        this.previous = this.origin;
        this.intermediate = this.origin;
        this.line = new Line(this.origin, this.origin);
        this.motionEventCircularPool = MotionEventCircularPool.createPool(id);
        BasicEventHandler motionGesturesHandler = new BasicEventHandler();
        BasicEventHandler movedMotionGesturesHandler = motionGesturesHandler;
        BasicEventHandler scrolledMotionGesturesHandler = motionGesturesHandler;
        try {
            motionGesturesHandler = BasicMotionGesturesHandler.getInstance();
            movedMotionGesturesHandler = MovedMotionGesturesHandler.getInstance();
            scrolledMotionGesturesHandler = ScrolledMotionGesturesHandler.getInstance();
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.CONSTRUCTOR, e);
        }
        this.motionGesturesHandler = ((BasicMotionGesturesHandler) motionGesturesHandler);
        this.movedMotionGesturesHandler = movedMotionGesturesHandler;
        this.scrolledMotionGesturesHandler = scrolledMotionGesturesHandler;
    }

    // throws Exception
    public virtual bool processPressedMotionEvent(GPoint current, int deviceId, int button)
    {
        this.intermediate = this.origin;
        this.previous = this.origin;
        MotionGestureEvent @event = this.motionEventCircularPool.getInstance(TouchMotionGestureFactory.getInstance().PRESSED);
        @event.setPreviousPoint(this.previous);
        @event.setCurrentPoint(current);
        this.motionGesturesHandler.fireEvent(@event);
        return true;
    }

    // throws Exception
    public virtual bool processReleasedMotionEvent(GPoint current, int deviceId, int button)
    {
        MotionGestureEvent @event = this.motionEventCircularPool.getInstance(TouchMotionGestureFactory.getInstance().RELEASED);
        @event.setPreviousPoint(this.previous);
        @event.setCurrentPoint(current);
        this.motionGesturesHandler.fireEvent(@event);
        return true;
    }

    // throws Exception
    public virtual void processDraggedMotionEvent(GPoint current, int deviceId, int buttonMask)
    {
        if (this.previous == this.origin || this.intermediate == this.origin) {
            this.previous = current;
            this.intermediate = current;
            return;
        }
        this.line.setP1(this.previous);
        this.line.setP2(current);
        int minimumMotionGesture = MotionGestureConfigurationFactory.getInstance().getMinimumMotionGesture();
        if (this.j2seMath.abs(((float) this.line.getDeltaX())) < minimumMotionGesture && this.j2seMath.abs(((float) this.line.getDeltaY())) < minimumMotionGesture) {
            this.intermediate = current;
            return;
        }
        double gradient = this.line.getGradient();
        double absGradient = ((double) this.j2seMath.abs(((float) gradient)));
        MotionGestureConfiguration conf = MotionGestureConfigurationFactory.getInstance();
        TouchMotionGestureFactory touchMotionGestureFactory = TouchMotionGestureFactory.getInstance();
        MotionGestureInput newMotionGesture = touchMotionGestureFactory.NO_MOTION;
        double diagonalToleranceHigher = 12.0;
        double diagonalToleranceLower = 12.0;
        if (conf.isDiagonalMotionGestureAllowed()) {
            diagonalToleranceHigher = ((double) (90 - conf.getDiagonalTolerance()));
            diagonalToleranceLower = ((double) conf.getDiagonalTolerance());
        }
        if (absGradient > Math.Tan(Math.ToRadians(diagonalToleranceHigher))) {
            if (this.line.getDeltaY() > 0) {
                newMotionGesture = touchMotionGestureFactory.UP;
            } else {
                newMotionGesture = touchMotionGestureFactory.DOWN;
            }
        } else {
            if (absGradient < Math.Tan(Math.ToRadians(diagonalToleranceLower))) {
                if (this.line.getDeltaX() > 0) {
                    newMotionGesture = touchMotionGestureFactory.LEFT;
                } else {
                    newMotionGesture = touchMotionGestureFactory.RIGHT;
                }
            } else {
                if (gradient > 0.0) {
                    if (this.line.getDeltaX() > 0) {
                        newMotionGesture = touchMotionGestureFactory.DIAGONAL_UP_LEFT;
                    } else {
                        newMotionGesture = touchMotionGestureFactory.DIAGONAL_DOWN_RIGHT;
                    }
                } else {
                    if (this.line.getDeltaX() > 0) {
                        newMotionGesture = touchMotionGestureFactory.DIAGONAL_DOWN_LEFT;
                    } else {
                        newMotionGesture = touchMotionGestureFactory.DIAGONAL_UP_RIGHT;
                    }
                }
            }
        }
        this.previous = current;
        this.intermediate = current;
        MotionGestureEvent @event = this.motionEventCircularPool.getInstance(newMotionGesture);
        @event.setPreviousPoint(this.previous);
        @event.setCurrentPoint(current);
        this.motionGesturesHandler.fireEvent(@event);
        return;
    }

    // throws Exception
    public virtual bool processMovedMotionEvent(GPoint current, int deviceId, int button)
    {
        MotionGestureEvent @event = this.motionEventCircularPool.getInstance(TouchMotionGestureFactory.getInstance().NO_MOTION);
        @event.setPreviousPoint(this.previous);
        @event.setCurrentPoint(current);
        this.movedMotionGesturesHandler.fireEvent(@event);
        return true;
    }

    // throws Exception
    public virtual bool processScrolledMotionEvent(GPoint current, int deviceId, int button)
    {
        TouchMotionGestureFactory touchMotionGestureFactory = TouchMotionGestureFactory.getInstance();
        MotionGestureInput newMotionGesture = touchMotionGestureFactory.NO_MOTION;
        if (button > 0) {
            newMotionGesture = touchMotionGestureFactory.SCROLL_UP;
        } else if (button < 0) {
            newMotionGesture = touchMotionGestureFactory.SCROLL_DOWN;
        }
        MotionGestureEvent @event = this.motionEventCircularPool.getInstance(newMotionGesture);
        @event.setPreviousPoint(this.previous);
        @event.setCurrentPoint(current);
        this.scrolledMotionGesturesHandler.fireEvent(@event);
        return true;
    }

    public virtual BasicMotionGesturesHandler getMotionGesturesHandler()
    {
        return this.motionGesturesHandler;
    }

}

