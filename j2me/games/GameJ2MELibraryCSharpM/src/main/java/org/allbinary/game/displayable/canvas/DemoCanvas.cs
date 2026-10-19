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
//using Command = javax.microedition.lcdui.Command;
//using CommandListener = javax.microedition.lcdui.CommandListener;
//using Graphics = javax.microedition.lcdui.Graphics;
//using Item = javax.microedition.lcdui.Item;
using J2MEUtil = org.allbinary.J2MEUtil;
using Animation = org.allbinary.animation.Animation;
using IndexedAnimationBehavior = org.allbinary.animation.IndexedAnimationBehavior;
using SpecialAnimation = org.allbinary.animation.special.SpecialAnimation;
using GameAdStateFactory = org.allbinary.business.advertisement.GameAdStateFactory;
using BaseGameStatistics = org.allbinary.canvas.BaseGameStatistics;
using CustomGameMenuUtil = org.allbinary.canvas.CustomGameMenuUtil;
using FullScreenUtil = org.allbinary.canvas.FullScreenUtil;
using GameStatisticsFactory = org.allbinary.canvas.GameStatisticsFactory;
using RunnableCanvas = org.allbinary.canvas.RunnableCanvas;
using GameAdState = org.allbinary.game.GameAdState;
using GameInfo = org.allbinary.game.GameInfo;
using GameCommandsFactory = org.allbinary.game.commands.GameCommandsFactory;
using ChangedGameFeatureListener = org.allbinary.game.configuration.@event.ChangedGameFeatureListener;
using Features = org.allbinary.game.configuration.feature.Features;
using GameFeatureFactory = org.allbinary.game.configuration.feature.GameFeatureFactory;
using InputFeatureFactory = org.allbinary.game.configuration.feature.InputFeatureFactory;
using MainFeatureFactory = org.allbinary.game.configuration.feature.MainFeatureFactory;
using BasicBuildGameInitializerFactory = org.allbinary.game.init.BasicBuildGameInitializerFactory;
using GameInitializationUtil = org.allbinary.game.init.GameInitializationUtil;
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
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using SWTUtil = org.allbinary.game.layer.SWTUtil;
using DemoGameMidlet = org.allbinary.game.midlet.DemoGameMidlet;
using HighScoreCommands = org.allbinary.game.score.HighScoreCommands;
using HighScores = org.allbinary.game.score.HighScores;
using HighScoresFactoryInterface = org.allbinary.game.score.HighScoresFactoryInterface;
using HighScoresHelper = org.allbinary.game.score.HighScoresHelper;
using HighScoresHelperBase = org.allbinary.game.score.HighScoresHelperBase;
using HighScoresPaintable = org.allbinary.game.score.HighScoresPaintable;
using NullHighScoresSingletonFactory = org.allbinary.game.score.NullHighScoresSingletonFactory;
using GameState = org.allbinary.game.state.GameState;
using GameStateFactory = org.allbinary.game.state.GameStateFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using ResizableListenerHandler = org.allbinary.graphics.ResizableListenerHandler;
using ProgressCanvas = org.allbinary.graphics.canvas.transition.progress.ProgressCanvas;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using MyCommandsFactory = org.allbinary.graphics.displayable.command.MyCommandsFactory;
using DisplayChangeEvent = org.allbinary.graphics.displayable.@event.DisplayChangeEvent;
using DisplayChangeEventHandler = org.allbinary.graphics.displayable.@event.DisplayChangeEventHandler;
using DisplayChangeEventListener = org.allbinary.graphics.displayable.@event.DisplayChangeEventListener;
using FullScreenPaintableFactory = org.allbinary.graphics.displayable.screen.FullScreenPaintableFactory;
using CommandCurrentSelectionFormFactory = org.allbinary.graphics.form.CommandCurrentSelectionFormFactory;
using FormType = org.allbinary.graphics.form.FormType;
using FormTypeFactory = org.allbinary.graphics.form.FormTypeFactory;
using ScrollSelectionForm = org.allbinary.graphics.form.ScrollSelectionForm;
using ScrollSelectionFormNoneFactory = org.allbinary.graphics.form.ScrollSelectionFormNoneFactory;
using CommandTextItemArrayFactory = org.allbinary.graphics.form.item.CommandTextItemArrayFactory;
using ABCustomItem = org.allbinary.graphics.form.item.ABCustomItem;
using CurrentDisplayableFactory = org.allbinary.graphics.opengles.CurrentDisplayableFactory;
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using OpenGLFeatureUtil = org.allbinary.graphics.opengles.OpenGLFeatureUtil;
using OpenGLThreadUtil = org.allbinary.graphics.opengles.OpenGLThreadUtil;
using InitUpdatePaintable = org.allbinary.graphics.paint.InitUpdatePaintable;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using Paintable = org.allbinary.graphics.paint.Paintable;
using PaintableInterface = org.allbinary.graphics.paint.PaintableInterface;
using StatePaintable = org.allbinary.graphics.paint.StatePaintable;
using StatePaintableFactory = org.allbinary.graphics.paint.StatePaintableFactory;
using BasicMotionGesturesHandler = org.allbinary.input.motion.gesture.observer.BasicMotionGesturesHandler;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using OperatingSystemFactory = org.allbinary.logic.system.os.OperatingSystemFactory;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using InApplicationPurchaseFactory = org.allbinary.logic.system.security.licensing.InApplicationPurchaseFactory;
using LockableFeature = org.allbinary.logic.system.security.licensing.LockableFeature;
using LockableFeatureFactory = org.allbinary.logic.system.security.licensing.LockableFeatureFactory;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using AllBinaryMediaManager = org.allbinary.media.audio.AllBinaryMediaManager;
using EarlySoundsFactory = org.allbinary.media.audio.EarlySoundsFactory;
using PrimaryPlayerQueueFactory = org.allbinary.media.audio.PrimaryPlayerQueueFactory;
using SecondaryPlayerQueueFactory = org.allbinary.media.audio.SecondaryPlayerQueueFactory;
using CommonSeps = org.allbinary.@string.CommonSeps;
using NullThread = org.allbinary.thread.NullThread;
using ThreadFactoryUtil = org.allbinary.thread.ThreadFactoryUtil;
using ThreadUtil = org.allbinary.thread.ThreadUtil;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.displayable.canvas;

public class DemoCanvas : RunnableCanvas, GameCanvasRunnableInterface, MenuListener, DisplayChangeEventListener, DemoPaintableInterface
{
    public readonly BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
    public readonly MyCommandsFactory myCommandsFactory = MyCommandsFactory.getInstance();
    public readonly GameAdStateFactory gameAdStateFactory = GameAdStateFactory.getInstance();
    public readonly GameInputStrings gameInputStrings = GameInputStrings.getInstance();
    public readonly GameStateFactory gameStateFactory = GameStateFactory.getInstance();
    private readonly ThreadFactoryUtil threadFactoryUtil = ThreadFactoryUtil.getInstance();
    public readonly FormUtil formUtil = FormUtil.getInstance();
    public Paintable fullscreenPaintable = FullScreenPaintableFactory.getInstance().paintable;
    private StatePaintable basicGameDemoPaintable = StatePaintableFactory.getInstance();
    private SpecialAnimation specialAnimationInterface = SpecialAnimation.getInstance();
    private Animation paintedSpecialAnimationInterface = SpecialAnimation.getInstance();
    private readonly FullScreenUtil fullScreenUtil = FullScreenUtil.getInstance();
    private AllBinaryGameCanvas gameCanvas = NullGameCanvas.getInstance();
    private readonly HighScoresHelperBase highScoresHelper = new HighScoresHelper();
    private readonly HighScoresPaintable realHighScoresPaintable = new HighScoresPaintable();
    private Paintable highScoresPaintable = NullPaintable.getInstance();
    private int state = 0;
    private Thread canvasThread = NullThread.NULL_THREAD;
    private readonly TimeDelayHelper timeDelayHelper = new TimeDelayHelper(6000);
    private BasicColor basicColor;
    public readonly AbeClientInformationInterface abeClientInformation;
    private readonly HighScoresFactoryInterface highScoresFactoryInterface;
    private BasicMenuInputProcessor menuInputProcessor = NoMenuInputProcessor.getInstance();
    private ScrollSelectionForm menuForm = ScrollSelectionForm.getNullScrollSelectionForm();
    private readonly BasicBuildGameInitializerFactory gameInitializationInterfaceFactoryInterface;
    private bool initialized = false;
    private readonly DemoGameStartupRunnable demoGameRunnable;
    private Paintable defaultPaintableInterface = NullPaintable.getInstance();
    private PaintableInterface paintableInterface = NullPaintable.getInstance();
    private readonly InitUpdatePaintable overlayPaintable;
    private readonly PaintableInterface progressPaintable = ProgressCanvasFactory.getLazyInstance();
    private int tempWait = NullWaitGameRunnable.getInstance().WAIT;
    private readonly InputToGameKeyMapping inputToGameKeyMapping = PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance().getInputMapping();
    public GameRunnable gameRunnable = NullWaitGameRunnable.getInstance();
    public DemoCanvas(AbeClientInformationInterface abeClientInformation, CommandListener commandListener, HighScoresFactoryInterface highScoresFactoryInterface, Paintable paintable, InitUpdatePaintable overlayPaintable, BasicBuildGameInitializerFactory gameInitializationInterfaceFactoryInterface, bool isContinue) : base(commandListener, CurrentDisplayableFactory.getInstance().DEFAULT_CHILD_NAME_LIST, true)
    {
        this.basicColor = this.basicColorFactory.RED;
        // base(commandListener, CurrentDisplayableFactory.getInstance().DEFAULT_CHILD_NAME_LIST, true) is called from the constructor declaration
        this.abeClientInformation = abeClientInformation;
        this.setWait(NullWaitGameRunnable.getInstance().WAIT);
        this.gameInitializationInterfaceFactoryInterface = gameInitializationInterfaceFactoryInterface;
        GameInitializationUtil.getInstance().initDemo(abeClientInformation, this, gameInitializationInterfaceFactoryInterface);
        ResizableListenerHandler.getInstance().fireEvent(false);
        this.overlayPaintable = overlayPaintable;
        this.highScoresFactoryInterface = highScoresFactoryInterface;
        this.setDefaultPaintableInterface(paintable);
        this.setPaintableInterface(this.getDefaultPaintableInterface());
        if (isContinue) {
            this.addCommand(GameCommandsFactory.getInstance().CONTINUE_COMMAND);
        }
        if (ChangedGameFeatureListener.getInstance().isChangedFeature(GameFeatureFactory.getInstance().SOUND)) {
            this.mediaInit();
        }
        this.demoGameRunnable = new DemoGameStartupRunnable(this);
        DisplayChangeEventHandler.getInstance().addListenerInterface(this);
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    public override void onDisplayChangeEvent(DisplayChangeEvent displayChangeEvent)
    {
        try {
            this.logUtil.putF(new StringMaker().append(this.commonLabels.START_LABEL).append(this.displayInfo.ToString()).ToString(), this, this.canvasStrings.ON_DISPLAY_CHANGE_EVENT);
            ScrollSelectionForm scrollSelectionForm = this.getMenuForm();
            if (scrollSelectionForm != null) {
                FormType formType = FormTypeFactory.getInstance().getFormType();
                Rectangle rectangle = this.formUtil.createFormRectangle();
                scrollSelectionForm.init(rectangle, formType);
            }
            this.overlayPaintable.init();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.canvasStrings.ON_DISPLAY_CHANGE_EVENT, e);
        }
    }

    protected virtual object[] getCustomCommands()
    {
        GameCommandsFactory gameCommandsFactory = GameCommandsFactory.getInstance();
        if (J2MEUtil.isHTML()) {
            object[] commandArray = new object[] { gameCommandsFactory.START_COMMAND, HighScoreCommands.getInstance().DISPLAY, GameInputMappingCanvas.DISPLAY, gameCommandsFactory.DISPLAY_ABOUT };
            return commandArray;
        } else {
            BasicArrayList commandList = new BasicArrayListD();
            commandList.add(gameCommandsFactory.START_COMMAND);
            InApplicationPurchaseFactory inApplicationPurchaseFactory = InApplicationPurchaseFactory.getInstance();
            if (inApplicationPurchaseFactory.isEnabled()) {
                BasicArrayList list = LockableFeatureFactory.getInstance().getList();
                if (list.size() > 0 && !inApplicationPurchaseFactory.isPurchased(((LockableFeature) list.get(0)))) {
                    commandList.add(gameCommandsFactory.BUY_COMMAND);
                }
            }
            commandList.add(HighScoreCommands.getInstance().DISPLAY);
            try {
                bool isOverScan = OperatingSystemFactory.getInstance().getOperatingSystemInstance().isOverScan();
                if (SWTUtil.isSWT) {
                    commandList.add(GameInputMappingCanvas.DISPLAY);
                } else if (!isOverScan) {
                    commandList.add(gameCommandsFactory.DISPLAY_OPTIONS);
                    commandList.add(gameCommandsFactory.DISPLAY_LOAD_FORM);
                    commandList.add(GameInputMappingCanvas.DISPLAY);
                }
            } catch (Exception e) {
            }
            commandList.add(gameCommandsFactory.DISPLAY_ABOUT);
            object[] commandArray = commandList.toArray();
            return commandArray;
        }
    }

    public override void initCommands(CommandListener cmdListener)
    {
        this.removeAllCommands();
        object[] commandArray = this.getCustomCommands();
        int size = commandArray.Length;
        for (int index = 0; index < size; index++) {
            this.addCommand(((Command) commandArray[index]));
        }
        CustomGameMenuUtil.add(this);
        this.setCommandListener(cmdListener);
    }

    // throws Exception
    public virtual void initPostPaint()
    {
    }

    // throws Exception
    public virtual void mediaInit()
    {
        AllBinaryMediaManager.init(EarlySoundsFactory.getInstance());
    }

    public override void itemStateChanged(Item item)
    {
        ForcedLogUtil.log(this.commonStrings.NOT_IMPLEMENTED, this);
    }

    // throws Exception
    protected virtual void initMenu()
    {
        this.close();
        CommandTextItemArrayFactory commandTextItemArrayFactory = DemoLimitedCommandTextItemArrayFactory.getInstance().getCommandTextItemArrayFactory();
        ABCustomItem[] items = commandTextItemArrayFactory.getInstance(this.getCommandStack(), this.basicColorFactory.BLACK, this.basicColorFactory.WHITE);
        FormType formType = FormTypeFactory.getInstance().getFormType();
        Rectangle rectangle = this.formUtil.createFormRectangle();
        PreLogUtil.put(new StringMaker().append(this.commonLabels.START_LABEL).append(this.displayInfo.ToString()).ToString(), this, "initMenu");
        ScrollSelectionForm scrollSelectionForm = CommandCurrentSelectionFormFactory.getInstance(StringUtil.getInstance().EMPTY_STRING, items, rectangle, formType, 15, true, this.basicColorFactory.BLACK, this.basicColorFactory.WHITE);
        this.setMenuForm(scrollSelectionForm);
        FormType formType2 = FormTypeFactory.getInstance().getFormType();
        Rectangle rectangle2 = this.formUtil.createFormRectangle();
        scrollSelectionForm.init(rectangle2, formType2);
        if (this.getMenuForm() != ScrollSelectionFormNoneFactory.getInstance()) {
            this.setMenuInputProcessor(new CommandFormInputProcessor(new BasicArrayListD(), -1, this, this.getMenuForm()));
        }
        this.open();
    }

    public override void open()
    {
        BasicMotionGesturesHandler.getInstance().addListenerInterface(this.getMenuInputProcessor());
        GameKeyEventHandler.getInstance().addListener(this.getMenuInputProcessor());
    }

    public override void close()
    {
        BasicMotionGesturesHandler.getInstance().removeListener(this.getMenuInputProcessor());
        GameKeyEventHandler.getInstance().removeListener(this.getMenuInputProcessor());
    }

    private static readonly int id = 0;
    public override int getSourceId()
    {
        return DemoCanvas.id;
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
        this.addGameKeyEvent(keyCode, false);
    }

    public override void keyReleasedByDevice(int keyCode, int deviceId)
    {
        this.removeGameKeyEvent(keyCode, false);
    }

    private bool isSingleKeyRepeatableProcessing = Features.getInstance().isFeature(InputFeatureFactory.getInstance().SINGLE_KEY_REPEAT_PRESS);
    public override void keyRepeatedByDevice(int keyCode, int deviceId)
    {
        if (this.isSingleKeyRepeatableProcessing) {
            this.addGameKeyEvent(keyCode, true);
        }
    }

    private readonly GameKey NONE = GameKeyFactory.getInstance().NONE;
    private readonly GameKeyEventFactory gameKeyEventFactory = GameKeyEventFactory.getInstance();
    private int lastKeyNotMapped = -1;
    private void addGameKeyEvent(int keyCode, bool repeated)
    {
        try {
            GameKey gameKey = this.inputToGameKeyMapping.getInstanceForCanvas(this, keyCode);
            if (gameKey != this.NONE) {
                GameKeyEvent gameKeyEvent = this.gameKeyEventFactory.getInstanceForInput(this, gameKey);
                DownGameKeyEventHandler.getInstance().fireEvent(gameKeyEvent);
            } else {
                if (this.lastKeyNotMapped != keyCode) {
                    this.lastKeyNotMapped = keyCode;
                    this.logUtil.putF(new StringMaker().append(this.gameInputStrings.NO_KEY).appendint(keyCode).ToString(), this, this.gameInputStrings.ADD_KEY_EVENT);
                }
            }
        } catch (Exception e) {
            this.logUtil.put("Key Event Error", this, this.gameInputStrings.ADD_KEY_EVENT, e);
        }
    }

    private void removeGameKeyEvent(int keyCode, bool repeated)
    {
        try {
            GameKey gameKey = this.inputToGameKeyMapping.getInstanceForCanvas(this, keyCode);
            if (gameKey != this.NONE) {
                GameKeyEvent gameKeyEvent = this.gameKeyEventFactory.getInstanceForInput(this, gameKey);
                UpGameKeyEventHandler.getInstance().fireEvent(gameKeyEvent);
            } else {
                this.logUtil.putF(new StringMaker().append(this.gameInputStrings.NO_KEY).appendint(keyCode).ToString(), this, this.gameInputStrings.REMOVE_KEY_EVENT);
            }
        } catch (Exception e) {
            this.logUtil.put("Key Event Error", this, this.gameInputStrings.REMOVE_KEY_EVENT, e);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void pause()
    {
        this.close();
        this.setPaused(true);
        this.gameRunnable = NullWaitGameRunnable.getInstance();
        this.gameCanvas.pause();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void unPause()
    {
        this.open();
        this.gameCanvas.unPause();
        this.gameRunnable = this.gameCanvas.gameRunnable;
        this.setPaused(false);
    }

    public override bool isPausable()
    {
        if (CurrentDisplayableFactory.getInstance().getUsedRunnable() == NullWaitGameRunnable.getInstance()) {
            return true;
        } else {
            return false;
        }
    }

    public override bool isGameOver()
    {
        this.logUtil.putF(new StringMaker().append(this.commonStrings.NOT_IMPLEMENTED).append(" since not a game").ToString(), this, "isGameOver");
        return false;
    }

    // throws Exception
    public override void setLoadStateHashtable(ABHashtable<object, object> hashtable)
    {
        this.logUtil.putF("Trying to continue a demo lol - only continue a game canvas not the demo", this, "setLoadStateHashtable");
    }

    // throws Exception
    public override ABHashtable<object, object> getLoadStateHashtable()
    {
        this.logUtil.putF("Trying to continue a demo lol - only continue a game canvas not the demo", this, "getLoadStateHashtable");
        return this.stdUtil.NULL_TABLE;
    }

    // throws Exception
    public override ABHashtable<object, object> getCurrentStateHashtable()
    {
        this.logUtil.putF("Trying to save the AI lol", this, "getCurrentStateHashtable");
        return this.stdUtil.NULL_TABLE;
    }

    public override void setHighScoreSubmitted(bool isNotUsed)
    {
    }

    public override void paint(Graphics graphics)
    {
        this.paintableInterface.paint(graphics);
        this.paintedSpecialAnimationInterface.paintXY(graphics, 0, 0);
        this.highScoresPaintable.paint(graphics);
        this.getBasicGameDemoPaintable().paint(graphics);
        this.overlayPaintable.paint(graphics);
        this.fullscreenPaintable.paint(graphics);
        this.progressPaintable.paint(graphics);
    }

    public override void paintThreed(Graphics graphics)
    {
        this.paintableInterface.paintThreed(graphics);
        this.paintedSpecialAnimationInterface.paintThreedXYZ(graphics, 0, 0, 0);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void processGameOver()
    {
        this.logUtil.putF("Not Implemented since not a game", this, "setGameOver");
    }

    protected virtual void demoStateChange()
    {
        int newState = this.state + 1;
        if (newState > 2) {
            newState = 0;
        } else if (newState == 2) {
            if (!this.highScoresHelper.isAnyHighScores()) {
                newState = 0;
            } else {
                HighScores highScores = this.highScoresHelper.getNextHighScores();
                if (highScores == NullHighScoresSingletonFactory.getInstance()) {
                    newState = 0;
                } else {
                    this.getRealHighScoresPaintable().setHighScores(highScores);
                }
            }
        }
        this.setState(newState);
        this.updateDemoState();
    }

    private readonly string SET_STATE = "setState";
    protected virtual void updateDemoState()
    {
        PreLogUtil.put(SmallIntegerSingletonFactory.getInstance().createInstance(this.state).ToString(), this, this.SET_STATE);
        this.getBasicGameDemoPaintable().setState(this.state);
        if (this.state == 0) {
            this.highScoresPaintable = NullPaintable.getInstance();
            this.paintedSpecialAnimationInterface = this.getSpecialAnimationInterface();
            if (!this.demoGameRunnable.isRunning() && this.gameCanvas.isInitialized()) {
                this.getSpecialAnimationInterface().reset();
            }
        } else if (this.state == 1) {
            this.paintedSpecialAnimationInterface = SpecialAnimation.getInstance();
        } else if (this.state == 2) {
            this.highScoresPaintable = this.getRealHighScoresPaintable();
        }
        GameAdState gameAdState = this.gameAdStateFactory.getCurrentInstance();
        gameAdState.processPageAdState();
    }

    // throws Exception
    protected virtual int getNextRandom()
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    // throws Exception
    protected virtual AllBinaryGameLayerManager createGameLayerManager(int randomValue)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    // throws Exception
    protected virtual GameCanvasRunnableInterface createRunnable(int randomLevel)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    // throws Exception
    protected virtual void create()
    {
        PreLogUtil.put(this.commonStrings.START, this, "create");
        this.highScoresPaintable = NullPaintable.getInstance();
        int randomLevel = this.getNextRandom();
        this.gameCanvas = ((AllBinaryGameCanvas) this.createRunnable(randomLevel));
        this.basicColor = this.gameCanvas.getLayerManager().getForegroundBasicColor();
        this.getRealHighScoresPaintable().setBasicColorP(this.basicColor);
        this.gameCanvas.setGameCanvasStartListener(this);
        GameInfo gameInfo = this.gameCanvas.getLayerManager().getGameInfo();
        this.getHighScoresFactoryInterface().fetchHighScores(gameInfo, this.highScoresHelper);
    }

    // throws Exception
    protected virtual void start()
    {
        AllBinaryGameCanvas gameCanvas = this.gameCanvas;
        PreLogUtil.put(new StringMaker().append("Game Thread in DemoCanvas: ").append(this.stringUtil.toString(gameCanvas)).ToString(), this, this.commonStrings.START);
        this.canvasThread = this.threadFactoryUtil.getInstanceGameCanvasRunnable(gameCanvas);
        this.gameCanvas.setThread(this.canvasThread);
        this.threadFactoryUtil.start(this.canvasThread);
        if (this.getWait() == NullWaitGameRunnable.getInstance().WAIT) {
            this.setWait(this.getTempWait());
        }
    }

    public virtual void preDemoProcess()
    {
        if (!this.gameCanvas.isInitialized() || this.gameCanvas.getTitle() == NullGameCanvas.NO_GAME) {
            if (AllBinaryMediaManager.update()) {
                if (!PrimaryPlayerQueueFactory.getInstance().process()) {
                    SecondaryPlayerQueueFactory.getInstance().process();
                }
            }
        }
        this.overlayPaintable.update();
    }

    // throws Exception
    public override void process()
    {
        base.process();
        this.getMenuInputProcessor().processInputList();
        this.preDemoProcess();
        if (this.state == 0) {
            IndexedAnimationBehavior indexedAnimationBehavior = (((IndexedAnimationBehavior) this.getSpecialAnimationInterface().getAnimationBehavior()));
            if (indexedAnimationBehavior.loopIndex < 1) {
                this.timeDelayHelper.setStartTimeTNT();
            }
            DemoGameMidlet demoGameMidlet = ((DemoGameMidlet) this.getCustomCommandListener());
            if (this.gameCanvas != NullGameCanvas.getInstance() && this.gameCanvas.isGameOver()) {
                this.stopGameDemo();
                int randomLevel = this.getNextRandom();
                GameInfo gameInfo = this.gameCanvas.getLayerManager().getGameInfo();
                gameInfo.setCurrentLevel(randomLevel);
                this.gameCanvas.setGameOver(false);
                this.start();
            } else if (this.gameCanvas == NullGameCanvas.getInstance() && demoGameMidlet.isReady()) {
                if (!this.demoGameRunnable.isRunning()) {
                    this.startDemoGame();
                    this.demoGameRunnable.setRunning(true);
                    Thread thread = this.threadFactoryUtil.getInstanceForRunnable(this.demoGameRunnable);
                    this.demoGameRunnable.setThread(thread);
                    this.threadFactoryUtil.start(thread);
                }
            }
        }
    }

    // throws Exception
    protected void startDemoGame()
    {
        DemoCanvasProgressUtil.showProgress(this);
    }

    // throws Exception
    protected virtual void stopGameDemo()
    {
        if (this.gameCanvas != NullGameCanvas.getInstance()) {
            this.logUtil.putF("Set Running False", this, "stopGameDemo");
            this.gameCanvas.setRunning(false);
        }
        ThreadUtil.getInstance().join(this.canvasThread);
    }

    public override void showGamePaintable()
    {
        string METHOD_NAME = "showGamePaintable";
        PreLogUtil.put(this.commonStrings.START, this, METHOD_NAME);
        bool isDefault = J2MEUtil.isHTML();
        if (this.gameCanvas != NullGameCanvas.getInstance() && (this.gameCanvas.isRunning() || isDefault || SWTUtil.isSWT) && !(this.gameCanvas.getType() == NullGameCanvas.TYPE)) {
            this.gameRunnable = this.gameCanvas.gameRunnable;
            PreLogUtil.put("Showing Game", this, METHOD_NAME);
            this.setPaintableInterface(this.gameCanvas);
        } else {
            this.gameRunnable = NullWaitGameRunnable.getInstance();
            PreLogUtil.put("Not Showing Game", this, METHOD_NAME);
            this.setPaintableInterface(this.getDefaultPaintableInterface());
        }
    }

    protected virtual bool isReadyForStateChange()
    {
        return !this.demoGameRunnable.isRunning() && this.gameCanvas.isInitialized();
    }

    // throws Exception
    protected virtual void processGame()
    {
        this.gameRunnable.run();
        if (!this.specialAnimationInterface.isComplete() && this.isReadyForStateChange()) {
            this.specialAnimationInterface.nextFrame();
        }
        if (this.timeDelayHelper.isTimeTNT() && this.isReadyForStateChange()) {
            this.demoStateChange();
        } else {
            this.process();
        }
    }

    public override void run()
    {
        this.logUtil.putF(this.commonStrings.START_RUNNABLE, this, this.commonStrings.RUN);
        try {
            ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
            Features features = Features.getInstance();
            OpenGLFeatureFactory openGLFeatureFactory = OpenGLFeatureFactory.getInstance();
            progressCanvas.addNormalPortion(50, "Demo Thread");
            this.setCurrentThread();
            this.setRunning(true);
            if (features.isFeature(MainFeatureFactory.getInstance().LOAD_ONDEMAND)) {
                progressCanvas.end();
            } else {
                progressCanvas.addNormalPortion(50, "Demo Thread Running");
            }
            this.fullScreenUtil.initOnRun(this, this.getCustomCommandListener());
            this.initMenu();
            this.initPostPaint();
            this.updateDemoState();
            if (features.isDefault(openGLFeatureFactory.OPENGL_AS_GAME_THREAD)) {
                while (this.gameCanvas == NullGameCanvas.getInstance() || !this.gameCanvas.isInitialized()) {
                    this.loopTimeHelper.setStartTimeTNT();
                    this.processGame();
                    this.processLoopSleep();
                }
                DemoGameRunnable demoGameRunnable = new DemoGameRunnable(this);
                CurrentDisplayableFactory currentDisplayableFactory = CurrentDisplayableFactory.getInstance();
                currentDisplayableFactory.setRunnable(demoGameRunnable);
                currentDisplayableFactory.setMyCanvas(this);
                OpenGLThreadUtil.getInstance().onResume();
            }
            if (features.isDefault(openGLFeatureFactory.OPENGL_AS_GAME_THREAD) || J2MEUtil.isHTML()) {
                DemoGameRunnable demoGameRunnable = new DemoGameRunnable(this);
                CurrentDisplayableFactory currentDisplayableFactory = CurrentDisplayableFactory.getInstance();
                currentDisplayableFactory.setRunnable(demoGameRunnable);
                currentDisplayableFactory.setMyCanvas(this);
            } else {
                while (this.isRunning()) {
                    this.run3();
                }
                this.end();
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.RUN, e);
        }
        this.logUtil.putF(this.commonStrings.END_RUNNABLE, this, this.commonStrings.RUN);
    }

    // throws Exception
    public virtual void run3()
    {
        this.loopTimeHelper.setStartTimeTNT();
        this.processGame();
        this.processLoopSleep();
    }

    public override void setRunning(bool running)
    {
        base.setRunning(running);
        try {
            Features features = Features.getInstance();
            OpenGLFeatureFactory openGLFeatureFactory = OpenGLFeatureFactory.getInstance();
            if (running) {
            } else {
                if ((features.isDefault(openGLFeatureFactory.OPENGL) || J2MEUtil.isHTML()) || SWTUtil.isSWT) {
                    CurrentDisplayableFactory currentDisplayableFactory = CurrentDisplayableFactory.getInstance();
                    currentDisplayableFactory.clearRunnable();
                    this.end();
                }
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.SET_RUNNING, e);
        }
    }

    private static readonly string BOT_GAME_STATS = "Bot Game Statistics: ";
    private readonly BaseGameStatistics baseGameStatistics = GameStatisticsFactory.getInstance();
    // throws Exception
    public virtual void end()
    {
        ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
        Features features = Features.getInstance();
        this.baseGameStatistics.add(new StringMaker().append(DemoCanvas.BOT_GAME_STATS).append(this.baseGameStatistics.ToString()).append(CommonSeps.getInstance().NEW_LINE).ToString());
        this.baseGameStatistics.init();
        if (features.isFeature(MainFeatureFactory.getInstance().LOAD_ONDEMAND)) {
            progressCanvas.start();
        }
        this.logUtil.putF("Demo End", this, this.commonStrings.RUN);
        this.close();
        DisplayChangeEventHandler.getInstance().removeListener(this);
        this.stopGameDemo();
    }

    public override void setGameState(GameState gameState)
    {
    }

    public override GameState getGameState()
    {
        return this.gameStateFactory.PLAYING_GAME_STATE;
    }

    public virtual AllBinaryGameCanvas getGameCanvasRunnableInterface()
    {
        return this.gameCanvas;
    }

    public virtual bool isDemoLoading()
    {
        AllBinaryGameCanvas gameCanvas = this.gameCanvas;
        if (gameCanvas == NullGameCanvas.getInstance()) {
            return true;
        } else if (gameCanvas.isInitialized()) {
            return false;
        }
        return true;
    }

    protected virtual int getState()
    {
        return this.state;
    }

    protected virtual void setState(int state)
    {
        this.state = state;
    }

    public override bool isHighScoreSubmitted()
    {
        this.logUtil.putF("Wow the AI got a high score!", this, "isHighScoreSubmitted");
        return false;
    }

    public virtual HighScoresPaintable getRealHighScoresPaintable()
    {
        return this.realHighScoresPaintable;
    }

    protected virtual void setSpecialAnimationInterface(SpecialAnimation specialAnimationInterface)
    {
        specialAnimationInterface.setFrame(0);
        this.specialAnimationInterface = specialAnimationInterface;
    }

    protected virtual SpecialAnimation getSpecialAnimationInterface()
    {
        return this.specialAnimationInterface;
    }

    protected virtual void setPaintableInterface(PaintableInterface paintableInterface)
    {
        this.paintableInterface = paintableInterface;
    }

    protected virtual PaintableInterface getPaintableInterface()
    {
        return this.paintableInterface;
    }

    protected virtual void setDefaultPaintableInterface(Paintable defaultPaintableInterface)
    {
        this.defaultPaintableInterface = defaultPaintableInterface;
    }

    protected virtual Paintable getDefaultPaintableInterface()
    {
        return this.defaultPaintableInterface;
    }

    public virtual HighScoresFactoryInterface getHighScoresFactoryInterface()
    {
        return this.highScoresFactoryInterface;
    }

    protected virtual void setMenuInputProcessor(BasicMenuInputProcessor menuInputProcessor)
    {
        this.menuInputProcessor = menuInputProcessor;
    }

    protected virtual BasicMenuInputProcessor getMenuInputProcessor()
    {
        return this.menuInputProcessor;
    }

    public virtual ScrollSelectionForm getMenuForm()
    {
        return this.menuForm;
    }

    public virtual void setMenuForm(ScrollSelectionForm menuForm)
    {
        this.menuForm = menuForm;
    }

    public override bool isInitialized()
    {
        return this.initialized;
    }

    protected virtual Paintable getOverlayPaintable()
    {
        return this.overlayPaintable;
    }

    protected virtual void setBasicGameDemoPaintable(StatePaintable basicGameDemoPaintable)
    {
        this.basicGameDemoPaintable = basicGameDemoPaintable;
    }

    protected virtual StatePaintable getBasicGameDemoPaintable()
    {
        return this.basicGameDemoPaintable;
    }

    public virtual void setTempWait(int tempWait)
    {
        this.tempWait = tempWait;
    }

    public virtual int getTempWait()
    {
        return this.tempWait;
    }

    public override bool isSingleThread()
    {
        return OpenGLFeatureUtil.getInstance().isAnyThreed() || SWTUtil.isSWT;
    }

    public virtual bool isRunningInAnotherThread()
    {
        Features features = Features.getInstance();
        OpenGLFeatureFactory openGLFeatureFactory = OpenGLFeatureFactory.getInstance();
        if (features.isDefault(openGLFeatureFactory.OPENGL_AS_GAME_THREAD)) {
            return true;
        } else {
            return this.isRunning();
        }
    }

    public virtual BasicBuildGameInitializerFactory getGameInitializationInterfaceFactoryInterface()
    {
        return this.gameInitializationInterfaceFactoryInterface;
    }

    public static readonly int TYPE = 3;
    public override int getType()
    {
        return DemoCanvas.TYPE;
    }

}

