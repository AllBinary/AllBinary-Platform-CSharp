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
//using JsType = jsinterop.annotations.JsType;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
//using JsProperty = jsinterop.annotations.JsProperty;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsConstructor = jsinterop.annotations.JsConstructor;

namespace org.allbinary.math;

public class AngleIncrementInfo
{
    private readonly short angleIncrement;
    public readonly int? DOWN_FRAME;
    public readonly int? UP_FRAME;
    public readonly int? LEFT_FRAME;
    public readonly int? RIGHT_FRAME;
    public AngleIncrementInfo(short angleIncrement)
    {
        this.angleIncrement = angleIncrement;
        AngleFactory angleFactory = AngleFactory.getInstance();
        SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
        this.DOWN_FRAME = smallIntegerSingletonFactory.getAt(angleFactory.DOWN.getValue() / this.angleIncrement);
        this.UP_FRAME = smallIntegerSingletonFactory.getAt(((int) angleFactory.UP.getValue()));
        this.LEFT_FRAME = smallIntegerSingletonFactory.getAt(angleFactory.LEFT.getValue() / this.angleIncrement);
        this.RIGHT_FRAME = smallIntegerSingletonFactory.getAt(angleFactory.RIGHT.getValue() / this.angleIncrement);
    }

    private readonly FrameUtil frameUtil = FrameUtil.getInstance();
    public virtual int getFrameAngle(int frame)
    {
        return this.frameUtil.getFrameAngle(frame, ((int) this.angleIncrement));
    }

    public virtual short getAngleIncrement()
    {
        return this.angleIncrement;
    }

    private static readonly string INCREMENT = "Inc: ";
    public override string ToString()
    {
        return new StringMaker().append(AngleIncrementInfo.INCREMENT).appendshort(this.angleIncrement).ToString();
    }

    public virtual int getClosestGeneralDirection(short angle)
    {
        int? closestDirection = SmallIntegerSingletonFactory.getInstance().getAt(360);
        if (((int) this.UP_FRAME) - angle < ((int) closestDirection) - angle) {
            closestDirection = this.UP_FRAME;
        }
        if (((int) this.DOWN_FRAME) - angle < ((int) closestDirection) - angle) {
            closestDirection = this.DOWN_FRAME;
        }
        if (((int) this.LEFT_FRAME) - angle < ((int) closestDirection) - angle) {
            closestDirection = this.LEFT_FRAME;
        }
        if (((int) this.RIGHT_FRAME) - angle < ((int) closestDirection) - angle) {
            closestDirection = this.RIGHT_FRAME;
        }
        return ((int) closestDirection);
    }

}

