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
using Graphics = javax.microedition.lcdui.Graphics;
using ScaleProperties = org.allbinary.media.ScaleProperties;

namespace org.allbinary.animation;

public class NullAnimationFactory : AnimationInterfaceFactoryInterface, ProceduralAnimationInterfaceFactoryInterface
{
    public static NullAnimationFactory NULL_NOT_FOR_USE_ANIMATION_FACTORY = new NullAnimationFactory();
    private static NullAnimationFactory NULL_ANIMATION_FACTORY = new NullAnimationFactory();
    private readonly Animation NULL_ANIMATION;
    public readonly Animation[] EMPTY_ARRAY = new Animation[0];
    private NullAnimationFactory()
    {
        this.NULL_ANIMATION = new __SwtClosure_N65760((__swtSelf_N65760, graphics, x, y) => {
        });
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

    private sealed class __SwtClosure_N65760 : Animation
    {
        private readonly global::System.Action<__SwtClosure_N65760, Graphics, int, int> callback1;

        public __SwtClosure_N65760(global::System.Action<__SwtClosure_N65760, Graphics, int, int> callback1)
        {
            this.callback1 = callback1;
        }

        public override void paintXY(Graphics graphics, int x, int y) => callback1(this, graphics, x, y);
    }

}

