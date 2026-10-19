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
using BasicColor = org.allbinary.graphics.color.BasicColor;
using Angle = org.allbinary.math.Angle;
using AngleFactory = org.allbinary.math.AngleFactory;
using AngleInfo = org.allbinary.math.AngleInfo;

namespace org.allbinary.animation;

public class VectorRotationAnimation : VectorBaseRotationAnimation
{
    public VectorRotationAnimation(int[][][] currentPoints, BasicColor basicColor, AnimationBehavior animationBehavior) : base(AngleInfo.getInstance(((short) (AngleFactory.getInstance().TOTAL_ANGLE / currentPoints.Length))), currentPoints, basicColor, animationBehavior)
    {
        // base(AngleInfo.getInstance(((short) (AngleFactory.getInstance().TOTAL_ANGLE / currentPoints.Length))), currentPoints, basicColor, animationBehavior) is called from the constructor declaration
        this.angleInfo.adjustAngle(this.getFrame());
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

    public override void setFrame(int index)
    {
        base.setFrame(index);
        this.angleInfo.adjustAngle(this.getFrame());
    }

    public override void adjustFrame(short newAngle)
    {
        this.setFrame(this.frameUtil.getFrameForAngle(newAngle, ((int) this.angleInfo.getAngleIncrementInfo().getAngleIncrement())));
    }

    public override void adjustFrameToAngle(Angle newAngle)
    {
        this.adjustFrame(newAngle.getValue());
    }

}

