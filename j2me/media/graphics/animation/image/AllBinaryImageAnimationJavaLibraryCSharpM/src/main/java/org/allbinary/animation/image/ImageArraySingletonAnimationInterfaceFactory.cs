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
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using SingletonAnimationInterfaceFactory = org.allbinary.animation.SingletonAnimationInterfaceFactory;
using IndexedAnimationToImageArrayUtil = org.allbinary.image.IndexedAnimationToImageArrayUtil;

namespace org.allbinary.animation.image;

public class ImageArraySingletonAnimationInterfaceFactory : SingletonAnimationInterfaceFactory
{
    public ImageArraySingletonAnimationInterfaceFactory(Image[] imageArray) : base(new ImageArrayAnimation(imageArray, AnimationBehavior.getInstance()))
    {
        // base(new ImageArrayAnimation(imageArray, AnimationBehavior.getInstance())) is called from the constructor declaration
    }

}

