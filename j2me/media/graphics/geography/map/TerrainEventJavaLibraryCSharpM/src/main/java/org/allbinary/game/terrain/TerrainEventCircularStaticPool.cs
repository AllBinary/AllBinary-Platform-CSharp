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
using AllBinaryEventCircularPool = org.allbinary.logic.util.@event.AllBinaryEventCircularPool;

namespace org.allbinary.game.terrain;

public class TerrainEventCircularStaticPool
{
    private static readonly TerrainEventCircularStaticPool instance = new TerrainEventCircularStaticPool();
    public static TerrainEventCircularStaticPool getInstance()
    {
        return TerrainEventCircularStaticPool.instance;
    }

    private AllBinaryEventCircularPool EVENT_POOL = new AllBinaryEventCircularPool(20);
    public virtual void init()
    {
        this.EVENT_POOL.initAllBinaryEventCircularPool(new TerrainEventFactory());
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual TerrainEvent getNext(BasicTerrainInfo basicTerrainInfo)
    {
        TerrainEvent trackingEvent = ((TerrainEvent) this.EVENT_POOL.getNextInstance());
        trackingEvent.setBasicTerrainInfoForCircularStaticPool(basicTerrainInfo);
        return trackingEvent;
    }

}

