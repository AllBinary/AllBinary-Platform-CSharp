/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using NoShakeAnimationListener = org.allbinary.animation.transition.shake.NoShakeAnimationListener;
using ShakeAnimationListener = org.allbinary.animation.transition.shake.ShakeAnimationListener;
using ShakeAnimationListenerFactory = org.allbinary.animation.transition.shake.ShakeAnimationListenerFactory;
using GameConfigurationCentral = org.allbinary.game.configuration.GameConfigurationCentral;
using TickableInterface = org.allbinary.game.tick.TickableInterface;
using AllBinaryNoVibration = org.allbinary.media.AllBinaryNoVibration;
using AllBinaryVibration = org.allbinary.media.AllBinaryVibration;
using AllBinaryVibrationME = org.allbinary.media.AllBinaryVibrationME;

namespace org.allbinary.game.layer;

public class AdvancedRTSProperties
{
    public static AdvancedRTSProperties createPropertiesSimulated()
    {
        return new AdvancedRTSProperties(NoShakeAnimationListener.NO_SHAKE_ANIMATION_LISTENER, AllBinaryNoVibration.NO_VIBRATION, 0, new WaypointBehaviorBase());
    }

    public static AdvancedRTSProperties createProperties()
    {
        return new AdvancedRTSProperties(ShakeAnimationListenerFactory.getInstance(), AllBinaryVibration.getInstance(), ((int) GameConfigurationCentral.getInstance().VIBRATION.getValue()) * 100, new WaypointBehaviorBase());
    }

    public readonly ShakeAnimationListener shakeListener;
    public readonly AllBinaryVibrationME vibration;
    public readonly int duration;
    public TickableInterface waypointBehaviorBase;
    public AdvancedRTSProperties(ShakeAnimationListener shakeListener, AllBinaryVibrationME vibration, int duration, TickableInterface waypointBehaviorBase)
    {
        this.shakeListener = shakeListener;
        this.vibration = vibration;
        this.duration = duration;
        this.waypointBehaviorBase = waypointBehaviorBase;
    }

}

