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
using GameKeyFactory = org.allbinary.game.input.GameKeyFactory;
using PlayerGameInput = org.allbinary.game.input.PlayerGameInput;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using GameKeyEventUtil = org.allbinary.game.input.@event.GameKeyEventUtil;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using SpecialGameInputFactory = org.allbinary.game.layer.special.SpecialGameInputFactory;
using SpecialGameInputInterface = org.allbinary.game.layer.special.SpecialGameInputInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.displayable.canvas;

public class CheatGameInputProcessor : PlayerGameInput
{
    private readonly string PROCESS_GAME = "processGame";
    private readonly AllBinaryGameCanvas gameCanvas;
    public static SpecialGameInputInterface inputProcessor = SpecialGameInputFactory.NO_SPECIAL_GAME_INPUT;
    public CheatGameInputProcessor(AllBinaryGameCanvas gameCanvas) : base(new BasicArrayListD(), new BasicArrayListD(), -1)
    {
        // base(new BasicArrayListD(), new BasicArrayListD(), -1) is called from the constructor declaration
        this.gameCanvas = gameCanvas;
    }

    private readonly GameKeyFactory gameKeyFactory = GameKeyFactory.getInstance();
    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void update()
    {
        try {
            AllBinaryGameLayerManager gameLayerManager = this.gameCanvas.getLayerManager();
            BasicArrayList list = this.getGameKeyEventList();
            int size = list.size();
            for (int index = 0; index < size; index++) {
                object anyType = list.objectArray[index];
                int key = GameKeyEventUtil.getKey(anyType);
                if (key == this.gameKeyFactory.LEVEL_DOWN.getId()) {
                    CheatGameInputProcessor.inputProcessor.strafeLeft();
                    break;
                } else if (key == this.gameKeyFactory.LEVEL_UP.getId()) {
                    CheatGameInputProcessor.inputProcessor.strafeRight();
                    break;
                }
                if (key == this.gameKeyFactory.LEFT.getId()) {
                    CheatGameInputProcessor.inputProcessor.left();
                    break;
                } else if (key == this.gameKeyFactory.RIGHT.getId()) {
                    CheatGameInputProcessor.inputProcessor.right();
                    break;
                } else if (key == this.gameKeyFactory.UP.getId()) {
                    CheatGameInputProcessor.inputProcessor.up();
                    break;
                } else if (key == this.gameKeyFactory.DOWN.getId()) {
                    CheatGameInputProcessor.inputProcessor.down();
                    break;
                } else if (key == this.gameKeyFactory.KEY_NUM1.getId()) {
                    CheatGameInputProcessor.inputProcessor.special1(gameLayerManager, GameKeyEvent.NONE);
                    break;
                } else if (key == this.gameKeyFactory.KEY_NUM3.getId()) {
                    CheatGameInputProcessor.inputProcessor.special2(gameLayerManager, GameKeyEvent.NONE);
                    break;
                }
            }
            list.clear();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.UPDATE, e);
        }
    }

}

