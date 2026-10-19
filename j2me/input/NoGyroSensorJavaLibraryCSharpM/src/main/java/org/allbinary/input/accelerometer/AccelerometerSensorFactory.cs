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
using Features = org.allbinary.game.configuration.feature.Features;
using SensorFeatureFactory = org.allbinary.game.configuration.feature.SensorFeatureFactory;
using AllBinaryOrientationSensor = org.allbinary.input.gyro.AllBinaryOrientationSensor;

namespace org.allbinary.input.accelerometer;

public class AccelerometerSensorFactory
{
    private static AllBinaryOrientationSensor allBinaryAccelerometerSensor = AllBinaryOrientationSensor.NULL_ALLBINARY_ORIENTATION_SENSOR;
    // throws Exception
    public static void init()
    {
        Features features = Features.getInstance();
        SensorFeatureFactory sensorFeatureFactory = SensorFeatureFactory.getInstance();
        if (features.isFeature(sensorFeatureFactory.ORIENTATION_SENSORS)) {
            throw new Exception("No Orientation Sensors");
        } else if (features.isFeature(sensorFeatureFactory.SIMULATED_ORIENTATION_SENSORS)) {
            throw new Exception("No Simulation Sensors");
        } else if (features.isFeature(sensorFeatureFactory.NO_ORIENTATION)) {
            AccelerometerSensorFactory.allBinaryAccelerometerSensor = new NoAccelerometerSensor();
        } else {
            throw new Exception("Not Such SensorFeature");
        }
    }

    public static AllBinaryOrientationSensor getInstance()
    {
        return AccelerometerSensorFactory.allBinaryAccelerometerSensor;
    }

}

