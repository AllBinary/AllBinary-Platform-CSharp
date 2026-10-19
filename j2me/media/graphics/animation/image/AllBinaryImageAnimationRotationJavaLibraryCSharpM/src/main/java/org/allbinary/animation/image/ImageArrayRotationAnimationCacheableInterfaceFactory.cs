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
using CacheableInterface = org.allbinary.logic.util.cache.CacheableInterface;
using CacheableInterfaceFactoryInterface = org.allbinary.logic.util.cache.CacheableInterfaceFactoryInterface;

namespace org.allbinary.animation.image;

public class ImageArrayRotationAnimationCacheableInterfaceFactory : CacheableInterfaceFactoryInterface
{
    // throws Exception
    public virtual CacheableInterface getInstance(object key)
    {
        return new ImageArrayRotationAnimationCacheable(key, AnimationBehavior.getInstance());
    }

}

