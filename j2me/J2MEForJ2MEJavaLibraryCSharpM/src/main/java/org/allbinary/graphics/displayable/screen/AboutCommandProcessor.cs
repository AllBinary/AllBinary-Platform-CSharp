/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2022 AllBinary
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
//using Canvas = javax.microedition.lcdui.Canvas;
//using Command = javax.microedition.lcdui.Command;
//using CommandListener = javax.microedition.lcdui.CommandListener;

namespace org.allbinary.graphics.displayable.screen;

public class AboutCommandProcessor
{
    private static readonly AboutCommandProcessor instance = new AboutCommandProcessor();
    public static AboutCommandProcessor getInstance()
    {
        return AboutCommandProcessor.instance;
    }

    public virtual void process(CommandListener midletCommandListener, Command command, Canvas canvas)
    {
        midletCommandListener.commandAction(command, canvas);
    }

}

