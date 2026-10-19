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
using AllBinaryGameCanvas = org.allbinary.game.displayable.canvas.AllBinaryGameCanvas;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryEventCircularPool = org.allbinary.logic.util.@event.AllBinaryEventCircularPool;

namespace org.allbinary.game.combat.destroy.@event;

public class DestroyEventCircularStaticPool
{
    private static readonly DestroyEventCircularStaticPool instance = new DestroyEventCircularStaticPool();
    public static DestroyEventCircularStaticPool getInstance()
    {
        return DestroyEventCircularStaticPool.instance;
    }

    private AllBinaryEventCircularPool EVENT_POOL = new AllBinaryEventCircularPool(20);
    private DestroyEventCircularStaticPool()
    {
    }

    public virtual void init(AllBinaryGameCanvas combatGameCanvas)
    {
        this.EVENT_POOL.initAllBinaryEventCircularPool(new DestroyEventFactory(combatGameCanvas));
    }

    // throws Exception
    public virtual DestroyedEvent getInstanceForLayer(AllBinaryLayer layerInterface)
    {
        DestroyedEvent destroyedEvent = ((DestroyedEvent) this.EVENT_POOL.getNextInstance());
        destroyedEvent.setLayerInterfaceForCircularStaticPool(layerInterface);
        return destroyedEvent;
    }

}

