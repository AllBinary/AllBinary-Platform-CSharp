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
using BasicAI = org.allbinary.game.ai.BasicAI;

namespace org.allbinary.game.ag.ai;

public class ArrayAI : BasicAI
{
    private readonly ArtificialIntelligenceInterface[] artificialIntelligenceInterfaceArray;
    public ArrayAI(ArtificialIntelligenceInterface[] artificialIntelligenceInterface, AllBinaryLayer ownerLayerInterface, GameInput gameInput) : base(ownerLayerInterface, gameInput)
    {
        // base(ownerLayerInterface, gameInput) is called from the constructor declaration
        this.artificialIntelligenceInterfaceArray = artificialIntelligenceInterface;
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        int size = this.artificialIntelligenceInterfaceArray.Length;
        for (int index = 0; index < size; index++) {
            this.artificialIntelligenceInterfaceArray[index].processAI(allBinaryLayerManager);
        }
    }

    public virtual ArtificialIntelligenceInterface[] getArtificialIntelligenceInterface()
    {
        return this.artificialIntelligenceInterfaceArray;
    }

}

