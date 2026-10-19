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
using BasicRandomAIFactory = org.allbinary.game.ag.ai.tactical.BasicRandomAIFactory;
using ArtificialIntelligenceInterfaceFactoryInterface = org.allbinary.game.ai.ArtificialIntelligenceInterfaceFactoryInterface;
using BasicAI = org.allbinary.game.ai.BasicAI;
using GameInput = org.allbinary.game.input.GameInput;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using Visitor = org.allbinary.logic.util.visitor.Visitor;
using org.allbinary.util;

namespace org.allbinary.game.ag.ai;

public class DiveAndDirectionalTrackingAIFactory : ArtificialIntelligenceInterfaceFactoryInterface
{
    // throws Exception
    public virtual ArtificialIntelligenceInterface getInstance(ABHashtable<object, object> hashtable, AllBinaryLayer ownerLayerInterface, GameInput gameInput)
    {
        object visitorCanBeNull = hashtable.get(((object) BasicAI.AI_VISITOR));
        if (visitorCanBeNull == null) {
            visitorCanBeNull = ThrustAIVisitorFactory.getInstance();
        }
        ABHashtable<object, object> hashtable2 = new BasicProbabilityAIDataFactory().getInstance();
        hashtable2.put(BasicAI.AI_VISITOR, LastKeyAIVisitorFactory.getInstance());
        ArtificialIntelligenceInterface artificialIntelligenceInterface = new BasicRandomAIFactory().getInstance(hashtable2, ownerLayerInterface, gameInput);
        return new DiveAndDirectionalTrackingAI(ownerLayerInterface, artificialIntelligenceInterface, gameInput, ((Visitor) visitorCanBeNull));
    }

}

