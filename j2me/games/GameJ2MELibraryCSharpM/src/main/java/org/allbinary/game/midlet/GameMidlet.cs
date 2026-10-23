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
using java.util;
//using Canvas = javax.microedition.lcdui.Canvas;
//using Command = javax.microedition.lcdui.Command;
//using CommandListener = javax.microedition.lcdui.CommandListener;
//using Displayable = javax.microedition.lcdui.Displayable;
//using NullCanvas = javax.microedition.lcdui.NullCanvas;
//using MIDletStateChangeException = javax.microedition.midlet.MIDletStateChangeException;
using J2MEUtil = org.allbinary.J2MEUtil;
using TsUtil = org.allbinary.TsUtil;
using GameAdStateFactory = org.allbinary.business.advertisement.GameAdStateFactory;
using FullScreenUtil = org.allbinary.canvas.FullScreenUtil;
using GameStatisticsFactory = org.allbinary.canvas.GameStatisticsFactory;
using DebugFactory = org.allbinary.debug.DebugFactory;
using DebugInterface = org.allbinary.debug.DebugInterface;
using GameAdState = org.allbinary.game.GameAdState;
using GameInfo = org.allbinary.game.GameInfo;
using GameMode = org.allbinary.game.GameMode;
using GameStrings = org.allbinary.game.GameStrings;
using GameTypeFactory = org.allbinary.game.GameTypeFactory;
using PlayerTypesFactory = org.allbinary.game.PlayerTypesFactory;
using GameCommandsFactory = org.allbinary.game.commands.GameCommandsFactory;
using GameOptionsForm = org.allbinary.game.configuration.GameOptionsForm;
using GameOptionsFormFactory = org.allbinary.game.configuration.GameOptionsFormFactory;
using InGameFeatures = org.allbinary.game.configuration.InGameFeatures;
using InGameOptionsForm = org.allbinary.game.configuration.InGameOptionsForm;
using InGameOptionsFormFactory = org.allbinary.game.configuration.InGameOptionsFormFactory;
using LoadGameForm = org.allbinary.game.configuration.LoadGameForm;
using ChangedGameFeatureListener = org.allbinary.game.configuration.@event.ChangedGameFeatureListener;
using GameFeatureEventHandler = org.allbinary.game.configuration.@event.GameFeatureEventHandler;
using Features = org.allbinary.game.configuration.feature.Features;
using GameFeatureFormUtil = org.allbinary.game.configuration.feature.GameFeatureFormUtil;
using MainFeatureFactory = org.allbinary.game.configuration.feature.MainFeatureFactory;
using GamePersistanceSingleton = org.allbinary.game.configuration.persistance.GamePersistanceSingleton;
using KeyValuePersistance = org.allbinary.game.configuration.persistance.KeyValuePersistance;
using AllBinaryGameCanvas = org.allbinary.game.displayable.canvas.AllBinaryGameCanvas;
using BasicPaintablesCanvas = org.allbinary.game.displayable.canvas.BasicPaintablesCanvas;
using DemoCanvas = org.allbinary.game.displayable.canvas.DemoCanvas;
using GameCanvasRunnableInterface = org.allbinary.game.displayable.canvas.GameCanvasRunnableInterface;
using GameEventHandlerUtil = org.allbinary.game.displayable.canvas.GameEventHandlerUtil;
using GameInputMappingCanvas = org.allbinary.game.displayable.canvas.GameInputMappingCanvas;
using GameInputMappingInstructionsCanvas = org.allbinary.game.displayable.canvas.GameInputMappingInstructionsCanvas;
using MenuListener = org.allbinary.game.displayable.canvas.MenuListener;
using NullGameCanvasRunnable = org.allbinary.game.displayable.canvas.NullGameCanvasRunnable;
using TextNotificationUtil = org.allbinary.game.input.TextNotificationUtil;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using GameNotificationEventHandler = org.allbinary.game.layer.hud.@event.GameNotificationEventHandler;
using HelpPaintable = org.allbinary.game.paint.help.HelpPaintable;
using HighScoreCommands = org.allbinary.game.score.HighScoreCommands;
using HighScoreCommandsFactory = org.allbinary.game.score.HighScoreCommandsFactory;
using HighScoreTextBox = org.allbinary.game.score.displayable.HighScoreTextBox;
using HighScoreUtil = org.allbinary.game.score.displayable.HighScoreUtil;
using HighScoresCanvas = org.allbinary.game.score.displayable.HighScoresCanvas;
using GameStateFactory = org.allbinary.game.state.GameStateFactory;
using ResizableListenerHandler = org.allbinary.graphics.ResizableListenerHandler;
using ProgressCanvas = org.allbinary.graphics.canvas.transition.progress.ProgressCanvas;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using ColorChangeEventHandler = org.allbinary.graphics.color.ColorChangeEventHandler;
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using MyCanvas = org.allbinary.graphics.displayable.MyCanvas;
using MyCommandsFactory = org.allbinary.graphics.displayable.command.MyCommandsFactory;
using AboutCommandProcessor = org.allbinary.graphics.displayable.screen.AboutCommandProcessor;
using AboutPaintableFactory = org.allbinary.graphics.displayable.screen.AboutPaintableFactory;
using CommandForm = org.allbinary.graphics.displayable.screen.CommandForm;
using WebCommandProcessor = org.allbinary.graphics.displayable.screen.WebCommandProcessor;
using AllBinarySensorManager = org.allbinary.input.AllBinarySensorManager;
using VirtualKeyboardEventHandler = org.allbinary.input.@event.VirtualKeyboardEventHandler;
using BasicMotionGesturesHandler = org.allbinary.input.motion.gesture.observer.BasicMotionGesturesHandler;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using ClientInformationFactory = org.allbinary.logic.system.security.licensing.ClientInformationFactory;
using InApplicationPurchaseFactory = org.allbinary.logic.system.security.licensing.InApplicationPurchaseFactory;
using LockableFeature = org.allbinary.logic.system.security.licensing.LockableFeature;
using LockableFeatureFactory = org.allbinary.logic.system.security.licensing.LockableFeatureFactory;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using AllBinaryMediaManager = org.allbinary.media.audio.AllBinaryMediaManager;
using MidletStrings = org.allbinary.midlet.MidletStrings;
using ProgressMidlet = org.allbinary.midlet.ProgressMidlet;
using NullThread = org.allbinary.thread.NullThread;
using ThreadFactoryUtil = org.allbinary.thread.ThreadFactoryUtil;
using ThreadUtil = org.allbinary.thread.ThreadUtil;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using EnumerationUtil = org.allbinary.util.EnumerationUtil;
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;

namespace org.allbinary.game.midlet;

public class GameMidlet : ProgressMidlet, CommandListener
{
    private readonly EnumerationUtil enumerationUtil = EnumerationUtil.getInstance();
    public readonly BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
    public readonly Features features = Features.getInstance();
    public readonly MidletStrings midletStrings = MidletStrings.getInstance();
    public readonly MyCommandsFactory myCommandsFactory = MyCommandsFactory.getInstance();
    public readonly GameStrings gameStrings = GameStrings.getInstance();
    public readonly GameAdStateFactory gameAdStateFactory = GameAdStateFactory.getInstance();
    public readonly GameStateFactory gameStateFactory = GameStateFactory.getInstance();
    public readonly TsUtil tsUtil = TsUtil.getInstance();
    private readonly string DISPLAYABLE = " Displayable: ";
    private readonly string COMMAND_NAME = "command Name/Label: ";
    private readonly string NO_COMMAND = "No Command";
    private readonly string NO_DISPLAYABLE = "No Displayable";
    private readonly string COMMAND_ACTION;
    private readonly string PAUSE_APP_BACKGROUND = "pauseAppBackground";
    private readonly string UN_PAUSE_APP_BACKGROUND = "unPauseAppBackground";
    private readonly AboutCommandProcessor aboutCommandProcessor = AboutCommandProcessor.getInstance();
    private readonly WebCommandProcessor webCommandProcessor = WebCommandProcessor.getInstance();
    private readonly GameMidletStateFactory gameMidletStateFactory = GameMidletStateFactory.getInstance();
    public readonly TimeDelayHelper gameStartTimeHelper = new TimeDelayHelper(240);
    private readonly FullScreenUtil fullScreenUtil = FullScreenUtil.getInstance();
    private readonly DebugInterface debugInterface;
    private GameCanvasRunnableInterface allbinaryGameCanvasRunnableInterface = NullGameCanvasRunnable.NULL_GAME_CANVAS_RUNNABLE;
    private global::org.allbinary.thread.NullThread thread = NullThread.NULL_THREAD;
    private CommandForm loadGameForm;
    private bool isFullScreen = false;
    private bool resized = false;
    public GameMidlet(ClientInformationFactory clientInformationFactory) : base(clientInformationFactory)
    {
        this.COMMAND_ACTION = new StringMaker().append("GameMidlet::").append(this.midletStrings.COMMAND_ACTION).ToString();
        // base(clientInformationFactory) is called from the constructor declaration
        SmallIntegerSingletonFactory.getInstance().initWithRange(0x291, 6);
        this.loadGameForm = CommandForm.getNullCommandForm();
        ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
        progressCanvas.init(this);
        GameFeatureEventHandler.getInstance().addListenerInterface(ChangedGameFeatureListener.getInstance());
        GamePersistanceSingleton.getInstance().clear();
        this.debugInterface = DebugFactory.getInstance();
        this.init();
    }

    public virtual void init()
    {
    }

    // throws Exception
    public virtual void setDemo()
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    // throws Exception
    public virtual void createGame()
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    // throws Exception
    public virtual void mediaShutdown()
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    public virtual void stopAll()
    {
    }

    public override void pauseApp()
    {
        this.pauseAppBackground(true);
        GameAdState gameAdState = this.gameAdStateFactory.getCurrentInstance();
        gameAdState.getAdvertisements().stopAll();
    }

    public virtual void pauseAppBackground(bool background)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.PAUSE_APP_BACKGROUND);
        if (this.allbinaryGameCanvasRunnableInterface != NullGameCanvasRunnable.NULL_GAME_CANVAS_RUNNABLE) {
            this.allbinaryGameCanvasRunnableInterface.pause();
        } else {
            this.logUtil.putF("<<<<<< Null", this, this.PAUSE_APP_BACKGROUND);
        }
        AllBinarySensorManager.getInstance().shutdown();
    }

    public virtual void unPauseApp()
    {
        this.unPauseAppBackground(true);
        GameAdState gameAdState = this.gameAdStateFactory.getCurrentInstance();
        gameAdState.getAdvertisements().startAll();
    }

    public virtual void unPauseAppBackground(bool background)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.UN_PAUSE_APP_BACKGROUND);
        AllBinarySensorManager.getInstance().init();
        GameCanvasRunnableInterface gameCanvasRunnableInterface = this.allbinaryGameCanvasRunnableInterface;
        if (gameCanvasRunnableInterface != NullGameCanvasRunnable.NULL_GAME_CANVAS_RUNNABLE) {
            gameCanvasRunnableInterface.unPause();
        } else {
            this.logUtil.putF("<<<<<< Null", this, this.UN_PAUSE_APP_BACKGROUND);
        }
    }

    public override void destroyAppInRunnable(bool unconditional, bool isProgress)
    {
        ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
        if (isProgress) {
            progressCanvas.start();
            this.commandAction(this.myCommandsFactory.SET_DISPLAYABLE, progressCanvas);
        }
        this.destroyApp(unconditional);
        if (isProgress) {
            progressCanvas.end();
        }
    }

    public override void destroyApp(bool unconditional)
    {
        string METHOD_NAME = "GameMidlet::destroyApp";
        try {
            PreLogUtil.put(GameStatisticsFactory.getInstance().ToString(), this, METHOD_NAME);
            GameAdState gameAdState = this.gameAdStateFactory.getCurrentInstance();
            gameAdState.getAdvertisements().stopAll();
            if (!this.isDestroyed()) {
                this.stopGameCanvasRunnableInterface();
                this.setGameCanvasRunnableInterface(NullGameCanvasRunnable.NULL_GAME_CANVAS_RUNNABLE);
                this.mediaShutdown();
            } else {
                this.logUtil.putF("Midlet Managment Error: Midlet Should Only Be Destroyed Once", this, METHOD_NAME);
            }
            base.destroyApp(true);
            PreLogUtil.put(this.commonStrings.END, this, METHOD_NAME);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, METHOD_NAME, e);
        }
        this.logUtil.putF(this.commonStrings.END, this, METHOD_NAME);
    }

    // throws MIDletStateChangeException
    public override void startApp()
    {
        try {
            GameAdState gameAdState = this.gameAdStateFactory.getCurrentInstance();
            gameAdState.getAdvertisements().startAll();
            string START_APP = "startApp";
            this.logUtil.putF(this.commonStrings.START, this, START_APP);
            object gameCanvasRunnableInterface = this.allbinaryGameCanvasRunnableInterface;
            if (gameCanvasRunnableInterface == NullGameCanvasRunnable.NULL_GAME_CANVAS_RUNNABLE) {
                this.gameMidletStateFactory.setCurrentGameState(this.gameStateFactory.NO_GAME_STATE);
                this.setDemo();
            } else {
                this.logUtil.putF("GameCanvasRunnableInterface is available", this, START_APP);
                if (gameCanvasRunnableInterface == this.getCurrentDisplayable()) {
                    this.unPauseAppBackground(false);
                } else {
                    this.logUtil.putF("GameCanvasRunnableInterface is not current displayable", this, START_APP);
                }
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "startApp", e);
            this.destroyApp(false);
            this.notifyDestroyed();
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void commandAction(Command command, Displayable displayable)
    {
        try {
            string displayableAsString = this.NO_DISPLAYABLE;
            if (displayable != null) {
                displayableAsString = displayable.ToString();
            }
            string label = this.NO_COMMAND;
            if (command != null) {
                label = command.getLabel();
            }
            PreLogUtil.put(new StringMaker().append(this.COMMAND_NAME).append(label).append(this.DISPLAYABLE).append(displayableAsString).ToString(), this, this.COMMAND_ACTION);
            GameCommandsFactory gameCommandsFactory = GameCommandsFactory.getInstance();
            GameCanvasRunnableInterface allbinaryGameCanvasRunnableInterface = this.allbinaryGameCanvasRunnableInterface;
            object gameCanvasRunnableInterface = allbinaryGameCanvasRunnableInterface;
            if (command == gameCommandsFactory.SHOW_GAME_CANVAS) {
                if (this.getDisplay().getCurrent() != gameCanvasRunnableInterface && allbinaryGameCanvasRunnableInterface.getType() != NullGameCanvasRunnable.NULL_GAME_CANVAS_RUNNABLE.getType()) {
                    this.setDisplay(((Displayable) gameCanvasRunnableInterface));
                }
                this.unPauseAppBackground(false);
            } else if (command == gameCommandsFactory.CLOSE_AND_SHOW_GAME_CANVAS) {
                MenuListener menuListener = ((MenuListener) displayable);
                menuListener.close();
                this.setDisplay(((Displayable) gameCanvasRunnableInterface));
                this.unPauseAppBackground(false);
            } else if (command == gameCommandsFactory.EXIT_COMMAND) {
                if (GameMidletEventHandler.getInstance().getEventListenerInterfaceListP().size() == 0) {
                    this.exitProgress(true);
                }
                GameMidletEventHandler.getInstance().fireEvent(new DemoGameMidletEvent(this, DemoGameMidletStateFactory.getInstance().NONE));
            } else if (command == gameCommandsFactory.EXIT_WITHOUT_PROGRESS_COMMAND) {
                this.exitProgress(false);
            } else if (command == gameCommandsFactory.START_COMMAND || command == gameCommandsFactory.RESTART_COMMAND || command == gameCommandsFactory.CONTINUE_COMMAND) {
                if (this.gameMidletStateFactory.getCurrentGameState() != this.gameStateFactory.PLAYING_GAME_STATE || command == gameCommandsFactory.RESTART_COMMAND) {
                    if (this.gameStartTimeHelper.isTimeTNT()) {
                        if (command == gameCommandsFactory.START_COMMAND && this.isDemoLoading()) {
                            this.logUtil.putF("Trying to Start Game Before Loading Complete", this, this.midletStrings.COMMAND_ACTION);
                        } else {
                            this.startedBefore = true;
                            this.createGame();
                            this.gameMidletStateFactory.setCurrentGameState(this.gameStateFactory.PLAYING_GAME_STATE);
                        }
                    } else {
                        this.logUtil.putF("Starting Game Too Often", this, this.midletStrings.COMMAND_ACTION);
                    }
                } else {
                    this.logUtil.putF("Already in playing state", this, this.COMMAND_ACTION);
                }
            } else if (command == gameCommandsFactory.BUY_COMMAND) {
                InApplicationPurchaseFactory inApplicationPurchaseFactory = InApplicationPurchaseFactory.getInstance();
                BasicArrayList list = LockableFeatureFactory.getInstance().getList();
                LockableFeature lockableFeature = ((LockableFeature) list.get(0));
                if (list.size() > 0 && !inApplicationPurchaseFactory.isPurchased(lockableFeature)) {
                    inApplicationPurchaseFactory.purchase(lockableFeature);
                } else {
                    TextNotificationUtil.getInstance().fireSuccess("Already Purchased");
                }
            } else if (command == gameCommandsFactory.QUIT_COMMAND) {
                if (this.gameStartTimeHelper.isTimeTNT()) {
                    if (displayable is HighScoreTextBox) {
                        MenuListener menuListener = ((MenuListener) displayable);
                        menuListener.close();
                    }
                    this.stopGameCanvasRunnableInterface();
                    this.gameMidletStateFactory.setCurrentGameState(this.gameStateFactory.NO_GAME_STATE);
                    this.setDemo();
                }
            } else if (command == this.myCommandsFactory.RESUME_COMMAND) {
                this.unPauseAppBackground(false);
            } else if (command == this.myCommandsFactory.PAUSE_COMMAND) {
                this.pauseAppBackground(false);
            } else if (command == this.myCommandsFactory.SET_DISPLAYABLE) {
                this.pauseAppBackground(false);
                this.setDisplay(displayable);
            } else if (command == gameCommandsFactory.SET_MENU_DISPLAYABLE) {
                this.pauseAppBackground(false);
                MenuListener menuListener = ((MenuListener) displayable);
                menuListener.open();
                this.setDisplay(displayable);
            } else if (command == gameCommandsFactory.START_TRACE) {
                this.debugInterface.start();
                AllBinaryGameCanvas gameCanvas = ((AllBinaryGameCanvas) allbinaryGameCanvasRunnableInterface);
                gameCanvas.addCommand(gameCommandsFactory.STOP_TRACE);
                gameCanvas.removeCommand(gameCommandsFactory.START_TRACE);
            } else if (command == gameCommandsFactory.STOP_TRACE) {
                this.pauseAppBackground(false);
                this.debugInterface.stop();
                this.unPauseAppBackground(false);
                AllBinaryGameCanvas gameCanvas = ((AllBinaryGameCanvas) allbinaryGameCanvasRunnableInterface);
                gameCanvas.addCommand(gameCommandsFactory.START_TRACE);
                gameCanvas.removeCommand(gameCommandsFactory.STOP_TRACE);
            } else if (command == gameCommandsFactory.DEFAULT_OPTIONS) {
                Displayable tempDisplayable = displayable;
                if (tempDisplayable is GameOptionsForm) {
                    GameFeatureFormUtil.getInstance().setDefault(((CommandForm) tempDisplayable));
                }
            } else if (command == GameInputMappingInstructionsCanvas.DISPLAY) {
                Displayable tempDisplayable = displayable;
                if (tempDisplayable is GameInputMappingCanvas) {
                    GameInputMappingCanvas gameInputMappingCanvas = ((GameInputMappingCanvas) tempDisplayable);
                    gameInputMappingCanvas.update();
                }
                this.commandAction(gameCommandsFactory.SET_MENU_DISPLAYABLE, this.getInputMappingInstructionsCanvas());
            } else if (HighScoreCommandsFactory.getInstance().isHighScoreCommand(command)) {
                Displayable tempDisplayable = displayable;
                if (tempDisplayable is HighScoresCanvas) {
                    HighScoresCanvas highScoresCanvas = ((HighScoresCanvas) tempDisplayable);
                    highScoresCanvas.updateCommand(command);
                }
            } else if (command == HighScoreCommands.getInstance().DISPLAY) {
                this.commandAction(gameCommandsFactory.SET_MENU_DISPLAYABLE, this.createHighScoresCanvas());
            } else if (command == GameInputMappingInstructionsCanvas.CLOSE) {
                MenuListener menuListener = ((MenuListener) displayable);
                menuListener.close();
                this.commandAction(GameInputMappingCanvas.DISPLAY, NullCanvas.NULL_CANVAS);
            } else if (command == GameInputMappingCanvas.DISPLAY) {
                if (J2MEUtil.isHTML()) {
                    this.pauseAppBackground(false);
                }
                this.commandAction(gameCommandsFactory.SET_MENU_DISPLAYABLE, this.getInputMappingCanvas());
            } else if (command == GameInputMappingCanvas.DEFAULT) {
                Displayable tempDisplayable = displayable;
                if (tempDisplayable is GameInputMappingCanvas) {
                    GameInputMappingCanvas gameInputMappingCanvas = ((GameInputMappingCanvas) tempDisplayable);
                    gameInputMappingCanvas.setDefault();
                }
            } else if (command == InGameOptionsForm.DISPLAY) {
                this.pauseAppBackground(false);
                ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
                progressCanvas.addNormalPortion(50, "In Game Options");
                AllBinaryGameLayerManager layerManager = this.createGameLayerManager();
                InGameOptionsFormFactory inGameOptionsFormFactory = InGameOptionsFormFactory.getInstance();
                inGameOptionsFormFactory.init(this, new InGameFeatures(), "Options In Game", layerManager.getBackgroundBasicColor(), layerManager.getForegroundBasicColor());
                CommandForm inGameOptionsForm = inGameOptionsFormFactory.get();
                inGameOptionsForm.setItemStateListener(allbinaryGameCanvasRunnableInterface);
                this.commandAction(gameCommandsFactory.SET_MENU_DISPLAYABLE, inGameOptionsForm);
            } else if (command == InGameOptionsForm.DEFAULT) {
                InGameOptionsForm inGameOptionsForm = ((InGameOptionsForm) InGameOptionsFormFactory.getInstance().get());
                GameFeatureFormUtil.getInstance().setDefault(inGameOptionsForm);
            } else if (command == gameCommandsFactory.DISPLAY_OPTIONS) {
                AllBinaryMediaManager.setMuted(true);
                this.stopAll();
                MainFeatureFactory mainFeatureFactory = MainFeatureFactory.getInstance();
                this.isFullScreen = this.features.isFeature(mainFeatureFactory.FULL_SCREEN);
                ResizableListenerHandler.getInstance().fireEvent(true);
                this.setResized(false);
                this.commandAction(gameCommandsFactory.SET_MENU_DISPLAYABLE, this.getGameOptionsForm());
            } else if (command == gameCommandsFactory.CLOSE_OPTIONS) {
                ResizableListenerHandler.getInstance().fireEvent(false);
                this.commandAction(gameCommandsFactory.CLOSE_AND_SHOW_GAME_CANVAS, displayable);
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Close isFullScreen/change: ");
                stringBuffer.appendboolean(this.isFullScreen);
                stringBuffer.appendboolean(this.fullScreenUtil.isScreenChange(this.isFullScreen));
                stringBuffer.append(" isResized: ");
                stringBuffer.appendboolean(this.isResized());
                PreLogUtil.put(stringBuffer.ToString(), this, this.COMMAND_ACTION);
                if (this.isResized() || this.fullScreenUtil.isScreenChange(this.isFullScreen)) {
                    this.updateFullScreen();
                }
                AllBinaryMediaManager.setMuted(false);
            } else if (command == gameCommandsFactory.DISPLAY_LOAD_FORM) {
                this.pauseAppBackground(false);
                KeyValuePersistance keyValuePersistance = GamePersistanceSingleton.getInstance();
                keyValuePersistance.clear();
                keyValuePersistance.loadAll(this.abeClientInformation);
                if (this.getLoadGameForm() == CommandForm.getNullCommandForm()) {
                    AllBinaryGameLayerManager layerManager = this.createGameLayerManager();
                    this.setLoadGameForm(new LoadGameForm(this, "Load Game", layerManager.getBackgroundBasicColor(), layerManager.getForegroundBasicColor()));
                } else {
                    this.getLoadGameForm().update();
                }
                this.commandAction(gameCommandsFactory.SET_MENU_DISPLAYABLE, this.getLoadGameForm());
            } else if (command == gameCommandsFactory.LOAD_FILE) {
                LoadGameForm loadGameForm = ((LoadGameForm) this.getLoadGameForm());
                int index = loadGameForm.getSelectedId();
                if (index != -1) {
                    KeyValuePersistance keyValuePersistance = GamePersistanceSingleton.getInstance();
                    this.setStartStateHashtable(keyValuePersistance.get(index));
                    MenuListener menuListener = this.getLoadGameForm();
                    menuListener.close();
                    PreLogUtil.put(BasicMotionGesturesHandler.getInstance().ToString(), this, this.COMMAND_ACTION);
                    this.commandAction(gameCommandsFactory.START_COMMAND, NullCanvas.NULL_CANVAS);
                    PreLogUtil.put(BasicMotionGesturesHandler.getInstance().ToString(), this, this.COMMAND_ACTION);
                }
            } else if (command == gameCommandsFactory.DELETE_FILE) {
                LoadGameForm loadGameForm = ((LoadGameForm) this.getLoadGameForm());
                int index = loadGameForm.getSelectedText();
                if (index != -1) {
                    KeyValuePersistance keyValuePersistance = GamePersistanceSingleton.getInstance();
                    keyValuePersistance.delete(this.abeClientInformation, index);
                    keyValuePersistance.clear();
                    keyValuePersistance.loadAllSize(this.abeClientInformation, 1);
                    this.getLoadGameForm().update();
                }
            } else if (command == gameCommandsFactory.SAVE) {
                KeyValuePersistance keyValuePersistance = GamePersistanceSingleton.getInstance();
                this.pauseAppBackground(false);
                keyValuePersistance.save(this.abeClientInformation, this.getCurrentStateHashtable());
                this.unPauseAppBackground(false);
            } else if (command == HighScoreUtil.SUBMIT_TEXTBOX_COMMAND) {
                this.logUtil.putF("Submitted Score", this, this.COMMAND_ACTION);
                if (displayable is HighScoreTextBox) {
                    HighScoreTextBox highScoreTextBox = ((HighScoreTextBox) displayable);
                    highScoreTextBox.submitted = true;
                }
                allbinaryGameCanvasRunnableInterface.setHighScoreSubmitted(true);
                this.commandAction(gameCommandsFactory.CLOSE_AND_SHOW_GAME_CANVAS, displayable);
            } else if (command == gameCommandsFactory.DISPLAY_ABOUT) {
                this.aboutCommandProcessor.process(this, gameCommandsFactory.SET_MENU_DISPLAYABLE, this.getAboutCanvas());
            } else if (command == gameCommandsFactory.OPEN_WEB_URL) {
                this.webCommandProcessor.process(this, gameCommandsFactory.OPEN_WEB_URL, NullCanvas.NULL_CANVAS);
            } else if (command == gameCommandsFactory.TOGGLE_KEYBOARD) {
                VirtualKeyboardEventHandler virtualKeyboardEventHandler = VirtualKeyboardEventHandler.getInstance();
                virtualKeyboardEventHandler.fireEvent(virtualKeyboardEventHandler.SHOW_EVENT);
            } else if (this.tsUtil.compareTo(command.getLabel(), gameCommandsFactory.TOGGLE_FULLSCREEN.getLabel()) == 0) {
                MainFeatureFactory mainFeatureFactory = MainFeatureFactory.getInstance();
                bool isFullScreen = this.features.isFeature(mainFeatureFactory.FULL_SCREEN);
                if (isFullScreen) {
                    this.features.removeDefault(mainFeatureFactory.FULL_SCREEN);
                } else {
                    this.features.addDefault(mainFeatureFactory.FULL_SCREEN);
                }
                this.updateFullScreen();
            }
        } catch (Exception e) {
            this.logUtil.put(new StringMaker().append(this.commonStrings.EXCEPTION_LABEL).append(command.getLabel()).ToString(), this, this.midletStrings.COMMAND_ACTION, e);
            if (command != GameCommandsFactory.getInstance().EXIT_COMMAND) {
                this.exitProgress(false);
            }
        }
    }

    private void updateFullScreen()
    {
        MainFeatureFactory mainFeatureFactory = MainFeatureFactory.getInstance();
        bool isFullScreen = this.features.isFeature(mainFeatureFactory.FULL_SCREEN);
        Displayable displayable = this.getDisplay().getCurrent();
        if (displayable is Canvas) {
            Canvas canvas = ((Canvas) displayable);
            canvas.setFullScreenMode(isFullScreen);
        }
    }

    public virtual void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    // throws Exception
    public virtual MyCanvas getInputMappingInstructionsCanvas()
    {
        return new GameInputMappingInstructionsCanvas(this, this.createGameLayerManager());
    }

    // throws Exception
    public virtual MyCanvas getInputMappingCanvas()
    {
        return new GameInputMappingCanvas(this.abeClientInformation, this, this.createGameLayerManager(), this.getHelpPaintable());
    }

    // throws Exception
    public virtual MyCanvas getAboutCanvas()
    {
        return new BasicPaintablesCanvas(this, CanvasStrings.getInstance().ABOUT, this.createGameLayerManager(), AboutPaintableFactory.getInstance().paintableArray);
    }

    // throws Exception
    public virtual HelpPaintable getHelpPaintable()
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    // throws Exception
    public virtual HighScoresCanvas createHighScoresCanvas()
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    // throws Exception
    public virtual void startGameCanvasRunnableInterface()
    {
        ThreadFactoryUtil threadFactoryUtil = ThreadFactoryUtil.getInstance();
        this.thread = threadFactoryUtil.getInstanceGameCanvasRunnable(this.allbinaryGameCanvasRunnableInterface);
        this.logUtil.putF(new StringMaker().append("Thread Priority: ").appendint(((int) this.thread.getPriority())).ToString(), this, "startGameCanvasRunnableInterface");
        this.allbinaryGameCanvasRunnableInterface.setThread(this.thread);
        threadFactoryUtil.start(this.thread);
    }

    // throws Exception
    public virtual void stopGameCanvasRunnableInterface()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.gameStrings.STOP_GAME_CANVAS_RUNNABLE_INTERFACE);
        GameNotificationEventHandler.getInstance().removeAllListeners();
        ColorChangeEventHandler.getInstance().removeAllListeners();
        GameEventHandlerUtil.removeAllListeners();
        GameCanvasRunnableInterface gameCanvasRunnableInterface = this.allbinaryGameCanvasRunnableInterface;
        if (gameCanvasRunnableInterface != NullGameCanvasRunnable.NULL_GAME_CANVAS_RUNNABLE) {
            this.logUtil.putF(new StringMaker().append("Set Running False: ").append(gameCanvasRunnableInterface.ToString()).ToString(), this, this.gameStrings.STOP_GAME_CANVAS_RUNNABLE_INTERFACE);
            gameCanvasRunnableInterface.setRunning(false);
        } else {
            this.logUtil.putF("StopGame - Could Not Stop", this, this.gameStrings.STOP_GAME_CANVAS_RUNNABLE_INTERFACE);
        }
        ThreadUtil.getInstance().join(this.thread);
        ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
        if (this.features.isFeature(MainFeatureFactory.getInstance().LOAD_ALL)) {
            progressCanvas.addNormalPortion(50, "Stopped Game Runnable");
        } else {
            progressCanvas.addNormalPortion(50, "Stopped Main Runnable");
        }
        this.logUtil.putF(this.commonStrings.END, this, this.gameStrings.STOP_GAME_CANVAS_RUNNABLE_INTERFACE);
    }

    public virtual GameCanvasRunnableInterface getGameCanvasRunnableInterface()
    {
        return this.allbinaryGameCanvasRunnableInterface;
    }

    public virtual void setGameCanvasRunnableInterface(GameCanvasRunnableInterface gameCanvasRunnableInterface)
    {
        this.allbinaryGameCanvasRunnableInterface = gameCanvasRunnableInterface;
    }

    public virtual AllBinaryGameLayerManager createGameLayerManager()
    {
        GameInfo gameInfo = new GameInfo(GameTypeFactory.getInstance().SINGLE_PLAYER, GameMode.SERVER, PlayerTypesFactory.getInstance().PLAYER_TYPE_ONE, 1, 1);
        return new AllBinaryGameLayerManager(this.basicColorFactory.BLACK, this.basicColorFactory.WHITE, gameInfo);
    }

    public virtual CommandForm getGameOptionsForm()
    {
        AllBinaryGameLayerManager layerManager = this.createGameLayerManager();
        return GameOptionsFormFactory.getInstance().init(this, "Game Options", layerManager.getBackgroundBasicColor(), layerManager.getForegroundBasicColor());
    }

    // throws Exception
    public virtual void save()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.SAVE);
        ABHashtable<object, object> hashtable = this.getCurrentStateHashtable();
        GamePersistanceSingleton.getInstance().save(this.abeClientInformation, hashtable);
    }

    // throws Exception
    public override ABHashtable<object, object> getCurrentStateHashtable()
    {
        this.logUtil.putF(this.commonStrings.START, this, "getCurrentStateHashtable");
        ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
        if (this.allbinaryGameCanvasRunnableInterface != NullGameCanvasRunnable.NULL_GAME_CANVAS_RUNNABLE) {
            ABHashtable<object, object> currentHashtable = this.allbinaryGameCanvasRunnableInterface.getCurrentStateHashtable();
            Enumeration<object> enumeration = currentHashtable.keys();
            object key = null;
            while (this.enumerationUtil.hasMoreElements(enumeration)) {
                key = this.enumerationUtil.nextElement(enumeration);
                hashtable.put(key, currentHashtable.get(key));
            }
        }
        return hashtable;
    }

    public virtual void setLoadGameForm(LoadGameForm loadGameForm)
    {
        this.loadGameForm = loadGameForm;
    }

    public virtual CommandForm getLoadGameForm()
    {
        return this.loadGameForm;
    }

    public virtual void setResized(bool resized)
    {
        this.resized = resized;
    }

    public virtual bool isResized()
    {
        return this.resized;
    }

    private bool startedBefore = false;
    public virtual bool isDemoLoading()
    {
        if (this.startedBefore) {
            return false;
        }
        Displayable displayable = this.getDisplay().getCurrent();
        if (displayable is DemoCanvas) {
            DemoCanvas demoCanvas = ((DemoCanvas) displayable);
            if (demoCanvas.isDemoLoading()) {
                return true;
            }
        }
        return false;
    }

}

