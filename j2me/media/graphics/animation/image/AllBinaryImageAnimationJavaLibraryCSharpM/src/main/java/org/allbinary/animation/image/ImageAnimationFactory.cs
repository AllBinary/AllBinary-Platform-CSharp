/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using OpenGLUtil = org.allbinary.graphics.opengles.OpenGLUtil;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;

namespace org.allbinary.animation.image;

public class ImageAnimationFactory : BaseImageAnimationFactory
{
    // throws Exception
    public static ImageAnimationFactory createFactory(Image image)
    {
        return new ImageAnimationFactory(image, image.getWidth(), image.getHeight(), 0, 0, AnimationBehaviorFactory.getInstance());
    }

    public ImageAnimationFactory(Image image, int width, int height, int dx, int dy, AnimationBehaviorFactory animationBehaviorFactory) : base(image, PrimitiveIntUtil.getArrayInstance(), width, height, dx, dy, animationBehaviorFactory)
    {
        // base(image, PrimitiveIntUtil.getArrayInstance(), width, height, dx, dy, animationBehaviorFactory) is called from the constructor declaration
    }

    // throws Exception
    public override Animation getInstance(int instanceId)
    {
        Image scaledImage = this.animationFactoryImageScaleUtil.createImage(this.getImage(), this.animationFactoryInitializationVisitor.width, this.animationFactoryInitializationVisitor.height, this.scaleProperties.scaleWidth, this.scaleProperties.scaleHeight);
        OpenGLUtil openGLUtil = OpenGLUtil.getInstance();
        scaledImage = openGLUtil.addImage(scaledImage);
        if (this.animationFactoryInitializationVisitor.dx != 0 || this.animationFactoryInitializationVisitor.dy != 0) {
            this.animationFactoryImageScaleUtil.processAdjust(this);
            return new AdjustedImageAnimation(scaledImage, this.animationFactoryInitializationVisitor.dx, this.animationFactoryInitializationVisitor.dy, this.animationBehaviorFactory.getOrCreateInstance());
        } else {
            return new ImageAnimation(scaledImage, this.animationBehaviorFactory.getOrCreateInstance());
        }
    }

}

