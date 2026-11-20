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
using ScaleProperties = org.allbinary.media.ScaleProperties;

namespace org.allbinary.animation;

public class NullRotationAnimationFactory : AnimationInterfaceFactoryInterface, ProceduralAnimationInterfaceFactoryInterface
{
    private static NullRotationAnimationFactory NULL_ROTATION_ANIMATION_FACTORY = new NullRotationAnimationFactory();
    public readonly RotationAnimation[] NULL_ROTATION_ANIMATION_ARRAY = new RotationAnimation[0];
    private readonly Animation NULL_ANIMATION = new NullRotationAnimation2();
    private NullRotationAnimationFactory()
    {
    }

    public static NullRotationAnimationFactory getFactoryInstance()
    {
        return NullRotationAnimationFactory.NULL_ROTATION_ANIMATION_FACTORY;
    }

    public virtual Animation getInstance(int instanceId)
    {
        return this.NULL_ANIMATION;
    }

    // throws Exception
    public virtual Animation getInstanceAnimation(Animation animationInterface)
    {
        return this.NULL_ANIMATION;
    }

    public virtual void setInitialScale(ScaleProperties scaleProperties)
    {
    }

}

