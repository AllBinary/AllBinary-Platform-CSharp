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
using AndroidUtil = org.allbinary.AndroidUtil;
using Animation = org.allbinary.animation.Animation;
using AnimationBehaviorFactory = org.allbinary.animation.AnimationBehaviorFactory;
using ProceduralAnimationInterfaceFactoryInterface = org.allbinary.animation.ProceduralAnimationInterfaceFactoryInterface;
using BaseImageAnimationFactory = org.allbinary.animation.image.BaseImageAnimationFactory;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorUtil = org.allbinary.graphics.color.BasicColorUtil;
using AnimationFactorySpriteScaleUtil = org.allbinary.image.sprite.AnimationFactorySpriteScaleUtil;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;

namespace org.allbinary.animation.image.sprite;

public class SpriteIndexedAnimationFactory : BaseImageAnimationFactory, ProceduralAnimationInterfaceFactoryInterface
{
    // throws Exception
    public static SpriteIndexedAnimationFactory createCWHDXY(Image image, BasicColor[] basicColorArray, int width, int height, int dx, int dy, AnimationBehaviorFactory animationBehaviorFactory)
    {
        return new SpriteIndexedAnimationFactory(image, basicColorArray, PrimitiveIntUtil.getArrayInstance(), width, height, dx, dy, animationBehaviorFactory);
    }

    // throws Exception
    public static SpriteIndexedAnimationFactory createCWH(Image image, BasicColor[] basicColorArray, int width, int height, AnimationBehaviorFactory animationBehaviorFactory)
    {
        SpriteIndexedAnimationFactory spriteIndexedAnimationFactory = new SpriteIndexedAnimationFactory(image, basicColorArray, PrimitiveIntUtil.getArrayInstance(), width, height, 0, 0, animationBehaviorFactory);
        spriteIndexedAnimationFactory.initHWH();
        return spriteIndexedAnimationFactory;
    }

    // throws Exception
    public static SpriteIndexedAnimationFactory createWH(Image image, int width, int height, AnimationBehaviorFactory animationBehaviorFactory)
    {
        return new SpriteIndexedAnimationFactory(image, BasicColorUtil.getInstance().ZERO_ARRAY, PrimitiveIntUtil.getArrayInstance(), width, height, 0, 0, animationBehaviorFactory);
    }

    private readonly AnimationFactorySpriteScaleUtil animationFactorySpriteScaleUtil = AnimationFactorySpriteScaleUtil.getInstance();
    private BasicColor[] basicColorArray = BasicColorUtil.getInstance().ZERO_ARRAY;
    private SpriteIndexedAnimationFactory(Image image, BasicColor[] basicColorArray, int[] sequenceArray, int width, int height, int dx, int dy, AnimationBehaviorFactory animationBehaviorFactory) : base(image, sequenceArray, width, height, dx, dy, animationBehaviorFactory)
    {
        // base(image, sequenceArray, width, height, dx, dy, animationBehaviorFactory) is called from the constructor declaration
        this.basicColorArray = basicColorArray;
    }

    private void initHWH()
    {
        this.animationFactoryInitializationVisitor.dx = -(this.animationFactoryInitializationVisitor.width >> 2);
        this.animationFactoryInitializationVisitor.dy = -(this.animationFactoryInitializationVisitor.height >> 2);
        if (AndroidUtil.isAndroid()) {
            this.animationFactoryInitializationVisitor.dx += 3;
        }
    }

    // throws Exception
    public override Animation getInstance(int instanceId)
    {
        Sprite sprite = this.animationFactorySpriteScaleUtil.createImage(this.getImage(), this.animationFactoryInitializationVisitor.width, this.animationFactoryInitializationVisitor.height, this.scaleProperties.scaleWidth, this.scaleProperties.scaleHeight);
        if (this.animationFactoryInitializationVisitor.dx != 0 || this.animationFactoryInitializationVisitor.dy != 0) {
            return new AdjustedSpriteIndexedAnimation(sprite, this.getImage(), this.basicColorArray, this.animationFactoryInitializationVisitor.dx, this.animationFactoryInitializationVisitor.dy, this.animationBehaviorFactory.getOrCreateInstance());
        } else {
            return new SpriteIndexedAnimation(sprite, this.getImage(), this.basicColorArray, this.animationBehaviorFactory.getOrCreateInstance());
        }
    }

    // throws Exception
    public override Animation getInstanceAnimation(Animation animationInterface)
    {
        return this.getInstance(0);
    }

}

