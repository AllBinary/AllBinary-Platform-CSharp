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
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
//using TextField = javax.microedition.lcdui.TextField;
using CommonStrings = org.allbinary.@string.CommonStrings;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using GameCommandsFactory = org.allbinary.game.commands.GameCommandsFactory;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using CustomTextBox = org.allbinary.graphics.form.item.CustomTextBox;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using Paintable = org.allbinary.graphics.paint.Paintable;
using SimpleTextPaintable = org.allbinary.graphics.paint.SimpleTextPaintable;
using VirtualKeyboardEventHandler = org.allbinary.input.@event.VirtualKeyboardEventHandler;

namespace org.allbinary.game.displayable.screen;

public class LicenseRegistrationTextBox : CustomTextBox
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public static readonly Command DISPLAY_COMMAND = new Command("Register", StringUtil.getInstance().EMPTY_STRING, Command.SCREEN, 3);
    public static readonly Command SUBMIT_COMMAND = new Command("Submit", StringUtil.getInstance().EMPTY_STRING, Command.SCREEN, 3);
    private readonly Paintable pleaseWaitPaintable = new SimpleTextPaintable(commonStrings.PLEASE_WAIT, BasicColorFactory.getInstance().WHITE);
    private Paintable paintable = NullPaintable.getInstance();
    public LicenseRegistrationTextBox(CommandListener cmdListener, BasicColor backgrounBasicColor, BasicColor foregroundBasicColor) : base(cmdListener, "Enter Registration Code:", StringUtil.getInstance().EMPTY_STRING, 60, TextField.ANY, Font.getDefaultFont(), backgrounBasicColor, foregroundBasicColor)
    {
        // base(cmdListener, "Enter Registration Code:", StringUtil.getInstance().EMPTY_STRING, 60, TextField.ANY, Font.getDefaultFont(), backgrounBasicColor, foregroundBasicColor) is called from the constructor declaration
    }

    public virtual void initCommands(CommandListener cmdListener)
    {
        this.removeAllCommands();
        this.addCommand(GameCommandsFactory.getInstance().CLOSE_AND_SHOW_GAME_CANVAS);
        this.addCommand(GameCommandsFactory.getInstance().TOGGLE_KEYBOARD);
        this.addCommand(SUBMIT_COMMAND);
        this.setCommandListener(cmdListener);
    }

    public virtual void open()
    {
        try {
            VirtualKeyboardEventHandler virtualKeyboardEventHandler = VirtualKeyboardEventHandler.getInstance();
            virtualKeyboardEventHandler.fireEvent(virtualKeyboardEventHandler.SHOW_EVENT);
        } catch (Exception e) {
            this.logUtil.put(commonStrings.EXCEPTION, this, "open", e);
        }
        base.open();
        this.paintable = NullPaintable.getInstance();
        this.repaint();
    }

    // throws Exception
    public virtual void close()
    {
        try {
            VirtualKeyboardEventHandler virtualKeyboardEventHandler = VirtualKeyboardEventHandler.getInstance();
            virtualKeyboardEventHandler.fireEvent(virtualKeyboardEventHandler.HIDE_EVENT);
        } catch (Exception e) {
            this.logUtil.put(commonStrings.EXCEPTION, this, "open", e);
        }
        this.paintable = this.pleaseWaitPaintable;
        this.repaint();
        base.close();
    }

    public virtual void paint(Graphics graphics)
    {
        base.paint(graphics);
        this.paintable.paint(graphics);
    }

    public virtual void submit()
    {
        CommandListener commandListener = this.getCustomCommandListener();
        commandListener.commandAction(SUBMIT_COMMAND, this);
    }

}

