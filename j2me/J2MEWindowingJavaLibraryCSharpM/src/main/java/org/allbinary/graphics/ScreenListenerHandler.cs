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

namespace org.allbinary.graphics;

public class ScreenListenerHandler
{
    private static readonly ScreenListenerHandler instance = new ScreenListenerHandler();
    public static ScreenListenerHandler getInstance()
    {
        return ScreenListenerHandler.instance;
    }

    private ScreenListenerInterface screenListenerInterface = new ScreenEmptyListener();
    public virtual void setListener(ScreenListenerInterface screenListenerInterface)
    {
        this.screenListenerInterface = screenListenerInterface;
    }

    public virtual void fireWithState(bool isFullScreen)
    {
        this.screenListenerInterface.onFullScreen(isFullScreen);
    }

    public virtual void fire()
    {
        this.screenListenerInterface.onFullScreenDisplay();
    }

}

