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

namespace org.allbinary.graphics.displayable.command;

public class MyCommandsFactory
{
    private static readonly MyCommandsFactory instance = new MyCommandsFactory();
    public static MyCommandsFactory getInstance()
    {
        return MyCommandsFactory.instance;
    }

    public readonly Command NO_COMMAND = new Command(StringUtil.getInstance().EMPTY_STRING, StringUtil.getInstance().EMPTY_STRING, -1, -1);
    public readonly Command GAUGE_CHANGE = new Command("GAUGE_CHANGE", StringUtil.getInstance().EMPTY_STRING, Command.ITEM, 1);
    public readonly Command SET_DISPLAYABLE = new Command("Display", StringUtil.getInstance().EMPTY_STRING, Command.SCREEN, 2);
    public readonly Command PAUSE_COMMAND = new Command("Pause", StringUtil.getInstance().EMPTY_STRING, Command.SCREEN, 0);
    public readonly Command RESUME_COMMAND = new Command("Resume", StringUtil.getInstance().EMPTY_STRING, Command.SCREEN, 0);
    protected MyCommandsFactory()
    {
    }

}

