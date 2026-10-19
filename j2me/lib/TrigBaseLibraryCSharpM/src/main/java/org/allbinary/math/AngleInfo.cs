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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsConstructor = jsinterop.annotations.JsConstructor;

namespace org.allbinary.math;

public class AngleInfo
{
    private readonly AngleIncrementInfo angleIncrementInfo;
    private short angle = 0;
    public static AngleInfo getInstance(short angleIncrement)
    {
        return new AngleInfo(AngleIncrementInfoFactory.getInstance().getAt(angleIncrement));
    }

    private AngleInfo(AngleIncrementInfo angleIncrementInfo)
    {
        this.angleIncrementInfo = angleIncrementInfo;
    }

    private readonly FrameUtil frameUtil = FrameUtil.getInstance();
    public virtual void adjustAngle(int frame)
    {
        int newAngle = this.angleIncrementInfo.getAngleIncrement() * frame - 90;
        this.setAngle(((short) this.frameUtil.adjustAngleToFrameAngle(newAngle)));
    }

    public virtual short getAngle()
    {
        return this.angle;
    }

    public virtual void setAngle(short angle)
    {
        this.angle = angle;
    }

    public virtual AngleIncrementInfo getAngleIncrementInfo()
    {
        return this.angleIncrementInfo;
    }

    private static readonly string ANGLE = "Angle: ";
    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(AngleInfo.ANGLE);
        stringBuffer.appendshort(this.angle);
        stringBuffer.append(CommonSeps.getInstance().SPACE);
        stringBuffer.append(StringUtil.getInstance().toString(this.getAngleIncrementInfo()));
        return stringBuffer.ToString();
    }

}

