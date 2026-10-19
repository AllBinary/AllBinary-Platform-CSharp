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
//using Canvas = javax.microedition.lcdui.Canvas;
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
using GameKeyEventHandler = org.allbinary.game.input.@event.GameKeyEventHandler;
using GameKeyEventUtil = org.allbinary.game.input.@event.GameKeyEventUtil;
using HighScoresCanvas = org.allbinary.game.score.displayable.HighScoresCanvas;
using Anchor = org.allbinary.graphics.Anchor;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.score;

public class HighScoresCanvasLevelChangeInputProcessor : HighScoresCanvasInputProcessor, UpdateMyFontInterface
{
    private readonly DisplayInfoSingleton displayInfoSingleton = DisplayInfoSingleton.getInstance();
    private readonly string INSTRUCTIONS = "(Right = Next Track, Left = Previous Track)";
    private MyFontProcessor myFontProcessor;
    private int anchor = Anchor.TOP_LEFT;
    private int fontHeight = 0;
    public HighScoresCanvasLevelChangeInputProcessor(HighScoresCanvas highScoresCanvas) : base(highScoresCanvas)
    {
        this.myFontProcessor = new UpdateMyFontProcessor(this);
        // base(highScoresCanvas) is called from the constructor declaration
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.fontHeight = font.getHeight();
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public override void open()
    {
        GameKeyEventHandler.getInstance().addListener(this);
    }

    public override void close()
    {
        GameKeyEventHandler.getInstance().removeListener(this);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void update()
    {
        BasicArrayList list = this.getGameKeyEventList();
        int size = list.size();
        for (int index = 0; index < size; index++) {
            object anyType = list.objectArray[index];
            int key = GameKeyEventUtil.getKey(anyType);
            if (key == Canvas.RIGHT) {
                this.getHighScoresCanvas().getGameInfo().nextGameLevel();
            } else if (key == Canvas.LEFT) {
                this.getHighScoresCanvas().getGameInfo().previousGameLevel();
            }
            this.getHighScoresCanvas().executeUpdate();
        }
        list.clear();
    }

    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        int width = this.displayInfoSingleton.getLastWidth();
        int topScoresWidth = (graphics.getFont().stringWidth(this.INSTRUCTIONS) >> 1);
        graphics.drawString(this.INSTRUCTIONS, (width >> 1) - topScoresWidth, this.fontHeight * 2, this.anchor);
    }

}

