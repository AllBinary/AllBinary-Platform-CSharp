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

namespace org.allbinary.game;

public class GameStrings
{
    private static readonly GameStrings instance = new GameStrings();
    public static GameStrings getInstance()
    {
        return GameStrings.instance;
    }

    public readonly string PROCESS_TICK = "processTick";
    public readonly string ON_GAME_INITIALIZED = "onGameInitialized";
    public readonly string UPDATESURFACE = "updateSurface";
    public readonly string ON_SET_DISPLAYABLE = "onSetDisplayable";
    public readonly string UNPAUSE = "unPause";
    public readonly string TOGGLE_MENU = "toggleMenu";
    public readonly string SET_GAME_OVER = "setGameOver";
    public readonly string GAME_STATE = "Game State: ";
    public readonly string SET_GAME_STATE = "setGameState";
    public readonly string STOP_GAME_CANVAS_RUNNABLE_INTERFACE = "stopGameCanvasRunnableInterface";
}

