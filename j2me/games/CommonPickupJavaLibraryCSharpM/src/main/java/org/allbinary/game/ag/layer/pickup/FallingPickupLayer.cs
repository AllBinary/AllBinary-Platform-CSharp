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
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using CountedPickedUpLayerInterfaceFactory = org.allbinary.game.layer.pickup.CountedPickedUpLayerInterfaceFactory;
using PickupLayer = org.allbinary.game.layer.pickup.PickupLayer;
using RemoteInfo = org.allbinary.game.multiplayer.layer.RemoteInfo;
using TickableInterface = org.allbinary.game.tick.TickableInterface;
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using ViewPosition = org.allbinary.view.ViewPosition;

namespace org.allbinary.game.ag.layer.pickup;

public class FallingPickupLayer : PickupLayer, TickableInterface
{
    private static readonly string NAME = "FallingPickupLayer";
    public FallingPickupLayer(RemoteInfo remoteInfo) : base(FallingPickupLayer.NAME, remoteInfo, 0, CountedPickedUpLayerInterfaceFactory.NULL_COUNTED_PICKUP_LAYER_FACTORY, NullAnimationFactory.getFactoryInstance().getInstance(0), new Rectangle(PointFactory.getInstance().ZERO_ZERO, 0, 0), ViewPosition.getInstanceD())
    {
        // base(FallingPickupLayer.NAME, remoteInfo, 0, CountedPickedUpLayerInterfaceFactory.NULL_COUNTED_PICKUP_LAYER_FACTORY, NullAnimationFactory.getFactoryInstance().getInstance(0), new Rectangle(PointFactory.getInstance().ZERO_ZERO, 0, 0), ViewPosition.getInstanceD()) is called from the constructor declaration
    }

    public override void processTick(AllBinaryLayerManager allBinaryLayerManager)
    {
        this.setPosition(this.x, this.y + 1, this.z);
    }

    public override bool implmentsTickableInterface()
    {
        return true;
    }

}

