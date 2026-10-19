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
using Life = org.allbinary.game.ag.life.Life;
using LifeInterfaceCompositeInterface = org.allbinary.game.ag.life.LifeInterfaceCompositeInterface;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerCircularPool = org.allbinary.layer.AllBinaryLayerCircularPool;
using AllBinaryLayerFactoryInterface = org.allbinary.layer.AllBinaryLayerFactoryInterface;

namespace org.allbinary.game.ag.layer.pickup.life;

public class LifeLayerCircularStaticPool : AllBinaryLayerCircularPool
{
    public LifeLayerCircularStaticPool(AllBinaryLayerFactoryInterface allbinaryLayerFactoryInterface, int total)
    {
        base.initAllBinaryLayerCircularPool(allbinaryLayerFactoryInterface, total);
    }

    // throws Exception
    public virtual void visit(AllBinaryLayer sourceLayerInterface)
    {
        LifeLayer lifeLayer = ((LifeLayer) this.getNextInstance());
        LifeInterfaceCompositeInterface lifeInterfaceCompositeInterface = ((LifeInterfaceCompositeInterface) sourceLayerInterface);
        Life lifeInterface = lifeInterfaceCompositeInterface.getLifeInterface();
        lifeLayer.visit(lifeInterface);
    }

}

