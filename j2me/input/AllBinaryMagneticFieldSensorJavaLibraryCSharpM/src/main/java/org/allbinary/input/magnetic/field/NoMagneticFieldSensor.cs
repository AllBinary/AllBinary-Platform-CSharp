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
using AllBinarySensorListener = org.allbinary.input.AllBinarySensorListener;
using Orientation = org.allbinary.logic.math.Orientation;

namespace org.allbinary.input.magnetic.field;

public class NoMagneticFieldSensor : AllBinaryMagneticFieldSensor, AllBinarySensorListener
{
    // throws Exception
    public virtual Orientation getOrientation()
    {
        return Orientation.NONE;
    }

    public override void onSensorChange()
    {
    }

}

