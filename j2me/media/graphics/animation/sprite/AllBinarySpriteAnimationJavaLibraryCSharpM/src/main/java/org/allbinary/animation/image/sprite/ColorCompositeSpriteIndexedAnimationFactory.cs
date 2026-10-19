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
using BasicColor = org.allbinary.graphics.color.BasicColor;
using AnimationFactorySpriteScaleUtil = org.allbinary.image.sprite.AnimationFactorySpriteScaleUtil;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;

namespace org.allbinary.animation.image.sprite;

public class ColorCompositeSpriteIndexedAnimationFactory : BaseImageAnimationFactory, ProceduralAnimationInterfaceFactoryInterface
{
    private readonly AnimationFactorySpriteScaleUtil animationFactorySpriteScaleUtil = AnimationFactorySpriteScaleUtil.getInstance();
    private readonly BasicColor[] basicColorArray;
    public ColorCompositeSpriteIndexedAnimationFactory(Image image, BasicColor[] basicColorArray, int width, int height, AnimationBehaviorFactory animationBehaviorFactory) : base(image, PrimitiveIntUtil.getArrayInstance(), width, height, 0, 0, animationBehaviorFactory)
    {
        // base(image, PrimitiveIntUtil.getArrayInstance(), width, height, 0, 0, animationBehaviorFactory) is called from the constructor declaration
        this.basicColorArray = basicColorArray;
    }

    // throws Exception
    public override Animation getInstance(int instanceId)
    {
        Sprite sprite = this.animationFactorySpriteScaleUtil.createImage(this.getImage(), this.animationFactoryInitializationVisitor.width, this.animationFactoryInitializationVisitor.height, this.scaleProperties.scaleWidth, this.scaleProperties.scaleHeight);
        return new SpriteIndexedAnimation(sprite, this.getImage(), this.basicColorArray, this.animationBehaviorFactory.getOrCreateInstance());
    }

    // throws Exception
    public override Animation getInstanceAnimation(Animation animationInterface)
    {
        return this.getInstance(0);
    }

}

