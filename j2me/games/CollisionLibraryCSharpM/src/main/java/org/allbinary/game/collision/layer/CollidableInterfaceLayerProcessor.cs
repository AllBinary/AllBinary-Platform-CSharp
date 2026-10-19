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
using CollidableInterfaceCompositeInterface = org.allbinary.game.collision.CollidableInterfaceCompositeInterface;
using CollidableCompositeLayer = org.allbinary.game.layer.CollidableCompositeLayer;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using LayerProcessor = org.allbinary.layer.LayerProcessor;

namespace org.allbinary.game.collision.layer;

public class CollidableInterfaceLayerProcessor : LayerProcessor
{
    public CollidableInterfaceLayerProcessor() : base(new CollidableInterfaceLayerManager())
    {
        // base(new CollidableInterfaceLayerManager()) is called from the constructor declaration
    }

    // throws Exception
    public override void processAt(AllBinaryLayerManager allBinaryLayerManager, AllBinaryLayer layerInterface, int index)
    {
        CollidableInterfaceCompositeInterface collidableInterfaceCompositeInterface = ((CollidableInterfaceCompositeInterface) layerInterface);
        if (collidableInterfaceCompositeInterface.getCollidableInferface().isCollidable(((CollidableCompositeLayer) collidableInterfaceCompositeInterface))) {
            AllBinaryCollisionManager.getInstance().process(this.getLayerManager(), collidableInterfaceCompositeInterface, index);
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

