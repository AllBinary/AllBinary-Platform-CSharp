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
using System.Runtime.CompilerServices;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryEventCircularPool = org.allbinary.logic.util.@event.AllBinaryEventCircularPool;

namespace org.allbinary.game.tracking;

public class TrackingEventCircularStaticPool
{
    private static TrackingEventCircularStaticPool instance = new TrackingEventCircularStaticPool();
    public static TrackingEventCircularStaticPool getInstance()
    {
        return TrackingEventCircularStaticPool.instance;
    }

    private AllBinaryEventCircularPool EVENT_POOL = new AllBinaryEventCircularPool(20);
    public virtual void init()
    {
        this.EVENT_POOL.initAllBinaryEventCircularPool(new TrackingEventFactory());
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual TrackingEvent getNextInstance(AllBinaryLayer layerInterface)
    {
        TrackingEvent trackingEvent = ((TrackingEvent) this.EVENT_POOL.getNextInstance());
        trackingEvent.setLayerInterfaceForCircularStaticPool(layerInterface);
        return trackingEvent;
    }

}

