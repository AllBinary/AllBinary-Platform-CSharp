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

public class NullIndexedAnimationFactory : AnimationInterfaceFactoryInterface, ProceduralAnimationInterfaceFactoryInterface
{
    public static readonly IndexedAnimation[] NULL_INDEXED_ANIMATION_ARRAY = new IndexedAnimation[0];
    private static NullIndexedAnimationFactory NULL_INDEXED_ANIMATION_FACTORY = new NullIndexedAnimationFactory();
    public class NullIndexedAnimationInner : NullIndexedAnimation
    {
        public NullIndexedAnimationInner() : base(new IndexedAnimationBehavior(1, 250))
        {
            // base(new IndexedAnimationBehavior(1, 250)) is called from the constructor declaration
        }

        public override void paintXY(Graphics graphics, int x, int y)
        {
        }

    }
    private readonly Animation NULL_ANIMATION = new NullIndexedAnimationInner();
    private NullIndexedAnimationFactory()
    {
    }

    public static NullIndexedAnimationFactory getFactoryInstance()
    {
        return NullIndexedAnimationFactory.NULL_INDEXED_ANIMATION_FACTORY;
    }

    // throws Exception
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

