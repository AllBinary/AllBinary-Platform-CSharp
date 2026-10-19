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
using MotionGestureInput = org.allbinary.input.motion.gesture.MotionGestureInput;
using TouchMotionGestureFactory = org.allbinary.input.motion.gesture.TouchMotionGestureFactory;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.input.motion.gesture.observer;

public class ReleaseControlledMotionGestureListener : MotionGestureEventListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private MotionGestureInput currentMotionGesture = TouchMotionGestureFactory.getInstance().NO_MOTION;
    private bool isMouseGestureOccurring = false;
    private BasicArrayList motionGestureCollection = new BasicArrayListD();
    private CompleteMotionGestureListenerInterface signed;
    public ReleaseControlledMotionGestureListener(CompleteMotionGestureListenerInterface signed)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.signed = signed;
    }

    public virtual void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(this.commonStrings.NOT_IMPLEMENTED, this);
    }

    public virtual void onUpMotionGestureEvent(MotionGestureEvent ev)
    {
        this.onMotionGestureEvent(ev);
    }

    public virtual void onDownMotionGestureEvent(MotionGestureEvent ev)
    {
        this.onMotionGestureEvent(ev);
    }

    public virtual void onLeftMotionGestureEvent(MotionGestureEvent ev)
    {
        this.onMotionGestureEvent(ev);
    }

    public virtual void onRightMotionGestureEvent(MotionGestureEvent ev)
    {
        this.onMotionGestureEvent(ev);
    }

    public virtual void onDiagonalDownRightMotionGestureEvent(MotionGestureEvent ev)
    {
        this.onMotionGestureEvent(ev);
    }

    public virtual void onDiagonalDownLeftMotionGestureEvent(MotionGestureEvent ev)
    {
        this.onMotionGestureEvent(ev);
    }

    public virtual void onDiagonalUpRightMotionGestureEvent(MotionGestureEvent ev)
    {
        this.onMotionGestureEvent(ev);
    }

    public virtual void onDiagonalUpLeftMotionGestureEvent(MotionGestureEvent ev)
    {
        this.onMotionGestureEvent(ev);
    }

    public virtual void onPressedMotionGestureEvent(MotionGestureEvent ev)
    {
        this.isMouseGestureOccurring = true;
        this.currentMotionGesture = TouchMotionGestureFactory.getInstance().NO_MOTION;
        this.onMotionGestureEvent(ev);
    }

    public virtual void onScrolledMotionGestureEvent(MotionGestureEvent motionGestureEvent)
    {
    }

    public virtual void released(MotionGestureEvent ev)
    {
        try {
            if (this.isMouseGestureOccurring == false) {
                return;
            }
            this.isMouseGestureOccurring = false;
            this.signed.onMotionGestureCompleted(this.motionGestureCollection);
            this.motionGestureCollection.clear();
        } catch (Exception e) {
            this.logUtil.put(new StringMaker().append(this.commonStrings.EXCEPTION_LABEL).append(StringUtil.getInstance().toString(ev.getMotionGesture())).ToString(), this, "release", e);
        }
    }

    public virtual void onMotionGestureEvent(MotionGestureEvent ev)
    {
        if (this.isMouseGestureOccurring == false) {
            return;
        }
        MotionGestureInput motionGestureInput = ev.getMotionGesture();
        if (motionGestureInput == TouchMotionGestureFactory.getInstance().PRESSED) {
            this.onPressedMotionGestureEvent(ev);
        } else if (motionGestureInput == TouchMotionGestureFactory.getInstance().RELEASED) {
            this.released(ev);
        } else {
            if (this.currentMotionGesture != motionGestureInput) {
                this.currentMotionGesture = motionGestureInput;
                this.motionGestureCollection.add(ev.getMotionGesture());
            }
        }
    }

}

