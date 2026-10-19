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
using System.Runtime.CompilerServices;
//using CommandListener = javax.microedition.lcdui.CommandListener;

namespace org.allbinary.logic.system.security.licensing;

public class LicenseUtil
{
    private static readonly LicenseUtil instance = new LicenseUtil();
    public static LicenseUtil getInstance()
    {
        return LicenseUtil.instance;
    }

    public virtual void init()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool isRunning()
    {
        return false;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void setRunning(bool running)
    {
    }

    public virtual bool shouldWait(CommandListener commandListener)
    {
        return this.isRunning();
    }

}

