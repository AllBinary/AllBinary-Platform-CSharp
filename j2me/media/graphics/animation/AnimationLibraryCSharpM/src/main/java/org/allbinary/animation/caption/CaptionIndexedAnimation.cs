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
//using Player = javax.microedition.media.Player;
using Animation = org.allbinary.animation.Animation;
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using AnimationEventHandler = org.allbinary.animation.AnimationEventHandler;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.animation.caption;

public class CaptionIndexedAnimation : IndexedAnimation
{
    private Animation animationInterface;
    private IndexedAnimation movieIndexedAnimationInterface;
    private int captionDx;
    private int captionDy;
    private int dx;
    private int dy;
    private int time;
    private AllBinaryEventObject END_EVENT;
    private TimeDelayHelper timeDelayHelper;
    private Player player;
    public CaptionIndexedAnimation(Animation animationInterface, IndexedAnimation movieIndexedAnimationInterface, Player player, int captionDx, int captionDy, int dx, int dy, int time, AnimationBehavior animationBehavior) : base(animationBehavior)
    {
        // base(animationBehavior) is called from the constructor declaration
        this.animationInterface = animationInterface;
        this.movieIndexedAnimationInterface = movieIndexedAnimationInterface;
        this.captionDx = captionDx;
        this.captionDy = captionDy;
        this.dx = dx;
        this.dy = dy;
        this.time = time;
        this.END_EVENT = new AllBinaryEventObject(this);
        int timePerFrame = this.time / this.getSize();
        this.timeDelayHelper = new TimeDelayHelper(timePerFrame);
        this.player = player;
        this.player.start();
    }

    // throws Exception
    public override void nextFrame()
    {
        if (this.timeDelayHelper.isTime(GameTickTimeDelayHelperFactory.getInstance().startTime)) {
            this.movieIndexedAnimationInterface.nextFrame();
        }
        if (this.isLastFrame()) {
            AnimationEventHandler.getInstance().fireEvent(this.END_EVENT);
        }
    }

    public override bool isLastFrame()
    {
        if (this.movieIndexedAnimationInterface.getFrame() == this.getSize() - 1) {
            return true;
        } else {
            return false;
        }
    }

    public override void previousFrame()
    {
        this.movieIndexedAnimationInterface.previousFrame();
    }

    public override void setFrame(int index)
    {
        this.movieIndexedAnimationInterface.setFrame(index);
    }

    public override int getFrame()
    {
        return this.movieIndexedAnimationInterface.getFrame();
    }

    public override int getSize()
    {
        return this.movieIndexedAnimationInterface.getSize();
    }

    public override void setSequence(int[] sequence)
    {
    }

    public override int[] getSequence()
    {
        return PrimitiveIntUtil.getArrayInstance();
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.animationInterface.paintXY(graphics, x + this.captionDx, y + this.captionDy);
        this.movieIndexedAnimationInterface.paintXY(graphics, x + this.captionDx + this.dx, y + this.captionDy + this.dy);
    }

    public override void paintThreedXYZ(Graphics graphics, int x, int y, int z)
    {
        this.animationInterface.paintThreedXYZ(graphics, x + this.captionDx, y + this.captionDy, z);
        this.movieIndexedAnimationInterface.paintThreedXYZ(graphics, x + this.captionDx + this.dx, y + this.captionDy + this.dy, z);
    }

}

