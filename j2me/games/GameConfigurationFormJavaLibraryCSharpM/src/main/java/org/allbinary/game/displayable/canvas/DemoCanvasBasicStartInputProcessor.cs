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
//using NullCanvas = javax.microedition.lcdui.NullCanvas;
using RunnableCanvas = org.allbinary.canvas.RunnableCanvas;
using GameCommandsFactory = org.allbinary.game.commands.GameCommandsFactory;
using GameInputStrings = org.allbinary.game.input.GameInputStrings;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.displayable.canvas;

public class DemoCanvasBasicStartInputProcessor : BasicMenuInputProcessor
{
    public DemoCanvasBasicStartInputProcessor(BasicArrayList gameKeyEventList, RunnableCanvas gameCanvas) : base(gameKeyEventList, -1, gameCanvas)
    {
        // base(gameKeyEventList, -1, gameCanvas) is called from the constructor declaration
    }

    // throws Exception
    public override int processInputList()
    {
        BasicArrayList list = this.getGameKeyEventList();
        int size = list.size();
        GameKeyEvent gameKeyEvent = null;
        for (int index = 0; index < size; index++) {
            gameKeyEvent = ((GameKeyEvent) list.objectArray[index]);
            this.logUtil.putF(new StringMaker().append("Start GameKey: ").append(StringUtil.getInstance().toString(gameKeyEvent)).ToString(), this, GameInputStrings.getInstance().PROCESS_INPUT);
        }
        this.getCanvas().getCustomCommandListener().commandAction(GameCommandsFactory.getInstance().START_COMMAND, NullCanvas.NULL_CANVAS);
        return size;
    }

}

