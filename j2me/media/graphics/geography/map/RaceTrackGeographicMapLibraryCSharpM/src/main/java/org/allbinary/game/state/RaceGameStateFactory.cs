/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.game.state;

public class RaceGameStateFactory
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static RaceGameStateFactory getInstance()
    {
        if (RaceGameStateFactory.instance == NullUtil.getInstance().NULL_OBJECT) {
            RaceGameStateFactory.instance = new RaceGameStateFactory();
        }
        return ((RaceGameStateFactory) RaceGameStateFactory.instance);
    }

    public readonly GameState START_GAME_STATE = GameStateFactory.getInstance().createGameState("START_GAME_STATE");
    public readonly GameState YELLOW_LIGHT_GAME_STATE = GameStateFactory.getInstance().createGameState("YELLOW_LIGHT_GAME_STATE");
    public readonly GameState RED_LIGHT_GAME_STATE = GameStateFactory.getInstance().createGameState("RED_LIGHT_GAME_STATE");
}

