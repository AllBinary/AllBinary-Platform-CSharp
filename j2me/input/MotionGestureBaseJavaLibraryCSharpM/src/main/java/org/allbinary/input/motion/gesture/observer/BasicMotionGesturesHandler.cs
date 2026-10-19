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
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventListenerInterface = org.allbinary.logic.util.@event.EventListenerInterface;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;

namespace org.allbinary.input.motion.gesture.observer;

public class BasicMotionGesturesHandler : BasicEventHandler
{
    private static readonly BasicMotionGesturesHandler SINGLETON = new BasicMotionGesturesHandler();
    public static BasicMotionGesturesHandler getInstance()
    {
        return BasicMotionGesturesHandler.SINGLETON;
    }

    protected BasicMotionGesturesHandler()
    {
    }

    // throws Exception
    protected override void process(AllBinaryEventObject eventObject, EventListenerInterface eventListenerInterface)
    {
        BaseMotionGestureEventListener baseMotionGestureEventListener = ((BaseMotionGestureEventListener) eventListenerInterface);
        baseMotionGestureEventListener.onMotionGestureEvent(((MotionGestureEvent) eventObject));
    }

}

