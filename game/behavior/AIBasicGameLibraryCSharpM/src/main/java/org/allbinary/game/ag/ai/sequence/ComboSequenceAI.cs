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
using ArtificialIntelligenceInterface = org.allbinary.ai.ArtificialIntelligenceInterface;
using GameInput = org.allbinary.game.input.GameInput;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;

namespace org.allbinary.game.ag.ai.sequence;

public class ComboSequenceAI : SequenceAI
{
    public ComboSequenceAI(ArtificialIntelligenceInterface[] artificialIntelligenceInterface, AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(artificialIntelligenceInterface, ownerLayerInterface, gameInput)
    {
        // base(artificialIntelligenceInterface, ownerLayerInterface, gameInput) is called from the constructor declaration
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        ArtificialIntelligenceInterface[] artificialIntelligenceInterfaceArray = this.getArtificialIntelligenceInterface();
        int size = artificialIntelligenceInterfaceArray.Length;
        for (int index = 0; index < size; index++) {
            this.setIndex(index);
            base.processAI(allBinaryLayerManager);
        }
    }

}

