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
using Animation = org.allbinary.animation.Animation;
using AnimationBehaviorFactory = org.allbinary.animation.AnimationBehaviorFactory;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;

namespace org.allbinary.animation.image;

public class BottomToTopImageAnimationFactory : BaseImageAnimationFactory
{
    public BottomToTopImageAnimationFactory(Image image, AnimationBehaviorFactory animationBehaviorFactory) : base(image, PrimitiveIntUtil.getArrayInstance(), image.getWidth(), image.getHeight(), 0, 0, animationBehaviorFactory)
    {
        // base(image, PrimitiveIntUtil.getArrayInstance(), image.getWidth(), image.getHeight(), 0, 0, animationBehaviorFactory) is called from the constructor declaration
    }

    // throws Exception
    public override Animation getInstance(int instanceId)
    {
        Image scaledImage = this.animationFactoryImageScaleUtil.createImage(this.getImage(), this.animationFactoryInitializationVisitor.width, this.animationFactoryInitializationVisitor.height, this.scaleProperties.scaleWidth, this.scaleProperties.scaleHeight);
        return new BottomToTopImageAnimation(scaledImage, this.animationBehaviorFactory.getOrCreateInstance());
    }

}

