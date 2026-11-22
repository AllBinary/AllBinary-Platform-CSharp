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

extern alias GameLicensingNullJavaLibraryCSharp;
extern alias OpenGLNoneOtherJavaLibraryCSharp;
using System;
using System.Linq;
using Command = javax.microedition.lcdui.Command;
using CommandListener = javax.microedition.lcdui.CommandListener;
using Graphics = javax.microedition.lcdui.Graphics;
using GameInfo = org.allbinary.game.GameInfo;
using GameCommandsFactory = org.allbinary.game.commands.GameCommandsFactory;
using GameCommandCanvas = org.allbinary.game.displayable.canvas.GameCommandCanvas;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using ColorFillBasePaintable = org.allbinary.game.paint.ColorFillBasePaintable;
using ColorFillPaintableFactory = org.allbinary.game.paint.ColorFillPaintableFactory;
using HighScoreCommandsFactory = org.allbinary.game.score.HighScoreCommandsFactory;
using HighScores = org.allbinary.game.score.HighScores;
using HighScoresCanvasInputProcessor = org.allbinary.game.score.HighScoresCanvasInputProcessor;
using HighScoresCanvasInputProcessorFactoryInterface = org.allbinary.game.score.HighScoresCanvasInputProcessorFactoryInterface;
using HighScoresFactoryInterface = org.allbinary.game.score.HighScoresFactoryInterface;
using HighScoresHelperBase = org.allbinary.game.score.HighScoresHelperBase;
using HighScoresPaintable = org.allbinary.game.score.HighScoresPaintable;
using HighScoresResultsListener = org.allbinary.game.score.HighScoresResultsListener;
using NoHighScoresFactory = org.allbinary.game.score.NoHighScoresFactory;
using NullHighScoresSingletonFactory = org.allbinary.game.score.NullHighScoresSingletonFactory;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using Paintable = org.allbinary.graphics.paint.Paintable;
using SimpleTextPaintable = org.allbinary.graphics.paint.SimpleTextPaintable;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;
using SecondaryThreadPool = org.allbinary.thread.SecondaryThreadPool;

namespace org.allbinary.game.score.displayable;

public class HighScoresCanvas : GameCommandCanvas, HighScoresResultsListener
{
    public const string NAME = "HighScoresCanvas";
    private Paintable paintable = NullPaintable.getInstance();
    private readonly HighScoreCommandsFactory highScoreCommandsFactory = HighScoreCommandsFactory.getInstance();
    private readonly SimpleTextPaintable waitPaintable;
    private readonly HighScoresPaintable highScoresPaintable;
    private readonly HighScoresFactoryInterface highScoresFactoryInterface;
    public ColorFillBasePaintable colorFillPaintable;
    private readonly HighScoresHelperBase highScoresHelper = new HighScoresHelperBase();
    private readonly GameInfo gameInfo;
    private readonly HighScoresCanvasInputProcessor highScoresCanvasInputProcessor;
    private Command currentCommand;
    public bool hasPainted = false;
    public HighScoresCanvas(CommandListener commandListener, AllBinaryGameLayerManager allBinaryGameLayerManager, GameInfo gameInfo, HighScoresPaintable paintable, HighScoresFactoryInterface highScoresFactoryInterface, HighScoresCanvasInputProcessorFactoryInterface highScoresCanvasInputProcessorFactoryInterface) : base(commandListener, HighScoresCanvas.NAME, allBinaryGameLayerManager.getBackgroundBasicColor(), allBinaryGameLayerManager.getForegroundBasicColor())
    {
        this.waitPaintable = new SimpleTextPaintable(this.commonStrings.PLEASE_WAIT_FOR_SERVER, BasicColorFactory.getInstance().WHITE);
        this.currentCommand = this.highScoreCommandsFactory.HIGH_SCORE_COMMANDS[0];
        // Constructor invocation emitted in the initializer.
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.highScoresPaintable = paintable;
        this.highScoresFactoryInterface = highScoresFactoryInterface;
        this.highScoresCanvasInputProcessor = highScoresCanvasInputProcessorFactoryInterface.getInstance(this);
        this.gameInfo = gameInfo;
        this.waitPaintable.setBasicColorP(allBinaryGameLayerManager.getForegroundBasicColor());
        this.getHighScoresPaintable().setBasicColorP(allBinaryGameLayerManager.getForegroundBasicColor());
        this.colorFillPaintable = ColorFillPaintableFactory.getInstance().getInstance(allBinaryGameLayerManager.getBackgroundBasicColor(), false);
        if (this.highScoresHelper.getHighScoresArray().Length == NoHighScoresFactory.getInstance().NO_HIGH_SCORES.Length) {
            this.setPaintable(this.waitPaintable);
        } else {
            this.logUtil.putF("Show HighScores that are already loaded", this, this.commonStrings.CONSTRUCTOR);
            this.updateCommand(this.currentCommand);
            this.setPaintable(this.getHighScoresPaintable());
        }
        SecondaryThreadPool.getInstance().runTask(new HighScoreRunnable(this));
    }

    public override void initCommands(CommandListener cmdListener)
    {
        this.removeAllCommands();
        this.addCommand(GameCommandsFactory.getInstance().CLOSE_AND_SHOW_GAME_CANVAS);
        this.setCommandListener(cmdListener);
    }

    public override void open()
    {
        base.open();
        this.highScoresCanvasInputProcessor.open();
    }

    // throws Exception
    public override void close()
    {
        base.close();
        this.highScoresCanvasInputProcessor.close();
    }

    public override void paint(Graphics graphics)
    {
        this.colorFillPaintable.paint(graphics);
        this.paintable.paint(graphics);
        if (this.waitPaintable != this.paintable) {
            this.highScoresCanvasInputProcessor.paint(graphics);
        }
        base.paint(graphics);
        this.hasPainted = true;
    }

    public virtual void executeUpdate()
    {
        try {
            this.highScoresFactoryInterface.fetchHighScores(this.getGameInfo(), this);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.UPDATE, e);
        }
    }

    private HighScoresPaintable getHighScoresPaintable()
    {
        return this.highScoresPaintable;
    }

    public virtual void setHighScoresArray(HighScores[] highScoresArray)
    {
        try {
            if (highScoresArray != null) {
                this.logUtil.putF(new StringMaker().append(this.commonStrings.START).appendint(highScoresArray.Length).ToString(), this, "setHighScoresArray");
            } else {
                this.logUtil.putF(this.commonStrings.START, this, "setHighScoresArray");
            }
            this.highScoresHelper.setHighScoresArray(highScoresArray);
            this.updateCommand(this.currentCommand);
            this.setPaintable(this.getHighScoresPaintable());
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.UPDATE, e);
        }
    }

    // throws Exception
    public virtual void updateCommand(Command command)
    {
        this.logUtil.putF(new StringMaker().append(this.commonStrings.START).append(this.stringUtil.toString(command)).ToString(), this, this.commonStrings.UPDATE);
        GameCommandsFactory gameCommandsFactory = GameCommandsFactory.getInstance();
        if (this.highScoreCommandsFactory.isHighScoreCommand(command)) {
            int index = this.highScoreCommandsFactory.getIndex(command);
            int nextIndex = index + 1;
            HighScores[] highScoresArray = this.highScoresHelper.getHighScoresArray();
            if (nextIndex >= highScoresArray.Length) {
                nextIndex = 0;
            }
            if (highScoresArray.Length > 0) {
                this.getHighScoresPaintable().setHighScores(highScoresArray[index]);
            } else {
                this.getHighScoresPaintable().setHighScores(NullHighScoresSingletonFactory.getInstance());
            }
            if (index != nextIndex) {
                this.removeAllCommands();
                this.addCommand(gameCommandsFactory.CLOSE_AND_SHOW_GAME_CANVAS);
                this.addCommand(this.highScoreCommandsFactory.HIGH_SCORE_COMMANDS[nextIndex]);
            }
        }
        this.currentCommand = command;
        this.close();
        base.initMenu();
        this.open();
        this.repaintBehavior.onChangeRepaint(this);
    }

    public virtual GameInfo getGameInfo()
    {
        return this.gameInfo;
    }

    private void setPaintable(Paintable paintable)
    {
        this.paintable = paintable;
        this.repaintBehavior.onChangeRepaint(this);
    }

}

