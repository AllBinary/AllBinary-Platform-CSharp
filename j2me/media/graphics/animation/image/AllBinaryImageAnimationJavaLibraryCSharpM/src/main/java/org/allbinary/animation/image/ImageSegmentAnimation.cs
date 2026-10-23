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
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.animation.image;

public class ImageSegmentAnimation : ImageAnimation
{
    private int startX;
    private int startY;
    private int drawWidth;
    private int drawHeight;
    private CircularIndexUtil circularIndexUtil;
    private int[] sequenceArray;
    public ImageSegmentAnimation(Image image, int[] sequenceArray, AnimationBehavior animationBehavior) : base(image, animationBehavior)
    {
        // base(image, animationBehavior) is called from the constructor declaration
        this.startX = 0;
        this.startY = 0;
        this.drawWidth = this.getImage().getWidth();
        this.drawHeight = this.getImage().getHeight();
        this.circularIndexUtil = CircularIndexUtil.createInstance(this.drawHeight);
        this.sequenceArray = sequenceArray;
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
        return this.circularIndexUtil.getSize();
    }

    public override void setSequence(int[] sequenceArray)
    {
        this.sequenceArray = sequenceArray;
    }

    public override int[] getSequence()
    {
        return this.sequenceArray;
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
    }

    public virtual int getStartX()
    {
        return this.startX;
    }

    public virtual void setStartX(int startX)
    {
        this.startX = startX;
    }

    public virtual int getStartY()
    {
        return this.startY;
    }

    public virtual void setStartY(int startY)
    {
        this.startY = startY;
    }

    public virtual int getDrawWidth()
    {
        return this.drawWidth;
    }

    public virtual void setDrawWidth(int drawWidth)
    {
        this.drawWidth = drawWidth;
    }

    public virtual int getDrawHeight()
    {
        return this.drawHeight;
    }

    public virtual void setDrawHeight(int drawHeight)
    {
        this.drawHeight = drawHeight;
    }

}

