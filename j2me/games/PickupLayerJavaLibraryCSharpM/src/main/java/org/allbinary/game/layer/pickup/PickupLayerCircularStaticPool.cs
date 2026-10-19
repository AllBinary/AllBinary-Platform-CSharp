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

namespace org.allbinary.game.layer.pickup;

public class PickupLayerCircularStaticPool : AllBinaryLayerCircularPool
{
    private static PickupLayerCircularStaticPool SINGLETON = new PickupLayerCircularStaticPool();
    private PickupLayerCircularStaticPool()
    {
    }

    public static PickupLayerCircularStaticPool getInstance()
    {
        return PickupLayerCircularStaticPool.SINGLETON;
    }

    // throws Exception
    public virtual PickedUpLayerInterface getInstanceXYZ(PickedUpLayerInterfaceFactoryInterface pickedUpLayerInterfaceFactoryInterface, int x, int y, int z)
    {
        PickupLayer pickupLayer = ((PickupLayer) this.getNextInstance());
        pickupLayer.initXYZ(x, y, z);
        pickupLayer.init(pickedUpLayerInterfaceFactoryInterface, pickedUpLayerInterfaceFactoryInterface.getAnimationInterface());
        return pickupLayer;
    }

}

