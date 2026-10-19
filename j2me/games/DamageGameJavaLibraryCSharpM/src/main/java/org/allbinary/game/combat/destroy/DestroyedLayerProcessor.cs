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
using DestroyEventCircularStaticPool = org.allbinary.game.combat.destroy.@event.DestroyEventCircularStaticPool;
using DestroyedEvent = org.allbinary.game.combat.destroy.@event.DestroyedEvent;
using DestroyedEventHandler = org.allbinary.game.combat.destroy.@event.DestroyedEventHandler;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using BasicLayerProcessor = org.allbinary.layer.BasicLayerProcessor;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.combat.destroy;

public class DestroyedLayerProcessor : BasicLayerProcessor
{
    private static BasicLayerProcessor DESTROYED_LAYER_PROCESSOR = BasicLayerProcessor.NULL_LAYER_PROCESSOR;
    private DestroyedLayerProcessor()
    {
    }

    public static void init()
    {
        DestroyedLayerProcessor.DESTROYED_LAYER_PROCESSOR = new DestroyedLayerProcessor();
    }

    public static BasicLayerProcessor getInstance()
    {
        return DestroyedLayerProcessor.DESTROYED_LAYER_PROCESSOR;
    }

    // throws Exception
    public override void process(AllBinaryLayerManager allBinaryLayerManager)
    {
        BasicArrayList list = this.getList();
        int size = list.size();
        DestroyedEventHandler destroyedEventHandler = DestroyedEventHandler.getInstance();
        DestroyEventCircularStaticPool destroyEventCircularStaticPool = DestroyEventCircularStaticPool.getInstance();
        DestroyedEvent destroyedEvent = null;
        AllBinaryLayer layerInterface = null;
        for (int index = 0; index < size; index++) {
            object layerInterfaceCanBeNull = list.objectArray[index];
            if (layerInterfaceCanBeNull != null) {
                layerInterface = ((AllBinaryLayer) layerInterfaceCanBeNull);
                allBinaryLayerManager.remove(layerInterface);
                destroyedEvent = destroyEventCircularStaticPool.getInstanceForLayer(layerInterface);
                destroyedEventHandler.fireEvent(destroyedEvent);
            } else {
                CommonStrings commonStrings = CommonStrings.getInstance();
            }
        }
        list.clear();
    }

}

