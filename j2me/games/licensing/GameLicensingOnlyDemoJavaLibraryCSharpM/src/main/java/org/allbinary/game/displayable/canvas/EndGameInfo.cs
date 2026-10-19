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
using GameInfo = org.allbinary.game.GameInfo;
using MyCanvas = org.allbinary.graphics.displayable.MyCanvas;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.displayable.canvas;

public class EndGameInfo
{
    public readonly string NORMAL_GAME_OVER_WIN = "You Won";
    private readonly string TEASER_DEMO_GAME_END_LAST_LEVEL = "End of Demo.";
    private readonly string TEASER_DEMO_GAME_END = "Demo Game Over.";
    private string gameOverStr = StringUtil.getInstance().EMPTY_STRING;
    private string winStr;
    public void update(GameInfo gameInfo, MyCanvas myCanvas)
    {
        if (gameInfo.isLastLevel()) {
            this.setWinStr(this.TEASER_DEMO_GAME_END_LAST_LEVEL);
            this.setGameOverStr(this.TEASER_DEMO_GAME_END_LAST_LEVEL);
        } else {
            this.setWinStr(this.NORMAL_GAME_OVER_WIN);
            this.setGameOverStr(this.TEASER_DEMO_GAME_END);
        }
    }

    public virtual string getGameOverStr()
    {
        return this.gameOverStr;
    }

    public virtual void setGameOverStr(string gameOverStr)
    {
        this.gameOverStr = gameOverStr;
    }

    public virtual string getWinStr()
    {
        return this.winStr;
    }

    public virtual void setWinStr(string winStr)
    {
        this.winStr = winStr;
    }

    public EndGameInfo()
    {
        this.winStr = this.gameOverStr;
    }

}

