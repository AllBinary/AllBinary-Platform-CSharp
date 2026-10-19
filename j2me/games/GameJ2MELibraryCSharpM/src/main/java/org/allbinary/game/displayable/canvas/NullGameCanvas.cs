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
//using CommandListener = javax.microedition.lcdui.CommandListener;
//using Graphics = javax.microedition.lcdui.Graphics;
//using NullCommandListener = javax.microedition.lcdui.NullCommandListener;
using BasicBuildGameInitializerFactory = org.allbinary.game.init.BasicBuildGameInitializerFactory;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using NoHighScoresFactory = org.allbinary.game.score.NoHighScoresFactory;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.displayable.canvas;

public class NullGameCanvas : AllBinaryGameCanvas
{
    private static NullGameCanvas createNull()
    {
        try {
            return new NullGameCanvas(AllBinaryGameLayerManager.getNullInstance());
        } catch (Exception e) {
            LogUtil.getInstance().put(CommonStrings.getInstance().EXCEPTION, "NullGameCanvas", CommonStrings.getInstance().GET_INSTANCE, e);
            throw new SystemException();
        }
    }

    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static NullGameCanvas getInstance()
    {
        if (NullGameCanvas.instance == NullUtil.getInstance().NULL_OBJECT) {
            NullGameCanvas.instance = NullGameCanvas.createNull();
        }
        return ((NullGameCanvas) NullGameCanvas.instance);
    }

    // throws Exception
    public static NullGameCanvas createCanvas(AllBinaryGameLayerManager gameLayerManager)
    {
        NullGameCanvas nullGameCanvas = new NullGameCanvas(gameLayerManager);
        nullGameCanvas.setInitialized(true);
        nullGameCanvas.setTitle(NullGameCanvas.NO_GAME);
        return nullGameCanvas;
    }

    public static readonly string NO_GAME = "No Background Game";
    protected NullGameCanvas(AllBinaryGameLayerManager gameLayerManager) : base(NullCommandListener.NULL_COMMAND_LISTENER, gameLayerManager, NoHighScoresFactory.getInstance(), BasicBuildGameInitializerFactory.NULL_BASE_BUILD_GMAE_INITIALIZER_FACTORY, false)
    {
        // base(NullCommandListener.NULL_COMMAND_LISTENER, gameLayerManager, NoHighScoresFactory.getInstance(), BasicBuildGameInitializerFactory.NULL_BASE_BUILD_GMAE_INITIALIZER_FACTORY, false) is called from the constructor declaration
        base.setWait(1200);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override bool isGameOver()
    {
        return false;
    }

    private bool runningNull = true;
    public override void setRunning(bool running)
    {
        this.runningNull = running;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override bool isRunning()
    {
        return this.runningNull;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void pause()
    {
        this.setPaused(true);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void unPause()
    {
        this.setPaused(false);
    }

    public override void initCommands(CommandListener cmdListener)
    {
        this.removeAllCommands();
        this.setCommandListener(cmdListener);
    }

    // throws Exception
    public override void buildGameInit(bool isProgress)
    {
    }

    public override void draw(Graphics graphics)
    {
    }

    public override void run()
    {
        try {
            this.logUtil.putF(this.commonStrings.START_RUNNABLE, this, this.commonStrings.RUN);
            this.logUtil.putF(this.commonStrings.END_RUNNABLE, this, this.commonStrings.RUN);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.RUN, e);
        }
    }

    public static readonly int TYPE = 1;
    public override int getType()
    {
        return NullGameCanvas.TYPE;
    }

}

