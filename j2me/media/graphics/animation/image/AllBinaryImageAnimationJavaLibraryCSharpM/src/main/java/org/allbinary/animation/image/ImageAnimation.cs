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

namespace org.allbinary.animation.image;

public class ImageAnimation : IndexedAnimation
{
    private readonly Image image;
    public ImageAnimation(Image image, AnimationBehavior animationBehavior) : base(animationBehavior)
    {
        // base(animationBehavior) is called from the constructor declaration
        this.image = image;
    }

    // throws Exception
    public override int getAnimationSize()
    {
        return this.getSize();
    }

    public override void nextFrame()
    {
    }

    public override void previousFrame()
    {
    }

    public override void setFrame(int index)
    {
    }

    public override int getFrame()
    {
        return 0;
    }

    public override int getSize()
    {
        return 1;
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
        graphics.drawImage(this.image, x, y, this.anchor);
    }

    protected virtual Image getImage()
    {
        return this.image;
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

