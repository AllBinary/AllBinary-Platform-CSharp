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
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.layer;

public class LayerProcessor : LayerProcessorInterface
{
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly LayerManager layerManager;
    public LayerProcessor(LayerManager layerManager)
    {
        this.layerManager = layerManager;
    }

    // throws Exception
    public virtual void processAt(AllBinaryLayerManager allBinaryLayerManager, AllBinaryLayer layerInterface, int index)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    // throws Exception
    public virtual bool isProcessorLayer(AllBinaryLayer layerInterface)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    public virtual LayerManager getLayerManager()
    {
        return this.layerManager;
    }

    // throws Exception
    public virtual void process(AllBinaryLayerManager allBinaryLayerManager)
    {
        LayerManager layerManager = this.getLayerManager();
        int size = layerManager.getSize();
        for (int index = 0; index < size; index++) {
            this.processAt(allBinaryLayerManager, ((AllBinaryLayer) layerManager.getLayerAt(index)), index);
        }
    }

}

