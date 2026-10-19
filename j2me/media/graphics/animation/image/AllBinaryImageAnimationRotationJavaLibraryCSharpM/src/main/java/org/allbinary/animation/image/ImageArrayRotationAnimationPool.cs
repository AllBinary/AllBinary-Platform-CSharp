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
using BasicArrayListResetablePool = org.allbinary.logic.util.cache.BasicArrayListResetablePool;
using CacheableInterface = org.allbinary.logic.util.cache.CacheableInterface;
using CacheableInterfaceFactoryInterface = org.allbinary.logic.util.cache.CacheableInterfaceFactoryInterface;
using PoolInterface = org.allbinary.logic.util.cache.PoolInterface;

namespace org.allbinary.animation.image;

public class ImageArrayRotationAnimationPool : BasicArrayListResetablePool
{
    private static PoolInterface IMAGE_ROTATION_ANIMATION_POOL = new ImageArrayRotationAnimationPool(new ImageArrayRotationAnimationCacheableInterfaceFactory());
    public ImageArrayRotationAnimationPool(CacheableInterfaceFactoryInterface cacheableInterfaceFactoryInterface) : base(cacheableInterfaceFactoryInterface)
    {
        // base(cacheableInterfaceFactoryInterface) is called from the constructor declaration
    }

    public static PoolInterface getInstance()
    {
        return ImageArrayRotationAnimationPool.IMAGE_ROTATION_ANIMATION_POOL;
    }

    // throws Exception
    public override CacheableInterface remove(object key)
    {
        CacheableInterface cacheableInterface = base.remove(key);
        ImageArrayRotationAnimationInfo allBinaryImageRotationAnimationInfo = ((ImageArrayRotationAnimationInfo) key);
        ImageArrayRotationAnimationCacheable imageArrayRotationAnimationCacheable = (((ImageArrayRotationAnimationCacheable) cacheableInterface));
        imageArrayRotationAnimationCacheable.setImageArray(allBinaryImageRotationAnimationInfo.getImageArray());
        return cacheableInterface;
    }

}

