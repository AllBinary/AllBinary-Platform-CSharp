// Generated Code Do Not Modify

using System;
using System.Linq;
using GameState = org.allbinary.game.state.GameState;
using GameStateFactory = org.allbinary.game.state.GameStateFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace org.allbinary.game.midlet;

public class GameMidletStateFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly GameMidletStateFactory INSTANCE = new GameMidletStateFactory();
    private GameState currentGameState = GameStateFactory.getInstance().NO_GAME_STATE;
    private GameMidletStateFactory()
    {
    }

    public static GameMidletStateFactory getInstance()
    {
        return GameMidletStateFactory.INSTANCE;
    }

    public virtual GameState getCurrentGameState()
    {
        return this.currentGameState;
    }

    public virtual void setCurrentGameState(GameState currentGameState)
    {
        this.logUtil.putF(new StringMaker().append(CommonLabels.getInstance().CURRENT).append(" GameState: ").append(StringUtil.getInstance().toString(currentGameState)).ToString(), this, "setCurrentGameState");
        this.currentGameState = currentGameState;
    }

}

