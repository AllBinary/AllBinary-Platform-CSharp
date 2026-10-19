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

namespace org.allbinary.game.collision;

public class CollidableNeverCollideBehavior : CollidableBaseBehavior
{
    public CollidableNeverCollideBehavior(bool isCollidable) : base(isCollidable)
    {
        // base(isCollidable) is called from the constructor declaration
    }

    public override bool isCollision(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer allbinaryCollidableLayer)
    {
        return false;
    }

    // throws Exception
    public override void collide(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer allbinaryCollidableLayer)
    {
    }

    public override void collideInterface(CollidableCompositeLayer ownerLayer, CollidableInterfaceCompositeInterface collidableInterfaceCompositeInterface)
    {
    }

    public override bool isCollisionInterface(CollidableCompositeLayer ownerLayer, CollidableInterfaceCompositeInterface collidableInterfaceCompositeInterface)
    {
        return false;
    }

}

