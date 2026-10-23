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
//using CommandListener = javax.microedition.lcdui.CommandListener;
//using Graphics = javax.microedition.lcdui.Graphics;
//using Item = javax.microedition.lcdui.Item;
using GameState = org.allbinary.game.state.GameState;
using GameStateFactory = org.allbinary.game.state.GameStateFactory;
using StdUtil = org.allbinary.logic.StdUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using org.allbinary.util;

namespace org.allbinary.game.displayable.canvas;

public class NullGameCanvasRunnable : GameCanvasRunnableInterface
{
    public static readonly NullGameCanvasRunnable NULL_GAME_CANVAS_RUNNABLE = new NullGameCanvasRunnable();
    public readonly GameStateFactory gameStateFactory = GameStateFactory.getInstance();
    public virtual string getTitle()
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    public virtual bool isInitialized()
    {
        return false;
    }

    public virtual bool isPaused()
    {
        return false;
    }

    public virtual void unPause()
    {
    }

    public virtual void pause()
    {
    }

    public virtual bool isHighScoreSubmitted()
    {
        return false;
    }

    // throws Exception
    public virtual void setHighScoreSubmitted(bool highScoreSubmitted)
    {
    }

    // throws Exception
    public virtual void processGameOver()
    {
    }

    public virtual bool isGameOver()
    {
        return false;
    }

    public virtual void initCommands(CommandListener cmdListener)
    {
    }

    // throws Exception
    public virtual ABHashtable<object, object> getCurrentStateHashtable()
    {
        return StdUtil.getInstance().NULL_TABLE;
    }

    // throws Exception
    public virtual ABHashtable<object, object> getLoadStateHashtable()
    {
        return StdUtil.getInstance().NULL_TABLE;
    }

    // throws Exception
    public virtual void setLoadStateHashtable(ABHashtable<object, object> hashtable)
    {
    }

    public virtual int getType()
    {
        return -1;
    }

    // throws Exception
    public virtual void setGameState(GameState gameState)
    {
    }

    public virtual GameState getGameState()
    {
        return this.gameStateFactory.NO_GAME_STATE;
    }

    public virtual void itemStateChanged(Item item)
    {
    }

    public virtual void paint(Graphics graphics)
    {
    }

    public virtual void paintThreed(Graphics graphics)
    {
    }

    public virtual bool isRunning()
    {
        return false;
    }

    public virtual void setRunning(bool isRunning)
    {
    }

    // throws Exception
    public virtual void setThread(global::org.allbinary.thread.NullThread thread)
    {
    }

    public virtual void run()
    {
    }

}

