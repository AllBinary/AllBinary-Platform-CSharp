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

namespace org.allbinary.game.score;

public class HighScoreCommandsFactory : HighScoreCommandsBaseFactory
{
    private static readonly HighScoreCommandsFactory instance = new HighScoreCommandsFactory();
    public static HighScoreCommandsFactory getInstance()
    {
        return HighScoreCommandsFactory.instance;
    }

    private HighScoreCommandsFactory() : base(new Command[] { HighScoreCommands.getInstance().PERSONAL, HighScoreCommands.getInstance().WORLD })
    {
        // base(new Command[] { HighScoreCommands.getInstance().PERSONAL, HighScoreCommands.getInstance().WORLD }) is called from the constructor declaration
    }

}

