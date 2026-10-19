/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2006 AllBinary 
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
using CollidableRTSBehavior = org.allbinary.game.layer.CollidableRTSBehavior;
using CollidableInterfaceCompositeInterface = org.allbinary.game.collision.CollidableInterfaceCompositeInterface;

namespace org.allbinary.game.layer.waypoint;

public class CollidableWaypointBehavior : CollidableRTSBehavior
{
    public CollidableWaypointBehavior(bool collidable) : base(collidable)
    {
        // base(collidable) is called from the constructor declaration
    }

    public override bool isCollision(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer collisionLayer)
    {
        return false;
    }

    // throws Exception
    public override void collide(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer collisionLayer)
    {
    }

    public override bool isCollisionInterface(CollidableCompositeLayer ownerLayer, CollidableInterfaceCompositeInterface collidableInterface)
    {
        return false;
    }

    // throws Exception
    public override void collideInterface(CollidableCompositeLayer ownerLayer, CollidableInterfaceCompositeInterface collidableInterface)
    {
    }

}

