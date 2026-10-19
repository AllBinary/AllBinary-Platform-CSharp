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
using GameInput = org.allbinary.game.input.GameInput;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using org.allbinary.util;

namespace org.allbinary.game.ag.ai;

public class NullAIFactory : ArtificialIntelligenceInterfaceFactoryInterface
{
    private static NullAI NULL_AI = new NullAI();
    public virtual ArtificialIntelligenceInterface getInstance(ABHashtable<object, object> hashtable, AllBinaryLayer ownerLayerInterface, GameInput gameInput)
    {
        return NullAIFactory.NULL_AI;
    }

    public static ArtificialIntelligenceInterface getInstance()
    {
        return NullAIFactory.NULL_AI;
    }

}

