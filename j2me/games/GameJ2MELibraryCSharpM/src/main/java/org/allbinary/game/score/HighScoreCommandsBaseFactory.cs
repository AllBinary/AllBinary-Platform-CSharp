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
using J2MEUtil = org.allbinary.J2MEUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.game.score;

public class HighScoreCommandsBaseFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly Command[] HIGH_SCORE_COMMANDS;
    public HighScoreCommandsBaseFactory(Command[] HIGH_SCORE_COMMANDS)
    {
        this.HIGH_SCORE_COMMANDS = HIGH_SCORE_COMMANDS;
    }

    public virtual bool isHighScoreCommand(Command command)
    {
        for (int index = this.HIGH_SCORE_COMMANDS.Length - 1; index >= 0; index--) {
            if (command == this.HIGH_SCORE_COMMANDS[index]) {
                return true;
            }
        }
        return false;
    }

    // throws Exception
    public virtual int getIndex(Command command)
    {
        for (int index = this.HIGH_SCORE_COMMANDS.Length - 1; index >= 0; index--) {
            if (command == this.HIGH_SCORE_COMMANDS[index]) {
                return index;
            }
        }
        throw new Exception("No Such Command");
    }

}

