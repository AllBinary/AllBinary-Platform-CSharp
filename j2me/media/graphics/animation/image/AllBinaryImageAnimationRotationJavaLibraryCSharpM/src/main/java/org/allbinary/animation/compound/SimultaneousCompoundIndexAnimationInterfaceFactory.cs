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
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using ScaleProperties = org.allbinary.media.ScaleProperties;

namespace org.allbinary.animation.compound;

public class SimultaneousCompoundIndexAnimationInterfaceFactory : AnimationInterfaceFactoryInterface
{
    private readonly AnimationInterfaceFactoryInterface[] basicAnimationInterfaceFactoryInterfaceArray;
    private readonly AnimationBehaviorFactory animationBehaviorFactory;
    public SimultaneousCompoundIndexAnimationInterfaceFactory(AnimationInterfaceFactoryInterface[] basicAnimationInterfaceFactoryInterfaceArray, AnimationBehaviorFactory animationBehaviorFactory)
    {
        this.basicAnimationInterfaceFactoryInterfaceArray = basicAnimationInterfaceFactoryInterfaceArray;
        this.animationBehaviorFactory = animationBehaviorFactory;
    }

    // throws Exception
    public virtual Animation getInstance(int instanceId)
    {
        int size = this.basicAnimationInterfaceFactoryInterfaceArray.Length;
        IndexedAnimation[] animationInterfaceArray = new IndexedAnimation[size];
        for (int index = 0; index < size; index++) {
            animationInterfaceArray[index] = ((IndexedAnimation) this.basicAnimationInterfaceFactoryInterfaceArray[index].getInstance(instanceId));
        }
        return this.getOrCreate(animationInterfaceArray);
    }

    protected virtual Animation getOrCreate(IndexedAnimation[] animationInterfaceArray)
    {
        return new SimultaneousCompoundIndexAnimation(animationInterfaceArray, this.animationBehaviorFactory.getOrCreateInstance());
    }

    public virtual AnimationInterfaceFactoryInterface[] getBasicAnimationInterfaceFactoryInterfaceArray()
    {
        return this.basicAnimationInterfaceFactoryInterfaceArray;
    }

    public virtual void setInitialScale(ScaleProperties scaleProperties)
    {
    }

}

