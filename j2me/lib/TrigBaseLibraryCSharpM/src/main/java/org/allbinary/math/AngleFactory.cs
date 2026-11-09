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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsConstructor = jsinterop.annotations.JsConstructor;
//using JsProperty = jsinterop.annotations.JsProperty;

namespace org.allbinary.math;

public class AngleFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly AngleFactory instance = new AngleFactory();
    public static AngleFactory getInstance()
    {
        return AngleFactory.instance;
    }

    public readonly short TOTAL_ANGLE = 360;
    public readonly short QUARTER_TOTAL_ANGLE = 90;
    private readonly Angle[] angleArray;
    private readonly short NEGATIVE_ONE = ((short) (-1));
    public readonly NamedAngle NOT_ANGLE;
    public readonly NamedAngle DOWN;
    public readonly NamedAngle UP;
    public readonly NamedAngle LEFT;
    public readonly NamedAngle RIGHT;
    public AngleFactory()
    {
        this.angleArray = new Angle[((int) this.TOTAL_ANGLE)];
        this.NOT_ANGLE = new NamedAngle(this.NEGATIVE_ONE, CommonStrings.getInstance().EMPTY);
        CommonPhoneStrings commonPhoneStrings = CommonPhoneStrings.getInstance();
        short total = ((short) this.angleArray.Length);
        this.UP = new NamedAngle(((short) 0), commonPhoneStrings.UP);
        this.angleArray[0] = this.UP;
        for (int index_0 = 1; index_0 < 90; index_0++) {
            this.angleArray[index_0] = new Angle(((short) index_0));
        }
        this.RIGHT = new NamedAngle(((short) 90), commonPhoneStrings.RIGHT);
        this.angleArray[90] = this.RIGHT;
        for (int index_1 = 91; index_1 < 180; index_1++) {
            this.angleArray[index_1] = new Angle(((short) index_1));
        }
        this.DOWN = new NamedAngle(((short) 180), commonPhoneStrings.DOWN);
        this.angleArray[180] = this.DOWN;
        for (int index_2 = 181; index_2 < 270; index_2++) {
            this.angleArray[index_2] = new Angle(((short) index_2));
        }
        this.LEFT = new NamedAngle(((short) 270), commonPhoneStrings.LEFT);
        this.angleArray[270] = this.LEFT;
        for (int index_3 = 271; index_3 < ((int) total); index_3++) {
            this.angleArray[index_3] = new Angle(((short) index_3));
        }
    }

    private readonly FrameUtil frameUtil = FrameUtil.getInstance();
    public virtual Angle getAt(int index)
    {
        int adjustedIndex = ((int) this.frameUtil.adjustAngleToFrameAngle(index));
        return this.angleArray[adjustedIndex];
    }

    public virtual Angle getClosestDirection(int angle)
    {
        if ((angle >= 315 && angle < 360) || (angle >= 0 && angle < 45)) {
            return this.UP;
        } else if (angle >= 45 && angle < 135) {
            return this.RIGHT;
        } else if (angle >= 135 && angle < 225) {
            return this.DOWN;
        } else if (angle >= 225 && angle < 315) {
            return this.LEFT;
        }
        throw new SystemException();
    }

    public virtual Angle getGeneralDirection()
    {
        return this.NOT_ANGLE;
    }

    public static void main(string[] args)
    {
        StringMaker stringMaker = new StringMaker();
        AngleFactory angleFactory = AngleFactory.getInstance();
        for (int index = 0; index < 360; index++) {
            stringMaker.appendint(index).append(CommonSeps.getInstance().FORWARD_SLASH).appendshort(((short) angleFactory.getClosestDirection(index).getValue())).append(CommonSeps.getInstance().NEW_LINE);
        }
        LogUtil.getInstance().putF(stringMaker.ToString(), "main", "main");
    }

}

