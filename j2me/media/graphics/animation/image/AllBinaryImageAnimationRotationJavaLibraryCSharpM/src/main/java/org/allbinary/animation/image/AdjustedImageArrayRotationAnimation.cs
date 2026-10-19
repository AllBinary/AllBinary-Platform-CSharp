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
//using Graphics = javax.microedition.lcdui.Graphics;
//using Image = javax.microedition.lcdui.Image;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using AngleInfo = org.allbinary.math.AngleInfo;

namespace org.allbinary.animation.image;

//TWB - Adjustments should be done in the resource creation and not at the animation level
public class AdjustedImageArrayRotationAnimation : ImageArrayRotationAnimation
{
    // throws Exception
    public static AdjustedImageArrayRotationAnimation createAdjustedImageArrayRotationAnimationInfo(object anyType, AnimationBehavior animationBehavior)
    {
        ImageArrayRotationAnimationInfo imageRotationAnimationInfo = ((ImageArrayRotationAnimationInfo) anyType);
        return new AdjustedImageArrayRotationAnimation(imageRotationAnimationInfo.getImageArray(), imageRotationAnimationInfo.getAngleInfoP(), imageRotationAnimationInfo.getTotalAngle(), imageRotationAnimationInfo.getDx(), imageRotationAnimationInfo.getDy(), animationBehavior);
    }

    // throws Exception
    public static AdjustedImageArrayRotationAnimation createAnimation(Image[] imageArray, AngleInfo angleInfo, int totalAngle, AnimationBehavior animationBehavior)
    {
        return new AdjustedImageArrayRotationAnimation(imageArray, angleInfo, totalAngle, -(imageArray[0].getWidth() >> 2), -(imageArray[0].getHeight() >> 2), animationBehavior);
    }

    private int dx = 0;
    private int dy = 0;
    public AdjustedImageArrayRotationAnimation(Image[] imageArray, AngleInfo angleInfo, int totalAngle, int dx, int dy, AnimationBehavior animationBehavior) : base(imageArray, angleInfo, totalAngle, animationBehavior)
    {
        // base(imageArray, angleInfo, totalAngle, animationBehavior) is called from the constructor declaration
        this.init(dx, dy);
    }

    // throws Exception
    public virtual void init(int dx, int dy)
    {
        this.setDx(dx);
        this.setDy(dy);
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        base.paintXY(graphics, x + this.dx, y + this.dy);
    }

    public override void setDx(int dx)
    {
        this.dx = dx;
    }

    public override int getDx()
    {
        return this.dx;
    }

    public override void setDy(int dy)
    {
        this.dy = dy;
    }

    public override int getDy()
    {
        return this.dy;
    }

}

