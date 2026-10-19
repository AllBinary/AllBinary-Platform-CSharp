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
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using Anchor = org.allbinary.graphics.Anchor;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.animation.image;

public class TweenedImageAnimation : IndexedAnimation
{
    private readonly Image image;
    private readonly int dx;
    private readonly int dy;
    private int totalFrames;
    public CircularIndexUtil circularIndexUtil;
    public TweenedImageAnimation(Image image, int dx, int dy, int totalFrames, AnimationBehavior animationBehavior) : base(animationBehavior)
    {
        // base(animationBehavior) is called from the constructor declaration
        this.image = image;
        this.dx = dx;
        this.dy = dy;
        this.totalFrames = totalFrames;
        this.circularIndexUtil = CircularIndexUtil.createInstance(this.totalFrames);
    }

    // throws Exception
    public override int getAnimationSize()
    {
        return this.getSize();
    }

    public override void nextFrame()
    {
        this.circularIndexUtil.next();
    }

    public override void previousFrame()
    {
        this.circularIndexUtil.previous();
    }

    public override void setFrame(int index)
    {
        this.circularIndexUtil.setIndex(index);
    }

    public override int getFrame()
    {
        return this.circularIndexUtil.getIndex();
    }

    public override int getSize()
    {
        return this.totalFrames;
    }

    public override void setSequence(int[] sequence)
    {
    }

    public override int[] getSequence()
    {
        return PrimitiveIntUtil.getArrayInstance();
    }

    private int anchor = Anchor.TOP_LEFT;
    public override void paintXY(Graphics graphics, int x, int y)
    {
        int frame = this.getFrame();
        int currentX = this.dx * frame;
        int currentY = this.dy * frame;
        graphics.drawImage(this.image, x + currentX, y + currentY, this.anchor);
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

