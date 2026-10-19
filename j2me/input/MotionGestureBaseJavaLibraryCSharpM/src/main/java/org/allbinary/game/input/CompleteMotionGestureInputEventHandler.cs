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
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using BasicEventHandler = org.allbinary.logic.util.@event.handler.BasicEventHandler;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.input;

public class CompleteMotionGestureInputEventHandler : BasicEventHandler
{
    private static readonly CompleteMotionGestureInputEventHandler SINGLETON = new CompleteMotionGestureInputEventHandler();
    public static CompleteMotionGestureInputEventHandler getInstance()
    {
        return CompleteMotionGestureInputEventHandler.SINGLETON;
    }

    private readonly BasicArrayList list = new BasicArrayListD();
    private CompleteMotionGestureInputEventHandler()
    {
    }

    public virtual void addListener(CompleteMotionGestureInputEventListener completeMotionGestureInputEventListener)
    {
        if (!this.list.contains(completeMotionGestureInputEventListener)) {
            this.list.add(completeMotionGestureInputEventListener);
        }
    }

    public override void removeAllListeners()
    {
        this.list.clear();
        base.removeAllListeners();
    }

    public override void removeListener(EventListenerInterface eventListenerInterface)
    {
        this.list.remove(eventListenerInterface);
        base.removeListener(eventListenerInterface);
    }

    // throws Exception
    public override void fireEvent(AllBinaryEventObject eventObject)
    {
        for (int index = this.list.size(); --index >= 0; ) {
            try {
                CompleteMotionGestureInputEventListener completeMotionGestureInputEventListener = ((CompleteMotionGestureInputEventListener) this.list.objectArray[index]);
                completeMotionGestureInputEventListener.onCompleteMotionGestureInputEvent(((CompleteMotionGestureInputEvent) eventObject));
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, EventStrings.getInstance().FIRE_EVENT, e);
            }
        }
        base.fireEvent(eventObject);
    }

    // throws Exception
    protected override void process(AllBinaryEventObject eventObject, EventListenerInterface eventListenerInterface)
    {
        CompleteMotionGestureInputEventListenerInterface completeMotionGestureInputEventListenerInterface = ((CompleteMotionGestureInputEventListenerInterface) eventListenerInterface);
        completeMotionGestureInputEventListenerInterface.onCompleteMotionGestureInputEvent(((CompleteMotionGestureInputEvent) eventObject));
    }

}

