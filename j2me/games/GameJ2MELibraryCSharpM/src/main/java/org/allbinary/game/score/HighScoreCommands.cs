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
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.score;

public class HighScoreCommands
{
    private static readonly HighScoreCommands instance = new HighScoreCommands();
    public static HighScoreCommands getInstance()
    {
        return HighScoreCommands.instance;
    }

    public readonly Command DISPLAY = new Command("Scores", StringUtil.getInstance().EMPTY_STRING, Command.SCREEN, 1);
    public readonly Command PERSONAL = new Command("Personal", StringUtil.getInstance().EMPTY_STRING, Command.SCREEN, 1);
    public readonly Command WORLD = new Command("World", StringUtil.getInstance().EMPTY_STRING, Command.SCREEN, 1);
}

