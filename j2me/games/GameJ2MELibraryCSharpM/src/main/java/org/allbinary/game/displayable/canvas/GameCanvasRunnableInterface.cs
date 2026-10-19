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
//using CommandListener = javax.microedition.lcdui.CommandListener;
//using ItemStateListener = javax.microedition.lcdui.ItemStateListener;
using GameStateCompositeInterface = org.allbinary.game.state.GameStateCompositeInterface;
using PaintableInterface = org.allbinary.graphics.paint.PaintableInterface;
using RunnableInterface = org.allbinary.thread.RunnableInterface;
using org.allbinary.util;

namespace org.allbinary.game.displayable.canvas;

public interface GameCanvasRunnableInterface : RunnableInterface, PaintableInterface, ItemStateListener, GameStateCompositeInterface
{
    string getTitle();

    bool isInitialized();

    bool isPaused();

    void unPause();

    void pause();

    bool isHighScoreSubmitted();

    // throws Exception
    void setHighScoreSubmitted(bool highScoreSubmitted);

    // throws Exception
    void processGameOver();

    bool isGameOver();

    void initCommands(CommandListener cmdListener);

    // throws Exception
    ABHashtable<object, object> getCurrentStateHashtable();

    // throws Exception
    ABHashtable<object, object> getLoadStateHashtable();

    // throws Exception
    void setLoadStateHashtable(ABHashtable<object, object> hashtable);

    int getType();

}

