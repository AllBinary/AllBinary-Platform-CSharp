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
using AllBinarySensor = org.allbinary.input.AllBinarySensor;
using NoAllBinarySensor = org.allbinary.input.NoAllBinarySensor;

namespace org.allbinary.input.gyro;

public class SensorGameUpdateProcessor
{
    private AllBinarySensor inputSensor = NoAllBinarySensor.getInstance();
    public virtual void setInputSensor(AllBinarySensor inputSensor)
    {
        this.inputSensor = inputSensor;
    }

    public virtual AllBinarySensor getInputSensor()
    {
        return this.inputSensor;
    }

    // throws Exception
    public virtual void process(object anyType)
    {
    }

    // throws Exception
    public virtual void sendNotifications(object anyType)
    {
    }

    public virtual bool isAnySensor()
    {
        if (this.inputSensor == NoAllBinarySensor.getInstance()) {
            return false;
        } else {
            return true;
        }
    }

    public virtual void setNoSensors()
    {
        this.setInputSensor(NoAllBinarySensor.getInstance());
    }

}

