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
using AccelerometerSensorFactory = org.allbinary.input.accelerometer.AccelerometerSensorFactory;
using GyroSensorFactory = org.allbinary.input.gyro.GyroSensorFactory;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.input;

public class AllBinarySensorManager
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static AllBinarySensorManager getInstance()
    {
        if (AllBinarySensorManager.instance == NullUtil.getInstance().NULL_OBJECT) {
            AllBinarySensorManager.instance = new AllBinarySensorManager();
        }
        return ((AllBinarySensorManager) AllBinarySensorManager.instance);
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly string ORIENTATION_SENSOR_INPUT = "Orientation Sensor Input";
    public readonly string ORIENTATION_TYPE = "Orientation Type";
    private AllBinarySensorManager()
    {
        try {
            GyroSensorFactory.init();
            AccelerometerSensorFactory.init();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.CONSTRUCTOR, e);
        }
    }

    public virtual void init()
    {
    }

    private readonly BasicArrayList list = new BasicArrayListD();
    public virtual BasicArrayList getSensorNamesList()
    {
        return this.list;
    }

    public virtual void shutdown()
    {
    }

}

