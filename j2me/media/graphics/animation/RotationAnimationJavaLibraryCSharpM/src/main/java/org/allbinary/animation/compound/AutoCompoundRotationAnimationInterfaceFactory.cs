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
using AnimationBehaviorFactory = org.allbinary.animation.AnimationBehaviorFactory;
using AnimationInterfaceFactoryInterface = org.allbinary.animation.AnimationInterfaceFactoryInterface;
using RotationAnimation = org.allbinary.animation.RotationAnimation;

namespace org.allbinary.animation.compound;

public class AutoCompoundRotationAnimationInterfaceFactory : CompoundAnimationInterfaceFactory
{
    public AutoCompoundRotationAnimationInterfaceFactory(AnimationInterfaceFactoryInterface[] basicAnimationInterfaceFactoryInterfaceArray, AnimationBehaviorFactory animationBehaviorFactory) : base(basicAnimationInterfaceFactoryInterfaceArray, animationBehaviorFactory)
    {
        // base(basicAnimationInterfaceFactoryInterfaceArray, animationBehaviorFactory) is called from the constructor declaration
    }

    public override Animation[] createArray(int size)
    {
        return new RotationAnimation[size];
    }

    public override Animation createAnimation(Animation[] animationInterfaceArray)
    {
        return new AutoCompoundRotationAnimation(((RotationAnimation[]) animationInterfaceArray), this.animationBehaviorFactory.getOrCreateInstance());
    }

}

