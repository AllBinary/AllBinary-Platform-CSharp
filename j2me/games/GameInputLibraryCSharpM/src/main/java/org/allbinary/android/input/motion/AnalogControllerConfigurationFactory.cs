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
using AnalogControllerConfigurationEvent = org.allbinary.android.input.motion.@event.AnalogControllerConfigurationEvent;
using AnalogControllerConfigurationEventHandler = org.allbinary.android.input.motion.@event.AnalogControllerConfigurationEventHandler;
using ScaleFactorFactory = org.allbinary.logic.math.ScaleFactorFactory;

namespace org.allbinary.android.input.motion;

public class AnalogControllerConfigurationFactory
{
    private static readonly AnalogControllerConfigurationFactory instance = new AnalogControllerConfigurationFactory();
    public static AnalogControllerConfigurationFactory getInstance()
    {
        return AnalogControllerConfigurationFactory.instance;
    }

    public readonly int SCALE_FACTOR = ScaleFactorFactory.getInstance().DEFAULT_SCALE_FACTOR;
    public readonly int SCALE_VALUE = ScaleFactorFactory.getInstance().DEFAULT_SCALE_VALUE;
    private bool available = false;
    private readonly AnalogControllerConfigurationEvent analogControllerConfigurationEvent;
    private AnalogControllerConfigurationFactory()
    {
        this.analogControllerConfigurationEvent = new AnalogControllerConfigurationEvent(this);
    }

    public virtual bool isAvailable()
    {
        return this.available;
    }

    // throws Exception
    public virtual void setAvailable(bool available)
    {
        this.available = available;
        AnalogControllerConfigurationEventHandler.getInstance().fireEvent(this.analogControllerConfigurationEvent);
    }

}

