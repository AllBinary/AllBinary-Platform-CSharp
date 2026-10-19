/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2006 AllBinary 
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
using GameInputProcessor = org.allbinary.game.input.GameInputProcessor;

namespace org.allbinary.game.layer.unit;

public class UnitGameInputProcessor : GameInputProcessor
{
    public readonly UnitLayer unitLayer;
    public UnitGameInputProcessor(UnitLayer unitLayer)
    {
        this.unitLayer = unitLayer;
    }

}

