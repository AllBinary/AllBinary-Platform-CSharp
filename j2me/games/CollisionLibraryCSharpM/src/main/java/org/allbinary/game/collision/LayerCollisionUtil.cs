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
using OpenGLFeatureUtil = org.allbinary.graphics.opengles.OpenGLFeatureUtil;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;

namespace org.allbinary.game.collision;

public class LayerCollisionUtil
{
    private static readonly LayerCollisionUtil instance = new LayerCollisionUtil();
    public static LayerCollisionUtil getInstance()
    {
        return LayerCollisionUtil.instance;
    }

    private readonly CollisionProcessor collisionProcessor = null;
    private LayerCollisionUtil()
    {
        Features features = Features.getInstance();
        GameFeatureFactory gameFeatureFactory = GameFeatureFactory.getInstance();
        if (OpenGLFeatureUtil.getInstance().isAnyThreed() && !features.isFeature(gameFeatureFactory.COLLISIONS_FORCED_TWO_DIMENSIONAL)) {
            this.collisionProcessor = new CollisionThreedProcessor();
        } else {
            this.collisionProcessor = new Collision2DProcessor();
        }
    }

    public virtual bool isCollision(AllBinaryLayer myLayer, AllBinaryLayer myLayer2)
    {
        return this.collisionProcessor.isCollision(myLayer, myLayer2);
    }

}

