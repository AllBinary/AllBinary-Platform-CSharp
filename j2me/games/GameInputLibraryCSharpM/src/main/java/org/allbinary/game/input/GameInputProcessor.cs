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
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;

namespace org.allbinary.game.input;

public class GameInputProcessor
{
    private static readonly GameInputProcessor instance = new GameInputProcessor();
    public static GameInputProcessor getInstance()
    {
        return GameInputProcessor.instance;
    }

    public GameInputProcessor()
    {
    }

    // throws Exception
    public virtual void processEvent(AllBinaryLayerManager allbinaryLayerManager, GameKeyEvent gameKeyEvent)
    {
    }

    // throws Exception
    public virtual void processReleasedEvent(AllBinaryLayerManager allbinaryLayerManager, GameKeyEvent gameKeyEvent)
    {
    }

    // throws Exception
    public virtual void processAnalog(AllBinaryLayerManager allbinaryLayerManager, GameKeyEvent gameKeyEvent, int analogValue)
    {
    }

    // throws Exception
    public virtual void process(AllBinaryLayerManager allbinaryLayerManager, int? keyAsInteger)
    {
    }

    // throws Exception
    public virtual void processReleased(AllBinaryLayerManager allbinaryLayerManager, int? keyAsInteger)
    {
    }

}

