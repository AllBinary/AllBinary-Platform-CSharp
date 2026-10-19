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
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.game.state;

public class GameStateFactory
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static GameStateFactory getInstance()
    {
        if (GameStateFactory.instance == NullUtil.getInstance().NULL_OBJECT) {
            GameStateFactory.instance = new GameStateFactory();
        }
        return ((GameStateFactory) GameStateFactory.instance);
    }

    private int index = 0;
    public readonly GameState NO_GAME_STATE;
    public readonly GameState PLAYING_GAME_STATE;
    public readonly GameState SHOW_END_RESULT_GAME_STATE;
    public readonly GameState SHOW_HIGH_SCORE_GAME_STATE;
    private GameStateFactory()
    {
        this.NO_GAME_STATE = this.createGameState("NO_GAME_STATE");
        this.PLAYING_GAME_STATE = this.createGameState("PLAYING_GAME_STATE");
        this.SHOW_END_RESULT_GAME_STATE = this.createGameState("SHOW_END_RESULT_GAME_STATE");
        this.SHOW_HIGH_SCORE_GAME_STATE = this.createGameState("SHOW_HIGH_SCORE_GAME_STATE");
    }

    public virtual GameState createGameState(string name)
    {
        return new GameState(name, this.index++);
    }

}

