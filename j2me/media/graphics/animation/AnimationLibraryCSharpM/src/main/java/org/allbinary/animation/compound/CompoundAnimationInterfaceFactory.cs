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
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using ScaleProperties = org.allbinary.media.ScaleProperties;

namespace org.allbinary.animation.compound;

public class CompoundAnimationInterfaceFactory : AnimationInterfaceFactoryInterface
{
    public readonly AnimationInterfaceFactoryInterface[] basicAnimationInterfaceFactoryInterfaceArrayP;
    public readonly AnimationBehaviorFactory animationBehaviorFactory;
    public CompoundAnimationInterfaceFactory(AnimationInterfaceFactoryInterface[] basicAnimationInterfaceFactoryInterfaceArray, AnimationBehaviorFactory animationBehaviorFactory)
    {
        this.basicAnimationInterfaceFactoryInterfaceArrayP = basicAnimationInterfaceFactoryInterfaceArray;
        this.animationBehaviorFactory = animationBehaviorFactory;
    }

    // throws Exception
    public virtual Animation getInstance(int instanceId)
    {
        int size = this.basicAnimationInterfaceFactoryInterfaceArrayP.Length;
        Animation[] animationInterfaceArray = this.createArray(size);
        for (int index = 0; index < size; index++) {
            animationInterfaceArray[index] = this.basicAnimationInterfaceFactoryInterfaceArrayP[index].getInstance(instanceId);
        }
        return this.createAnimation(animationInterfaceArray);
    }

    public virtual Animation[] createArray(int size)
    {
        return NullAnimationFactory.getFactoryInstance().EMPTY_ARRAY;
    }

    public virtual Animation createAnimation(Animation[] animationInterfaceArray)
    {
        return NullAnimationFactory.getFactoryInstance().getInstance(0);
    }

    public virtual AnimationInterfaceFactoryInterface[] getBasicAnimationInterfaceFactoryInterfaceArray()
    {
        return this.basicAnimationInterfaceFactoryInterfaceArrayP;
    }

    public virtual void setInitialScale(ScaleProperties scaleProperties)
    {
        int size = this.basicAnimationInterfaceFactoryInterfaceArrayP.Length;
        for (int index = 0; index < size; index++) {
            this.basicAnimationInterfaceFactoryInterfaceArrayP[index].setInitialScale(scaleProperties);
        }
    }

}

