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

public class AnimationInterfaceFactoryInterfaceComposite : AnimationInterfaceFactoryInterface
{
    private readonly AnimationInterfaceFactoryInterface[] animationInterfaceFactoryInterfaceArray;
    public AnimationInterfaceFactoryInterfaceComposite(AnimationInterfaceFactoryInterface[] basicAnimationInterfaceFactoryInterfaceArray)
    {
        this.animationInterfaceFactoryInterfaceArray = basicAnimationInterfaceFactoryInterfaceArray;
    }

    // throws Exception
    public virtual Animation getInstance(int instanceId)
    {
        return NullAnimationFactory.getFactoryInstance().getInstance(0);
    }

    public virtual AnimationInterfaceFactoryInterface[] getAnimationInterfaceFactoryInterfaceArray()
    {
        return this.animationInterfaceFactoryInterfaceArray;
    }

    public virtual void setInitialScale(ScaleProperties scaleProperties)
    {
    }

}

