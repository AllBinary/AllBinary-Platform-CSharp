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
//using Choice = javax.microedition.lcdui.Choice;
//using Command = javax.microedition.lcdui.Command;
//using CommandListener = javax.microedition.lcdui.CommandListener;
using GameCommandsFactory = org.allbinary.game.commands.GameCommandsFactory;
using GameFeatureFormUtil = org.allbinary.game.configuration.feature.GameFeatureFormUtil;
using InGameFeatureChoiceGroups = org.allbinary.game.configuration.feature.InGameFeatureChoiceGroups;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using CommandForm = org.allbinary.graphics.displayable.screen.CommandForm;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.configuration;

public class InGameOptionsForm : CommandForm
{
    public static readonly Command DISPLAY = new Command("Options In Game", StringUtil.getInstance().EMPTY_STRING, Command.SCREEN, 1);
    public static readonly Command SAVE = new Command("Save", StringUtil.getInstance().EMPTY_STRING, Command.SCREEN, 1);
    public static readonly Command DEFAULT = new Command("Default", StringUtil.getInstance().EMPTY_STRING, Command.SCREEN, 1);
    public InGameOptionsForm(CommandListener commandListener, string title, BasicColor backgrounBasicColor, BasicColor foregroundBasicColor) : base(commandListener, title, backgrounBasicColor, foregroundBasicColor)
    {
        // base(commandListener, title, backgrounBasicColor, foregroundBasicColor) is called from the constructor declaration
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        GameFeatureFormUtil gameFeatureFormUtil = GameFeatureFormUtil.getInstance();
        gameFeatureFormUtil.addChoiceGroup(this, InGameFeatureChoiceGroups.getExclusiveInstance().get(), Choice.EXCLUSIVE);
        gameFeatureFormUtil.addChoiceGroup(this, InGameFeatureChoiceGroups.getMultipleInstance().get(), Choice.MULTIPLE);
        this.initCommands(commandListener);
    }

    public override void initCommands(CommandListener cmdListener)
    {
        this.removeAllCommands();
        this.addCommand(GameCommandsFactory.getInstance().CLOSE_AND_SHOW_GAME_CANVAS);
        this.addCommand(InGameOptionsForm.DEFAULT);
        this.setCommandListener(cmdListener);
    }

}

