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
using AnimationInterfaceFactoryInterface = org.allbinary.animation.AnimationInterfaceFactoryInterface;
using GameConfigurationCentral = org.allbinary.game.configuration.GameConfigurationCentral;
using NullUtil = org.allbinary.logic.NullUtil;
using AngleFactory = org.allbinary.math.AngleFactory;
using ScaleProperties = org.allbinary.media.ScaleProperties;
using ImageToRotationImageArrayUtil = org.allbinary.media.image.ImageToRotationImageArrayUtil;

namespace org.allbinary.animation.image;

//TWB - Adjustments should be done in the resource creation and not at the animation level
public class PooledImageArrayRotationAnimationFactory : AnimationInterfaceFactoryInterface
{
    // throws Exception
    public static PooledImageArrayRotationAnimationFactory createFactory(Image image, AnimationBehaviorFactory animationBehaviorFactory)
    {
        int totalAngle = ((int) AngleFactory.getInstance().TOTAL_ANGLE);
        int angleIncrement = (totalAngle / GameConfigurationCentral.getInstance().getGameControlFidelity());
        return new PooledImageArrayRotationAnimationFactory(image, image.getWidth(), image.getHeight(), -(image.getWidth() >> 2), -(image.getHeight() >> 2), angleIncrement, animationBehaviorFactory);
    }

    // throws Exception
    public static PooledImageArrayRotationAnimationFactory createDXY(Image image, int dx, int dy, AnimationBehaviorFactory animationBehaviorFactory)
    {
        int totalAngle = ((int) AngleFactory.getInstance().TOTAL_ANGLE);
        int angleIncrement = (totalAngle / GameConfigurationCentral.getInstance().getGameControlFidelity());
        return new PooledImageArrayRotationAnimationFactory(image, image.getWidth(), image.getHeight(), dx, dy, angleIncrement, animationBehaviorFactory);
    }

    private object allBinaryImageRotationAnimationInfo = NullUtil.getInstance().NULL_OBJECT;
    private readonly AnimationBehaviorFactory animationBehaviorFactory;
    public PooledImageArrayRotationAnimationFactory(Image image, int width, int height, int dx, int dy, int angleIncrement, AnimationBehaviorFactory animationBehaviorFactory)
    {
        this.animationBehaviorFactory = animationBehaviorFactory;
        int totalAngle = ((int) AngleFactory.getInstance().TOTAL_ANGLE);
        Image[] imageArray = ImageToRotationImageArrayUtil.getInstance().generate(image, angleIncrement, totalAngle);
        this.allBinaryImageRotationAnimationInfo = new ImageArrayRotationAnimationInfo(imageArray, angleIncrement, totalAngle, dx, dy);
    }

    // throws Exception
    public virtual Animation getInstance(int instanceId)
    {
        return AdjustedImageArrayRotationAnimation.createAdjustedImageArrayRotationAnimationInfo(this.allBinaryImageRotationAnimationInfo, this.animationBehaviorFactory.getOrCreateInstance());
    }

    public virtual void setInitialScale(ScaleProperties scaleProperties)
    {
    }

}

