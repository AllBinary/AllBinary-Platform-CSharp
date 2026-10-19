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
using SpecialAnimationInterface = org.allbinary.animation.special.SpecialAnimationInterface;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.animation.image;

public class ImageArraySpecialAnimation : ImageArrayAnimation, SpecialAnimationInterface
{
    private readonly TimeDelayHelper timeDelayHelper = new TimeDelayHelper(270);
    public ImageArraySpecialAnimation(Image[] imageArray, AnimationBehavior animationBehavior) : base(imageArray, animationBehavior)
    {
        // base(imageArray, animationBehavior) is called from the constructor declaration
        this.reset();
    }

    private int loopCount = 0;
    public virtual int getLoopCount()
    {
        return this.loopCount;
    }

    public override void setLastFrame()
    {
        this.circularIndexUtil.setIndex(this.circularIndexUtil.getSize() - 1);
    }

    public override void reset()
    {
        this.setFrame(this.getSize() - 1);
        this.loopCount = 0;
    }

    public override void nextFrame()
    {
        if (this.getFrame() > 0) {
            if (this.timeDelayHelper.isTime(GameTickTimeDelayHelperFactory.getInstance().startTime)) {
                this.previousFrame();
                if (this.getFrame() == 0) {
                    this.loopCount++;
                }
            }
        }
    }

    private readonly int loopCountTotal = 1;
    public override bool isComplete()
    {
        if (this.loopCount < this.loopCountTotal || this.getFrame() != 0) {
            return false;
        } else {
            return true;
        }
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        x = DisplayInfoSingleton.getInstance().getLastHalfWidth() - (this.getImage(this.circularIndexUtil.getIndex()).getWidth() >> 1);
        y = 5;
        base.paintXY(graphics, x, y);
    }

}

