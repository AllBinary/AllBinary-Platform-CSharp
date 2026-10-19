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
//using Graphics = javax.microedition.lcdui.Graphics;
using ScaleProperties = org.allbinary.media.ScaleProperties;

namespace org.allbinary.animation;

public class NullAnimationFactory : AnimationInterfaceFactoryInterface, ProceduralAnimationInterfaceFactoryInterface
{
    public static NullAnimationFactory NULL_NOT_FOR_USE_ANIMATION_FACTORY = new NullAnimationFactory();
    private static NullAnimationFactory NULL_ANIMATION_FACTORY = new NullAnimationFactory();
    private readonly Animation NULL_ANIMATION = new Animation()
#if JAVA_ANONYMOUS_CLASS_BODY
        public virtual void paintXY(Graphics graphics, int x, int y)
        {
        }

#endif
;
    public readonly Animation[] EMPTY_ARRAY = new Animation[0];
    private NullAnimationFactory()
    {
    }

    public static NullAnimationFactory getFactoryInstance()
    {
        return NullAnimationFactory.NULL_ANIMATION_FACTORY;
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

