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
using CollidableCompositeLayer = org.allbinary.game.layer.CollidableCompositeLayer;

namespace org.allbinary.game.combat.destroy;

public class DestroyableSimpleBehavior : DestroyableBaseBehavior
{
    public readonly CollidableCompositeLayer ownerLayer;
    private bool destroyed = false;
    public DestroyableSimpleBehavior(CollidableCompositeLayer ownerLayer)
    {
        this.ownerLayer = ownerLayer;
    }

    public override bool isDestroyed()
    {
        return this.destroyed;
    }

    public override void setDestroyed(bool destroyed)
    {
        this.destroyed = destroyed;
        if (this.isDestroyed()) {
            DestroyedLayerProcessor.getInstance().add(this.ownerLayer);
        }
    }

}

