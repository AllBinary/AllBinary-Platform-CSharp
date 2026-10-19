/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using ImageCacheFactory = org.allbinary.image.ImageCacheFactory;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using ScaleProperties = org.allbinary.media.ScaleProperties;

namespace org.allbinary.animation.image;

public class LazyImageRotationAnimationFactory : AnimationInterfaceFactoryInterface
{
    private readonly int layoutIndex;
    private readonly BaseImageAnimationFactory animationInterfaceFactoryInterface;
    public ScaleProperties scaleProperties = ScaleProperties.instance;
    public LazyImageRotationAnimationFactory(int layoutIndex, int associatedLazyAnimationId, BaseImageAnimationFactory animationInterfaceFactoryInterface)
    {
        this.layoutIndex = layoutIndex;
        this.animationInterfaceFactoryInterface = animationInterfaceFactoryInterface;
        ImageCacheFactory.getInstance().hasAnyLazyAnimationFactories = true;
        if (this.animationInterfaceFactoryInterface.animationBehaviorFactory == AnimationBehaviorFactory.getInstance()) {
            ForcedLogUtil.log("Using default AnimationBehaviorFactory with IndexedAnimationFactory", this);
        }
    }

    // throws Exception
    public virtual Animation getInstance(int instanceId)
    {
        if (this.animationInterfaceFactoryInterface.getImage().isReady()) {
            this.animationInterfaceFactoryInterface.setInitialScale(this.scaleProperties);
            return this.animationInterfaceFactoryInterface.getInstance(instanceId);
        } else {
            return new LazyImageRotationAnimation(this.layoutIndex, instanceId, this.scaleProperties, this.animationInterfaceFactoryInterface, this.animationInterfaceFactoryInterface.animationBehaviorFactory.getOrCreateInstance());
        }
    }

    public virtual void setInitialScale(ScaleProperties scaleProperties)
    {
        this.scaleProperties = scaleProperties;
    }

}

