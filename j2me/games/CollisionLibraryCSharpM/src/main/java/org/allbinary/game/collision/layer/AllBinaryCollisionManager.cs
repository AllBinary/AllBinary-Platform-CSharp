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
using CollidableCompositeLayer = org.allbinary.game.layer.CollidableCompositeLayer;
using LayerManager = org.allbinary.layer.LayerManager;

namespace org.allbinary.game.collision.layer;

public class AllBinaryCollisionManager
{
    private static AllBinaryCollisionManager allBinaryCollisionManager = new AllBinaryCollisionManager();
    private AllBinaryCollisionManager()
    {
    }

    public static AllBinaryCollisionManager getInstance()
    {
        return AllBinaryCollisionManager.allBinaryCollisionManager;
    }

    // throws Exception
    public virtual void process(LayerManager layerManager, CollidableInterfaceCompositeInterface collidableInterfaceCompositeInterface, int startIndex)
    {
        int size = layerManager.getSize();
        for (int index = startIndex + 1; index < size; index++) {
            CollidableInterfaceCompositeInterface collidableInterfaceCompositeInterface2 = ((CollidableInterfaceCompositeInterface) layerManager.getLayerAt(index));
            this.collide(layerManager, collidableInterfaceCompositeInterface, collidableInterfaceCompositeInterface2);
        }
    }

    // throws Exception
    private void collide(LayerManager layerManager, CollidableInterfaceCompositeInterface collidableInterfaceCompositeInterface, CollidableInterfaceCompositeInterface collidableInterfaceCompositeInterface2)
    {
        CollidableBaseBehavior collidableBase2 = collidableInterfaceCompositeInterface2.getCollidableInferface();
        CollidableBaseBehavior collidableBase = collidableInterfaceCompositeInterface.getCollidableInferface();
        if (collidableBase2.isCollidable(((CollidableCompositeLayer) collidableInterfaceCompositeInterface))) {
            if (collidableBase.isCollisionInterface(((CollidableCompositeLayer) collidableInterfaceCompositeInterface), collidableInterfaceCompositeInterface2)) {
                collidableBase.collideInterface(((CollidableCompositeLayer) collidableInterfaceCompositeInterface), collidableInterfaceCompositeInterface2);
                collidableBase2.collideInterface(((CollidableCompositeLayer) collidableInterfaceCompositeInterface), collidableInterfaceCompositeInterface);
            }
        }
    }

}

