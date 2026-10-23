/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2003 AllBinary 
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
using CollisionType = org.allbinary.game.collision.CollisionType;
using CollisionTypeFactory = org.allbinary.game.collision.CollisionTypeFactory;
using CollidableDestroyableDamageableBehavior = org.allbinary.game.layer.special.CollidableDestroyableDamageableBehavior;

namespace org.allbinary.game.layer;

public class CollidableRTSBehavior : CollidableDestroyableDamageableBehavior
{
    public CollidableRTSBehavior(bool collidable) : base(collidable)
    {
        // base(collidable) is called from the constructor declaration
    }

    public override bool isCollision(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer collidableInterfaceCompositeInterface)
    {
        CollisionTypeFactory collisionTypeFactory = CollisionTypeFactory.getInstance();
        CollisionType collisionType = collidableInterfaceCompositeInterface.getCollidableInferface().getCollisionTypeWith(ownerLayer);
        if (collisionType == collisionTypeFactory.PICKUP) {
        } else if (collisionType == collisionTypeFactory.COLLISION) {
            return base.isCollision(ownerLayer, collidableInterfaceCompositeInterface);
        } else {
            if (collidableInterfaceCompositeInterface.getX2() <= ownerLayer.getXP() || collidableInterfaceCompositeInterface.getY2() <= ownerLayer.getYP() || collidableInterfaceCompositeInterface.getYP() >= ownerLayer.getY2() || collidableInterfaceCompositeInterface.getXP() >= ownerLayer.getX2()) {
                return false;
            } else {
                return true;
            }
        }
        return false;
    }

    // throws Exception
    public override void collide(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer collidableInterfaceCompositeInterface)
    {
        CollisionTypeFactory collisionTypeFactory = CollisionTypeFactory.getInstance();
        CollisionType collisionType = collidableInterfaceCompositeInterface.getCollidableInferface().getCollisionTypeWith(ownerLayer);
        if (collisionType == collisionTypeFactory.PICKUP) {
        } else if (collisionType == collisionTypeFactory.COLLISION) {
            base.collide(ownerLayer, collidableInterfaceCompositeInterface);
        } else {
            this.collideNone(ownerLayer, collidableInterfaceCompositeInterface);
        }
    }

    // throws Exception
    public virtual void collideNone(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer collidableInterface)
    {
    }

}

