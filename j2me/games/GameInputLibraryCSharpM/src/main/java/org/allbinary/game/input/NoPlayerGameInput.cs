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
using System.Runtime.CompilerServices;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.input;

public class NoPlayerGameInput : PlayerGameInput
{
    private static readonly NoPlayerGameInput SINGLETON = new NoPlayerGameInput();
    public static NoPlayerGameInput getInstance()
    {
        return NoPlayerGameInput.SINGLETON;
    }

    private NoPlayerGameInput() : base(new BasicArrayListD(), new BasicArrayListD(), -1)
    {
        // base(new BasicArrayListD(), new BasicArrayListD(), -1) is called from the constructor declaration
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void onDownGameKeyEvent(GameKeyEvent gameKeyEvent)
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void onUpGameKeyEvent(GameKeyEvent gameKeyEvent)
    {
    }

}

