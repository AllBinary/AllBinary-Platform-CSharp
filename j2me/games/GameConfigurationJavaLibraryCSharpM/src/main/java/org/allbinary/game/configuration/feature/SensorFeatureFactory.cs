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

namespace org.allbinary.game.configuration.feature;

public class SensorFeatureFactory
{
    private static readonly SensorFeatureFactory instance = new SensorFeatureFactory();
    public static SensorFeatureFactory getInstance()
    {
        return SensorFeatureFactory.instance;
    }

    private SensorFeatureFactory()
    {
    }

    public readonly SensorFeature NO_ORIENTATION = new SensorFeature("No Orientation");
    public readonly SensorFeature ORIENTATION_SENSORS = new SensorFeature("Orientation Sensors");
    public readonly SensorFeature SIMULATED_ORIENTATION_SENSORS = new SensorFeature("Simulated Orientation Sensors");
    public readonly SensorFeature YAW = new SensorFeature("Yaw");
    public readonly SensorFeature YAW_MINUS_RIGHT_PLUS_LEFT = new SensorFeature("Yaw -Right +Left");
    public readonly SensorFeature YAW_MINUS_LEFT_PLUS_RIGHT = new SensorFeature("Yaw -Left +Right ");
    public readonly SensorFeature PITCH = new SensorFeature("Pitch");
    public readonly SensorFeature ROLL = new SensorFeature("Roll");
}

