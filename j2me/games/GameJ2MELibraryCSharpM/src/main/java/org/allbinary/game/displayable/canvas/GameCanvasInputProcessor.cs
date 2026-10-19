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
//using Canvas = javax.microedition.lcdui.Canvas;
using GameKey = org.allbinary.game.input.GameKey;
using GameKeyEventSourceInterface = org.allbinary.game.input.GameKeyEventSourceInterface;
using GameKeyFactory = org.allbinary.game.input.GameKeyFactory;
using InputProcessor = org.allbinary.game.input.InputProcessor;
using PlatformInputMappingFactory = org.allbinary.game.input.PlatformInputMappingFactory;
using DownGameKeyEventHandler = org.allbinary.game.input.@event.DownGameKeyEventHandler;
using DownKeyEventHandler = org.allbinary.game.input.@event.DownKeyEventHandler;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using GameKeyEventFactory = org.allbinary.game.input.@event.GameKeyEventFactory;
using UpGameKeyEventHandler = org.allbinary.game.input.@event.UpGameKeyEventHandler;
using InputToGameKeyMapping = org.allbinary.game.input.mapping.InputToGameKeyMapping;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.game.displayable.canvas;

public class GameCanvasInputProcessor : InputProcessor
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AllBinaryGameCanvas allBinaryGameCanvas;
    private readonly DownGameKeyEventHandler downGameKeyEventHandler = DownGameKeyEventHandler.getInstance();
    private readonly UpGameKeyEventHandler upGameKeyEventHandler = UpGameKeyEventHandler.getInstance();
    private readonly DownKeyEventHandler downKeyEventHandler = DownKeyEventHandler.getInstance();
    private readonly SmallIntegerSingletonFactory smallIntegerSingletonFactory = SmallIntegerSingletonFactory.getInstance();
    private readonly InputToGameKeyMapping inputToGameKeyMapping = PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance().getInputMapping();
    public GameCanvasInputProcessor(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        this.allBinaryGameCanvas = allBinaryGameCanvas;
        this.inputToGameKeyMapping.init(this.allBinaryGameCanvas);
    }

    private readonly GameKey NONE = GameKeyFactory.getInstance().NONE;
    private readonly GameKeyEventFactory gameKeyEventFactory = GameKeyEventFactory.getInstance();
    public override void keyPressedByDevice(int keyCode, int deviceId)
    {
        try {
            GameKey gameKey = this.inputToGameKeyMapping.getInstanceForCanvas(this.allBinaryGameCanvas, keyCode);
            if (gameKey != this.NONE) {
                GameKeyEvent gameKeyEvent = this.gameKeyEventFactory.getInstanceForInput(this.allBinaryGameCanvas, gameKey);
                this.downGameKeyEventHandler.fireEvent(gameKeyEvent);
                this.downGameKeyEventHandler.getInstanceForDevice(deviceId).fireEvent(gameKeyEvent);
            } else {
                this.logUtil.putF(new StringMaker().append(this.gameInputStrings.NO_KEY).appendint(keyCode).ToString(), this, this.gameInputStrings.ADD_KEY_EVENT);
            }
            int? keyCodeAsInteger = this.smallIntegerSingletonFactory.getAtNoThrow(keyCode);
            this.downKeyEventHandler.fireEventI(keyCodeAsInteger);
            this.downKeyEventHandler.getInstanceForDevice(deviceId).fireEventI(keyCodeAsInteger);
        } catch (Exception e) {
            this.logUtil.put("Key Event Error", this, this.gameInputStrings.ADD_KEY_EVENT, e);
        }
    }

    public override void keyReleasedByDevice(Canvas canvas, int keyCode, int deviceId)
    {
        this.removeGameKeyEvent(canvas, keyCode, deviceId, false);
    }

    private void removeGameKeyEvent(Canvas canvas, int keyCode, int deviceId, bool repeated)
    {
        try {
            GameKey gameKey = this.inputToGameKeyMapping.getInstanceForCanvas(canvas, keyCode);
            if (gameKey != this.NONE) {
                GameKeyEventSourceInterface gameKeyEventSourceInterface = ((GameKeyEventSourceInterface) canvas);
                GameKeyEvent gameKeyEvent = this.gameKeyEventFactory.getInstanceForInput(gameKeyEventSourceInterface, gameKey);
                this.upGameKeyEventHandler.fireEvent(gameKeyEvent);
                this.upGameKeyEventHandler.getInstanceForDevice(deviceId).fireEvent(gameKeyEvent);
            } else {
                this.logUtil.putF(new StringMaker().append(this.gameInputStrings.NO_KEY).appendint(keyCode).ToString(), this, this.gameInputStrings.REMOVE_KEY_EVENT);
            }
        } catch (Exception e) {
            this.logUtil.put("Key Event Error", this, this.gameInputStrings.REMOVE_KEY_EVENT, e);
        }
    }

}

