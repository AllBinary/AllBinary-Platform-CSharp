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
using Orientation = org.allbinary.logic.math.Orientation;

namespace org.allbinary.input.gyro;

public class OrientationToGameKeyEvent
{
    private AllBinaryOrientationSensor allBinaryGyroSensor = null;
    private readonly int MIN = 15;
    public OrientationToGameKeyEvent()
    {
        if (Features.getInstance().isFeature(SensorFeatureFactory.getInstance().NO_ORIENTATION)) {
            this.allBinaryGyroSensor = new NoGyroSensor();
        } else {
            throw new Exception("Not Such Feature");
        }
    }

    public virtual void setAllBinaryGyroSensor(AllBinaryOrientationSensor allBinaryGyroSensor)
    {
        this.allBinaryGyroSensor = allBinaryGyroSensor;
    }

    public virtual AllBinaryOrientationSensor getAllBinaryGyroSensor()
    {
        return this.allBinaryGyroSensor;
    }

    // throws Exception
    public virtual void process()
    {
    }

    // throws Exception
    private void updateGameKeyEvents(Orientation orientation, int yaw, int pitch, int roll)
    {
    }

}

