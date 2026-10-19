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
using CompleteMotionGestureInputEvent = org.allbinary.game.input.CompleteMotionGestureInputEvent;
using CompleteMotionGestureInputEventListenerInterface = org.allbinary.game.input.CompleteMotionGestureInputEventListenerInterface;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;

namespace org.allbinary.game.input.motion.action;

public class NoCompleteMotionGestureInputEventListener : CompleteMotionGestureInputEventListenerInterface
{
    private static readonly NoCompleteMotionGestureInputEventListener instance = new NoCompleteMotionGestureInputEventListener();
    private NoCompleteMotionGestureInputEventListener()
    {
    }

    public virtual void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    public virtual void onCompleteMotionGestureInputEvent(CompleteMotionGestureInputEvent completeMotionGestureInputEvent)
    {
    }

    public static NoCompleteMotionGestureInputEventListener getInstance()
    {
        return NoCompleteMotionGestureInputEventListener.instance;
    }

}

