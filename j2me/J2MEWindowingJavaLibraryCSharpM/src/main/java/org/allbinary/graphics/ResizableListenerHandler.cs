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

namespace org.allbinary.graphics;

public class ResizableListenerHandler
{
    private static readonly ResizableListenerHandler instance = new ResizableListenerHandler();
    public static ResizableListenerHandler getInstance()
    {
        return ResizableListenerHandler.instance;
    }

    public virtual void setListener(ResizableListenerInterface resizableListenerInterface)
    {
    }

    public virtual void fire(bool isFullScreen)
    {
    }

    // throws Exception
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void fireEvent(bool value)
    {
    }

}

