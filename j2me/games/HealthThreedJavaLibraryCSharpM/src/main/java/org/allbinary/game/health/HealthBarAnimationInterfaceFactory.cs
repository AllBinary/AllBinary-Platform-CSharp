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
using Animation = org.allbinary.animation.Animation;
using AnimationInterfaceFactoryInterface = org.allbinary.animation.AnimationInterfaceFactoryInterface;
using ProceduralAnimationInterfaceFactoryInterface = org.allbinary.animation.ProceduralAnimationInterfaceFactoryInterface;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using ScaleProperties = org.allbinary.media.ScaleProperties;

namespace org.allbinary.game.health;

public class HealthBarAnimationInterfaceFactory : AnimationInterfaceFactoryInterface, ProceduralAnimationInterfaceFactoryInterface
{
    public HealthBarAnimationInterfaceFactory()
    {
    }

    // throws Exception
    public virtual HealthBarAnimation getInstanceByLocation(AllBinaryLayer layerInterface, int location)
    {
        return new HealthBarThreedAnimation(layerInterface, location);
    }

    // throws Exception
    public virtual Animation getInstance(int instanceId)
    {
        return null;
    }

    // throws Exception
    public virtual Animation getInstanceAnimation(Animation animationInterface)
    {
        return null;
    }

    public virtual void setInitialScale(ScaleProperties scaleProperties)
    {
    }

}

