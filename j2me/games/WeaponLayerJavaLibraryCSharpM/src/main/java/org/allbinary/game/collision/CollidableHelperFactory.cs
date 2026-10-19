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
using Features = org.allbinary.game.configuration.feature.Features;
using GameFeatureFactory = org.allbinary.game.configuration.feature.GameFeatureFactory;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;

namespace org.allbinary.game.collision;

public class CollidableHelperFactory
{
    public static CollisionHelper getInstance()
    {
        if (Features.getInstance().isFeature(GameFeatureFactory.getInstance().COLLISIONS_WITH_SOURCE)) {
            return new CollisionHelper(AllBinaryLayer.NULL_ALLBINARY_LAYER);
        } else {
            return new SourceCollisionHelper(AllBinaryLayer.NULL_ALLBINARY_LAYER);
        }
    }

}

