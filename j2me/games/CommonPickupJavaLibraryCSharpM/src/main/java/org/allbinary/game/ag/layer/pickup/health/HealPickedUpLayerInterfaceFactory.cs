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
using FeaturedAnimationInterfaceFactoryInterfaceFactory = org.allbinary.animation.FeaturedAnimationInterfaceFactoryInterfaceFactory;
using CountedPickedUpLayerInterfaceFactory = org.allbinary.game.layer.pickup.CountedPickedUpLayerInterfaceFactory;
using IconLayerFactory = org.allbinary.game.layer.pickup.IconLayerFactory;
using PickedUpLayerInterfaceFactory = org.allbinary.game.layer.pickup.PickedUpLayerInterfaceFactory;
using PickedUpLayerInterfaceFactoryInterface = org.allbinary.game.layer.pickup.PickedUpLayerInterfaceFactoryInterface;
using PickedUpLayerTypeFactory = org.allbinary.game.layer.pickup.PickedUpLayerTypeFactory;
using PickupProcessorInterface = org.allbinary.game.layer.pickup.PickupProcessorInterface;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;

namespace org.allbinary.game.ag.layer.pickup.health;

public class HealPickedUpLayerInterfaceFactory : PickedUpLayerInterfaceFactory, PickupProcessorInterface
{
    private static PickedUpLayerInterfaceFactoryInterface pickedUpLayerInterfaceFactoryInterface = CountedPickedUpLayerInterfaceFactory.NULL_COUNTED_PICKUP_LAYER_FACTORY;
    // throws Exception
    public static void init()
    {
        HealPickedUpLayerInterfaceFactory.pickedUpLayerInterfaceFactoryInterface = new HealPickedUpLayerInterfaceFactory();
    }

    private HealLayerCircularStaticPool pool = new HealLayerCircularStaticPool(new HealLayerFactory(), 1);
    private HealPickedUpLayerInterfaceFactory() : base(PickedUpLayerTypeFactory.getInstance().HEAL, IconLayerFactory.getInstance(FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().get(HealthResources.getInstance().RESOURCE).getInstance(0), 10, 10), FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().get(HealthResources.getInstance().RESOURCE).getInstance(0))
    {
        // base(PickedUpLayerTypeFactory.getInstance().HEAL, IconLayerFactory.getInstance(FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().get(HealthResources.getInstance().RESOURCE).getInstance(0), 10, 10), FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().get(HealthResources.getInstance().RESOURCE).getInstance(0)) is called from the constructor declaration
    }

    public virtual int getTotal()
    {
        return 1;
    }

    public static PickedUpLayerInterfaceFactoryInterface getInstance()
    {
        return HealPickedUpLayerInterfaceFactory.pickedUpLayerInterfaceFactoryInterface;
    }

    // throws Exception
    public override void process(AllBinaryLayer sourceLayerInterface)
    {
        this.pool.visit(sourceLayerInterface);
    }

}

