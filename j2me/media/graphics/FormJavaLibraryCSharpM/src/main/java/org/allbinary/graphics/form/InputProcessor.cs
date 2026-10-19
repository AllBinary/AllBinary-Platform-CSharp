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
using Processor = org.allbinary.canvas.Processor;
using PlayerGameInputCompositeInterface = org.allbinary.game.input.PlayerGameInputCompositeInterface;

namespace org.allbinary.graphics.form;

public class InputProcessor : Processor
{
    private readonly PlayerGameInputCompositeInterface playerGameInputCompositeInterface;
    public InputProcessor(PlayerGameInputCompositeInterface playerGameInputCompositeInterface)
    {
        this.playerGameInputCompositeInterface = playerGameInputCompositeInterface;
    }

    // throws Exception
    public override void process()
    {
        this.playerGameInputCompositeInterface.getPlayerGameInput().update();
    }

}

