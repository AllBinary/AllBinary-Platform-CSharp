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
using BaseImageAnimationFactory = org.allbinary.animation.image.BaseImageAnimationFactory;
using BasicColorUtil = org.allbinary.graphics.color.BasicColorUtil;
using AnimationFactorySpriteScaleUtil = org.allbinary.image.sprite.AnimationFactorySpriteScaleUtil;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;

namespace org.allbinary.animation.image.sprite;

public class OneRowSpriteIndexedAnimationFactory : BaseImageAnimationFactory
{
    // throws Exception
    public static OneRowSpriteIndexedAnimationFactory createFactoryDX(Image image, int dx, AnimationBehaviorFactory animationBehaviorFactory)
    {
        OneRowSpriteIndexedAnimationFactory oneRowSpriteIndexedAnimationFactory = new OneRowSpriteIndexedAnimationFactory(image, PrimitiveIntUtil.getArrayInstance(), image.getHeight(), image.getHeight(), 0, 0, animationBehaviorFactory);
        oneRowSpriteIndexedAnimationFactory.initW(dx);
        return oneRowSpriteIndexedAnimationFactory;
    }

    // throws Exception
    public static OneRowSpriteIndexedAnimationFactory createFactoryDXY(Image image, int dx, int dy, AnimationBehaviorFactory animationBehaviorFactory)
    {
        OneRowSpriteIndexedAnimationFactory oneRowSpriteIndexedAnimationFactory = new OneRowSpriteIndexedAnimationFactory(image, PrimitiveIntUtil.getArrayInstance(), image.getHeight(), image.getHeight(), 0, 0, animationBehaviorFactory);
        oneRowSpriteIndexedAnimationFactory.init(dx, dy);
        return oneRowSpriteIndexedAnimationFactory;
    }

    // throws Exception
    public static OneRowSpriteIndexedAnimationFactory createFactoryWH(Image image, int width, int height, AnimationBehaviorFactory animationBehaviorFactory)
    {
        return new OneRowSpriteIndexedAnimationFactory(image, PrimitiveIntUtil.getArrayInstance(), width, height, 0, 0, animationBehaviorFactory);
    }

    // throws Exception
    public static OneRowSpriteIndexedAnimationFactory createFactory(Image image, AnimationBehaviorFactory animationBehaviorFactory)
    {
        return new OneRowSpriteIndexedAnimationFactory(image, PrimitiveIntUtil.getArrayInstance(), image.getHeight(), image.getHeight(), 0, 0, animationBehaviorFactory);
    }

    private readonly AnimationFactorySpriteScaleUtil animationFactorySpriteScaleUtil = AnimationFactorySpriteScaleUtil.getInstance();
    public OneRowSpriteIndexedAnimationFactory(Image image, int[] sequenceArray, int width, int height, int dx, int dy, AnimationBehaviorFactory animationBehaviorFactory) : base(image, sequenceArray, width, height, dx, dy, animationBehaviorFactory)
    {
        // base(image, sequenceArray, width, height, dx, dy, animationBehaviorFactory) is called from the constructor declaration
    }

    public virtual void init(int dx, int dy)
    {
        this.animationFactoryInitializationVisitor.dx = dx;
        this.animationFactoryInitializationVisitor.dy = dy;
    }

    public virtual void initW(int dx)
    {
        this.init(dx, 0);
        this.animationFactoryInitializationVisitor.dx += -(this.animationFactoryInitializationVisitor.width >> 2);
    }

    // throws Exception
    public override Animation getInstance(int instanceId)
    {
        Sprite sprite = this.animationFactorySpriteScaleUtil.createImage(this.getImage(), this.animationFactoryInitializationVisitor.width, this.animationFactoryInitializationVisitor.height, this.scaleProperties.scaleWidth, this.scaleProperties.scaleHeight);
        if (this.animationFactoryInitializationVisitor.dx != 0 || this.animationFactoryInitializationVisitor.dy != 0) {
            return new AdjustedSpriteIndexedAnimation(sprite, this.getImage(), BasicColorUtil.getInstance().ZERO_ARRAY, this.animationFactoryInitializationVisitor.dx, this.animationFactoryInitializationVisitor.dy, this.animationBehaviorFactory.getOrCreateInstance());
        } else {
            return new SpriteIndexedAnimation(sprite, this.getImage(), BasicColorUtil.getInstance().ZERO_ARRAY, this.animationBehaviorFactory.getOrCreateInstance());
        }
    }

}

