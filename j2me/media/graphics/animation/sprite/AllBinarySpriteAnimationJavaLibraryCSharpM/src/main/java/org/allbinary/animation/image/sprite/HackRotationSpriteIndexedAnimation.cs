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
//using Sprite = javax.microedition.lcdui.game.Sprite;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using RotationAnimation = org.allbinary.animation.RotationAnimation;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using AngleInfo = org.allbinary.math.AngleInfo;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.animation.image.sprite;

public class HackRotationSpriteIndexedAnimation : RotationAnimation
{
    public readonly Sprite sprite;
    private readonly Image image;
    public HackRotationSpriteIndexedAnimation(Sprite sprite, Image image, AngleInfo angleInfo, AnimationBehavior animationBehavior) : base(angleInfo, CircularIndexUtil.createInstance(360 / angleInfo.getAngleIncrementInfo().getAngleIncrement()), animationBehavior)
    {
        // base(angleInfo, CircularIndexUtil.createInstance(360 / angleInfo.getAngleIncrementInfo().getAngleIncrement()), animationBehavior) is called from the constructor declaration
        this.sprite = sprite;
        this.image = image;
    }

    // throws Exception
    public override int getAnimationSize()
    {
        return this.getSize();
    }

    public virtual void paintFrame(Graphics g, int frame, int x, int y)
    {
        this.setFrame(frame);
        this.paintXY(g, x, y);
    }

    public override void paintXY(Graphics g, int x, int y)
    {
        this.sprite.setPosition(x, y);
        this.paint(g);
    }

    public virtual void paint(Graphics g)
    {
        this.sprite.paint(g);
    }

    public override void nextRotation()
    {
        this.sprite.nextFrame();
    }

    public override void previousRotation()
    {
        this.sprite.prevFrame();
    }

    public override int getSize()
    {
        return this.sprite.getRawFrameCount();
    }

    public override void setFrame(int frame)
    {
        this.sprite.setFrame(frame);
    }

    public override int getFrame()
    {
        return this.sprite.getFrame();
    }

    public override void setSequence(int[] sequence)
    {
    }

    public override int[] getSequence()
    {
        return PrimitiveIntUtil.getArrayInstance();
    }

}

