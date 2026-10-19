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
using Animation = org.allbinary.animation.Animation;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.layer.pickup;

public class CountedPickedUpLayerInterfaceFactory : PickedUpLayerInterfaceFactory, CountedPickedUpLayerInterfaceFactoryInterface
{
    public static readonly CountedPickedUpLayerInterfaceFactory NULL_COUNTED_PICKUP_LAYER_FACTORY = new CountedPickedUpLayerInterfaceFactory(PickedUpLayerTypeFactory.getInstance().NONE, IconLayer.NULL_ICON_LAYER, NullAnimationFactory.getFactoryInstance().getInstance(0));
    private readonly int id;
    public CountedPickedUpLayerInterfaceFactory(PickedUpLayerType pickeUpLayerType, IconLayer iconLayer, Animation animationInterface) : base(pickeUpLayerType, iconLayer, animationInterface)
    {
        // base(pickeUpLayerType, iconLayer, animationInterface) is called from the constructor declaration
        BasicArrayList list = CountedPickedUpLayerInterfaceFactoryPool.getInstance().getList();
        this.id = list.size();
        list.add(this);
    }

    // throws Exception
    public override AllBinaryLayer getNextInstance(ABHashtable<object, object> hashtable, int x, int y, int z)
    {
        throw new Exception(CommonStrings.getInstance().NOT_IMPLEMENTED);
    }

    public override int getTotal()
    {
        return -1;
    }

    public override int getId()
    {
        return this.id;
    }

}

