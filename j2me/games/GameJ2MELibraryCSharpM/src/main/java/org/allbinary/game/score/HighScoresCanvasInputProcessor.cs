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
//using Graphics = javax.microedition.lcdui.Graphics;
using PlayerGameInput = org.allbinary.game.input.PlayerGameInput;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using HighScoresCanvas = org.allbinary.game.score.displayable.HighScoresCanvas;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.score;

public class HighScoresCanvasInputProcessor : PlayerGameInput
{
    private readonly HighScoresCanvas highScoresCanvas;
    public HighScoresCanvasInputProcessor(HighScoresCanvas highScoresCanvas) : base(new BasicArrayListD(), new BasicArrayListD(), -1)
    {
        // base(new BasicArrayListD(), new BasicArrayListD(), -1) is called from the constructor declaration
        this.highScoresCanvas = highScoresCanvas;
    }

    public virtual void open()
    {
    }

    public virtual void close()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void onPressGameKeyEvent(GameKeyEvent gameKeyEvent)
    {
        base.onPressGameKeyEvent(gameKeyEvent);
        this.update();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void onDownGameKeyEvent(GameKeyEvent gameKeyEvent)
    {
        base.onDownGameKeyEvent(gameKeyEvent);
        this.update();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void onUpGameKeyEvent(GameKeyEvent gameKeyEvent)
    {
        base.onUpGameKeyEvent(gameKeyEvent);
        this.update();
    }

    public virtual void paint(Graphics graphics)
    {
    }

    public virtual HighScoresCanvas getHighScoresCanvas()
    {
        return this.highScoresCanvas;
    }

}

