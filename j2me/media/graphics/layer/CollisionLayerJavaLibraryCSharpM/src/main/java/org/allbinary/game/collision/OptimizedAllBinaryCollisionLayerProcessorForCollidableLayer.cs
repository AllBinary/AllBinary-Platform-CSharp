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
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using LayerManager = org.allbinary.layer.LayerManager;
using LayerProcessor = org.allbinary.layer.LayerProcessor;

namespace org.allbinary.game.collision;

public class OptimizedAllBinaryCollisionLayerProcessorForCollidableLayer : LayerProcessor
{
    public OptimizedAllBinaryCollisionLayerProcessorForCollidableLayer() : base(new OptimizedAllBinaryCollisionLayerManager())
    {
        // base(new OptimizedAllBinaryCollisionLayerManager()) is called from the constructor declaration
    }

    // throws Exception
    public override void processAt(AllBinaryLayerManager allBinaryLayerManager, AllBinaryLayer layerInterface, int startIndex)
    {
        CollidableCompositeLayer collidableInterfaceCompositeInterface = ((CollidableCompositeLayer) layerInterface);
        CollidableBaseBehavior collidableBase = collidableInterfaceCompositeInterface.getCollidableInferface();
        if (collidableBase.isCollidable(collidableInterfaceCompositeInterface)) {
            LayerManager layerManager = this.getLayerManager();
            int size = layerManager.getSize();
            CollidableCompositeLayer collidableInterfaceCompositeInterface2 = null;
            CollidableBaseBehavior collidableBase2 = null;
            for (int index = startIndex + 1; index < size; index++) {
                collidableInterfaceCompositeInterface2 = ((CollidableCompositeLayer) layerManager.getLayerAt(index));
                collidableBase2 = collidableInterfaceCompositeInterface2.getCollidableInferface();
                if (collidableBase2.isCollidable(collidableInterfaceCompositeInterface) && collidableBase.isCollision(collidableInterfaceCompositeInterface, collidableInterfaceCompositeInterface2)) {
                    collidableBase.collide(collidableInterfaceCompositeInterface, collidableInterfaceCompositeInterface2);
                    collidableBase2.collide(collidableInterfaceCompositeInterface2, collidableInterfaceCompositeInterface);
                }
            }
        }
    }

    public override bool isProcessorLayer(AllBinaryLayer layerInterface)
    {
        if (layerInterface.implmentsCollidableInterface()) {
            return true;
        } else {
            return false;
        }
    }

}

