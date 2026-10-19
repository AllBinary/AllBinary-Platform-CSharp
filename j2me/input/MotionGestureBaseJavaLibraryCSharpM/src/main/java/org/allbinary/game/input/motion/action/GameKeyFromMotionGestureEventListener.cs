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
using CompleteMotionGestureInputEventListener = org.allbinary.game.input.CompleteMotionGestureInputEventListener;
using DownGameKeyEventHandler = org.allbinary.game.input.@event.DownGameKeyEventHandler;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using UpGameKeyEventHandler = org.allbinary.game.input.@event.UpGameKeyEventHandler;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.input.motion.action;

public class GameKeyFromMotionGestureEventListener : CompleteMotionGestureInputEventListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private GameKeyEvent previousGameKeyEvent = GameKeyEvent.NONE;
    public override void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    public override void onCompleteMotionGestureInputEvent(CompleteMotionGestureInputEvent completeMotionGestureInputEvent)
    {
        try {
            GameKeyCompleteMotionGestureInputEvent gameKeyCompleteMotionGestureInputEvent = ((GameKeyCompleteMotionGestureInputEvent) completeMotionGestureInputEvent);
            GameKeyEvent gameKeyEvent = gameKeyCompleteMotionGestureInputEvent.getGameKeyEvent();
            if (gameKeyEvent != this.previousGameKeyEvent) {
                if (this.previousGameKeyEvent != GameKeyEvent.NONE) {
                    UpGameKeyEventHandler.getInstance().fireEvent(this.previousGameKeyEvent);
                }
                this.previousGameKeyEvent = gameKeyEvent;
                if (gameKeyEvent != null && gameKeyEvent != GameKeyEvent.NONE) {
                    DownGameKeyEventHandler.getInstance().fireEvent(gameKeyEvent);
                }
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, "onCompleteMotionGestureInputEvent", e);
        }
    }

}

