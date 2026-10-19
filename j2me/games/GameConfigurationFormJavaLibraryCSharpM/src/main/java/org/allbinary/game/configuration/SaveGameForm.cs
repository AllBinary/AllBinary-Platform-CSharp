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
//using CommandListener = javax.microedition.lcdui.CommandListener;
//using TextField = javax.microedition.lcdui.TextField;
using GameCommandsFactory = org.allbinary.game.commands.GameCommandsFactory;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using CommandForm = org.allbinary.graphics.displayable.screen.CommandForm;
using ABSystemWrapper = org.allbinary.logic.ABSystemWrapper;
using MEUtil = org.allbinary.logic.MEUtil;

namespace org.allbinary.game.configuration;

public class SaveGameForm : CommandForm
{
    private static CommandForm FORM = CommandForm.getNullCommandForm();
    // throws Exception
    public static CommandForm createForm(CommandListener commandListener, string title, BasicColor backgrounBasicColor, BasicColor foregroundBasicColor)
    {
        SaveGameForm.FORM = new SaveGameForm(commandListener, title, backgrounBasicColor, foregroundBasicColor);
        return SaveGameForm.FORM;
    }

    public static CommandForm getInstance()
    {
        return SaveGameForm.FORM;
    }

    private readonly MEUtil meUtil = MEUtil.getInstance();
    private SaveGameForm(CommandListener commandListener, string title, BasicColor backgrounBasicColor, BasicColor foregroundBasicColor) : base(commandListener, title, backgrounBasicColor, foregroundBasicColor)
    {
        // base(commandListener, title, backgrounBasicColor, foregroundBasicColor) is called from the constructor declaration
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        string timeString = (ABSystemWrapper.getInstance().currentTimeMillis()).ToString();
        this.meUtil.appendItem(this, new TextField("Name: ", timeString, 30, TextField.ANY));
        this.initCommands(commandListener);
    }

    public override void initCommands(CommandListener cmdListener)
    {
        GameCommandsFactory gameCommandsFactory = GameCommandsFactory.getInstance();
        this.removeAllCommands();
        this.addCommand(gameCommandsFactory.SAVE);
        this.addCommand(gameCommandsFactory.CLOSE_AND_SHOW_GAME_CANVAS);
        this.setCommandListener(cmdListener);
    }

}

