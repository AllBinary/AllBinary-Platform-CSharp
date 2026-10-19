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
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;

namespace org.allbinary.animation;

public class AnimationEventHandler : BasicEventHandler
{
    private static readonly AnimationEventHandler eventHandler = new AnimationEventHandler();
    private AnimationEventHandler()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static AnimationEventHandler getInstance()
    {
        return AnimationEventHandler.eventHandler;
    }

}

