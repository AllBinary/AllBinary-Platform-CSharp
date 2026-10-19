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

namespace org.allbinary.game.collision;

public class SourceCollisionHelper : CollisionHelper
{
    public SourceCollisionHelper(AllBinaryLayer layerInterface) : base(layerInterface)
    {
        // base(layerInterface) is called from the constructor declaration
    }

    public override bool isCollidable(CollidableCompositeLayer layerInterface)
    {
        if (this.sourceLayerInterface != layerInterface) {
            return true;
        }
        return false;
    }

}

