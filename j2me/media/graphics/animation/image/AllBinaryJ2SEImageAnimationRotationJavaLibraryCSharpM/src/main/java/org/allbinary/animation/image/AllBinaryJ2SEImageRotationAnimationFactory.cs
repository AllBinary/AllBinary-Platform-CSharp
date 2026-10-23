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
using Features = org.allbinary.game.configuration.feature.Features;
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using OpenGLUtil = org.allbinary.graphics.opengles.OpenGLUtil;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using AngleFactory = org.allbinary.math.AngleFactory;
using AngleInfo = org.allbinary.math.AngleInfo;
using ImageCopyUtil = org.allbinary.media.image.ImageCopyUtil;

namespace org.allbinary.animation.image;

public class AllBinaryJ2SEImageRotationAnimationFactory : BaseImageAnimationFactory
{
    public readonly short angleIncrementP;
    private readonly bool resizeCanvasForRotation;
    // throws Exception
    public static AllBinaryJ2SEImageRotationAnimationFactory createDXY(Image image, int width, int height, int dx, int dy, short angleIncrement, AnimationBehaviorFactory animationBehaviorFactory, bool resizeCanvasForRotation)
    {
        AllBinaryJ2SEImageRotationAnimationFactory imageRotationAnimationFactory = new AllBinaryJ2SEImageRotationAnimationFactory(image, width, height, angleIncrement, animationBehaviorFactory, resizeCanvasForRotation);
        imageRotationAnimationFactory.animationFactoryInitializationVisitor.dx = dx;
        imageRotationAnimationFactory.animationFactoryInitializationVisitor.dy = dy;
        imageRotationAnimationFactory.animationFactoryInitializationVisitor.originalDx = dx;
        imageRotationAnimationFactory.animationFactoryInitializationVisitor.originalDy = dy;
        return imageRotationAnimationFactory;
    }

    public AllBinaryJ2SEImageRotationAnimationFactory(Image image, int width, int height, short angleIncrement, AnimationBehaviorFactory animationBehaviorFactory, bool resizeCanvasForRotation) : base(image, PrimitiveIntUtil.getArrayInstance(), width, height, 0, 0, animationBehaviorFactory)
    {
        // base(image, PrimitiveIntUtil.getArrayInstance(), width, height, 0, 0, animationBehaviorFactory) is called from the constructor declaration
        this.angleIncrementP = angleIncrement;
        this.resizeCanvasForRotation = resizeCanvasForRotation;
    }

    // throws Exception
    private Image getCanvasImage()
    {
        Features features = Features.getInstance();
        if (this.resizeCanvasForRotation && !features.isDefault(OpenGLFeatureFactory.getInstance().OPENGL)) {
            return ImageCopyUtil.getInstance().createImageScale(this.getImage(), 1.44f, false);
        } else {
            return this.getImage();
        }
    }

    // throws Exception
    public override Animation getInstance(int instanceId)
    {
        ImageCopyUtil imageCopyUtil = ImageCopyUtil.getInstance();
        Image canvasImage = this.getCanvasImage();
        Image scaledImage = this.animationFactoryImageScaleUtil.createImage(canvasImage, this.animationFactoryInitializationVisitor.width, this.animationFactoryInitializationVisitor.height, this.scaleProperties.scaleWidth, this.scaleProperties.scaleHeight);
        OpenGLUtil openGLUtil = OpenGLUtil.getInstance();
        scaledImage = openGLUtil.addImage(scaledImage);
        Image copyOfScaledImage = imageCopyUtil.createImageForRotation(scaledImage);
        if (this.animationFactoryInitializationVisitor.dx != 0 || this.animationFactoryInitializationVisitor.dy != 0) {
            this.animationFactoryImageScaleUtil.processAdjust(this);
            return new AllBinaryAdjustedJ2SEImageRotationAnimation(scaledImage, copyOfScaledImage, AngleInfo.getInstance(this.angleIncrementP), AngleFactory.getInstance().TOTAL_ANGLE, this.animationFactoryInitializationVisitor.dx, this.animationFactoryInitializationVisitor.dy, this.animationBehaviorFactory.getOrCreateInstance());
        } else {
            return new AllBinaryJ2SEImageRotationAnimation(scaledImage, copyOfScaledImage, AngleInfo.getInstance(this.angleIncrementP), AngleFactory.getInstance().TOTAL_ANGLE, this.animationBehaviorFactory.getOrCreateInstance());
        }
    }

    public virtual short getAngleIncrement()
    {
        return this.angleIncrementP;
    }

}

