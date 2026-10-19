/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2002 AllBinary 
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
//using Form = javax.microedition.lcdui.Form;
//using NullCommandListener = javax.microedition.lcdui.NullCommandListener;
using Processor = org.allbinary.canvas.Processor;
using MenuListener = org.allbinary.game.displayable.canvas.MenuListener;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using MyCommandInterface = org.allbinary.graphics.displayable.command.MyCommandInterface;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;

namespace org.allbinary.graphics.displayable.screen;

public class CommandForm : Form, MyCommandInterface, MenuListener
{
    private static object NULL_COMMAND_FORM = NullUtil.getInstance().NULL_OBJECT;
    public static CommandForm getNullCommandForm()
    {
        if (CommandForm.NULL_COMMAND_FORM == NullUtil.getInstance().NULL_OBJECT) {
            CommandForm.NULL_COMMAND_FORM = new CommandForm(NullCommandListener.NULL_COMMAND_LISTENER, StringUtil.getInstance().EMPTY_STRING, BasicColorFactory.getInstance().BLACK, BasicColorFactory.getInstance().WHITE);
        }
        return ((CommandForm) CommandForm.NULL_COMMAND_FORM);
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly Processor repaintProcessor;
    private ABStack<object> commandStack;
    public CommandForm(CommandListener commandListener, string formTitle, BasicColor backgrounBasicColor, BasicColor foregroundBasicColor) : base(formTitle)
    {
        this.repaintProcessor = ScreenRepaintProcessorFactory.getInstance().create(this);
        // base(formTitle) is called from the constructor declaration
        this.commandStack = StdUtil.getInstance().createStack();
        try {
            this.repaintProcessor.process();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.CONSTRUCTOR, e);
        }
    }

    public virtual void initCommands(CommandListener cmdListener)
    {
    }

    public override void open()
    {
        this.logUtil.putF(this.commonStrings.START, this, "open");
    }

    // throws Exception
    public override void close()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CLOSE);
    }

    // throws Exception
    public virtual void update()
    {
        this.repaintProcessor.process();
    }

    public override int getSourceId()
    {
        return 0;
    }

    public override void addCommand(Command command)
    {
        this.commandStack.push(command);
        base.addCommand(command);
    }

    public override void removeAllCommands()
    {
        int size = this.commandStack.size();
        for (int index = 0; index < size; index++) {
            base.removeCommand(((Command) this.commandStack.pop()));
        }
    }

}

