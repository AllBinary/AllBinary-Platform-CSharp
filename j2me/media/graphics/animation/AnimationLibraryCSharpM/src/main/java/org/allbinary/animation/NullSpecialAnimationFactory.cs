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
using SpecialAnimation = org.allbinary.animation.special.SpecialAnimation;
using ScaleProperties = org.allbinary.media.ScaleProperties;

namespace org.allbinary.animation;

public class NullSpecialAnimationFactory : AnimationInterfaceFactoryInterface, ProceduralAnimationInterfaceFactoryInterface
{
    private static NullSpecialAnimationFactory NULL_SPECIAL_ANIMATION_FACTORY = new NullSpecialAnimationFactory();
    private NullSpecialAnimationFactory()
    {
    }

    public static NullSpecialAnimationFactory getFactoryInstance()
    {
        return NullSpecialAnimationFactory.NULL_SPECIAL_ANIMATION_FACTORY;
    }

    // throws Exception
    public virtual Animation getInstance(int instanceId)
    {
        return SpecialAnimation.getInstance();
    }

    // throws Exception
    public virtual Animation getInstanceAnimation(Animation animationInterface)
    {
        return SpecialAnimation.getInstance();
    }

    public virtual void setInitialScale(ScaleProperties scaleProperties)
    {
    }

}

