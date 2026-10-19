/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2009 AllBinary
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
using MotionEvent = android.view.MotionEvent;
using BasicMotionGesturesHandler = org.allbinary.input.motion.gesture.observer.BasicMotionGesturesHandler;
using GameMotionGestureListener = org.allbinary.input.motion.gesture.observer.GameMotionGestureListener;
using MotionGestureReceiveInterfaceFactory = org.allbinary.input.motion.gesture.observer.MotionGestureReceiveInterfaceFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.android.input.motion;

public class BaseGameInputMotionEventProcessor : MotionEventProcessor
{
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly GameMotionGestureListener gameMotionGestureListener;
    protected BaseGameInputMotionEventProcessor()
    {
        this.gameMotionGestureListener = new GameMotionGestureListener(MotionGestureReceiveInterfaceFactory.getInstance());
        this.addListener();
    }

    public override void process(MotionEvent motionEvent)
    {
    }

    public virtual void addListener()
    {
        BasicMotionGesturesHandler motionGesturesHandler = BasicMotionGesturesHandler.getInstance();
        motionGesturesHandler.addListenerInterface(this.gameMotionGestureListener);
    }

}

