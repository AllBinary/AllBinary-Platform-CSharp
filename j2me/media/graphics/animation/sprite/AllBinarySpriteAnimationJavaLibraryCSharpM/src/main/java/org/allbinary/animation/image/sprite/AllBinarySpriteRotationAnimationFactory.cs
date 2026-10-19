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
//using Image = javax.microedition.lcdui.Image;
//using Sprite = javax.microedition.lcdui.game.Sprite;
using Animation = org.allbinary.animation.Animation;
using AnimationBehaviorFactory = org.allbinary.animation.AnimationBehaviorFactory;
using ProceduralAnimationInterfaceFactoryInterface = org.allbinary.animation.ProceduralAnimationInterfaceFactoryInterface;
using BaseImageAnimationFactory = org.allbinary.animation.image.BaseImageAnimationFactory;
using AnimationFactorySpriteScaleUtil = org.allbinary.image.sprite.AnimationFactorySpriteScaleUtil;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;

namespace org.allbinary.animation.image.sprite;

public class AllBinarySpriteRotationAnimationFactory : BaseImageAnimationFactory, ProceduralAnimationInterfaceFactoryInterface
{
    // throws Exception
    public static AllBinarySpriteRotationAnimationFactory createWHDY(Image image, int dx, int dy, AnimationBehaviorFactory animationBehaviorFactory)
    {
        AllBinarySpriteRotationAnimationFactory spriteRotationAnimationFactory = new AllBinarySpriteRotationAnimationFactory(image, PrimitiveIntUtil.getArrayInstance(), (image.getHeight() >> 2), (image.getHeight() >> 2), 0, 0, animationBehaviorFactory);
        spriteRotationAnimationFactory.initWH(dx, dy);
        return spriteRotationAnimationFactory;
    }

    // throws Exception
    public static AllBinarySpriteRotationAnimationFactory createWH(Image image, AnimationBehaviorFactory animationBehaviorFactory)
    {
        return AllBinarySpriteRotationAnimationFactory.createWHDY(image, 0, 0, animationBehaviorFactory);
    }

    // throws Exception
    public static AllBinarySpriteRotationAnimationFactory createDXY(Image image, int dx, int dy, AnimationBehaviorFactory animationBehaviorFactory)
    {
        AllBinarySpriteRotationAnimationFactory spriteRotationAnimationFactory = new AllBinarySpriteRotationAnimationFactory(image, PrimitiveIntUtil.getArrayInstance(), image.getHeight(), image.getHeight(), 0, 0, animationBehaviorFactory);
        spriteRotationAnimationFactory.init(dx, dy);
        return spriteRotationAnimationFactory;
    }

    // throws Exception
    public static AllBinarySpriteRotationAnimationFactory createDXYQ(Image image, int dx, int dy, AnimationBehaviorFactory animationBehaviorFactory)
    {
        AllBinarySpriteRotationAnimationFactory spriteRotationAnimationFactory = new AllBinarySpriteRotationAnimationFactory(image, PrimitiveIntUtil.getArrayInstance(), (image.getHeight() >> 2), (image.getHeight() >> 2), 0, 0, animationBehaviorFactory);
        spriteRotationAnimationFactory.init(dx, dy);
        return spriteRotationAnimationFactory;
    }

    // throws Exception
    public static AllBinarySpriteRotationAnimationFactory createQ(Image image, AnimationBehaviorFactory animationBehaviorFactory)
    {
        return new AllBinarySpriteRotationAnimationFactory(image, PrimitiveIntUtil.getArrayInstance(), (image.getHeight() >> 2), (image.getHeight() >> 2), 0, 0, animationBehaviorFactory);
    }

    // throws Exception
    public static AllBinarySpriteRotationAnimationFactory createWHF(Image image, AnimationBehaviorFactory animationBehaviorFactory)
    {
        return new AllBinarySpriteRotationAnimationFactory(image, PrimitiveIntUtil.getArrayInstance(), image.getHeight(), image.getHeight(), 0, 0, animationBehaviorFactory);
    }

    private readonly AnimationFactorySpriteScaleUtil animationFactorySpriteScaleUtil = AnimationFactorySpriteScaleUtil.getInstance();
    public AllBinarySpriteRotationAnimationFactory(Image image, int[] sequenceArray, int width, int height, int dx, int dy, AnimationBehaviorFactory animationBehaviorFactory) : base(image, sequenceArray, width, height, dx, dy, animationBehaviorFactory)
    {
        // base(image, sequenceArray, width, height, dx, dy, animationBehaviorFactory) is called from the constructor declaration
        if (animationBehaviorFactory == AnimationBehaviorFactory.getInstance()) {
            ForcedLogUtil.log("Using default AnimationBehaviorFactory with IndexedAnimationFactory", this);
        }
    }

    public virtual void init(int dx, int dy)
    {
        this.animationFactoryInitializationVisitor.dx = dx;
        this.animationFactoryInitializationVisitor.dy = dy;
    }

    private void initWH(int dx, int dy)
    {
        this.init(dx, dy);
        this.animationFactoryInitializationVisitor.dx += -this.animationFactoryInitializationVisitor.width / 5;
        this.animationFactoryInitializationVisitor.dy += -this.animationFactoryInitializationVisitor.height / 5;
    }

    // throws Exception
    public override Animation getInstance(int instanceId)
    {
        Sprite sprite = this.animationFactorySpriteScaleUtil.createImage(this.getImage(), this.animationFactoryInitializationVisitor.width, this.animationFactoryInitializationVisitor.height, this.scaleProperties.scaleWidth, this.scaleProperties.scaleHeight);
        if (this.animationFactoryInitializationVisitor.dx != 0 || this.animationFactoryInitializationVisitor.dy != 0) {
            return new AllBinaryAdjustedSpriteRotationAnimation(sprite, this.getImage(), this.animationFactoryInitializationVisitor.dx, this.animationFactoryInitializationVisitor.dy, this.animationBehaviorFactory.getOrCreateInstance());
        } else {
            return new AllBinarySpriteRotationAnimation(sprite, this.getImage(), this.animationBehaviorFactory.getOrCreateInstance());
        }
    }

    // throws Exception
    public override Animation getInstanceAnimation(Animation animationInterface)
    {
        return this.getInstance(0);
    }

}

