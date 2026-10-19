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
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using NamedInterface = org.allbinary.layer.NamedInterface;

namespace org.allbinary.game.collision;

public interface CollidableInterface : NamedInterface
{
    // throws Exception
    bool isCollidable(CollidableCompositeLayer ownerLayer);

    // throws Exception
    bool isCollision(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer collidableInterfaceCompositeInterface);

    // throws Exception
    void collide(CollidableCompositeLayer ownerLayer, CollidableCompositeLayer collidableInterfaceCompositeInterface);

    CollisionType getCollisionTypeWith(AllBinaryLayer layerInterface);

}

