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
using NullUtil = org.allbinary.logic.NullUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CacheableInterface = org.allbinary.logic.util.cache.CacheableInterface;

namespace org.allbinary.animation.image;

public class ImageArrayRotationAnimationCacheable : AdjustedImageArrayRotationAnimation, CacheableInterface
{
    public ImageArrayRotationAnimationCacheable(object anyType, AnimationBehavior animationBehavior) : base((((ImageArrayRotationAnimationInfo) anyType)).getImageArray(), (((ImageArrayRotationAnimationInfo) anyType)).getAngleInfoP(), (((ImageArrayRotationAnimationInfo) anyType)).getTotalAngle(), (((ImageArrayRotationAnimationInfo) anyType)).getDx(), (((ImageArrayRotationAnimationInfo) anyType)).getDy(), animationBehavior)
    {
        // base((((ImageArrayRotationAnimationInfo) anyType)).getImageArray(), (((ImageArrayRotationAnimationInfo) anyType)).getAngleInfoP(), (((ImageArrayRotationAnimationInfo) anyType)).getTotalAngle(), (((ImageArrayRotationAnimationInfo) anyType)).getDx(), (((ImageArrayRotationAnimationInfo) anyType)).getDy(), animationBehavior) is called from the constructor declaration
    }

    public override object getKey()
    {
        return NullUtil.getInstance().NULL_OBJECT;
    }

    public override string ToString()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

}

