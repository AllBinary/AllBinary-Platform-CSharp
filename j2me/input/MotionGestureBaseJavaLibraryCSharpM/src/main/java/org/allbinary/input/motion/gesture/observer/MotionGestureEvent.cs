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
using MotionGestureInput = org.allbinary.input.motion.gesture.MotionGestureInput;
using TouchMotionGestureFactory = org.allbinary.input.motion.gesture.TouchMotionGestureFactory;
using TsUtil = org.allbinary.TsUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace org.allbinary.input.motion.gesture.observer;

public class MotionGestureEvent : AllBinaryEventObject
{
    private MotionGestureInput motionGesture = TouchMotionGestureFactory.getInstance().NO_MOTION;
    private readonly int id;
    private GPoint previousPoint = PointFactory.getInstance().ZERO_ZERO;
    private GPoint currentPoint = PointFactory.getInstance().ZERO_ZERO;
    public MotionGestureEvent(object source, int id, MotionGestureInput motionGesture) : base(source)
    {
        // base(source) is called from the constructor declaration
        this.id = id;
        this.setMotionGesture(motionGesture);
    }

    public virtual MotionGestureInput getMotionGesture()
    {
        return this.motionGesture;
    }

    public virtual void setMotionGesture(MotionGestureInput motionGesture)
    {
        this.motionGesture = motionGesture;
    }

    public virtual GPoint getPreviousPoint()
    {
        return this.previousPoint;
    }

    public virtual void setPreviousPoint(GPoint previousPoint)
    {
        this.previousPoint = previousPoint;
    }

    public virtual GPoint getCurrentPoint()
    {
        return this.currentPoint;
    }

    public virtual void setCurrentPoint(GPoint currentPoint)
    {
        this.currentPoint = currentPoint;
    }

    private static readonly string PREVIOUS = " Previous: ";
    private static readonly string HASHCODE = " hashcode: ";
    private readonly CommonLabels commonLabels = CommonLabels.getInstance();
    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        StringUtil stringUtil = StringUtil.getInstance();
        stringBuffer.append(stringUtil.toString(this.motionGesture));
        stringBuffer.append(this.commonLabels.CURRENT);
        stringBuffer.append(stringUtil.toString(this.currentPoint));
        stringBuffer.append(MotionGestureEvent.PREVIOUS);
        stringBuffer.append(stringUtil.toString(this.previousPoint));
        stringBuffer.append(MotionGestureEvent.HASHCODE);
        stringBuffer.appendint(((int) TsUtil.getInstance().hashCode(this)));
        return stringBuffer.ToString();
    }

    public virtual int getId()
    {
        return this.id;
    }

}

