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
using CollidableBaseBehavior = org.allbinary.game.collision.CollidableBaseBehavior;
using CollidableInterfaceCompositeInterface = org.allbinary.game.collision.CollidableInterfaceCompositeInterface;
using DamageUtil = org.allbinary.game.combat.damage.DamageUtil;
using CollidableCompositeLayer = org.allbinary.game.layer.CollidableCompositeLayer;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;

namespace org.allbinary.game.layer.special;

public class CollidableDestroyableDamageableBehavior : CollidableBaseBehavior
{
    public readonly DamageUtil damageUtil = DamageUtil.getInstance();
    public CollidableDestroyableDamageableBehavior(bool collidable) : base(collidable)
    {
        // base(collidable) is called from the constructor declaration
    }

    public override bool isCollision(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer collisionLayer)
    {
        if (ownerLayer.getGroupInterface()[0] != collisionLayer.getGroupInterface()[0]) {
            return base.isCollision(ownerLayer, collisionLayer);
        }
        return false;
    }

    // throws Exception
    public override void collide(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer collidableInterfaceCompositeInterface)
    {
        CollidableDestroyableDamageableLayer ownerCollidableDestroyableDamageableLayer = ((CollidableDestroyableDamageableLayer) ownerLayer);
        CollidableDestroyableDamageableLayer collidableDestroyableDamageableLayer = ((CollidableDestroyableDamageableLayer) collidableInterfaceCompositeInterface);
        ownerCollidableDestroyableDamageableLayer.damage(collidableDestroyableDamageableLayer.getDamage(0), 0);
    }

    public override bool isCollisionInterface(CollidableCompositeLayer ownerLayer, CollidableInterfaceCompositeInterface collidableInterfaceCompositeInterface)
    {
        ForcedLogUtil.log("No Longer Used", this);
        return false;
    }

    // throws Exception
    public override void collideInterface(CollidableCompositeLayer ownerLayer, CollidableInterfaceCompositeInterface collidableInterfaceCompositeInterface)
    {
        ForcedLogUtil.log("No Longer Used", this);
    }

}

