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
using DisposalUtil = org.allbinary.DisposalUtil;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using RotationAnimation = org.allbinary.animation.RotationAnimation;
using Anchor = org.allbinary.graphics.Anchor;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using AngleInfo = org.allbinary.math.AngleInfo;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.animation.image;

public class ImageBaseRotationAnimation : RotationAnimation
{
    private readonly Image image;
    public ImageBaseRotationAnimation(Image image, AngleInfo angleInfo, short totalAngle, AnimationBehavior animationBehavior) : base(angleInfo, CircularIndexUtil.createInstance(totalAngle / angleInfo.getAngleIncrementInfo().getAngleIncrement()), animationBehavior)
    {
        // base(angleInfo, CircularIndexUtil.createInstance(totalAngle / angleInfo.getAngleIncrementInfo().getAngleIncrement()), animationBehavior) is called from the constructor declaration
        this.image = image;
    }

    // throws Exception
    public override int getAnimationSize()
    {
        return this.getSize();
    }

    public override void setSequence(int[] sequence)
    {
    }

    public override int[] getSequence()
    {
        return PrimitiveIntUtil.getArrayInstance();
    }

    public int anchor = Anchor.TOP_LEFT;
    public override void paintXY(Graphics graphics, int x, int y)
    {
        graphics.drawImage(this.image, x, y, this.anchor);
    }

    protected virtual Image getImage()
    {
        return this.image;
    }

    public override int getWidth()
    {
        return this.image.getWidth();
    }

    public override int getHeight()
    {
        return this.image.getHeight();
    }

    // throws Exception
    public virtual void close()
    {
        DisposalUtil.getInstance().disposeImage(this.image);
    }

    // throws Throwable
    protected override void finalize()
    {
        DisposalUtil.getInstance().disposeImage(this.image);
    }

}

