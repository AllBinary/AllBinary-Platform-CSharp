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
using GameConfigurationCentral = org.allbinary.game.configuration.GameConfigurationCentral;
using AngleFactory = org.allbinary.math.AngleFactory;
using AngleInfo = org.allbinary.math.AngleInfo;
using ScaleProperties = org.allbinary.media.ScaleProperties;

namespace org.allbinary.animation;

public class RotationAnimationFactory : AnimationInterfaceFactoryInterface, ProceduralAnimationInterfaceFactoryInterface
{
    public static RotationAnimationFactory createFactory()
    {
        short totalAngle = AngleFactory.getInstance().TOTAL_ANGLE;
        return new RotationAnimationFactory(totalAngle, ((short) (totalAngle / GameConfigurationCentral.getInstance().getGameControlFidelity())));
    }

    private short totalAngle;
    private short angleIncrement;
    public RotationAnimationFactory(short totalAngle, short angleIncrement)
    {
        this.totalAngle = totalAngle;
        this.angleIncrement = angleIncrement;
    }

    // throws Exception
    public virtual Animation getInstance(int instanceId)
    {
        return NullRotationAnimation.createTotalAngle(AngleInfo.getInstance(this.angleIncrement), this.totalAngle, AnimationBehavior.getInstance());
    }

    // throws Exception
    public virtual Animation getInstanceAnimation(Animation animationInterface)
    {
        return NullRotationAnimation.createTotalAngle(AngleInfo.getInstance(this.angleIncrement), this.totalAngle, AnimationBehavior.getInstance());
    }

    public virtual void setInitialScale(ScaleProperties scaleProperties)
    {
    }

}

