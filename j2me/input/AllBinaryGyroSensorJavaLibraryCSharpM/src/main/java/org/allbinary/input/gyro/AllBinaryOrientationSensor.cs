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
using CompleteMotionGestureInputEventListenerInterface = org.allbinary.game.input.CompleteMotionGestureInputEventListenerInterface;
using NoCompleteMotionGestureInputEventListener = org.allbinary.game.input.motion.action.NoCompleteMotionGestureInputEventListener;
using AllBinarySensor = org.allbinary.input.AllBinarySensor;
using Orientation = org.allbinary.logic.math.Orientation;
using PrimitiveFloatUtil = org.allbinary.logic.math.PrimitiveFloatUtil;

namespace org.allbinary.input.gyro;

public class AllBinaryOrientationSensor : AllBinarySensor
{
    public float[] sensorDataFloatArray = PrimitiveFloatUtil.getArrayInstance();
    public CompleteMotionGestureInputEventListenerInterface listener = NoCompleteMotionGestureInputEventListener.getInstance();
    public virtual void setCompleteMotionGestureInputEventListener(CompleteMotionGestureInputEventListenerInterface completeMotionGestureInputEventListenerInterface)
    {
        this.listener = completeMotionGestureInputEventListenerInterface;
    }

    public AllBinaryOrientationSensor()
    {
    }

    // throws Exception
    public virtual Orientation getOrientation()
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

}

