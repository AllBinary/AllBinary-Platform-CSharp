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
using ArtificialIntelligenceInterfaceFactoryInterface = org.allbinary.game.ai.ArtificialIntelligenceInterfaceFactoryInterface;
using BasicAI = org.allbinary.game.ai.BasicAI;
using InputProbability = org.allbinary.game.ag.ai.InputProbability;
using GameInput = org.allbinary.game.input.GameInput;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using Visitor = org.allbinary.logic.util.visitor.Visitor;
using org.allbinary.util;

namespace org.allbinary.game.ag.ai.tactical;

public class BasicRandomAIFactory : ArtificialIntelligenceInterfaceFactoryInterface
{
    // throws Exception
    public virtual ArtificialIntelligenceInterface getInstance(ABHashtable<object, object> hashtable, AllBinaryLayer ownerLayerInterface, GameInput gameInput)
    {
        Visitor visitor = ((Visitor) hashtable.get(((object) BasicAI.AI_VISITOR)));
        if (visitor == null) {
            throw new Exception("No Visitor Provided");
        }
        InputProbability inputProbability = ((InputProbability) hashtable.get(((object) InputProbability.INPUT_PROBABILITY)));
        return new BasicRandomAI(ownerLayerInterface, gameInput, inputProbability, visitor);
    }

}

