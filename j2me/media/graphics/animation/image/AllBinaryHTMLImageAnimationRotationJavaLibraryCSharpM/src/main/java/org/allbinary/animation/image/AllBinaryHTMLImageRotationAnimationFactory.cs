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
using GameConfigurationCentral = org.allbinary.game.configuration.GameConfigurationCentral;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using ImageCopyUtil = org.allbinary.media.image.ImageCopyUtil;
using AngleFactory = org.allbinary.math.AngleFactory;
using AngleInfo = org.allbinary.math.AngleInfo;

namespace org.allbinary.animation.image;

public class AllBinaryHTMLImageRotationAnimationFactory : BaseImageAnimationFactory
{
    public readonly short angleIncrement;
    // throws Exception
    public static AllBinaryHTMLImageRotationAnimationFactory createFactoryADXY(Image image, int width, int height, int dx, int dy, short angleIncrement, AnimationBehaviorFactory animationBehaviorFactory)
    {
        AllBinaryHTMLImageRotationAnimationFactory htmlImageRotationAnimationFactory = new AllBinaryHTMLImageRotationAnimationFactory(image, width, height, angleIncrement, animationBehaviorFactory);
        htmlImageRotationAnimationFactory.init(dx, dy);
        return htmlImageRotationAnimationFactory;
    }

    public AllBinaryHTMLImageRotationAnimationFactory(Image image, int width, int height, short angleIncrement, AnimationBehaviorFactory animationBehaviorFactory) : base(image, PrimitiveIntUtil.getArrayInstance(), width, height, 0, 0, animationBehaviorFactory)
    {
        // base(image, PrimitiveIntUtil.getArrayInstance(), width, height, 0, 0, animationBehaviorFactory) is called from the constructor declaration
        this.angleIncrement = angleIncrement;
    }

    public virtual void init(int dx, int dy)
    {
        this.animationFactoryInitializationVisitor.dx = dx;
        this.animationFactoryInitializationVisitor.dy = dy;
        this.animationFactoryInitializationVisitor.originalDx = dx;
        this.animationFactoryInitializationVisitor.originalDy = dy;
    }

    // throws Exception
    public virtual Animation getInstance(int instanceId)
    {
        Image scaledImage = this.animationFactoryImageScaleUtil.createImage(this.getImage(), this.animationFactoryInitializationVisitor.width, this.animationFactoryInitializationVisitor.height, this.scaleProperties.scaleWidth, this.scaleProperties.scaleHeight);
        Image copyOfScaledImage = ImageCopyUtil.getInstance().createImage(scaledImage);
        if (this.animationFactoryInitializationVisitor.dx != 0 || this.animationFactoryInitializationVisitor.dy != 0) {
            this.animationFactoryImageScaleUtil.processAdjust(this);
            return new AllBinaryAdjustedHTMLImageRotationAnimation(scaledImage, copyOfScaledImage, AngleInfo.getInstance(this.getAngleIncrement()), AngleFactory.getInstance().TOTAL_ANGLE, this.animationFactoryInitializationVisitor.dx, this.animationFactoryInitializationVisitor.dy, this.animationBehaviorFactory.getOrCreateInstance());
        } else {
            return new AllBinaryHTMLImageRotationAnimation(scaledImage, copyOfScaledImage, AngleInfo.getInstance(this.angleIncrement), AngleFactory.getInstance().TOTAL_ANGLE, this.animationBehaviorFactory.getOrCreateInstance());
        }
    }

    protected virtual short getAngleIncrement()
    {
        return this.angleIncrement;
    }

}

