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
using ProgressCanvas = org.allbinary.graphics.canvas.transition.progress.ProgressCanvas;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using MyCommandsFactory = org.allbinary.graphics.displayable.command.MyCommandsFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using org.allbinary.util;

namespace org.allbinary.game.midlet;

public class CreateGameRunnable : global::java.lang.Runnable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly DemoGameMidlet demoGameMidlet;
    private readonly ABHashtable<object, object> hashtable;
    private readonly DemoGameMidletEvent startGameMidletEvent;
    public CreateGameRunnable(DemoGameMidlet demoGameMidlet, ABHashtable<object, object> hashtable)
    {
        this.demoGameMidlet = demoGameMidlet;
        this.hashtable = hashtable;
        this.startGameMidletEvent = new DemoGameMidletEvent(this, DemoGameMidletStateFactory.getInstance().START_GAME);
    }

    public virtual void run()
    {
        try {
            this.logUtil.putF(this.commonStrings.START_RUNNABLE, this, this.commonStrings.RUN);
            ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
            this.demoGameMidlet.commandAction(MyCommandsFactory.getInstance().SET_DISPLAYABLE, progressCanvas);
            this.demoGameMidlet.stopGameCanvasRunnableInterface();
            this.demoGameMidlet.setGameCanvasRunnableInterface(this.demoGameMidlet.createGameCanvasRunnableInterface());
            this.demoGameMidlet.getGameCanvasRunnableInterface().setLoadStateHashtable(this.hashtable);
            this.demoGameMidlet.startGameCanvasRunnableInterface();
            DemoGameMidletEventHandler.getInstance().fireEvent(this.startGameMidletEvent);
            this.logUtil.putF(this.commonStrings.END_RUNNABLE, this, this.commonStrings.RUN);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.RUN, e);
        }
    }

}

