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
    private readonly string NORMAL_GAME_OVER = "Game Over";
    public readonly string NORMAL_GAME_OVER_WIN = "You Won";
    private string gameOverStr = StringUtil.getInstance().EMPTY_STRING;
    private string winStr;
    public EndGameInfo()
    {
        this.winStr = this.gameOverStr;
    }

    public virtual void update(GameInfo gameInfo, MyCanvas myCanvas)
    {
        this.setGameOverStr(this.NORMAL_GAME_OVER);
        this.setWinStr(this.NORMAL_GAME_OVER_WIN);
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

}

