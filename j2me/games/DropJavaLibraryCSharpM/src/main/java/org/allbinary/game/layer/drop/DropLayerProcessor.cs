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
using BasicLayerProcessor = org.allbinary.layer.BasicLayerProcessor;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.layer.drop;

public class DropLayerProcessor : BasicLayerProcessor
{
    private static readonly BasicLayerProcessor LAYER_PROCESSOR = new DropLayerProcessor();
    private DropLayerProcessor()
    {
    }

    public static BasicLayerProcessor getInstance()
    {
        return DropLayerProcessor.LAYER_PROCESSOR;
    }

    // throws Exception
    public override void process(AllBinaryLayerManager allBinaryLayerManager)
    {
        BasicArrayList list = this.getList();
        int size = list.size();
        AllBinaryLayer layerInterface = null;
        DropLayerInterface dropLayerInterface = null;
        for (int index = 0; index < size; index++) {
            layerInterface = ((AllBinaryLayer) list.objectArray[index]);
            dropLayerInterface = ((DropLayerInterface) layerInterface);
            layerInterface = ((AllBinaryLayer) dropLayerInterface.getDroppedLayer());
            allBinaryLayerManager.append(layerInterface);
        }
        list.clear();
    }

}

