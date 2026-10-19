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
using Processor = org.allbinary.canvas.Processor;
using Features = org.allbinary.game.configuration.feature.Features;
using SensorFeatureFactory = org.allbinary.game.configuration.feature.SensorFeatureFactory;
using NoCompleteMotionGestureInputEventListener = org.allbinary.game.input.motion.action.NoCompleteMotionGestureInputEventListener;
using SingleKeyPressGameKeyFromMotionGestureEventListener = org.allbinary.game.input.motion.action.SingleKeyPressGameKeyFromMotionGestureEventListener;
using AccelerometerSensorFactory = org.allbinary.input.accelerometer.AccelerometerSensorFactory;

namespace org.allbinary.input.gyro;

public class AccelerometerSensorUpdateProcessor : Processor
{
    // throws Exception
    public virtual void process()
    {
        SensorFeatureFactory sensorFeatureFactory = SensorFeatureFactory.getInstance();
        if (Features.getInstance().isFeature(sensorFeatureFactory.ORIENTATION_SENSORS)) {
            AccelerometerSensorFactory.getInstance().setCompleteMotionGestureInputEventListener(new SingleKeyPressGameKeyFromMotionGestureEventListener());
        } else if (Features.getInstance().isFeature(sensorFeatureFactory.SIMULATED_ORIENTATION_SENSORS)) {
            AccelerometerSensorFactory.getInstance().setCompleteMotionGestureInputEventListener(new SingleKeyPressGameKeyFromMotionGestureEventListener());
        } else if (Features.getInstance().isFeature(sensorFeatureFactory.NO_ORIENTATION)) {
            AccelerometerSensorFactory.getInstance().setCompleteMotionGestureInputEventListener(NoCompleteMotionGestureInputEventListener.getInstance());
        } else {
            throw new Exception("Sensor Feature Not Set");
        }
    }

}

