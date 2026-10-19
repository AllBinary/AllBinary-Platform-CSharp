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
using Input = org.allbinary.game.input.Input;
using InputFactory = org.allbinary.game.input.InputFactory;
using InputProcessor = org.allbinary.game.input.InputProcessor;
using PlatformKeyFactory = org.allbinary.game.input.PlatformKeyFactory;
using DownKeyEventHandler = org.allbinary.game.input.@event.DownKeyEventHandler;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using GameKeyEventFactory = org.allbinary.game.input.@event.GameKeyEventFactory;
using UpGameKeyEventHandler = org.allbinary.game.input.@event.UpGameKeyEventHandler;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.displayable.canvas;

public class FormInputProcessor : InputProcessor
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly GameKeyEventFactory gameKeyEventFactory = GameKeyEventFactory.getInstance();
    private readonly DownKeyEventHandler downKeyEventHandler = DownKeyEventHandler.getInstance();
    private readonly UpGameKeyEventHandler upGameKeyEventHandler = UpGameKeyEventHandler.getInstance();
    private readonly InputFactory inputFactory = InputFactory.getInstance();
    private readonly PlatformKeyFactory platformKeyFactory = PlatformKeyFactory.getInstance();
    private readonly AllBinaryGameCanvas allBinaryGameCanvas;
    public FormInputProcessor(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        this.allBinaryGameCanvas = allBinaryGameCanvas;
    }

    public override void keyPressedByDevice(int keyCode, int deviceId)
    {
        try {
            PreLogUtil.put(new StringMaker().append(this.inputFactory.KEY_CODE_LABEL).appendint(keyCode).append(CommonSeps.getInstance().SPACE).append(this.inputFactory.DEVICE_ID_LABEL).appendint(deviceId).ToString(), this, this.gameInputStrings.KEY_PRESSED);
            Input input = this.inputFactory.getInstanceById(keyCode);
            GameKeyEvent gameKeyEvent = this.gameKeyEventFactory.getInstanceForInput(this.allBinaryGameCanvas, input);
            this.downKeyEventHandler.fireEventForGameKeyEvent(gameKeyEvent);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.gameInputStrings.ADD_KEY_EVENT, e);
        }
    }

    public override void keyReleasedByDevice(Canvas canvas, int keyCode, int deviceId)
    {
        try {
            Input input = this.inputFactory.getInstanceById(keyCode);
            if (this.platformKeyFactory.isEnter(input)) {
                PreLogUtil.put(new StringMaker().append(this.inputFactory.KEY_CODE_LABEL).appendint(keyCode).append(CommonSeps.getInstance().SPACE).append(this.inputFactory.DEVICE_ID_LABEL).appendint(deviceId).ToString(), this, this.gameInputStrings.KEY_RELEASED);
                GameKey gameKey = GameKeyFactory.getInstance().KEY_NUM0;
                GameKeyEventSourceInterface gameKeyEventSourceInterface = ((GameKeyEventSourceInterface) canvas);
                GameKeyEvent gameKeyEvent = this.gameKeyEventFactory.getInstanceForInput(gameKeyEventSourceInterface, gameKey);
                this.upGameKeyEventHandler.fireEvent(gameKeyEvent);
                this.upGameKeyEventHandler.getInstanceForDevice(deviceId).fireEvent(gameKeyEvent);
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.gameInputStrings.ADD_KEY_EVENT, e);
        }
    }

}

