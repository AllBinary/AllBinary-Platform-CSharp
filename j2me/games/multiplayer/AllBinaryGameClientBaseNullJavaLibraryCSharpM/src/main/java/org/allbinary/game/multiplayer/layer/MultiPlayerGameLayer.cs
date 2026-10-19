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
using Group = org.allbinary.game.identification.Group;
using CollidableDestroyableDamageableLayer = org.allbinary.game.layer.special.CollidableDestroyableDamageableLayer;
using Rectangle = org.allbinary.graphics.Rectangle;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;

namespace org.allbinary.game.multiplayer.layer;

public class MultiPlayerGameLayer : CollidableDestroyableDamageableLayer, MultiPlayerGameLayerInterface
{
    public MultiPlayerGameLayer(RemoteInfo remoteInfo, Group[] groupInterface, string name, Rectangle layerInfo, ViewPositionBase viewPosition) : base(groupInterface, name, layerInfo, viewPosition)
    {
        // base(groupInterface, name, layerInfo, viewPosition) is called from the constructor declaration
    }

    public override MultiplayerBehavior getMultiplayerBehavior()
    {
        return MultiplayerBehavior.NULL_MULTIPLAYER_BEHAVIOR;
    }

    public virtual void setPingInfo(bool show)
    {
    }

    protected virtual void setFiring(short firing)
    {
    }

    protected virtual short getFiring()
    {
        return 0;
    }

}

