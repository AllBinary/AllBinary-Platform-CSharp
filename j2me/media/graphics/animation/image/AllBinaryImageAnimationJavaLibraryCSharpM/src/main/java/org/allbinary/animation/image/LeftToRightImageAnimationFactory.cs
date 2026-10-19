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

namespace org.allbinary.animation.image;

public class LeftToRightImageAnimationFactory : BaseImageAnimationFactory
{
    public LeftToRightImageAnimationFactory(Image image, int[] sequenceArray, int dx, int dy, AnimationBehaviorFactory animationBehaviorFactory) : base(image, sequenceArray, image.getWidth(), image.getHeight(), dx, dy, animationBehaviorFactory)
    {
        // base(image, sequenceArray, image.getWidth(), image.getHeight(), dx, dy, animationBehaviorFactory) is called from the constructor declaration
    }

    // throws Exception
    public override Animation getInstance(int instanceId)
    {
        Image scaledImage = this.animationFactoryImageScaleUtil.createImage(this.getImage(), this.animationFactoryInitializationVisitor.width, this.animationFactoryInitializationVisitor.height, this.scaleProperties.scaleWidth, this.scaleProperties.scaleHeight);
        if (this.animationFactoryInitializationVisitor.dx != 0 || this.animationFactoryInitializationVisitor.dy != 0) {
            this.animationFactoryImageScaleUtil.processAdjust(this);
            return new AdjustedLeftToRightImageAnimation(scaledImage, this.getSequenceArray(), this.animationFactoryInitializationVisitor.dx, this.animationFactoryInitializationVisitor.dy, this.animationBehaviorFactory.getOrCreateInstance());
        } else {
            return new LeftToRightImageAnimation(scaledImage, this.getSequenceArray(), this.animationBehaviorFactory.getOrCreateInstance());
        }
    }

}

