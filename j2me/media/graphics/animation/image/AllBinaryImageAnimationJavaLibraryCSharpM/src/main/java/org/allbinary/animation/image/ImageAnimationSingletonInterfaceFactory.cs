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
using Animation = org.allbinary.animation.Animation;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using SingletonAnimationInterfaceFactory = org.allbinary.animation.SingletonAnimationInterfaceFactory;
using AnimationFrameToImageUtil = org.allbinary.image.AnimationFrameToImageUtil;

namespace org.allbinary.animation.image;

public class ImageAnimationSingletonInterfaceFactory : SingletonAnimationInterfaceFactory
{
    public ImageAnimationSingletonInterfaceFactory(Animation animationInterface, int width, int height) : base(new ImageAnimation(AnimationFrameToImageUtil.getInstance().getInstanceWH(width, height, animationInterface), AnimationBehavior.getInstance()))
    {
        // base(new ImageAnimation(AnimationFrameToImageUtil.getInstance().getInstanceWH(width, height, animationInterface), AnimationBehavior.getInstance())) is called from the constructor declaration
    }

}

