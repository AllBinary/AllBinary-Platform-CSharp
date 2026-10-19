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
using AnimationBehavior = org.allbinary.animation.AnimationBehavior;
using IndexedAnimation = org.allbinary.animation.IndexedAnimation;
using IndexedAnimationBehavior = org.allbinary.animation.IndexedAnimationBehavior;

namespace org.allbinary.animation.special;

public class SpecialAnimation : IndexedAnimation, SpecialAnimationInterface
{
    private static readonly SpecialAnimation NULL_SPECIAL_ANIMATION = new SpecialAnimation(new IndexedAnimationBehavior(1, 250));
    public static SpecialAnimation getInstance()
    {
        return SpecialAnimation.NULL_SPECIAL_ANIMATION;
    }

    public SpecialAnimation(AnimationBehavior animationBehavior) : base(animationBehavior)
    {
        // base(animationBehavior) is called from the constructor declaration
    }

    public override void nextFrame()
    {
        IndexedAnimationBehavior indexedAnimationBehavior = (((IndexedAnimationBehavior) this.animationBehaviorP));
        indexedAnimationBehavior.loopIndex++;
    }

    public override void setLastFrame()
    {
    }

    public override bool isComplete()
    {
        return false;
    }

    public virtual void open()
    {
    }

    public virtual void close()
    {
    }

    public virtual void process()
    {
    }

}

