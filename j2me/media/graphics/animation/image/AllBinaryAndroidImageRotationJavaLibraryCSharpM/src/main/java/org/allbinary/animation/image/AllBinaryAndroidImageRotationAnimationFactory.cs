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
using Features = org.allbinary.game.configuration.feature.Features;
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using ImageCopyUtil = org.allbinary.media.image.ImageCopyUtil;
using AngleFactory = org.allbinary.math.AngleFactory;
using AngleInfo = org.allbinary.math.AngleInfo;

namespace org.allbinary.animation.image;

public class AllBinaryAndroidImageRotationAnimationFactory : BaseImageAnimationFactory
{
    // throws Exception
    public static AllBinaryAndroidImageRotationAnimationFactory createFactory(Image image, int width, int height, AnimationBehaviorFactory animationBehaviorFactory)
    {
        return new AllBinaryAndroidImageRotationAnimationFactory(image, width, height, ((short) (AngleFactory.getInstance().TOTAL_ANGLE / GameConfigurationCentral.getInstance().getGameControlFidelity())), animationBehaviorFactory, false);
    }

    // throws Exception
    public static AllBinaryAndroidImageRotationAnimationFactory createFactoryA(Image image, int width, int height, short angleIncrement, AnimationBehaviorFactory animationBehaviorFactory)
    {
        return new AllBinaryAndroidImageRotationAnimationFactory(image, width, height, angleIncrement, animationBehaviorFactory, false);
    }

    // throws Exception
    public static AllBinaryAndroidImageRotationAnimationFactory createFactoryU(Image image, AnimationBehaviorFactory animationBehaviorFactory)
    {
        AllBinaryAndroidImageRotationAnimationFactory androidImageRotationAnimationFactory = new AllBinaryAndroidImageRotationAnimationFactory(image, image.getWidth(), image.getHeight(), ((short) (AngleFactory.getInstance().TOTAL_ANGLE / GameConfigurationCentral.getInstance().getGameControlFidelity())), animationBehaviorFactory, false);
        androidImageRotationAnimationFactory.init(-(image.getWidth() >> 2), -(image.getHeight() >> 2));
        return androidImageRotationAnimationFactory;
    }

    // throws Exception
    public static AllBinaryAndroidImageRotationAnimationFactory createFactoryDXYU(Image image, int dx, int dy, AnimationBehaviorFactory animationBehaviorFactory)
    {
        AllBinaryAndroidImageRotationAnimationFactory androidImageRotationAnimationFactory = new AllBinaryAndroidImageRotationAnimationFactory(image, image.getWidth(), image.getHeight(), ((short) (AngleFactory.getInstance().TOTAL_ANGLE / GameConfigurationCentral.getInstance().getGameControlFidelity())), animationBehaviorFactory, false);
        androidImageRotationAnimationFactory.init(dx, dy);
        return androidImageRotationAnimationFactory;
    }

    // throws Exception
    public static AllBinaryAndroidImageRotationAnimationFactory createFactoryADXY(Image image, int width, int height, int dx, int dy, short angleIncrement, AnimationBehaviorFactory animationBehaviorFactory, bool resizeCanvasForRotation)
    {
        AllBinaryAndroidImageRotationAnimationFactory androidImageRotationAnimationFactory = new AllBinaryAndroidImageRotationAnimationFactory(image, width, height, angleIncrement, animationBehaviorFactory, resizeCanvasForRotation);
        androidImageRotationAnimationFactory.init(dx, dy);
        return androidImageRotationAnimationFactory;
    }

    public virtual void init(int dx, int dy)
    {
        this.animationFactoryInitializationVisitor.dx = dx;
        this.animationFactoryInitializationVisitor.dy = dy;
        this.animationFactoryInitializationVisitor.originalDx = dx;
        this.animationFactoryInitializationVisitor.originalDy = dy;
    }

    private readonly short angleIncrement;
    private readonly bool resizeCanvasForRotation;
    public AllBinaryAndroidImageRotationAnimationFactory(Image image, int width, int height, short angleIncrement, AnimationBehaviorFactory animationBehaviorFactory, bool resizeCanvasForRotation) : base(image, PrimitiveIntUtil.getArrayInstance(), width, height, 0, 0, animationBehaviorFactory)
    {
        // base(image, PrimitiveIntUtil.getArrayInstance(), width, height, 0, 0, animationBehaviorFactory) is called from the constructor declaration
        this.angleIncrement = angleIncrement;
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
        Image canvasImage = this.getCanvasImage();
        Image scaledImage = this.animationFactoryImageScaleUtil.createImage(canvasImage, this.animationFactoryInitializationVisitor.width, this.animationFactoryInitializationVisitor.height, this.scaleProperties.scaleWidth, this.scaleProperties.scaleHeight);
        Image copyOfScaledImage = ImageCopyUtil.getInstance().createImage(scaledImage);
        if (this.animationFactoryInitializationVisitor.dx != 0 || this.animationFactoryInitializationVisitor.dy != 0) {
            this.animationFactoryImageScaleUtil.processAdjust(this);
            return new AllBinaryAdjustedAndroidImageRotationAnimation(scaledImage, copyOfScaledImage, AngleInfo.getInstance(this.angleIncrement), AngleFactory.getInstance().TOTAL_ANGLE, this.animationFactoryInitializationVisitor.dx, this.animationFactoryInitializationVisitor.dy, animationBehaviorFactory.getOrCreateInstance());
        } else {
            return new AllBinaryFlickerAndroidImageRotationAnimation(scaledImage, copyOfScaledImage, AngleInfo.getInstance(this.angleIncrement), AngleFactory.getInstance().TOTAL_ANGLE, this.animationBehaviorFactory.getOrCreateInstance());
        }
    }

}

