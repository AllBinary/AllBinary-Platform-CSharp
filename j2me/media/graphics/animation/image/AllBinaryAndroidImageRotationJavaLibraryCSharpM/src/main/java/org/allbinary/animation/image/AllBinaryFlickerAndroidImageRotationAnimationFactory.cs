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
//using NullImage = javax.microedition.lcdui.NullImage;
using Animation = org.allbinary.animation.Animation;
using AnimationBehaviorFactory = org.allbinary.animation.AnimationBehaviorFactory;
using AnimationInterfaceFactoryInterface = org.allbinary.animation.AnimationInterfaceFactoryInterface;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using ImageCopyUtil = org.allbinary.media.image.ImageCopyUtil;
using AngleFactory = org.allbinary.math.AngleFactory;
using AngleInfo = org.allbinary.math.AngleInfo;
using ScaleProperties = org.allbinary.media.ScaleProperties;

namespace org.allbinary.animation.image;

public class AllBinaryFlickerAndroidImageRotationAnimationFactory : AnimationInterfaceFactoryInterface
{
    private Image image = NullImage.NULL_IMAGE;
    private readonly short angleIncrement;
    public readonly AnimationBehaviorFactory animationBehaviorFactory;
    public AllBinaryFlickerAndroidImageRotationAnimationFactory(Image image, int width, int height, short angleIncrement, AnimationBehaviorFactory animationBehaviorFactory)
    {
        this.setImage(image);
        this.angleIncrement = angleIncrement;
        this.animationBehaviorFactory = animationBehaviorFactory;
    }

    // throws Exception
    public virtual Animation getInstance(int instanceId)
    {
        Image image = ImageCopyUtil.getInstance().createImage(this.getImage());
        return new AllBinaryFlickerAndroidImageRotationAnimation(this.getImage(), image, AngleInfo.getInstance(this.angleIncrement), AngleFactory.getInstance().TOTAL_ANGLE, this.animationBehaviorFactory.getOrCreateInstance());
    }

    protected virtual short getAngleIncrement()
    {
        return this.angleIncrement;
    }

    protected virtual void setImage(Image image)
    {
        this.image = image;
    }

    protected virtual Image getImage()
    {
        return this.image;
    }

    public virtual void setInitialScale(ScaleProperties scaleProperties)
    {
    }

}

