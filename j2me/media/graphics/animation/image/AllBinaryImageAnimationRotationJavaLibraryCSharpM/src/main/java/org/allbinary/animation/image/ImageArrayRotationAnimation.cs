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
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using AngleInfo = org.allbinary.math.AngleInfo;

namespace org.allbinary.animation.image;

public class ImageArrayRotationAnimation : ImageArrayBaseRotationAnimation
{
    // throws Exception
    protected static ImageArrayRotationAnimation createAnimation(object anyType, AnimationBehavior animationBehavior)
    {
        ImageArrayRotationAnimationInfo imageRotationAnimationInfo = ((ImageArrayRotationAnimationInfo) anyType);
        return new ImageArrayRotationAnimation(imageRotationAnimationInfo.getImageArray(), imageRotationAnimationInfo.getAngleInfoP(), imageRotationAnimationInfo.getTotalAngle(), animationBehavior);
    }

    private int expectedTotalFrames = 0;
    public ImageArrayRotationAnimation(Image[] imageArray, AngleInfo angleInfo, int totalAngle, AnimationBehavior animationBehavior) : base(imageArray, angleInfo, animationBehavior)
    {
        // base(imageArray, angleInfo, animationBehavior) is called from the constructor declaration
        this.init(imageArray, angleInfo, totalAngle);
    }

    // throws Exception
    private void init(Image[] imageArray, AngleInfo angleInfo, int totalAngle)
    {
        this.expectedTotalFrames = totalAngle / this.angleInfo.getAngleIncrementInfo().getAngleIncrement();
        this.angleInfo.adjustAngle(0);
        if (this.expectedTotalFrames != this.getSize()) {
            throw new Exception("Wrong Number of Frames");
        }
    }

    public override void setImageArray(Image[] imageArray)
    {
        base.setImageArray(imageArray);
        this.angleInfo.adjustAngle(0);
    }

}

