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
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using ColorCompositeInterface = org.allbinary.graphics.color.ColorCompositeInterface;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace org.allbinary.animation.image.sprite;

public class SpriteIndexedAnimation : IndexedAnimation, ColorCompositeInterface
{
    public readonly Sprite sprite;
    public readonly Image image;
    private readonly BasicColor[] basicColorArray;
    public SpriteIndexedAnimation(Sprite sprite, Image image, BasicColor[] basicColorArray, AnimationBehavior animationBehavior) : base(animationBehavior)
    {
        // base(animationBehavior) is called from the constructor declaration
        this.sprite = sprite;
        this.image = image;
        this.basicColorArray = basicColorArray;
        if (this.basicColorArray.Length != 0 && this.getSize() != this.basicColorArray.Length) {
            throw new Exception(new StringMaker().append(CommonLabels.getInstance().TOTAL_LABEL).appendint(this.getSize()).append("!=").appendint(this.basicColorArray.Length).ToString());
        }
    }

    // throws Exception
    public override int getAnimationSize()
    {
        return this.getSize();
    }

    public override void setBasicColorP(BasicColor basicColor)
    {
        for (int index = 0; index < this.basicColorArray.Length; index++) {
            if (basicColor == this.basicColorArray[index]) {
                this.setFrame(index);
                break;
            }
        }
    }

    public override BasicColor getBasicColorP()
    {
        if (this.basicColorArray.Length < this.getFrame()) {
            return this.basicColorArray[this.getFrame()];
        } else {
            return BasicColorFactory.getInstance().WHITE;
        }
    }

    public virtual void paintFrame(Graphics graphics, int frame, int x, int y)
    {
        this.setFrame(frame);
        this.sprite.setPosition(x, y);
        this.sprite.paint(graphics);
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.sprite.setPosition(x, y);
        this.sprite.paint(graphics);
    }

    protected virtual void paint(Graphics graphics)
    {
        this.sprite.paint(graphics);
    }

    public override void nextFrame()
    {
        this.sprite.nextFrame();
    }

    public override void previousFrame()
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

    public override bool isLastFrame()
    {
        if (this.sprite.getFrame() == this.getSize() - 1) {
            return true;
        } else {
            return false;
        }
    }

    public virtual int getLastFrame()
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

    // throws Exception
    public virtual void close()
    {
    }

    // throws Throwable
    protected override void finalize()
    {
    }

}

