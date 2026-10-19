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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.content;

public class CommandUriAction
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly CommandUriAction instance = new CommandUriAction();
    public static CommandUriAction getInstance()
    {
        return CommandUriAction.instance;
    }

    public virtual void add(Command command, string url)
    {
    }

    public virtual void process(Command command)
    {
    }

}

