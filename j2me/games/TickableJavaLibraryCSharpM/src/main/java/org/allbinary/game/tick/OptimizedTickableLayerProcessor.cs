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
using AllBinaryGameLayer = org.allbinary.game.layer.AllBinaryGameLayer;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using LayerProcessor = org.allbinary.layer.LayerProcessor;

namespace org.allbinary.game.tick;

public class OptimizedTickableLayerProcessor : LayerProcessor
{
    public OptimizedTickableLayerProcessor() : base(new OptimizedTickableLayerManager())
    {
        // base(new OptimizedTickableLayerManager()) is called from the constructor declaration
    }

    // throws Exception
    public override void processAt(AllBinaryLayerManager allBinaryLayerManager, AllBinaryLayer layerInterface, int index)
    {
        AllBinaryGameLayer tickableInterface = ((AllBinaryGameLayer) layerInterface);
        tickableInterface.processTick(allBinaryLayerManager);
    }

    public override bool isProcessorLayer(AllBinaryLayer layerInterface)
    {
        if (layerInterface.implmentsTickableInterface()) {
            return true;
        } else {
            return false;
        }
    }

}

