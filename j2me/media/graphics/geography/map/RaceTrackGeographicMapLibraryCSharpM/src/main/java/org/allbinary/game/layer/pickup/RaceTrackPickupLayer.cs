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
using BasicGroupFactory = org.allbinary.game.identification.BasicGroupFactory;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using RemoteInfo = org.allbinary.game.multiplayer.layer.RemoteInfo;
using TileLayerPositionIntoViewPosition = org.allbinary.game.view.TileLayerPositionIntoViewPosition;
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using ViewPosition = org.allbinary.view.ViewPosition;
using ViewPositionEventHandler = org.allbinary.view.@event.ViewPositionEventHandler;

namespace org.allbinary.game.layer.pickup;

public class RaceTrackPickupLayer : PickupLayer
{
    private static readonly string NAME = "RaceTrackPickupLayer";
    public RaceTrackPickupLayer() : base(NAME, RemoteInfo.REMOTE_INFO, 0, CountedPickedUpLayerInterfaceFactory.NULL_COUNTED_PICKUP_LAYER_FACTORY, NullAnimationFactory.getFactoryInstance().getInstance(0), new Rectangle(PointFactory.getInstance().ZERO_ZERO, 0, 0), new TileLayerPositionIntoViewPosition())
    {
        // base(NAME, RemoteInfo.REMOTE_INFO, 0, CountedPickedUpLayerInterfaceFactory.NULL_COUNTED_PICKUP_LAYER_FACTORY, NullAnimationFactory.getFactoryInstance().getInstance(0), new Rectangle(PointFactory.getInstance().ZERO_ZERO, 0, 0), new TileLayerPositionIntoViewPosition()) is called from the constructor declaration
    }

    private readonly ViewPositionEventHandler viewPositionEventHandler = ViewPositionEventHandler.getInstance();
    public virtual void setTiledLayer(AllBinaryTiledLayer tiledLayer)
    {
        TileLayerPositionIntoViewPosition viewPosition = ((TileLayerPositionIntoViewPosition) this.getViewPosition());
        viewPosition.setTiledLayer(tiledLayer);
        this.viewPositionEventHandler.addListener(((AllBinaryLayer) this));
    }

    public override void setDestroyed(bool destroyed)
    {
        base.setDestroyed(destroyed);
        if (this.isDestroyed()) {
            this.viewPositionEventHandler.removeListener(this);
        }
    }

}

