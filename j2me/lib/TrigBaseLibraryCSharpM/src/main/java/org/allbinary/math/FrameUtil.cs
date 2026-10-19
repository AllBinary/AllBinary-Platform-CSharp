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
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsConstructor = jsinterop.annotations.JsConstructor;

namespace org.allbinary.math;

public class FrameUtil
{
    private static readonly FrameUtil instance = new FrameUtil();
    public static FrameUtil getInstance()
    {
        return FrameUtil.instance;
    }

    private FrameUtil()
    {
    }

    public virtual int getFrameForAngle(short angle, int angleIncrement)
    {
        return this.adjustAngleToFrameAngle(((int) angle)) / angleIncrement;
    }

    public virtual int getFrameAngle(int frame, int angleIncrement)
    {
        int frameAngle = angleIncrement * frame - 90;
        return this.adjustAngleToFrameAngle(frameAngle);
    }

    public virtual int adjustAngleToFrameAngle(int currentAngle)
    {
        AngleFactory angleFactory = AngleFactory.getInstance();
        if (currentAngle > 359) {
            currentAngle = (currentAngle - angleFactory.TOTAL_ANGLE);
            while (currentAngle > 359) {
                currentAngle = (currentAngle - angleFactory.TOTAL_ANGLE);
            }
        }
        if (currentAngle < 0) {
            currentAngle = (currentAngle + angleFactory.TOTAL_ANGLE);
            while (currentAngle < 0) {
                currentAngle = (currentAngle + angleFactory.TOTAL_ANGLE);
            }
        }
        return currentAngle;
    }

}

