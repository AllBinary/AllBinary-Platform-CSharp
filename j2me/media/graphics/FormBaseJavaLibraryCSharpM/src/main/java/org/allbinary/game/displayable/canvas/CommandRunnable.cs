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
//using Command = javax.microedition.lcdui.Command;
//using CommandListener = javax.microedition.lcdui.CommandListener;
using MyCanvas = org.allbinary.graphics.displayable.MyCanvas;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.displayable.canvas;

public class CommandRunnable : Runnable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly CommandFormInputProcessor commandFormInputProcessor;
    private readonly Command command;
    public CommandRunnable(CommandFormInputProcessor commandFormInputProcessor, Command command)
    {
        this.commandFormInputProcessor = commandFormInputProcessor;
        this.command = command;
    }

    public virtual void run()
    {
        try {
            this.logUtil.putF(this.commonStrings.START_RUNNABLE, this, this.commonStrings.RUN);
            MyCanvas canvas = this.commandFormInputProcessor.getCanvas();
            CommandListener commandListener = canvas.getCustomCommandListener();
            commandListener.commandAction(this.command, canvas);
            this.logUtil.putF(this.commonStrings.END_RUNNABLE, this, this.commonStrings.RUN);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.RUN, e);
        }
    }

}

