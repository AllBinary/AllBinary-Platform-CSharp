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

public class NumberLayersSequenceAI : SequenceAI
{
    private int numberOfLayersLeft;
    public NumberLayersSequenceAI(int numberOfEnemiesLeft, ArtificialIntelligenceInterface[] artificialIntelligenceInterface, AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(artificialIntelligenceInterface, ownerLayerInterface, gameInput)
    {
        // base(artificialIntelligenceInterface, ownerLayerInterface, gameInput) is called from the constructor declaration
        this.numberOfLayersLeft = numberOfEnemiesLeft;
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        if (this.getIndex() == 0) {
            if (allBinaryLayerManager.getSize() < this.numberOfLayersLeft) {
                this.setIndex(1);
            }
        }
        base.processAI(allBinaryLayerManager);
    }

}

