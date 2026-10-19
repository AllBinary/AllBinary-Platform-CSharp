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
//using Canvas = javax.microedition.lcdui.Canvas;
using ArtificialIntelligenceInterface = org.allbinary.ai.ArtificialIntelligenceInterface;
using ArtificialIntelligenceInterfaceFactoryInterface = org.allbinary.game.ai.ArtificialIntelligenceInterfaceFactoryInterface;
using GameInput = org.allbinary.game.input.GameInput;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using org.allbinary.util;

namespace org.allbinary.game.ag.ai;

public class SpinnerAIFactory : ArtificialIntelligenceInterfaceFactoryInterface
{
    public virtual ArtificialIntelligenceInterface getInstance(ABHashtable<object, object> hashtable, AllBinaryLayer ownerLayerInterface, GameInput gameInput)
    {
        int[] direction = new int[] { Canvas.LEFT };
        return new SpinnerAI(direction, ownerLayerInterface, gameInput);
    }

}

