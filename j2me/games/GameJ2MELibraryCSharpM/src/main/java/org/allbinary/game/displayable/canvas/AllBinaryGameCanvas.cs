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
//using ChoiceGroup = javax.microedition.lcdui.ChoiceGroup;
//using CommandListener = javax.microedition.lcdui.CommandListener;
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
//using Item = javax.microedition.lcdui.Item;
//using NullCommandListener = javax.microedition.lcdui.NullCommandListener;
using AndroidUtil = org.allbinary.AndroidUtil;
using J2MEUtil = org.allbinary.J2MEUtil;
using GameAdStateFactory = org.allbinary.business.advertisement.GameAdStateFactory;
using BaseGameStatistics = org.allbinary.canvas.BaseGameStatistics;
using GameStatisticsFactory = org.allbinary.canvas.GameStatisticsFactory;
using Processor = org.allbinary.canvas.Processor;
using RunnableCanvas = org.allbinary.canvas.RunnableCanvas;
using DebugFactory = org.allbinary.debug.DebugFactory;
using NoDebug = org.allbinary.debug.NoDebug;
using GameAdState = org.allbinary.game.GameAdState;
using GameInfo = org.allbinary.game.GameInfo;
using GameStrings = org.allbinary.game.GameStrings;
using GameTypeFactory = org.allbinary.game.GameTypeFactory;
using Intermission = org.allbinary.game.Intermission;
using IntermissionCompositeInterface = org.allbinary.game.IntermissionCompositeInterface;
using IntermissionEnableListenerInterface = org.allbinary.game.IntermissionEnableListenerInterface;
using IntermissionInterface = org.allbinary.game.IntermissionInterface;
using PlayerTypesFactory = org.allbinary.game.PlayerTypesFactory;
using GameCommandsFactory = org.allbinary.game.commands.GameCommandsFactory;
using InGameFeatures = org.allbinary.game.configuration.InGameFeatures;
using InGameOptionsForm = org.allbinary.game.configuration.InGameOptionsForm;
using ChangedGameFeatureListener = org.allbinary.game.configuration.@event.ChangedGameFeatureListener;
using GameInitializedEvent = org.allbinary.game.configuration.@event.GameInitializedEvent;
using GameInitializedEventHandler = org.allbinary.game.configuration.@event.GameInitializedEventHandler;
using Features = org.allbinary.game.configuration.feature.Features;
using GameFeatureFactory = org.allbinary.game.configuration.feature.GameFeatureFactory;
using GameFeatureUtil = org.allbinary.game.configuration.feature.GameFeatureUtil;
using InputFeatureFactory = org.allbinary.game.configuration.feature.InputFeatureFactory;
using MainFeatureFactory = org.allbinary.game.configuration.feature.MainFeatureFactory;
using SensorFeatureFactory = org.allbinary.game.configuration.feature.SensorFeatureFactory;
using TouchFeatureFactory = org.allbinary.game.configuration.feature.TouchFeatureFactory;
using GameLevelDisplayChangeEventListenersFactory = org.allbinary.game.displayable.GameLevelDisplayChangeEventListenersFactory;
using BasicBuildGameInitializerFactory = org.allbinary.game.init.BasicBuildGameInitializerFactory;
using GameInitializationUtil = org.allbinary.game.init.GameInitializationUtil;
using GameInputStrings = org.allbinary.game.input.GameInputStrings;
using InputProcessor = org.allbinary.game.input.InputProcessor;
using NoPlayerGameInput = org.allbinary.game.input.NoPlayerGameInput;
using PlayerGameInput = org.allbinary.game.input.PlayerGameInput;
using GameKeyEventHandler = org.allbinary.game.input.@event.GameKeyEventHandler;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using SWTUtil = org.allbinary.game.layer.SWTUtil;
using ColorFillBasePaintable = org.allbinary.game.paint.ColorFillBasePaintable;
using ColorFillPaintableFactory = org.allbinary.game.paint.ColorFillPaintableFactory;
using ResourceLoadingLevel = org.allbinary.game.resource.ResourceLoadingLevel;
using ResourceLoadingLevelFactory = org.allbinary.game.resource.ResourceLoadingLevelFactory;
using HighScore = org.allbinary.game.score.HighScore;
using HighScoresHelperBaseInterface = org.allbinary.game.score.HighScoresHelperBaseInterface;
using HighScoresFactoryInterface = org.allbinary.game.score.HighScoresFactoryInterface;
using HighScoresPaintable = org.allbinary.game.score.HighScoresPaintable;
using NullHighScoresSingletonFactory = org.allbinary.game.score.NullHighScoresSingletonFactory;
using HighScoreTextBox = org.allbinary.game.score.displayable.HighScoreTextBox;
using GameState = org.allbinary.game.state.GameState;
using GameStateFactory = org.allbinary.game.state.GameStateFactory;
using GraphicsStrings = org.allbinary.graphics.GraphicsStrings;
using Rectangle = org.allbinary.graphics.Rectangle;
using ScreenCapture = org.allbinary.graphics.ScreenCapture;
using ScreenCaptureFactory = org.allbinary.graphics.ScreenCaptureFactory;
using ProgressCanvas = org.allbinary.graphics.canvas.transition.progress.ProgressCanvas;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using BasicColorSetUtil = org.allbinary.graphics.color.BasicColorSetUtil;
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using GameTickDisplayInfoSingleton = org.allbinary.graphics.displayable.GameTickDisplayInfoSingleton;
using MyCommandsFactory = org.allbinary.graphics.displayable.command.MyCommandsFactory;
using DisplayChangeEvent = org.allbinary.graphics.displayable.@event.DisplayChangeEvent;
using DisplayChangeEventHandler = org.allbinary.graphics.displayable.@event.DisplayChangeEventHandler;
using DisplayChangeEventListener = org.allbinary.graphics.displayable.@event.DisplayChangeEventListener;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using CommandCurrentSelectionFormFactory = org.allbinary.graphics.form.CommandCurrentSelectionFormFactory;
using FormPaintable = org.allbinary.graphics.form.FormPaintable;
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
using NullInitUpdatePaintable = org.allbinary.graphics.paint.NullInitUpdatePaintable;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using Paintable = org.allbinary.graphics.paint.Paintable;
using PaintableInterface = org.allbinary.graphics.paint.PaintableInterface;
using OpenGLImageSpecificFactory = org.allbinary.image.opengles.OpenGLImageSpecificFactory;
using SensorGameUpdateProcessor = org.allbinary.input.gyro.SensorGameUpdateProcessor;
using SingleSensorGameUpdateProcessor = org.allbinary.input.gyro.SingleSensorGameUpdateProcessor;
using BaseTouchInput = org.allbinary.input.motion.button.BaseTouchInput;
using NoButtonsTouchInputFactory = org.allbinary.input.motion.button.NoButtonsTouchInputFactory;
using TouchButtonFactory = org.allbinary.input.motion.button.TouchButtonFactory;
using TouchButtonsPaintableFactory = org.allbinary.input.motion.button.TouchButtonsPaintableFactory;
using TouchScreenFactory = org.allbinary.input.motion.button.TouchScreenFactory;
using BasicMotionGesturesHandler = org.allbinary.input.motion.gesture.observer.BasicMotionGesturesHandler;
using ABSystemWrapper = org.allbinary.logic.ABSystemWrapper;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using OperatingSystemFactory = org.allbinary.logic.system.os.OperatingSystemFactory;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using AllBinaryMediaManager = org.allbinary.media.audio.AllBinaryMediaManager;
using PlayerQueue = org.allbinary.media.audio.PlayerQueue;
using PrimaryPlayerQueueFactory = org.allbinary.media.audio.PrimaryPlayerQueueFactory;
using SecondaryPlayerQueueFactory = org.allbinary.media.audio.SecondaryPlayerQueueFactory;
using SelectSound = org.allbinary.media.audio.SelectSound;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using SecondaryThreadPool = org.allbinary.thread.SecondaryThreadPool;
using GameTickTimeDelayHelper = org.allbinary.time.GameTickTimeDelayHelper;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using org.allbinary.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.game.displayable.canvas;

public class AllBinaryGameCanvas : RunnableCanvas, AllBinaryGameCanvasInterface, GameCanvasRunnableInterface, MenuListener, IntermissionCompositeInterface, IntermissionEnableListenerInterface, PopupMenuInterface, DisplayChangeEventListener, UpdateMyFontInterface
{
    public readonly BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
    public readonly BasicColorSetUtil basicSetColorUtil = BasicColorSetUtil.getInstance();
    public readonly TouchFeatureFactory touchFeatureFactory = TouchFeatureFactory.getInstance();
    public readonly OpenGLFeatureFactory openGLFeatureFactory = OpenGLFeatureFactory.getInstance();
    public readonly TouchButtonFactory touchButtonFactory = TouchButtonFactory.getInstance();
    public readonly GameAdStateFactory gameAdStateFactory = GameAdStateFactory.getInstance();
    public readonly GameStrings gameStrings = GameStrings.getInstance();
    public readonly GameInputStrings gameInputStrings = GameInputStrings.getInstance();
    public readonly GameStateFactory gameStateFactory = GameStateFactory.getInstance();
    private readonly GameTickTimeDelayHelper gameTickTimeDelayHelper = GameTickTimeDelayHelperFactory.getInstance();
    private readonly GameTickDisplayInfoSingleton gameTickDisplayInfoSingleton = GameTickDisplayInfoSingleton.getInstance();
    public readonly GameCanvasRunnable gameRunnable;
    public readonly GameCanvasPauseRunnable gamePauseRunnable;
    public readonly FormUtil formUtil = FormUtil.getInstance();
    public readonly MyFormUtil myFormUtil = MyFormUtil.getInstance();
    private readonly MyFontProcessor updateMyFontProcessor;
    private MyFontProcessor myFontProcessor;
    public Paintable gameSpecificPaintable = NullPaintable.getInstance();
    private readonly SensorGameUpdateProcessor sensorGameUpdateProcessor = new SingleSensorGameUpdateProcessor();
    public EndGameInfo endGameInfo = new EndGameInfo();
    private readonly IntermissionInterface startIntermissionInterface = new Intermission();
    private readonly IntermissionInterface endLevelIntermissionInterface = new Intermission();
    private static readonly int id = 0;
    public AllBinaryGameLayerManager gameLayerManager = AllBinaryGameLayerManager.getNullInstance();
    private GameState gameState;
    private bool gameOver = false;
    private bool initialized = false;
    private readonly TimeDelayHelper gameStateTimeHelper = new TimeDelayHelper(0);
    public readonly HighScoresHelperBaseInterface highScoresHelper;
    private bool highScoreSubmitted = false;
    private readonly HighScoresPaintable realHighScoresPaintable = new HighScoresPaintable();
    private Paintable highScoresPaintable = NullPaintable.getInstance();
    private BasicArrayList localPlayerGameInputList = new BasicArrayListD();
    private bool isCheating = false;
    private ABHashtable<object, object> hashtable;
    private bool isSingleKeyRepeatableProcessing = false;
    private BasicBuildGameInitializerFactory gameInitializationInterfaceFactoryInterface = BasicBuildGameInitializerFactory.NULL_BASE_BUILD_GMAE_INITIALIZER_FACTORY;
    private Paintable touchButtonsPaintable = NullPaintable.getInstance();
    public Paintable touchPaintable = NullPaintable.getInstance();
    private PlayerGameInput cheatProcessor = NoPlayerGameInput.getInstance();
    private Processor gameInputProcessor = Processor.getInstance();
    private Processor endGameProcessor = Processor.getInstance();
    private Processor realEndGameProcessor = Processor.getInstance();
    private Processor startIntermissionProcessor = Processor.getInstance();
    private Processor realStartIntermissionProcessor = Processor.getInstance();
    private Paintable endGamePaintable = NullPaintable.getInstance();
    private Paintable endGameStatePaintable = NullPaintable.getInstance();
    public Paintable nonBotPaintable = NullPaintable.getInstance();
    private Paintable intermissionPaintable = NullPaintable.getInstance();
    private InitUpdatePaintable startIntermissionPaintable = NullInitUpdatePaintable.getInstance();
    private Processor mainStateProcessor = Processor.getInstance();
    private Processor processGameProcessor = Processor.getInstance();
    private readonly HighScoresFactoryInterface highScoresFactoryInterface;
    private int startLevel = 0;
    private BasicMenuInputProcessor mainMenuInputProcessor = NoMenuInputProcessor.getInstance();
    private BasicMenuInputProcessor popupMenuInputProcessor = NoMenuInputProcessor.getInstance();
    private BasicMenuInputProcessor menuInputProcessor = NoMenuInputProcessor.getInstance();
    private ScrollSelectionForm menuForm = ScrollSelectionForm.getNullScrollSelectionForm();
    private Paintable formPaintable = NullPaintable.getInstance();
    private Paintable openMenuPaintable = NullPaintable.getInstance();
    private Paintable menuPaintable = NullPaintable.getInstance();
    private BaseTouchInput currentTouchInputFactory = NoButtonsTouchInputFactory.getInstance();
    public ColorFillBasePaintable colorFillPaintable;
    private readonly BaseGameStatistics baseGameStatistics = GameStatisticsFactory.getInstance();
    private readonly PlayerQueue primaryPlayerQueue = PrimaryPlayerQueueFactory.getInstance();
    private readonly PlayerQueue secondaryPlayerQueue = SecondaryPlayerQueueFactory.getInstance();
    public readonly string BUILD_GAME = "buildGame";
    public readonly GameTypeFactory gameTypeFactory = GameTypeFactory.getInstance();
    public readonly ScreenCapture screenCapture = ScreenCaptureFactory.getInstance();
    private readonly BasicMotionGesturesHandler basicMotionGesturesHandler = BasicMotionGesturesHandler.getInstance();
    private readonly GameKeyEventHandler gameKeyEventHandler = GameKeyEventHandler.getInstance();
    private readonly DemoGameBehavior gameBehavior = null;
    private readonly BaseMenuBehavior menuBehavior = null;
    private PaintableInterface progressPaintable = ProgressCanvasFactory.getLazyInstance();
    public int fontHeightP = 0;
    public AllBinaryGameCanvas(CommandListener commandListener, AllBinaryGameLayerManager gameLayerManager, HighScoresFactoryInterface highScoresFactoryInterface, BasicBuildGameInitializerFactory gameInitializationInterfaceFactoryInterface, bool buffered) : base(commandListener, CanvasStrings.getInstance().EMPTY_CHILD_NAME_LIST, true)
    {
        this.gameRunnable = new GameCanvasRunnable(this);
        this.gamePauseRunnable = new GameCanvasPauseRunnable(this);
        this.updateMyFontProcessor = new UpdateMyFontProcessor(this);
        this.myFontProcessor = this.updateMyFontProcessor;
        this.gameState = this.gameStateFactory.NO_GAME_STATE;
        this.hashtable = this.stdUtil.NULL_TABLE;
        this.colorFillPaintable = ColorFillPaintableFactory.getInstance().getInstance(this.basicColorFactory.BLACK, true);
        this.rawGameInputProcessor = new GameCanvasInputProcessor(this);
        this.rawInputProcessor = new FormInputProcessor(this);
        this.inputProcessor = this.getRawGameInputProcessor();
        // base(commandListener, CanvasStrings.getInstance().EMPTY_CHILD_NAME_LIST, true) is called from the constructor declaration
        this.highScoresHelper = highScoresFactoryInterface.createHighScoresHelper();
        this.gameInitializationInterfaceFactoryInterface = gameInitializationInterfaceFactoryInterface;
        this.init(gameLayerManager, buffered);
        this.highScoresFactoryInterface = highScoresFactoryInterface;
        if (this.gameLayerManager.getGameInfo().getGameType() == this.gameTypeFactory.BOT || this.gameLayerManager.getGameInfo().getGameType() == this.gameTypeFactory.NONE) {
            this.gameBehavior = DemoGameBehavior.getInstance();
            this.menuBehavior = BaseMenuBehavior.getInstance();
        } else {
            this.gameBehavior = BaseGameBehavior.getInstance();
            this.menuBehavior = this.getInGameMenuBehavior();
        }
        this.initPopupMenu();
        this.initMenu();
        this.initSpecialPaint();
        DisplayChangeEventHandler.getInstance().addListenerInterface(this);
    }

    public override void updateMeasurement(Graphics graphics)
    {
        try {
            Font font = graphics.getFont();
            this.logUtil.putF(new StringMaker().append(this.commonStrings.START).append(this.canvasStrings.FD_WIDTH).appendint(((int) MyFontProcessor.defaultCharWidth(font))).append(this.canvasStrings.FD_HEIGHT).appendint(((int) font.getHeight())).ToString(), this, this.canvasStrings.UPDATE_MEASUREMENT);
            this.fontHeightP = font.getHeight();
            this.myFormUtil.updateMeasurement(graphics);
            Rectangle popupMenuRectangle = this.myFormUtil.getPopupMenuRectangle();
            BasicPopupMenuPaintable basicPopupMenuPaintable = (((BasicPopupMenuPaintable) this.getOpenMenuPaintable()));
            basicPopupMenuPaintable.init(popupMenuRectangle);
            if (this.getPopupMenuInputProcessor() != NoMenuInputProcessor.getInstance()) {
                PopupMenuInputProcessor popupMenuInputProcessor = (((PopupMenuInputProcessor) this.getPopupMenuInputProcessor()));
                popupMenuInputProcessor.init(popupMenuRectangle);
            }
            this.myFontProcessor = MyFontProcessor.getInstance();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.canvasStrings.ON_DISPLAY_CHANGE_EVENT, e);
        }
    }

    public virtual BaseMenuBehavior getInGameMenuBehavior()
    {
        return InGameMenuBehavior.getInstance();
    }

    public override void setCurrentThread()
    {
        if (J2MEUtil.isHTML()) {
            base.setCurrentThreadFake();
        } else {
            base.setCurrentThread();
        }
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    public override void onDisplayChangeEvent(DisplayChangeEvent displayChangeEvent)
    {
        try {
            this.logUtil.putF(new StringMaker().append(this.commonStrings.START).append(DisplayInfoSingleton.getInstance().ToString()).ToString(), this, this.canvasStrings.UPDATE_MEASUREMENT);
            this.myFontProcessor = this.updateMyFontProcessor;
            this.menuBehavior.onDisplayChangeEvent(this, displayChangeEvent);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.canvasStrings.ON_DISPLAY_CHANGE_EVENT, e);
        }
    }

    // throws Exception
    public virtual void updateMenuFromEvent(DisplayChangeEvent displayChangeEvent)
    {
        FormType formType = FormTypeFactory.getInstance().getFormType();
        Rectangle rectangle = this.formUtil.createFormRectangle();
        this.menuForm.init(rectangle, formType);
        if (this.currentTouchInputFactory != NoButtonsTouchInputFactory.getInstance()) {
            this.touchButtonFactory.toggle(this.isPaused(), this.currentTouchInputFactory.getList());
        }
        this.myFontProcessor = this.updateMyFontProcessor;
    }

    // throws Exception
    public override void processSleep()
    {
        base.processSleep();
        if (AllBinaryMediaManager.update()) {
            if (!this.primaryPlayerQueue.process()) {
                this.secondaryPlayerQueue.process();
            }
        }
        if (this.menuInputProcessor.processInputList() != -1) {
            this.runnableCanvasRefreshHelper.process();
        }
    }

    // throws Exception
    protected virtual void initPopupMenu()
    {
        if (this.popupMenuInputProcessor == NoMenuInputProcessor.getInstance()) {
            Features features = Features.getInstance();
            Rectangle popupMenuRectangle = this.myFormUtil.getPopupMenuRectangle();
            if (features.isFeature(this.touchFeatureFactory.TOUCH_ENABLED)) {
                this.setOpenMenuPaintable(new BasicPopupMenuPaintable(popupMenuRectangle, this.gameLayerManager.getBackgroundBasicColor(), this.gameLayerManager.getForegroundBasicColor()));
                this.setPopupMenuInputProcessor(new PopupMenuInputProcessor(new BasicArrayListD(), -1, this, popupMenuRectangle));
            }
        } else {
        }
    }

    protected virtual void initMenu()
    {
        try {
            this.menuBehavior.initMenu(this);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "initMenu", e);
        }
    }

    // throws Exception
    protected virtual void initMenu2()
    {
        this.closeMenu();
        FormType formType = FormTypeFactory.getInstance().getFormType();
        GameLimitedCommandTextItemArrayFactory gameLimitedCommandTextItemArrayFactory = GameLimitedCommandTextItemArrayFactory.getInstance();
        CommandTextItemArrayFactory commandTextItemArrayFactory = gameLimitedCommandTextItemArrayFactory.getCommandTextItemArrayFactory();
        ABCustomItem[] items = commandTextItemArrayFactory.getInstance(this.getCommandStack(), this.gameLayerManager.getBackgroundBasicColor(), this.gameLayerManager.getForegroundBasicColor());
        Rectangle rectangle = this.formUtil.createFormRectangle();
        this.setMenuForm(CommandCurrentSelectionFormFactory.getInstance(StringUtil.getInstance().EMPTY_STRING, items, rectangle, formType, 25, false, this.gameLayerManager.getBackgroundBasicColor(), this.gameLayerManager.getForegroundBasicColor()));
        ScrollSelectionForm scrollSelectionForm = this.getMenuForm();
        Features features = Features.getInstance();
        if (features.isFeature(this.touchFeatureFactory.TOUCH_ENABLED)) {
            this.mainMenuInputProcessor = new PopupCommandFormInputProcessor(new BasicArrayListD(), -1, this, scrollSelectionForm, ((PopupMenuInputProcessor) this.getPopupMenuInputProcessor()));
        } else {
        }
        this.setMenuInputProcessor(this.getPopupMenuInputProcessor());
        if (scrollSelectionForm != ScrollSelectionFormNoneFactory.getInstance()) {
            this.setFormPaintable(new FormPaintable(scrollSelectionForm));
        } else {
        }
        this.closeMenu();
    }

    public virtual void updateMenu()
    {
        try {
            this.menuBehavior.updateMenu(this);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "initMenu", e);
        }
    }

    // throws Exception
    public virtual void updateMenu2()
    {
        ScrollSelectionForm scrollSelectionForm = this.getMenuForm();
        scrollSelectionForm.deleteAll();
        GameLimitedCommandTextItemArrayFactory gameLimitedCommandTextItemArrayFactory = GameLimitedCommandTextItemArrayFactory.getInstance();
        CommandTextItemArrayFactory commandTextItemArrayFactory = gameLimitedCommandTextItemArrayFactory.getCommandTextItemArrayFactory();
        ABCustomItem[] items = commandTextItemArrayFactory.getInstance(this.getCommandStack(), this.gameLayerManager.getBackgroundBasicColor(), this.gameLayerManager.getForegroundBasicColor());
        int size = items.Length;
        for (int index = 0; index < size; index++) {
            scrollSelectionForm.append(items[index]);
        }
        FormType formType = FormTypeFactory.getInstance().getFormType();
        Rectangle rectangle = this.formUtil.createFormRectangle();
        scrollSelectionForm.init(rectangle, formType);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void pause()
    {
        this.gameBehavior.pause(this);
        this.closeMenu();
        base.pause();
        this.touchButtonFactory.toggle(this.isPaused(), BasicArrayListUtil.getInstance().getImmutableInstance());
        this.tsUtil.gc();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void unPause()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.gameStrings.UNPAUSE);
        this.closeMenu();
        this.tsUtil.gc();
        base.unPause();
        this.touchButtonFactory.toggle(this.isPaused(), BasicArrayListUtil.getInstance().getImmutableInstance());
        this.gameBehavior.unPause(this);
    }

    public override bool isPausable()
    {
        if (CurrentDisplayableFactory.getInstance().getUsedRunnable() == NullWaitGameRunnable.getInstance()) {
            return true;
        } else {
            return false;
        }
    }

    // throws Exception
    public override void popupMenu()
    {
        this.menuBehavior.popupMenu(this);
    }

    // throws Exception
    public virtual void popupMenu2()
    {
        this.primaryPlayerQueue.add(SelectSound.getInstance());
        this.setMenuPaintable(this.getFormPaintable());
        this.setMenuInputProcessor(this.mainMenuInputProcessor);
        this.basicMotionGesturesHandler.addListenerInterface(this.mainMenuInputProcessor);
        this.gameKeyEventHandler.addListener(this.mainMenuInputProcessor);
    }

    // throws Exception
    public override void toggleMenu()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.gameStrings.TOGGLE_MENU);
        if (this.getMenuPaintable() == this.getOpenMenuPaintable()) {
            this.pause();
            this.updateMenu();
            this.popupMenu();
        } else if (this.getMenuPaintable() == this.getFormPaintable()) {
            this.primaryPlayerQueue.add(SelectSound.getInstance());
            this.unPause();
        }
    }

    public override void closeMenu()
    {
        this.menuBehavior.closeMenu(this);
    }

    public virtual void closeMenu2()
    {
        this.setMenuPaintable(this.getOpenMenuPaintable());
        this.basicMotionGesturesHandler.removeListener(this.mainMenuInputProcessor);
        this.gameKeyEventHandler.removeListener(this.mainMenuInputProcessor);
        this.setMenuInputProcessor(this.getPopupMenuInputProcessor());
    }

    public override void open()
    {
        this.basicMotionGesturesHandler.addListenerInterface(this.menuInputProcessor);
        this.gameKeyEventHandler.addListener(this.menuInputProcessor);
    }

    public override void close()
    {
        this.basicMotionGesturesHandler.removeListener(this.menuInputProcessor);
        this.gameKeyEventHandler.removeListener(this.menuInputProcessor);
        this.primaryPlayerQueue.clear();
        this.secondaryPlayerQueue.clear();
    }

    // throws Exception
    protected virtual void processorInit()
    {
        this.setMainStateProcessor(Processor.getInstance());
        this.setProcessGameProcessorInit();
    }

    protected virtual void setProcessGameProcessorInit()
    {
        this.setProcessGameProcessor(new GameProcessor(this));
    }

    protected virtual void initSpecialPaint()
    {
        this.menuBehavior.initSpecialPaint(this);
    }

    // throws Exception
    private void init(AllBinaryGameLayerManager gameLayerManager, bool buffered)
    {
        this.gameStateTimeHelper.setStartTimeTNT();
        this.setHighScoreSubmitted(false);
        this.setLayerManager(gameLayerManager);
        if (!buffered) {
            string BUFF_MESSAGE = "XXX Not Buffering Causes Concurrency Issues XXX";
            this.logUtil.putF(BUFF_MESSAGE, this, this.commonStrings.CONSTRUCTOR);
        } else {
            throw new Exception("Buffering is disabled");
        }
        this.setGameInputProcessor(Processor.getInstance());
        Features features = Features.getInstance();
        if (features.isFeature(GameFeatureFactory.getInstance().CHEATING)) {
            this.isCheating = true;
            this.cheatProcessor = new CheatGameInputProcessor(this);
            this.gameKeyEventHandler.addListener(this.cheatProcessor);
        } else {
            this.isCheating = false;
            this.cheatProcessor = NoPlayerGameInput.getInstance();
        }
        this.realEndGameProcessor = new EndGameProcessor(this);
        this.setEndGameProcessor(Processor.getInstance());
        this.realStartIntermissionProcessor = new StartIntermissionProcessor(this);
        this.startIntermissionProcessor = Processor.getInstance();
        this.setEndGameStatePaintable(new EndGamePaintable(this));
        this.setEndGamePaintable(NullPaintable.getInstance());
        this.setIntermissionPaintable(NullPaintable.getInstance());
        this.getStartIntermissionInterface().setListener(this);
    }

    public override void notifyIntermission(bool enable)
    {
        if (enable) {
            this.startIntermissionProcessor = this.realStartIntermissionProcessor;
        } else {
            this.startIntermissionProcessor = Processor.getInstance();
        }
        if (enable) {
            this.setIntermissionPaintable(this.getStartIntermissionPaintable());
        } else {
            this.setIntermissionPaintable(NullPaintable.getInstance());
        }
    }

    // throws Exception
    public virtual void mediaInit()
    {
        ForcedLogUtil.log(this.commonStrings.NOT_IMPLEMENTED, this);
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    protected virtual void initConfigurable(AbeClientInformationInterface abeClientInformation)
    {
        ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
        progressCanvas.addNormalPortion(50, "Setting Configurables");
        GameInitializationUtil.getInstance().initGame(abeClientInformation, this, this.gameInitializationInterfaceFactoryInterface);
        GameFeatureFactory gameFeatureFactory = GameFeatureFactory.getInstance();
        ChangedGameFeatureListener changedGameFeatureListener = ChangedGameFeatureListener.getInstance();
        if (changedGameFeatureListener.isChangedFeature(gameFeatureFactory.SOUND)) {
            Features features = Features.getInstance();
            this.logUtil.putF(new StringMaker().append("Sound Changing To: ").appendboolean(features.isFeature(gameFeatureFactory.SOUND)).ToString(), this, "initConfigurable");
            this.mediaInit();
            changedGameFeatureListener.remove(gameFeatureFactory.SOUND);
        }
        SensorFeatureFactory sensorFeatureFactory = SensorFeatureFactory.getInstance();
        if (changedGameFeatureListener.isChangedFeature(sensorFeatureFactory.ORIENTATION_SENSORS) || changedGameFeatureListener.isChangedFeature(sensorFeatureFactory.NO_ORIENTATION) || changedGameFeatureListener.isChangedFeature(sensorFeatureFactory.SIMULATED_ORIENTATION_SENSORS)) {
            changedGameFeatureListener.remove(sensorFeatureFactory.NO_ORIENTATION);
            changedGameFeatureListener.remove(sensorFeatureFactory.ORIENTATION_SENSORS);
            changedGameFeatureListener.remove(sensorFeatureFactory.SIMULATED_ORIENTATION_SENSORS);
        }
        ResourceLoadingLevelFactory resourceLoadingLevelFactory = ResourceLoadingLevelFactory.getInstance();
        this.loadResourceLoadingLevel(resourceLoadingLevelFactory.LOAD_GAME);
    }

    // throws Exception
    protected virtual void initApp(AbeClientInformationInterface abeClientInformation)
    {
        this.initConfigurable(abeClientInformation);
        this.processorInit();
        this.sensorGameUpdateProcessor.process(this.gameLayerManager);
        this.sensorGameUpdateProcessor.sendNotifications(this.gameLayerManager);
        this.initTouch();
    }

    // throws Exception
    protected virtual void initTouch()
    {
        GameInitializedEvent gameInitializedEvent = GameInitializationUtil.getInstance().EVENT;
        ResourceLoadingLevelFactory resourceLoadingLevelFactory = ResourceLoadingLevelFactory.getInstance();
        gameInitializedEvent.setResourceLoadingLevel(resourceLoadingLevelFactory.LOAD_TOUCH);
        GameInitializedEventHandler.getInstance().fireEvent(gameInitializedEvent);
        this.touchButtonFactory.defaultList();
        this.updateTouch();
        this.postInitTouch();
    }

    // throws Exception
    public virtual void updateCurrentTouchInputFactory(BaseTouchInput nextTouchInput)
    {
        if (nextTouchInput != this.currentTouchInputFactory) {
            this.currentTouchInputFactory = nextTouchInput;
            PreLogUtil.put(this.currentTouchInputFactory.ToString(), this, this.gameInputStrings.UDPATE_CURRENT_TOUCH_INPUT_FACTORY);
            this.touchButtonFactory.toggle(this.isPaused(), this.currentTouchInputFactory.getList());
        }
    }

    // throws Exception
    protected virtual void updateTouch()
    {
        this.gameBehavior.updateTouch(this);
    }

    // throws Exception
    protected virtual void updateTouch2()
    {
        Features features = Features.getInstance();
        if (features.isFeature(this.touchFeatureFactory.AUTO_HIDE_SHOW_SCREEN_BUTTONS)) {
            if (this.gameLayerManager.getGameInfo().getCurrentLevel() - this.getStartLevel() == 1) {
                this.setTouchPaintableP(NullPaintable.getInstance());
            }
        }
    }

    // throws Exception
    protected virtual void postInitTouch()
    {
        this.setTouchButtonsPaintable(TouchButtonsPaintableFactory.getInstance(this.gameLayerManager.getForegroundBasicColor()));
        this.updateScreenButtonPaintable();
    }

    public override void initCommands(CommandListener cmdListener)
    {
        this.removeAllCommands();
        this.addCommands();
        this.setCommandListener(cmdListener);
    }

    public virtual void addCommands()
    {
        GameCommandsFactory gameCommandsFactory = GameCommandsFactory.getInstance();
        MyCommandsFactory myCommandsFactory = MyCommandsFactory.getInstance();
        if (DebugFactory.getInstance() != NoDebug.getInstance()) {
            this.addCommand(gameCommandsFactory.START_TRACE);
        }
        this.addCommand(gameCommandsFactory.RESTART_COMMAND);
        this.addCommand(myCommandsFactory.PAUSE_COMMAND);
        this.addCommand(gameCommandsFactory.QUIT_COMMAND);
        bool isOverScan = OperatingSystemFactory.getInstance().getOperatingSystemInstance().isOverScan();
        if (J2MEUtil.isHTML()) {
        } else if (SWTUtil.isSWT) {
        } else if (!isOverScan) {
            if (TouchScreenFactory.getInstance().isTouch() && new InGameFeatures().isAny()) {
                this.addCommand(InGameOptionsForm.DISPLAY);
            }
            this.addCommand(gameCommandsFactory.SAVE);
            this.addCommand(gameCommandsFactory.DISPLAY_LOAD_FORM);
        }
    }

    public override void itemStateChanged(Item item)
    {
        try {
            string itemLabel = item.getLabel();
            this.logUtil.putF(new StringMaker().append(this.commonLabels.ITEM_LABEL).append(itemLabel).ToString(), this, "itemStateChanged");
            if (item is ChoiceGroup) {
                GameFeatureUtil gameFeatureUtil = GameFeatureUtil.getInstance();
                if (gameFeatureUtil.isExclusive(itemLabel)) {
                    gameFeatureUtil.updateExclusiveForChoiceGroup(((ChoiceGroup) item));
                } else {
                    gameFeatureUtil.updateMultiple(((ChoiceGroup) item));
                }
            }
            this.sensorGameUpdateProcessor.process(this.gameLayerManager);
            this.updateTouch();
            this.updateScreenButtonPaintable();
            this.sensorGameUpdateProcessor.sendNotifications(this.gameLayerManager);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "itemStateChanged", e);
        }
    }

    // throws Exception
    public virtual void updateScreenButtonPaintable()
    {
        this.gameBehavior.updateScreenButtonPaintable(this);
    }

    public virtual void updateScreenButtonPaintable2()
    {
        Features features = Features.getInstance();
        if (features.isFeature(this.touchFeatureFactory.AUTO_HIDE_SHOW_SCREEN_BUTTONS)) {
            this.setTouchPaintableP(this.getTouchButtonsPaintable());
            this.setStartLevel(this.gameLayerManager.getGameInfo().getCurrentLevel());
        } else if (features.isFeature(this.touchFeatureFactory.SHOW_SCREEN_BUTTONS)) {
            this.setTouchPaintableP(this.getTouchButtonsPaintable());
        } else if (features.isFeature(this.touchFeatureFactory.HIDE_SCREEN_BUTTONS)) {
            this.setTouchPaintableP(NullPaintable.getInstance());
        } else {
            this.setTouchPaintableP(NullPaintable.getInstance());
        }
    }

    public override AllBinaryGameLayerManager getLayerManager()
    {
        return this.gameLayerManager;
    }

    public virtual void setLayerManager(AllBinaryGameLayerManager layerManager)
    {
        this.gameLayerManager = layerManager;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override bool isGameOver()
    {
        return this.gameOver;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void setGameOver(bool gameOver)
    {
        this.gameOver = gameOver;
    }

    // throws Exception
    public override void processGameOver()
    {
        PreLogUtil.put(this.commonStrings.START, this, this.gameStrings.SET_GAME_OVER);
        this.setGameOver(true);
        this.removePauseCommand();
        this.setGameState(this.gameStateFactory.SHOW_END_RESULT_GAME_STATE);
        this.setEndGamePaintable(this.getEndGameStatePaintable());
    }

    public override bool isHighScoreSubmitted()
    {
        return this.highScoreSubmitted;
    }

    // throws Exception
    public override void setHighScoreSubmitted(bool highScoreSubmitted)
    {
        this.highScoreSubmitted = highScoreSubmitted;
        if (highScoreSubmitted) {
            this.highScoresHelper.setSelectedHighScores(NullHighScoresSingletonFactory.getInstance());
        }
        this.logUtil.putF(new StringMaker().append("isHighScoreSubmitted: ").appendboolean(highScoreSubmitted).ToString(), this, "setHighScoreSubmitted");
    }

    public override GameState getGameState()
    {
        return this.gameState;
    }

    // throws Exception
    public override void setGameState(GameState gameState)
    {
        this.logUtil.putF(new StringMaker().append(this.gameStrings.GAME_STATE).append(this.stringUtil.toString(gameState)).ToString(), this, this.gameStrings.SET_GAME_STATE);
        this.gameState = gameState;
        this.gameStateTimeHelper.setStartTimeTNT();
        this.updateEndGameProcessor();
        this.updateGameKeyEventProcessor();
        this.gameBehavior.setGameState(this);
    }

    // throws Exception
    public virtual void updateGameState()
    {
        GameAdState gameAdState = this.gameAdStateFactory.getCurrentInstance();
        gameAdState.processAdState(this.gameState, this.gameLayerManager.getGameInfo().getGameType());
        if (this.gameState != this.gameStateFactory.PLAYING_GAME_STATE) {
            gameAdState.processPageAdState();
        }
    }

    private void updateGameKeyEventProcessor()
    {
        if (this.getGameState() != this.gameStateFactory.PLAYING_GAME_STATE || this.isCheating) {
        } else {
        }
    }

    protected virtual void removeAllGameKeyInputListenersOnBuild()
    {
        this.removeAllGameKeyInputListeners();
    }

    protected virtual void removeAllGameKeyInputListeners()
    {
        this.gameBehavior.removeAllGameKeyInputListeners(this);
    }

    protected virtual void removeAllGameKeyInputListeners2()
    {
        this.logUtil.putF("Remove PlayerInput Listeners", this, "removeAllGameKeyInputListeners");
        for (int index = this.localPlayerGameInputList.size() - 1; index >= 0; index--) {
            PlayerGameInput playerGameInput = ((PlayerGameInput) this.localPlayerGameInputList.get(index));
            this.removeKeyInputListener(playerGameInput);
            playerGameInput.removeNonAIInputGameKeyEvents();
        }
    }

    public virtual void removeKeyInputListener(PlayerGameInput playerGameInput)
    {
        this.gameKeyEventHandler.removeListener(playerGameInput);
    }

    // throws Exception
    protected virtual void updateEndGameProcessor()
    {
        this.gameBehavior.updateEndGameProcessor(this);
    }

    // throws Exception
    protected virtual void updateEndGameProcessor2()
    {
        if (this.getGameState() == this.gameStateFactory.SHOW_END_RESULT_GAME_STATE || this.getGameState() == this.gameStateFactory.SHOW_HIGH_SCORE_GAME_STATE) {
            this.setEndGameProcessor(this.realEndGameProcessor);
        } else {
            this.setEndGameProcessor(Processor.getInstance());
        }
    }

    // throws Exception
    public virtual void buildGameInit(bool isPortion)
    {
    }

    // throws Exception
    protected virtual void cleanupGame()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CLEANUP);
        ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
        progressCanvas.addNormalPortion(10, "Cleaning Up");
        this.primaryPlayerQueue.clear();
        this.secondaryPlayerQueue.clear();
        GameLevelDisplayChangeEventListenersFactory.getInstance().clear();
    }

    // throws Exception
    public virtual void loadResourceLoadingLevel(ResourceLoadingLevel resourceLoadingLevel)
    {
        GameInitializedEvent gameInitializedEvent = GameInitializationUtil.getInstance().EVENT;
        gameInitializedEvent.setResourceLoadingLevel(resourceLoadingLevel);
        GameInitializedEventHandler.getInstance().fireEvent(gameInitializedEvent);
    }

    // throws Exception
    public virtual void loadResources(int level)
    {
        GameInitializedEvent gameInitializedEvent = GameInitializationUtil.getInstance().EVENT;
        gameInitializedEvent.setLevel(level);
        GameInitializedEventHandler.getInstance().fireEvent(gameInitializedEvent);
    }

    // throws Exception
    public virtual void updateColor()
    {
    }

    // throws Exception
    public virtual void buildGame(int portion)
    {
        this.screenCapture.endRecording();
        this.screenCapture.startRecording();
        ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
        Features features = Features.getInstance();
        progressCanvas.addNormalPortion(portion, "Generic Build");
        this.removeAllGameKeyInputListenersOnBuild();
        this.updateTouch();
        progressCanvas.addNormalPortion(portion, "High Scores");
        this.highScoresFactoryInterface.fetchHighScores(this.gameLayerManager.getGameInfo(), this.highScoresHelper);
        this.setHighScoresPaintable(NullPaintable.getInstance());
        progressCanvas.addNormalPortion(portion, "Finishing.");
        this.getEndGameInfoP().update(this.getLayerManager().getGameInfo(), this);
        this.isSingleKeyRepeatableProcessing = features.isFeature(InputFeatureFactory.getInstance().SINGLE_KEY_REPEAT_PRESS);
        this.setGameOver(false);
        progressCanvas.addNormalPortion(portion, "Finishing..");
        this.updateColor();
        this.getStartIntermissionPaintable().update();
        if (!this.isRunningInAnotherThread()) {
            return;
        }
        progressCanvas.addNormalPortion(portion, "Finishing...");
        if (this.isMainCanvas() || !this.isInitialized()) {
            if (features.isFeature(MainFeatureFactory.getInstance().LOAD_ONDEMAND)) {
                if (this.getCustomCommandListener() != null) {
                    progressCanvas.end();
                }
            } else {
                progressCanvas.end();
            }
            this.setInitialized(true);
        }
        if (this.getCustomCommandListener() == NullCommandListener.NULL_COMMAND_LISTENER) {
            this.logUtil.putF("Show Game Paintable in DemoCanvas Thread", this, this.BUILD_GAME);
            this.gameCanvasStartListener.showGamePaintable();
        } else {
            this.logUtil.putF("No GameCanvasStartListener", this, this.BUILD_GAME);
        }
        this.colorFillPaintable.setBasicColorP(this.gameLayerManager.getBackgroundBasicColor());
        this.gameBehavior.buildGame(this);
    }

    public virtual void buildGame2()
    {
        PreLogUtil.put(new StringMaker().append(this.gameInputStrings.ENABLE_PLAYER_GAME_INPUTS).appendint(this.localPlayerGameInputList.size()).ToString(), this, this.BUILD_GAME);
        PlayerGameInput playerGameInput = null;
        for (int index = this.localPlayerGameInputList.size() - 1; index >= 0; index--) {
            playerGameInput = ((PlayerGameInput) this.localPlayerGameInputList.get(index));
            PreLogUtil.put(new StringMaker().append(this.gameInputStrings.ENABLE_PLAYER_GAME_INPUT).append(playerGameInput.ToString()).ToString(), this, this.BUILD_GAME);
            playerGameInput.removeNonAIInputGameKeyEvents();
            this.addKeyInputListener(playerGameInput);
        }
    }

    public virtual void addKeyInputListener(PlayerGameInput playerGameInput)
    {
        GameKeyEventHandler.getInstance().addListenerForPlayer(playerGameInput, playerGameInput.getPlayerInputId());
    }

    private DemoPaintableInterface gameCanvasStartListener = NullDemoPaintable.NULL_DEMO_PAINTABLE;
    public virtual void setGameCanvasStartListener(DemoPaintableInterface gameCanvasStartListener)
    {
        this.gameCanvasStartListener = gameCanvasStartListener;
    }

    // throws Exception
    public virtual void loadState()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.LOAD);
        ABHashtable<object, object> hashtable = this.getLoadStateHashtable();
        if (hashtable != null && hashtable.size() > 0) {
            string levelAsString = ((string) hashtable.get(((object) GameInfo.LEVEL_NAME)));
            int level = ((int) (levelAsString).ToString());
            GameInfo gameInfo = this.gameLayerManager.getGameInfo();
            gameInfo.setCurrentLevel(level);
        }
    }

    // throws Exception
    public override ABHashtable<object, object> getLoadStateHashtable()
    {
        this.logUtil.putF(new StringMaker().append(this.commonLabels.START_LABEL).append(this.stringUtil.toString(this.hashtable)).ToString(), this, "getLoadStateHashtable");
        return this.hashtable;
    }

    public override void setLoadStateHashtable(ABHashtable<object, object> hashtable)
    {
        this.logUtil.putF(new StringMaker().append(this.commonLabels.START_LABEL).append(this.stringUtil.toString(hashtable)).ToString(), this, "setLoadStateHashtable");
        this.hashtable = hashtable;
    }

    public override ABHashtable<object, object> getCurrentStateHashtable()
    {
        ABHashtable<object, object> hashtable = this.stdUtil.createHashtable();
        int level = this.gameLayerManager.getGameInfo().getCurrentLevel();
        hashtable.put(GameInfo.LEVEL_NAME.ToString(), (level).ToString());
        this.logUtil.putF(new StringMaker().append("End: ").append(this.stringUtil.toString(hashtable)).ToString(), this, "getCurrentStateHashtable");
        return hashtable;
    }

    public virtual void paintGameOver(Graphics graphics)
    {
        ForcedLogUtil.log(this.commonStrings.NOT_IMPLEMENTED, this);
    }

    public override void draw(Graphics graphics)
    {
        this.colorFillPaintable.paint(graphics);
        this.basicSetColorUtil.setBasicColorP(graphics, this.gameLayerManager.getForegroundBasicColor());
        this.gameSpecificPaintable.paint(graphics);
    }

    public virtual void clear(Graphics graphics)
    {
        this.colorFillPaintable.paint(graphics);
    }

    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        this.baseGameStatistics.nextRefresh();
        this.draw(graphics);
        this.menuPaintable.paint(graphics);
        this.progressPaintable.paint(graphics);
    }

    public override void paintThreed(Graphics graphics)
    {
    }

    // throws Exception
    public virtual void processEndLevelIntermissionGameState()
    {
    }

    public virtual void nonBotPaint(Graphics graphics)
    {
        this.endGamePaintable.paint(graphics);
        this.intermissionPaintable.paint(graphics);
        this.paintIntermission(graphics);
        this.touchPaintable.paint(graphics);
    }

    public virtual void paintIntermission(Graphics graphics)
    {
    }

    private readonly InputProcessor rawGameInputProcessor;
    private readonly InputProcessor rawInputProcessor;
    private InputProcessor inputProcessor;
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
        this.inputProcessor.keyPressedByDevice(keyCode, deviceId);
    }

    public override void keyRepeatedByDevice(int keyCode, int deviceId)
    {
        if (this.isSingleKeyRepeatableProcessing) {
            this.inputProcessor.keyPressedByDevice(keyCode, deviceId);
        }
    }

    public override void keyReleasedByDevice(int keyCode, int deviceId)
    {
        this.inputProcessor.keyReleasedByDevice(this, keyCode, deviceId);
    }

    // throws Exception
    public virtual void handleRawKey(int keyCode, int deviceId, bool repeated)
    {
    }

    protected virtual int endProgress(bool isProgress)
    {
        int portion = 30;
        if (isProgress && this.isMainCanvas()) {
            MyCommandsFactory myCommandsFactory = MyCommandsFactory.getInstance();
            ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
            progressCanvas.start();
            this.getCustomCommandListener().commandAction(myCommandsFactory.SET_DISPLAYABLE, progressCanvas);
            portion = 4;
        }
        return portion;
    }

    // throws Exception
    protected virtual void processPlayingGame()
    {
        this.cheatProcessor.update();
        this.sensorGameUpdateProcessor.getInputSensor().update();
        this.gameInputProcessor.process();
        this.gameLayerManager.process();
        this.startIntermissionProcessor.process();
    }

    // throws Exception
    protected virtual void threadInit()
    {
    }

    // throws Exception
    protected virtual void processGame()
    {
        base.process();
        if (AllBinaryMediaManager.update()) {
            if (!this.primaryPlayerQueue.process()) {
                this.secondaryPlayerQueue.process();
            }
        }
        this.mainStateProcessor.process();
        this.menuInputProcessor.processInputList();
        this.endGameProcessor.process();
        this.baseGameStatistics.nextFrame();
    }

    public virtual void notifyDonePainting()
    {
        lock (this) {
            this.threadObjectUtil.notifyObject(this);
        }
    }

    private readonly long YIELD_SLEEP = 100L;
    // throws Exception
    public virtual void shouldWait()
    {
        Features features = Features.getInstance();
        if (AndroidUtil.isAndroid()) {
        } else if (features.isFeature(this.openGLFeatureFactory.OPENGL_2D)) {
        } else {
            if (features.isDefault(this.openGLFeatureFactory.OPENGL)) {
                OpenGLImageSpecificFactory openGLImageSpecificFactory = OpenGLImageSpecificFactory.getInstance();
                while (openGLImageSpecificFactory.updating) {
                    System.Threading.Thread.Sleep((int) (this.YIELD_SLEEP));
                }
            }
        }
    }

    public override void run()
    {
        try {
            this.logUtil.putF(this.commonStrings.START_RUNNABLE, this, this.commonStrings.RUN);
            ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
            progressCanvas.addNormalPortion(50, "Game Thread");
            this.setCurrentThread();
            this.setRunning(true);
            if (this.getCustomCommandListener() == NullCommandListener.NULL_COMMAND_LISTENER) {
                System.Threading.Thread.Sleep((int) (this.YIELD_SLEEP));
            }
            this.shouldWait();
            this.threadInit();
            if (this.getCustomCommandListener() == NullCommandListener.NULL_COMMAND_LISTENER) {
                System.Threading.Thread.Sleep((int) (this.YIELD_SLEEP));
            }
            this.open();
            GameAdState gameAdState = this.gameAdStateFactory.getCurrentInstance();
            gameAdState.init();
            gameAdState.setGameIsReady(true);
            this.gameBehavior.run(this);
            this.logUtil.putF(this.commonStrings.END_RUNNABLE, this, this.commonStrings.RUN);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.RUN, e);
        }
    }

    // throws Exception
    public virtual void run2()
    {
        Features features = Features.getInstance();
        if (features.isDefault(this.openGLFeatureFactory.OPENGL_AS_GAME_THREAD) || J2MEUtil.isHTML()) {
            if (features.isDefault(this.openGLFeatureFactory.OPENGL_AS_GAME_THREAD)) {
                this.logUtil.putF(this.openGLFeatureFactory.OPENGL_AS_GAME_THREAD.getName(), this, this.commonStrings.RUN);
            }
            if (J2MEUtil.isHTML()) {
                this.logUtil.putF(GraphicsStrings.getInstance().HTML, this, this.commonStrings.RUN);
            }
            CurrentDisplayableFactory currentDisplayableFactory = CurrentDisplayableFactory.getInstance();
            currentDisplayableFactory.setRunnable(this.gameRunnable);
            currentDisplayableFactory.setDisplayable(this);
            OpenGLThreadUtil.getInstance().onResume();
        } else if (features.isDefault(this.openGLFeatureFactory.OPENGL_AND_GAME_HAVE_DIFFERENT_THREADS)) {
            this.logUtil.putF(this.openGLFeatureFactory.OPENGL_AND_GAME_HAVE_DIFFERENT_THREADS.getName(), this, this.commonStrings.RUN);
            OpenGLThreadUtil.getInstance().onResume();
            while (this.isRunning()) {
                this.run3();
            }
            this.end();
        } else {
            this.logUtil.putF("this thread", this, this.commonStrings.RUN);
            while (this.isRunning()) {
                this.run3();
            }
            this.end();
        }
    }

    // throws Exception
    public virtual void run3()
    {
        this.loopTimeHelper.setStartTime(this.gameTickTimeDelayHelper.setStartTime());
        this.gameTickDisplayInfoSingleton.update();
        this.processGame();
        this.processLoopSleep();
    }

    public override void setRunning(bool running)
    {
        base.setRunning(running);
        try {
            Features features = Features.getInstance();
            if (running) {
            } else {
                if (features.isDefault(this.openGLFeatureFactory.OPENGL) || SWTUtil.isSWT) {
                    if (this.gameLayerManager.getGameInfo().getGameType() != this.gameTypeFactory.BOT) {
                        CurrentDisplayableFactory currentDisplayableFactory = CurrentDisplayableFactory.getInstance();
                        currentDisplayableFactory.clearRunnable();
                    }
                    this.end();
                }
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.SET_RUNNING, e);
        }
    }

    // throws Exception
    public virtual void end()
    {
        this.screenCapture.endRecording();
        this.baseGameStatistics.add(new StringMaker().append(this.baseGameStatistics.ToString()).append(CommonSeps.getInstance().NEW_LINE).ToString());
        this.baseGameStatistics.init();
        this.gameKeyEventHandler.removeListener(this.cheatProcessor);
        this.close();
        this.removeAllGameKeyInputListeners();
        this.endGameThread();
    }

    // throws Exception
    public virtual void endGameThread()
    {
        DisplayChangeEventHandler.getInstance().removeListener(this);
        GameLevelDisplayChangeEventListenersFactory.getInstance().clear();
        GameAdState gameAdState = this.gameAdStateFactory.getCurrentInstance();
        gameAdState.notPlayingAdState();
    }

    public virtual HighScore createHighScore(long score)
    {
        GameInfo gameInfo = this.gameLayerManager.getGameInfo();
        return new HighScore(0, "NONE", new GameInfo(gameInfo.getGameType(), gameInfo.getGameMode(), PlayerTypesFactory.getInstance().PLAYER_TYPE_ONE, 0, 0), score);
    }

    // throws Exception
    public virtual void setHighScore(AbeClientInformationInterface abeClientInformation, string name, long score, bool autoSubmit, bool isLast)
    {
        this.gameBehavior.setHighScore(abeClientInformation, this, name, score, autoSubmit, isLast);
    }

    // throws Exception
    public virtual void setHighScore2(AbeClientInformationInterface abeClientInformation, string name, long score, bool autoSubmit, bool isLast)
    {
        HighScore highScore = this.createHighScore(score);
        HighScoreTextBox textBox = new HighScoreTextBox(this.highScoresFactoryInterface, this.highScoresHelper, abeClientInformation, this.gameLayerManager.getGameInfo(), this.getCustomCommandListener(), name, highScore, this.gameLayerManager.getBackgroundBasicColor(), this.gameLayerManager.getForegroundBasicColor());
        if (isLast) {
            this.getCustomCommandListener().commandAction(GameCommandsFactory.getInstance().SET_MENU_DISPLAYABLE, textBox);
        }
        if (autoSubmit) {
            class SaveHighScoreRunnable : global::java.lang.Runnable
            {
                private readonly ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
                public virtual void run()
                {
                    LogUtil logUtil = LogUtil.getInstance();
                    try {
                        if (isLast) {
                            textBox.submit();
                        } else {
                            textBox.saveHighScore();
                        }
                    } catch (Exception e) {
                        CommonStrings commonStrings = CommonStrings.getInstance();
                        logUtil.put(commonStrings.EXCEPTION, this, "run", e);
                        this.progressCanvas.end();
                    }
                }

            }
            SecondaryThreadPool.getInstance().runTask(new SaveHighScoreRunnable());
        }
    }

    protected virtual TimeDelayHelper getGameStateTimeHelper()
    {
        return this.gameStateTimeHelper;
    }

    protected virtual void setInitialized(bool initialized)
    {
        this.initialized = initialized;
    }

    public override bool isInitialized()
    {
        return this.initialized;
    }

    public override int getSourceId()
    {
        return AllBinaryGameCanvas.id;
    }

    public virtual void setProgressPaintable(PaintableInterface paintable)
    {
        this.progressPaintable = paintable;
    }

    public override IntermissionInterface getStartIntermissionInterface()
    {
        return this.startIntermissionInterface;
    }

    public override IntermissionInterface getEndLevelIntermissionInterface()
    {
        return this.endLevelIntermissionInterface;
    }

    protected virtual void setTouchPaintableP(Paintable paintable)
    {
        this.touchPaintable = paintable;
    }

    public virtual Paintable getTouchPaintableP()
    {
        return this.touchPaintable;
    }

    protected virtual void setEndGamePaintable(Paintable endGamePaintable)
    {
        this.endGamePaintable = endGamePaintable;
    }

    public virtual Paintable getEndGamePaintable()
    {
        return this.endGamePaintable;
    }

    protected virtual void setIntermissionPaintable(Paintable intermissionPaintable)
    {
        this.intermissionPaintable = intermissionPaintable;
    }

    public virtual Paintable getIntermissionPaintable()
    {
        return this.intermissionPaintable;
    }

    public virtual EndGameInfo getEndGameInfoP()
    {
        return this.endGameInfo;
    }

    public virtual void setHighScoresPaintable(Paintable highScoresPaintable)
    {
        this.highScoresPaintable = highScoresPaintable;
    }

    public virtual Paintable getHighScoresPaintable()
    {
        return this.highScoresPaintable;
    }

    protected virtual HighScoresPaintable getRealHighScoresPaintable()
    {
        return this.realHighScoresPaintable;
    }

    protected virtual void clearPlayerGameInputList()
    {
        PlayerGameInput playerGameInput = null;
        for (int index = this.localPlayerGameInputList.size() - 1; index >= 0; index--) {
            playerGameInput = ((PlayerGameInput) this.localPlayerGameInputList.get(index));
            this.gameKeyEventHandler.removeListener(playerGameInput);
        }
        this.localPlayerGameInputList.clear();
    }

    protected virtual void addPlayerGameInput(PlayerGameInput playerGameInput)
    {
        this.localPlayerGameInputList.add(playerGameInput);
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

    public virtual int getStartLevel()
    {
        return this.startLevel;
    }

    public virtual void setStartLevel(int startLevel)
    {
        this.startLevel = startLevel;
    }

    protected virtual void setTouchButtonsPaintable(Paintable touchButtonsPaintable)
    {
        this.touchButtonsPaintable = touchButtonsPaintable;
    }

    protected virtual Paintable getTouchButtonsPaintable()
    {
        return this.touchButtonsPaintable;
    }

    public virtual void setGameInputProcessor(Processor gameInputProcessor)
    {
        this.gameInputProcessor = gameInputProcessor;
    }

    protected virtual Processor getGameInputProcessor()
    {
        return this.gameInputProcessor;
    }

    protected virtual void setEndGameProcessor(Processor endGameProcessor)
    {
        this.endGameProcessor = endGameProcessor;
    }

    protected virtual Processor getEndGameProcessor()
    {
        return this.endGameProcessor;
    }

    protected virtual void setEndGameStatePaintable(Paintable endGameStatePaintable)
    {
        this.endGameStatePaintable = endGameStatePaintable;
    }

    protected virtual Paintable getEndGameStatePaintable()
    {
        return this.endGameStatePaintable;
    }

    protected virtual void setNonBotPaintableP(Paintable nonBotPaintable)
    {
        this.nonBotPaintable = nonBotPaintable;
    }

    protected virtual Paintable getNonBotPaintableP()
    {
        return this.nonBotPaintable;
    }

    protected virtual void setStartIntermissionPaintable(InitUpdatePaintable startIntermissionPaintable)
    {
        this.startIntermissionPaintable = startIntermissionPaintable;
    }

    protected virtual InitUpdatePaintable getStartIntermissionPaintable()
    {
        return this.startIntermissionPaintable;
    }

    public virtual void setMainStateProcessor(Processor mainStateProcessor)
    {
        this.mainStateProcessor = mainStateProcessor;
    }

    protected virtual Processor getMainStateProcessor()
    {
        return this.mainStateProcessor;
    }

    protected virtual void setProcessGameProcessor(Processor processGameProcessor)
    {
        this.processGameProcessor = processGameProcessor;
    }

    public virtual Processor getProcessGameProcessor()
    {
        return this.processGameProcessor;
    }

    protected virtual void setOpenMenuPaintable(Paintable openMenuPaintable)
    {
        this.openMenuPaintable = openMenuPaintable;
    }

    protected virtual Paintable getOpenMenuPaintable()
    {
        return this.openMenuPaintable;
    }

    protected virtual void setPopupMenuInputProcessor(BasicMenuInputProcessor popupMenuInputProcessor)
    {
        this.popupMenuInputProcessor = popupMenuInputProcessor;
    }

    protected virtual BasicMenuInputProcessor getPopupMenuInputProcessor()
    {
        return this.popupMenuInputProcessor;
    }

    public virtual SensorGameUpdateProcessor getSensorGameUpdateProcessor()
    {
        return this.sensorGameUpdateProcessor;
    }

    public virtual InputProcessor getRawGameInputProcessor()
    {
        return this.rawGameInputProcessor;
    }

    public virtual InputProcessor getRawInputProcessor()
    {
        return this.rawInputProcessor;
    }

    public virtual void setInputProcessor(InputProcessor inputProcessor)
    {
        this.inputProcessor = inputProcessor;
    }

    protected virtual InputProcessor getInputProcessor()
    {
        return this.inputProcessor;
    }

    protected virtual void setMenuPaintable(Paintable menuPaintable)
    {
        this.menuPaintable = menuPaintable;
    }

    protected virtual Paintable getMenuPaintable()
    {
        return this.menuPaintable;
    }

    private void setFormPaintable(Paintable formPaintable)
    {
        this.formPaintable = formPaintable;
    }

    protected virtual Paintable getFormPaintable()
    {
        return this.formPaintable;
    }

    public virtual void setGameSpecificPaintableP(Paintable gameSpecificPaintable)
    {
        this.gameSpecificPaintable = gameSpecificPaintable;
    }

    protected virtual Paintable getGameSpecificPaintableP()
    {
        return this.gameSpecificPaintable;
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

    public static readonly int TYPE = 2;
    public override int getType()
    {
        return AllBinaryGameCanvas.TYPE;
    }

}

