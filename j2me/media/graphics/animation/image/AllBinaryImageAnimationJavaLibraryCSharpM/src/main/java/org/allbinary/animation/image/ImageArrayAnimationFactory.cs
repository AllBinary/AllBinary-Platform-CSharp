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
using AnimationBehaviorFactory = org.allbinary.animation.AnimationBehaviorFactory;
using AnimationInterfaceFactoryInterface = org.allbinary.animation.AnimationInterfaceFactoryInterface;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using ScaleProperties = org.allbinary.media.ScaleProperties;

namespace org.allbinary.animation.image;

public class ImageArrayAnimationFactory : AnimationInterfaceFactoryInterface
{
    private int dx = 0;
    private int dy = 0;
    private readonly Image[] imageArray;
    private readonly AnimationBehaviorFactory animationBehaviorFactory;
    public ImageArrayAnimationFactory(Image[] imageArray, int dx, int dy, AnimationBehaviorFactory animationBehaviorFactory)
    {
        this.imageArray = imageArray;
        this.animationBehaviorFactory = animationBehaviorFactory;
        this.dx = dx;
        this.dy = dy;
    }

    // throws Exception
    public virtual Animation getInstance(int instanceId)
    {
        if (this.dx != 0 || this.dy != 0) {
            return new AdjustedImageArrayAnimation(this.imageArray, this.dx, this.dy, this.animationBehaviorFactory.getOrCreateInstance());
        } else {
            return new ImageArrayAnimation(this.imageArray, AnimationBehavior.getInstance());
        }
    }

    public virtual void setInitialScale(ScaleProperties scaleProperties)
    {
    }

}

