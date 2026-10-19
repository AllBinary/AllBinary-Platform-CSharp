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
using AllMotionRecognizer = org.allbinary.input.motion.AllMotionRecognizer;
using BasicMotionGesturesHandler = org.allbinary.input.motion.gesture.observer.BasicMotionGesturesHandler;
using GameMotionGestureListener = org.allbinary.input.motion.gesture.observer.GameMotionGestureListener;
using MotionGestureReceiveInterfaceFactory = org.allbinary.input.motion.gesture.observer.MotionGestureReceiveInterfaceFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input;

//TouchJ2ME
public class TouchJ2ME
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly int DEVICE_ID = 0;
    private AllMotionRecognizer motionRecognizer = new AllMotionRecognizer();
    public TouchJ2ME()
    {
        BasicMotionGesturesHandler motionGesturesHandler = this.motionRecognizer.getMotionGestureRecognizer().getMotionGesturesHandler();
        motionGesturesHandler.addListenerInterface(new GameMotionGestureListener(MotionGestureReceiveInterfaceFactory.getInstance()));
    }

    public virtual void pointerDragged(int x, int y)
    {
        try {
            this.motionRecognizer.processDraggedMotionEvent(x, y, DEVICE_ID, 0);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, "pointerDragged", e);
        }
    }

    public virtual void pointerPressed(int x, int y)
    {
        try {
            this.motionRecognizer.processStartMotionEvent(x, y, DEVICE_ID, 0);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, "pointerPressed", e);
        }
    }

    public virtual void pointerReleased(int x, int y)
    {
        try {
            this.motionRecognizer.processEndMotionEvent(x, y, DEVICE_ID, 0);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, "pointerReleased", e);
        }
    }

}

