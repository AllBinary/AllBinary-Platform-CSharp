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
using WeaponProperties = org.allbinary.game.combat.weapon.WeaponProperties;
using CountedPickedUpLayerInterfaceFactory = org.allbinary.game.layer.pickup.CountedPickedUpLayerInterfaceFactory;
using IconLayerFactory = org.allbinary.game.layer.pickup.IconLayerFactory;
using PickedUpLayerInterfaceFactoryInterface = org.allbinary.game.layer.pickup.PickedUpLayerInterfaceFactoryInterface;
using PickedUpLayerTypeFactory = org.allbinary.game.layer.pickup.PickedUpLayerTypeFactory;
using WeaponLayerCircularPool = org.allbinary.game.layer.weapon.WeaponLayerCircularPool;
using ScoreableInterface = org.allbinary.game.score.ScoreableInterface;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using org.allbinary.util;

namespace org.allbinary.game.ag.layer.weapon.mine;

public class MineCountedPickedUpLayerInterfaceFactory : CountedPickedUpLayerInterfaceFactory
{
    private readonly WeaponLayerCircularPool weaponLayerCircularStaticPool = MineLayerCircularStaticPool.getInstance();
    private static PickedUpLayerInterfaceFactoryInterface pickedUpLayerInterfaceFactoryInterface = CountedPickedUpLayerInterfaceFactory.NULL_COUNTED_PICKUP_LAYER_FACTORY;
    // throws Exception
    public static void init()
    {
        MineCountedPickedUpLayerInterfaceFactory.pickedUpLayerInterfaceFactoryInterface = new MineCountedPickedUpLayerInterfaceFactory();
    }

    private MineCountedPickedUpLayerInterfaceFactory() : base(PickedUpLayerTypeFactory.getInstance().MINE, IconLayerFactory.getInstance(FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().get(MineWeaponResources.getInstance().DROP_ICON_RESOURCE).getInstance(0), 10, 10), FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().get(MineWeaponResources.getInstance().DROP_RESOURCE).getInstance(0))
    {
        // base(PickedUpLayerTypeFactory.getInstance().MINE, IconLayerFactory.getInstance(FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().get(MineWeaponResources.getInstance().DROP_ICON_RESOURCE).getInstance(0), 10, 10), FeaturedAnimationInterfaceFactoryInterfaceFactory.getInstance().get(MineWeaponResources.getInstance().DROP_RESOURCE).getInstance(0)) is called from the constructor declaration
    }

    public static PickedUpLayerInterfaceFactoryInterface getInstance()
    {
        return MineCountedPickedUpLayerInterfaceFactory.pickedUpLayerInterfaceFactoryInterface;
    }

    public override int getTotal()
    {
        return 3;
    }

    private readonly WeaponProperties weaponProperties = new WeaponProperties(-1L, -1L, 0, 8000, ((short) 10));
    private readonly SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
    // throws Exception
    public override AllBinaryLayer getNextInstance(ABHashtable<object, object> hashtable, int x, int y, int z)
    {
        AllBinaryLayer sourceLayerInterface = ((AllBinaryLayer) hashtable.get(((object) this.smallIntegerSingletonFactory.getAt(0))));
        int? angle = ((int?) hashtable.get(((object) this.smallIntegerSingletonFactory.getAt(1))));
        ScoreableInterface scoreableInterface = ((ScoreableInterface) sourceLayerInterface);
        return this.weaponLayerCircularStaticPool.getInstanceWeaponLayer(sourceLayerInterface, x, y, z, ((int) ((int) angle)), 0, this.weaponProperties, scoreableInterface);
    }

}

