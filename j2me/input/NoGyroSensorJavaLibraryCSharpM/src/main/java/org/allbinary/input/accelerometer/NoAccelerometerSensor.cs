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
using AllBinaryOrientationSensor = org.allbinary.input.gyro.AllBinaryOrientationSensor;
using Orientation = org.allbinary.logic.math.Orientation;

namespace org.allbinary.input.accelerometer;

public class NoAccelerometerSensor : AllBinaryOrientationSensor
{
    public NoAccelerometerSensor()
    {
    }

    // throws Exception
    public override Orientation getOrientation()
    {
        return Orientation.NONE;
    }

    public override void onSensorChange()
    {
    }

}

