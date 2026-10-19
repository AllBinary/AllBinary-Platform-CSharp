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
using GameInputMotionEventProcessorFactory = org.allbinary.android.input.motion.GameInputMotionEventProcessorFactory;
using GameKeyEventHandler = org.allbinary.game.input.@event.GameKeyEventHandler;
using BasicMotionGesturesHandler = org.allbinary.input.motion.gesture.observer.BasicMotionGesturesHandler;

namespace org.allbinary.game.displayable.canvas;

public class GameEventHandlerUtil
{
    public static void removeAllListeners()
    {
        BasicMotionGesturesHandler.getInstance().removeAllListeners();
        GameKeyEventHandler.getInstance().removeAllListeners();
        GameInputMotionEventProcessorFactory.getInstance().addListener();
    }

}

