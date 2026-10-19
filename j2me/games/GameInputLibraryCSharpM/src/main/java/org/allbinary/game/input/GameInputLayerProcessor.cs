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
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using LayerProcessor = org.allbinary.layer.LayerProcessor;

namespace org.allbinary.game.input;

public class GameInputLayerProcessor : LayerProcessor
{
    public GameInputLayerProcessor() : base(new GameInputLayerManager())
    {
        // base(new GameInputLayerManager()) is called from the constructor declaration
    }

    // throws Exception
    public override void processAt(AllBinaryLayerManager allBinaryLayerManager, AllBinaryLayer layerInterface, int index)
    {
        GameInputInterface gameInputInterface = ((GameInputInterface) layerInterface);
        gameInputInterface.processInput(allBinaryLayerManager);
    }

    public override bool isProcessorLayer(AllBinaryLayer layerInterface)
    {
        if (layerInterface.implmentsGameInputInterface()) {
            return true;
        } else {
            return false;
        }
    }

}

