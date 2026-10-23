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
using System.Runtime.CompilerServices;
using LayerManagerEvent = org.allbinary.layer.@event.LayerManagerEvent;
using LayerManagerEventHandler = org.allbinary.layer.@event.LayerManagerEventHandler;

namespace org.allbinary.layer;

public class AllBinaryLayerManager : LayerManager
{
    private readonly LayerManagerEventHandler layerManagerEventHandler = LayerManagerEventHandler.getInstance();
    private readonly LayerManagerEvent createLayerManagerEvent;
    private readonly LayerManagerEvent deleteLayerManagerEvent;
    private LayerProcessor[] basicLayerProcessorArray = new LayerProcessor[0];
    public AllBinaryLayerManager() : base(LayerManagerNoDebug.getInstance())
    {
        this.createLayerManagerEvent = new LayerManagerEvent(this, this.layerManagerEventHandler.CREATE);
        this.deleteLayerManagerEvent = new LayerManagerEvent(this, this.layerManagerEventHandler.DELETE);
        // base(LayerManagerNoDebug.getInstance()) is called from the constructor declaration
    }

    public virtual LayerProcessor[] getLayerProcessorArray()
    {
        return this.basicLayerProcessorArray;
    }

    public virtual void setLayerProcessorArray(LayerProcessor[] layerProcessorArray)
    {
        this.basicLayerProcessorArray = layerProcessorArray;
    }

    public void log()
    {
        int size = this.basicLayerProcessorArray.Length;
        for (int index = 0; index < size; index++) {
            LayerProcessor layerProcessorInterface = this.basicLayerProcessorArray[index];
        }
    }

    // throws Exception
    public override void append(AllBinaryLayer layerInterface)
    {
        if (!this.contains(layerInterface)) {
            this.appendProcessors(layerInterface);
            base.append(layerInterface);
        }
    }

    // throws Exception
    public override void appendAt(AllBinaryLayer layerInterface, int index)
    {
        if (!this.contains(layerInterface)) {
            this.appendProcessors(layerInterface);
            base.appendAt(layerInterface, index);
        }
    }

    // throws Exception
    private void appendProcessors(AllBinaryLayer layerInterface)
    {
        this.createLayerManagerEvent.setLayerInterface(layerInterface);
        this.layerManagerEventHandler.fireEvent(this.createLayerManagerEvent);
        LayerProcessor layerProcessorInterface = null;
        for (int index = this.basicLayerProcessorArray.Length; --index >= 0; ) {
            layerProcessorInterface = this.basicLayerProcessorArray[index];
            if (layerProcessorInterface.isProcessorLayer(layerInterface)) {
                layerProcessorInterface.getLayerManager().append(layerInterface);
            }
        }
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void remove(AllBinaryLayer layerInterface)
    {
        this.deleteLayerManagerEvent.setLayerInterface(layerInterface);
        this.layerManagerEventHandler.fireDeleteEvent(this.deleteLayerManagerEvent);
        LayerProcessor layerProcessorInterface = null;
        for (int index = this.basicLayerProcessorArray.Length; --index >= 0; ) {
            layerProcessorInterface = this.basicLayerProcessorArray[index];
            layerProcessorInterface.getLayerManager().remove(layerInterface);
        }
        base.remove(layerInterface);
    }

    // throws Exception
    public virtual void process()
    {
        LayerProcessor layerProcessorInterface = null;
        int size = this.basicLayerProcessorArray.Length;
        for (int index = 0; index < size; index++) {
            layerProcessorInterface = this.basicLayerProcessorArray[index];
            layerProcessorInterface.process(this);
        }
    }

    // throws Exception
    public override void cleanup()
    {
        LayerProcessor layerProcessorInterface = null;
        int size = this.basicLayerProcessorArray.Length;
        for (int index = 0; index < size; index++) {
            layerProcessorInterface = this.basicLayerProcessorArray[index];
            layerProcessorInterface.getLayerManager().cleanup();
        }
        base.cleanup();
    }

}

