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
//using NullImage = javax.microedition.lcdui.NullImage;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using Anchor = org.allbinary.graphics.Anchor;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.animation.image;

public class ImageArrayAnimation : IndexedAnimation
{
    private Image[] imageArray = NullImage.NULL_IMAGE_ARRAY;
    private int totalFrames = 0;
    public CircularIndexUtil circularIndexUtil = CircularIndexUtil.NULL_CIRCULAR_INDEX_UTIL;
    public ImageArrayAnimation(Image[] imageArray, AnimationBehavior animationBehavior) : base(animationBehavior)
    {
        // base(animationBehavior) is called from the constructor declaration
        this.setImageArray(imageArray);
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

    public virtual Image getImage(int index)
    {
        return this.imageArray[index];
    }

    public virtual Image[] getImageArray()
    {
        return this.imageArray;
    }

    protected virtual void setImageArray(Image[] imageArray)
    {
        this.imageArray = imageArray;
        this.totalFrames = imageArray.Length;
        this.circularIndexUtil = CircularIndexUtil.createInstance(this.totalFrames);
    }

    private int anchor = Anchor.TOP_LEFT;
    public override void paintXY(Graphics graphics, int x, int y)
    {
        graphics.drawImage(this.imageArray[this.circularIndexUtil.getIndex()], x, y, this.anchor);
    }

}

