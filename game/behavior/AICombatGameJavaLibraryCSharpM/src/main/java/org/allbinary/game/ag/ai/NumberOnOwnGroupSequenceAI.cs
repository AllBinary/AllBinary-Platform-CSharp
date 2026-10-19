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
using SequenceAI = org.allbinary.game.ag.ai.sequence.SequenceAI;
using GameInput = org.allbinary.game.input.GameInput;
using GroupLayerManagerListener = org.allbinary.game.layer.identification.GroupLayerManagerListener;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;

namespace org.allbinary.game.ag.ai;

public class NumberOnOwnGroupSequenceAI : SequenceAI
{
    private int?[] numberOnSameTeam;
    public NumberOnOwnGroupSequenceAI(int?[] numberOnSameTeam, ArtificialIntelligenceInterface[] artificialIntelligenceInterface, AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(artificialIntelligenceInterface, ownerLayerInterface, gameInput)
    {
        // base(artificialIntelligenceInterface, ownerLayerInterface, gameInput) is called from the constructor declaration
        this.numberOnSameTeam = numberOnSameTeam;
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        AllBinaryLayer layerInterface = this.getOwnerLayerInterface();
        int index = this.getIndex();
        if (this.numberOnSameTeam.Length > index) {
            int size = GroupLayerManagerListener.getInstance().getGroupSizeFromInterface(layerInterface);
            if (((int) this.numberOnSameTeam[index]) > size) {
                this.next();
            }
        }
        base.processAI(allBinaryLayerManager);
    }

}

