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
using CollidableInterfaceCompositeInterface = org.allbinary.game.collision.CollidableInterfaceCompositeInterface;
using CollisionType = org.allbinary.game.collision.CollisionType;
using CollisionTypeFactory = org.allbinary.game.collision.CollisionTypeFactory;
using CollidableCompositeLayer = org.allbinary.game.layer.CollidableCompositeLayer;
using PickedUpLayerInterface = org.allbinary.game.layer.pickup.PickedUpLayerInterface;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;

namespace org.allbinary.game.layer.special;

public class CollidableCharacterNoDamageBehavior : CollidableDestroyableDamageableBehavior
{
    public CollidableCharacterNoDamageBehavior(bool collidable) : base(collidable)
    {
        // base(collidable) is called from the constructor declaration
    }

    // throws Exception
    public override void collide(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer collidableInterfaceCompositeInterface)
    {
        CollisionTypeFactory collisionTypeFactory = CollisionTypeFactory.getInstance();
        CollisionType collisionType = collidableInterfaceCompositeInterface.getCollidableInferface().getCollisionTypeWith(ownerLayer);
        if (collisionType == collisionTypeFactory.PICKUP) {
            CollidableDestroyableDamageableLayer collidableDestroyableDamageableLayer = ((CollidableDestroyableDamageableLayer) ownerLayer);
            collidableDestroyableDamageableLayer.getPickupBehavior().doPickupLayer(((PickedUpLayerInterface) collidableInterfaceCompositeInterface));
        } else {
        }
    }

    // throws Exception
    public override void collideInterface(CollidableCompositeLayer ownerLayer, CollidableInterfaceCompositeInterface collidableInterfaceCompositeInterface)
    {
        ForcedLogUtil.log(this.commonStrings.NOT_IMPLEMENTED, this);
    }

}

