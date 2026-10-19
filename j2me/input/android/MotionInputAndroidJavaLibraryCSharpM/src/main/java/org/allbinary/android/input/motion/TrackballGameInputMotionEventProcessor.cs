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
using SingleKeyPressGameKeyFromMotionGestureEventListener = org.allbinary.game.input.motion.action.SingleKeyPressGameKeyFromMotionGestureEventListener;
using DownTrackballInputToGameKeyEventAction = org.allbinary.input.motion.trackball.action.DownTrackballInputToGameKeyEventAction;
using LeftTrackballInputToGameKeyEventAction = org.allbinary.input.motion.trackball.action.LeftTrackballInputToGameKeyEventAction;
using RightTrackballInputToGameKeyEventAction = org.allbinary.input.motion.trackball.action.RightTrackballInputToGameKeyEventAction;
using UpTrackballInputToGameKeyEventAction = org.allbinary.input.motion.trackball.action.UpTrackballInputToGameKeyEventAction;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.android.input.motion;

public class TrackballGameInputMotionEventProcessor : MotionEventProcessor
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static TrackballGameInputMotionEventProcessor PROCESSOR = new TrackballGameInputMotionEventProcessor();
    public static TrackballGameInputMotionEventProcessor getInstance()
    {
        return TrackballGameInputMotionEventProcessor.PROCESSOR;
    }

    private readonly SingleKeyPressGameKeyFromMotionGestureEventListener listener = new SingleKeyPressGameKeyFromMotionGestureEventListener();
    private TrackballGameInputMotionEventProcessor()
    {
    }

    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public override void process(MotionEvent motionEvent)
    {
        try {
            float x = motionEvent.getX();
            float y = motionEvent.getY();
            if (x < 0f) {
                this.listener.onCompleteMotionGestureInputEvent(LeftTrackballInputToGameKeyEventAction.getInstance());
            } else if (x > 0f) {
                this.listener.onCompleteMotionGestureInputEvent(RightTrackballInputToGameKeyEventAction.getInstance());
            }
            if (y < 0f) {
                this.listener.onCompleteMotionGestureInputEvent(UpTrackballInputToGameKeyEventAction.getInstance());
            } else if (y > 0f) {
                this.listener.onCompleteMotionGestureInputEvent(DownTrackballInputToGameKeyEventAction.getInstance());
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.PROCESS, e);
        }
    }

}

