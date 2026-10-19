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
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
//using NullCommandListener = javax.microedition.lcdui.NullCommandListener;
using Processor = org.allbinary.canvas.Processor;
using GameCommandsFactory = org.allbinary.game.commands.GameCommandsFactory;
using Features = org.allbinary.game.configuration.feature.Features;
using InputFeatureFactory = org.allbinary.game.configuration.feature.InputFeatureFactory;
using RepaintBehavior = org.allbinary.game.displayable.RepaintBehavior;
using GameInputStrings = org.allbinary.game.input.GameInputStrings;
using GameKey = org.allbinary.game.input.GameKey;
using GameKeyFactory = org.allbinary.game.input.GameKeyFactory;
using PlatformInputMappingFactory = org.allbinary.game.input.PlatformInputMappingFactory;
using DownGameKeyEventHandler = org.allbinary.game.input.@event.DownGameKeyEventHandler;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using GameKeyEventFactory = org.allbinary.game.input.@event.GameKeyEventFactory;
using GameKeyEventHandler = org.allbinary.game.input.@event.GameKeyEventHandler;
using UpGameKeyEventHandler = org.allbinary.game.input.@event.UpGameKeyEventHandler;
using InputToGameKeyMapping = org.allbinary.game.input.mapping.InputToGameKeyMapping;
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using MyCanvas = org.allbinary.graphics.displayable.MyCanvas;
using DisplayChangeEvent = org.allbinary.graphics.displayable.@event.DisplayChangeEvent;
using DisplayChangeEventHandler = org.allbinary.graphics.displayable.@event.DisplayChangeEventHandler;
using DisplayChangeEventListener = org.allbinary.graphics.displayable.@event.DisplayChangeEventListener;
using ScreenRepaintProcessorFactory = org.allbinary.graphics.displayable.screen.ScreenRepaintProcessorFactory;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using CommandCurrentSelectionFormFactory = org.allbinary.graphics.form.CommandCurrentSelectionFormFactory;
using FormPaintable = org.allbinary.graphics.form.FormPaintable;
using FormTypeFactory = org.allbinary.graphics.form.FormTypeFactory;
using PaintableForm = org.allbinary.graphics.form.PaintableForm;
using ScrollSelectionForm = org.allbinary.graphics.form.ScrollSelectionForm;
using ScrollSelectionFormNoneFactory = org.allbinary.graphics.form.ScrollSelectionFormNoneFactory;
using CommandTextItemArrayFactory = org.allbinary.graphics.form.item.CommandTextItemArrayFactory;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using AllCommandsVisitor = org.allbinary.graphics.form.item.validation.AllCommandsVisitor;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using Paintable = org.allbinary.graphics.paint.Paintable;
using BasicMotionGesturesHandler = org.allbinary.input.motion.gesture.observer.BasicMotionGesturesHandler;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using CommonSeps = org.allbinary.@string.CommonSeps;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.displayable.canvas;

public class GameCommandCanvas : MyCanvas, MenuListener, DisplayChangeEventListener, UpdateMyFontInterface
{
    private readonly Processor repaintProcessor;
    public readonly GameInputStrings gameInputStrings = GameInputStrings.getInstance();
    private static readonly int id = 0;
    public readonly BasicColor foregroundBasicColor;
    public readonly BasicColor backgroundBasicColor;
    public readonly InputToGameKeyMapping inputToGameKeyMapping = PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance().getInputMapping();
    public readonly GameKeyFactory gameKeyFactory = GameKeyFactory.getInstance();
    private readonly GameKeyEventFactory gameKeyEventFactory = GameKeyEventFactory.getInstance();
    private readonly DownGameKeyEventHandler downGameKeyEventHandler = DownGameKeyEventHandler.getInstance();
    private readonly UpGameKeyEventHandler upGameKeyEventHandler = UpGameKeyEventHandler.getInstance();
    public readonly RepaintBehavior repaintBehavior;
    public readonly MyFontProcessor updateMyFontProcessor;
    public MyFontProcessor myFontProcessor;
    public int foregroundColor;
    public int backgroundColor;
    private BasicMenuInputProcessor menuInputProcessor = NoMenuInputProcessor.getInstance();
    private Paintable menuPaintable = NullPaintable.getInstance();
    private PaintableForm menuForm = PaintableForm.getNullPaintableForm();
    private bool isSingleKeyRepeatableProcessing = Features.getInstance().isFeature(InputFeatureFactory.getInstance().SINGLE_KEY_REPEAT_PRESS);
    public int fontHeight = 0;
    public GameCommandCanvas(CommandListener cmdListener, string name, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor) : base(name, CanvasStrings.getInstance().EMPTY_CHILD_NAME_LIST)
    {
        this.repaintProcessor = ScreenRepaintProcessorFactory.getInstance().create(this);
        this.updateMyFontProcessor = new UpdateMyFontProcessor(this);
        this.myFontProcessor = this.updateMyFontProcessor;
        // base(name, CanvasStrings.getInstance().EMPTY_CHILD_NAME_LIST) is called from the constructor declaration
        this.repaintBehavior = RepaintBehavior.getInstance();
        this.foregroundBasicColor = foregroundBasicColor;
        this.backgroundBasicColor = backgroundBasicColor;
        this.foregroundColor = ((int) this.foregroundBasicColor);
        this.backgroundColor = ((int) this.backgroundBasicColor);
        this.initCommands(cmdListener);
        if (cmdListener != NullCommandListener.NULL_COMMAND_LISTENER) {
            try {
                this.initMenu();
                this.repaintProcessor.process();
            } catch (Exception e) {
                throw new SystemException();
            }
        }
    }

    public override void updateMeasurement(Graphics graphics)
    {
        try {
            Font font = graphics.getFont();
            this.logUtil.putF(new StringMaker().append(this.commonStrings.START).append(this.canvasStrings.FD_WIDTH).appendint(((int) MyFontProcessor.defaultCharWidth(font))).append(this.canvasStrings.FD_HEIGHT).appendint(((int) font.getHeight())).ToString(), this, this.canvasStrings.UPDATE_MEASUREMENT);
            this.fontHeight = font.getHeight();
            Rectangle rectangle = this.createRectangle(this.menuForm.size());
            this.menuForm.init(rectangle, FormTypeFactory.getInstance().VERTICAL_CENTER_FORM);
            this.update();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.canvasStrings.ON_DISPLAY_CHANGE_EVENT, e);
        }
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    public override void onDisplayChangeEvent(DisplayChangeEvent displayChangeEvent)
    {
        this.logUtil.putF(new StringMaker().append(this.commonStrings.START).append(DisplayInfoSingleton.getInstance().ToString()).ToString(), this, this.canvasStrings.ON_DISPLAY_CHANGE_EVENT);
        this.myFontProcessor = this.updateMyFontProcessor;
    }

    public virtual void initCommands(CommandListener cmdListener)
    {
        this.removeAllCommands();
        this.addCommand(GameCommandsFactory.getInstance().CLOSE_AND_SHOW_GAME_CANVAS);
        this.setCommandListener(cmdListener);
    }

    // throws Exception
    protected virtual void initMenu()
    {
        ScrollSelectionForm form = this.createForm();
        this.menuForm = form;
        if (form != ScrollSelectionFormNoneFactory.getInstance()) {
            this.setMenuInputProcessor(new ImmediateCommandFormInputProcessor(new BasicArrayListD(), -1, this, form));
            this.menuPaintable = new FormPaintable(form);
        }
        this.repaintBehavior.onChangeRepaint(this);
    }

    // throws Exception
    public virtual ScrollSelectionForm createForm()
    {
        ABCustomItem[] items = new CommandTextItemArrayFactory(new AllCommandsVisitor()).getInstance(this.getCommandStack(), this.backgroundBasicColor, this.foregroundBasicColor);
        Rectangle rectangle = this.createRectangle(items.Length);
        return CommandCurrentSelectionFormFactory.getInstance(StringUtil.getInstance().EMPTY_STRING, items, rectangle, FormTypeFactory.getInstance().VERTICAL_CENTER_FORM, 15, false, this.backgroundBasicColor, this.foregroundBasicColor);
    }

    public virtual Rectangle createRectangle(int size)
    {
        int height = size * this.fontHeight;
        int startY = (this.displayInfo.getLastHeight() * 2 / 3) - height;
        PointFactory pointFactory = PointFactory.getInstance();
        Rectangle rectangle = new Rectangle(pointFactory.createXY(30, startY), this.displayInfo.getLastWidth() - 30, startY);
        return rectangle;
    }

    public override void open()
    {
        this.logUtil.putF(this.commonStrings.START, this, "open");
        BasicMotionGesturesHandler.getInstance().addListenerInterface(this.getMenuInputProcessor());
        GameKeyEventHandler.getInstance().addListener(this.getMenuInputProcessor());
        DisplayChangeEventHandler.getInstance().addListenerInterface(this);
    }

    // throws Exception
    public override void close()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CLOSE);
        BasicMotionGesturesHandler.getInstance().removeListener(this.getMenuInputProcessor());
        GameKeyEventHandler.getInstance().removeListener(this.getMenuInputProcessor());
        DisplayChangeEventHandler.getInstance().removeListener(this);
    }

    // throws Exception
    public virtual void update()
    {
        this.repaintProcessor.process();
    }

    public override int getSourceId()
    {
        return GameCommandCanvas.id;
    }

    public override void keyPressed(int keyCode)
    {
        this.keyPressedByDevice(keyCode, 0);
    }

    public override void keyReleased(int keyCode)
    {
        this.keyReleasedByDevice(keyCode, 0);
    }

    public override void keyRepeated(int keyCode)
    {
        this.keyRepeatedByDevice(keyCode, 0);
    }

    public override void keyPressedByDevice(int keyCode, int deviceId)
    {
        this.logUtil.putF(new StringMaker().append(CommonSeps.getInstance().SPACE).appendint(keyCode).ToString(), this, this.gameInputStrings.KEY_PRESSED);
        this.addGameKeyEvent(keyCode, 0, false);
    }

    public override void keyReleasedByDevice(int keyCode, int deviceId)
    {
        this.removeGameKeyEvent(keyCode, deviceId, false);
    }

    public override void keyRepeatedByDevice(int keyCode, int deviceId)
    {
        if (this.isSingleKeyRepeatableProcessing) {
            this.addGameKeyEvent(keyCode, deviceId, true);
        }
    }

    private void addGameKeyEvent(int keyCode, int deviceId, bool repeated)
    {
        try {
            GameKey gameKey = this.inputToGameKeyMapping.getInstanceForCanvas(this, keyCode);
            if (gameKey != this.gameKeyFactory.NONE) {
                GameKeyEvent gameKeyEvent = this.gameKeyEventFactory.getInstanceForInput(this, gameKey);
                this.downGameKeyEventHandler.fireEvent(gameKeyEvent);
                this.downGameKeyEventHandler.getInstanceForDevice(deviceId).fireEvent(gameKeyEvent);
            } else {
                this.logUtil.putF(new StringMaker().append(this.gameInputStrings.NO_KEY).appendint(keyCode).ToString(), this, this.gameInputStrings.ADD_KEY_EVENT);
            }
        } catch (Exception e) {
            this.logUtil.put("Key Event Error", this, this.gameInputStrings.ADD_KEY_EVENT, e);
        }
    }

    private void removeGameKeyEvent(int keyCode, int deviceId, bool repeated)
    {
        try {
            GameKey gameKey = this.inputToGameKeyMapping.getInstanceForCanvas(this, keyCode);
            if (gameKey != this.gameKeyFactory.NONE) {
                GameKeyEvent gameKeyEvent = this.gameKeyEventFactory.getInstanceForInput(this, gameKey);
                this.upGameKeyEventHandler.fireEvent(gameKeyEvent);
                this.upGameKeyEventHandler.getInstanceForDevice(deviceId).fireEvent(gameKeyEvent);
            } else {
                this.logUtil.putF(new StringMaker().append(this.gameInputStrings.NO_KEY).appendint(keyCode).ToString(), this, this.gameInputStrings.REMOVE_KEY_EVENT);
            }
        } catch (Exception e) {
            this.logUtil.put("Key Event Error", this, this.gameInputStrings.REMOVE_KEY_EVENT, e);
        }
    }

    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        this.menuPaintable.paint(graphics);
        this.repaintBehavior.repaint(this);
    }

    private void setMenuInputProcessor(BasicMenuInputProcessor menuInputProcessor)
    {
        this.menuInputProcessor = menuInputProcessor;
    }

    protected virtual BasicMenuInputProcessor getMenuInputProcessor()
    {
        return this.menuInputProcessor;
    }

}

