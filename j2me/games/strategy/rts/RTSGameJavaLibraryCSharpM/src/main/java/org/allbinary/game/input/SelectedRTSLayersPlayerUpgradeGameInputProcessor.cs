/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2003 AllBinary 
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
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;

namespace org.allbinary.game.input;

public class SelectedRTSLayersPlayerUpgradeGameInputProcessor : SelectedRTSLayersPlayerGameInputProcessor
{
    public SelectedRTSLayersPlayerUpgradeGameInputProcessor(SelectedRTSLayersPlayerGameInput selectedRTSLayersPlayerGameInput) : base(selectedRTSLayersPlayerGameInput)
    {
        // base(selectedRTSLayersPlayerGameInput) is called from the constructor declaration
    }

    // throws Exception
    public override void processEvent(AllBinaryLayerManager allbinaryLayerManager, GameKeyEvent gameKeyEvent)
    {
        this.selectedRTSLayersPlayerGameInput.upgrade();
    }

}

