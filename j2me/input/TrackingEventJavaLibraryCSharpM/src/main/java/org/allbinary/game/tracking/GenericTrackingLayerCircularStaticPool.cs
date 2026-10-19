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
using AllBinaryLayerCircularPool = org.allbinary.layer.AllBinaryLayerCircularPool;

namespace org.allbinary.game.tracking;

public class GenericTrackingLayerCircularStaticPool : AllBinaryLayerCircularPool
{
    private static GenericTrackingLayerCircularStaticPool SINGLETON = new GenericTrackingLayerCircularStaticPool();
    private GenericTrackingLayerCircularStaticPool()
    {
    }

    public static GenericTrackingLayerCircularStaticPool getInstance()
    {
        return GenericTrackingLayerCircularStaticPool.SINGLETON;
    }

}

