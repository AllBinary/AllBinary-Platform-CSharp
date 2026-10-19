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

namespace org.allbinary.content;

public class NotificationUtil
{
    private static readonly NotificationUtil SINGLETON = new NotificationUtil();
    public static NotificationUtil getInstance()
    {
        return NotificationUtil.SINGLETON;
    }

    public virtual void notify(Command command, string resource, string message)
    {
    }

}

