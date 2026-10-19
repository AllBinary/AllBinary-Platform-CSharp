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
using GameCanvasRunnableInterface = org.allbinary.game.displayable.canvas.GameCanvasRunnableInterface;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using ProgressCanvas = org.allbinary.graphics.canvas.transition.progress.ProgressCanvas;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using StdUtil = org.allbinary.logic.StdUtil;
using ClientInformationFactory = org.allbinary.logic.system.security.licensing.ClientInformationFactory;
using PrimaryThreadPool = org.allbinary.thread.PrimaryThreadPool;
using NullGameCanvasRunnable = org.allbinary.game.displayable.canvas.NullGameCanvasRunnable;
using org.allbinary.util;

namespace org.allbinary.game.midlet;

public class DemoGameMidlet : GameMidlet
{
    public DemoGameMidlet(ClientInformationFactory clientInformationFactory) : base(clientInformationFactory)
    {
        // base(clientInformationFactory) is called from the constructor declaration
    }

    // throws Exception
    protected virtual bool isContinue()
    {
        ABHashtable<object, object> hashtable = this.getStartStateHashtable();
        if (hashtable != null && hashtable.size() > 0) {
            return true;
        } else {
            return false;
        }
    }

    public virtual int getHighestLevel()
    {
        return 1;
    }

    // throws Exception
    public virtual GameCanvasRunnableInterface createDemoGameCanvasRunnableInterface()
    {
        this.logUtil.putF(this.commonStrings.NOT_IMPLEMENTED, this, this.commonStrings.CREATE);
        return NullGameCanvasRunnable.NULL_GAME_CANVAS_RUNNABLE;
    }

    // throws Exception
    protected virtual GameCanvasRunnableInterface createGameCanvasRunnable(AllBinaryGameLayerManager allBinaryGameLayerManager)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    // throws Exception
    protected virtual GameCanvasRunnableInterface createGameCanvasRunnableInterface()
    {
        return this.createGameCanvasRunnable(this.createGameLayerManager());
    }

    public virtual void demoSetup()
    {
    }

    public virtual void postDemoSetup()
    {
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void setDemo()
    {
        this.logUtil.putF(this.commonStrings.START, this, "setDemo");
        ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
        progressCanvas.start();
        PrimaryThreadPool.getInstance().runTask(new DemoRunnable(this));
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void createGame()
    {
        string CREATE_GAME = "createGame";
        this.logUtil.putF(this.commonStrings.START, this, CREATE_GAME);
        ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
        progressCanvas.start();
        ABHashtable<object, object> hashtable = this.getStartStateHashtable();
        this.setStartStateHashtable(StdUtil.getInstance().NULL_TABLE);
        PrimaryThreadPool.getInstance().runTask(new CreateGameRunnable(this, hashtable));
        this.logUtil.putF(this.commonStrings.END, this, CREATE_GAME);
    }

    public virtual bool isReady()
    {
        return true;
    }

}

