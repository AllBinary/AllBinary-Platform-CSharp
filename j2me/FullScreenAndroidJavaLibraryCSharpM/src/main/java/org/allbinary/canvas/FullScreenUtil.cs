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
//using Canvas = javax.microedition.lcdui.Canvas;
//using CommandListener = javax.microedition.lcdui.CommandListener;

namespace org.allbinary.canvas;

public class FullScreenUtil
{
    private static readonly FullScreenUtil instance = new FullScreenUtil();
    public static FullScreenUtil getInstance()
    {
        return FullScreenUtil.instance;
    }

    // throws Exception
    public void initOnRun(Canvas fullScreenInterface, CommandListener commandListener)
    {
    }

    public void init(Canvas fullScreenInterface)
    {
    }

    public bool isScreenChange(bool isFullScreen)
    {
        return false;
    }

    public bool isScreenChangeCanvas(Canvas fullScreenInterface)
    {
        return this.isScreenChange(fullScreenInterface.isFullScreenMode());
    }

}

