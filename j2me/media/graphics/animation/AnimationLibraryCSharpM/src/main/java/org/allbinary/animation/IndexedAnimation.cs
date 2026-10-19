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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.animation;

public class IndexedAnimation : Animation, IndexedAnimationInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly AnimationBehavior animationBehaviorP;
    protected IndexedAnimation(AnimationBehavior animationBehavior)
    {
        this.animationBehaviorP = animationBehavior;
    }

    public virtual AnimationBehavior getAnimationBehavior()
    {
        return this.animationBehaviorP;
    }

    public override void reset()
    {
        this.animationBehaviorP.reset();
        this.setFrame(0);
    }

    public override void setFrame(int index)
    {
    }

    public override int getFrame()
    {
        return 0;
    }

    // throws Exception
    public virtual int getAnimationSize()
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    public override int getSize()
    {
        return 0;
    }

    public override void previousFrame()
    {
    }

    public virtual bool isLastFrame()
    {
        if (this.getFrame() == this.getSize() - 1) {
            return true;
        } else {
            return false;
        }
    }

    public override void setSequence(int[] sequence)
    {
    }

    public override int[] getSequence()
    {
        return PrimitiveIntUtil.getArrayInstance();
    }

    public virtual void setState(IndexedAnimation indexedAnimation)
    {
        this.setFrame(indexedAnimation.getFrame());
        this.setDx(indexedAnimation.getDx());
        this.setDy(indexedAnimation.getDy());
    }

    public virtual int getWidth()
    {
        return 0;
    }

    public virtual int getHeight()
    {
        return 0;
    }

}

