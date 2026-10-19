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
using Direction = org.allbinary.direction.Direction;
using DirectionUtil = org.allbinary.direction.DirectionUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using Angle = org.allbinary.math.Angle;
using AngleInfo = org.allbinary.math.AngleInfo;
using FrameUtil = org.allbinary.math.FrameUtil;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.animation;

public class RotationAnimation : IndexedAnimation, RotationAnimationInterface
{
    public readonly FrameUtil frameUtil = FrameUtil.getInstance();
    public readonly DirectionUtil directionUtil = DirectionUtil.getInstance();
    public readonly AngleInfo angleInfo;
    public CircularIndexUtil circularIndexUtil;
    protected RotationAnimation(AngleInfo angleInfo, CircularIndexUtil circularIndexUtil, AnimationBehavior animationBehavior) : base(animationBehavior)
    {
        // base(animationBehavior) is called from the constructor declaration
        this.angleInfo = angleInfo;
        this.circularIndexUtil = circularIndexUtil;
    }

    public virtual void nextRotationX()
    {
    }

    public virtual void previousRotationX()
    {
    }

    public override void nextRotation()
    {
        this.angleInfo.adjustAngle(this.circularIndexUtil.next());
    }

    public override void previousRotation()
    {
        this.angleInfo.adjustAngle(this.circularIndexUtil.previous());
    }

    public virtual void nextRotationZ()
    {
    }

    public virtual void previousRotationZ()
    {
    }

    public override void setFrame(int index)
    {
        this.circularIndexUtil.setIndex(index);
        int newFrame = this.circularIndexUtil.getIndex();
        this.angleInfo.adjustAngle(newFrame);
    }

    public override void setFrameByDirection(Direction direction)
    {
        Angle angle = this.directionUtil.getFrameAngle(direction);
        this.adjustFrameToAngle(angle);
    }

    public override void setFrameToAngle(Angle angle)
    {
        this.adjustFrameToAngle(angle);
    }

    public override void adjustFrameToAngle(Angle angle)
    {
        this.adjustFrame(angle.getValue());
    }

    public override void adjustFrame(short angle)
    {
        this.setFrame(this.frameUtil.getFrameForAngle(angle, ((int) this.angleInfo.getAngleIncrementInfo().getAngleIncrement())));
    }

    public override int getFrame()
    {
        return this.circularIndexUtil.getIndex();
    }

    public override int getSize()
    {
        return this.circularIndexUtil.getSize();
    }

    public override AngleInfo getAngleInfoP()
    {
        return this.angleInfo;
    }

    public override string ToString()
    {
        return new StringMaker().append(base.ToString()).append("circularIndexUtil: ").append(this.circularIndexUtil.ToString()).append("angleInfo: ").append(this.angleInfo.ToString()).ToString();
    }

}

