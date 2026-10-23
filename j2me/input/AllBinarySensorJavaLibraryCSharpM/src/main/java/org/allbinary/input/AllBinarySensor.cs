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
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input;

public class AllBinarySensor : AllBinarySensorListener
{
    public static readonly AllBinarySensor NULL_ALLBINARY_SENSOR = new AllBinarySensor();
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private static int max = 100;
    public AllBinarySensor()
    {
    }

    public virtual void init()
    {
    }

    // throws Exception
    public virtual void update()
    {
    }

    public static void setMax(int max)
    {
        AllBinarySensor.max = max;
    }

    public static int getMax()
    {
        return AllBinarySensor.max;
    }

    public virtual int getId()
    {
        return AllBinarySensor.getMax();
    }

    public virtual void shutdown()
    {
        this.logUtil.putF(this.commonStrings.START, this, "shutdown");
    }

    public virtual void onSensorChange()
    {
        ForcedLogUtil.log(this.commonStrings.NOT_IMPLEMENTED, this);
    }

}

