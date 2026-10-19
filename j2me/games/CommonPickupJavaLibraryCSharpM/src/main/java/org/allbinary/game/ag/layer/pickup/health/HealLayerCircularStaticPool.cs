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
using HealthInterface = org.allbinary.game.health.HealthInterface;
using HealthInterfaceCompositeInterface = org.allbinary.game.health.HealthInterfaceCompositeInterface;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerCircularPool = org.allbinary.layer.AllBinaryLayerCircularPool;
using AllBinaryLayerFactoryInterface = org.allbinary.layer.AllBinaryLayerFactoryInterface;

namespace org.allbinary.game.ag.layer.pickup.health;

public class HealLayerCircularStaticPool : AllBinaryLayerCircularPool
{
    public HealLayerCircularStaticPool(AllBinaryLayerFactoryInterface allbinaryLayerFactoryInterface, int total)
    {
        base.initAllBinaryLayerCircularPool(allbinaryLayerFactoryInterface, total);
    }

    // throws Exception
    public virtual void visit(AllBinaryLayer sourceLayerInterface)
    {
        HealLayer healLayer = ((HealLayer) this.getNextInstance());
        HealthInterfaceCompositeInterface healthInterfaceCompositeInterface = ((HealthInterfaceCompositeInterface) sourceLayerInterface);
        HealthInterface healthInterface = healthInterfaceCompositeInterface.getHealthInterface();
        healLayer.visit(healthInterface);
    }

}

