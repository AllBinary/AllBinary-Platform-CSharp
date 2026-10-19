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

namespace org.allbinary.layer;

public class SingleLayerLayerProcessor : LayerProcessor
{
    public SingleLayerLayerProcessor() : base(new SingleLayerLayerManager())
    {
        // base(new SingleLayerLayerManager()) is called from the constructor declaration
    }

    // throws Exception
    public override void process(AllBinaryLayerManager allBinaryLayerManager)
    {
        LayerManager layerManager = this.getLayerManager();
        this.processAt(allBinaryLayerManager, ((AllBinaryLayer) layerManager.getLayerAt(0)), 0);
    }

}

