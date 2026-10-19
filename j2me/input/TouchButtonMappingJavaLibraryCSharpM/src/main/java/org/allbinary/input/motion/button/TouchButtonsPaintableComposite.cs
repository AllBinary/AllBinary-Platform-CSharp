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
using CompleteMotionGestureInputEventHandler = org.allbinary.game.input.CompleteMotionGestureInputEventHandler;
using CompleteMotionGestureInputEventListenerInterface = org.allbinary.game.input.CompleteMotionGestureInputEventListenerInterface;
using GameKey = org.allbinary.game.input.GameKey;
using InputMappingInterface = org.allbinary.game.input.mapping.InputMappingInterface;
using GameKeyCompleteMotionGestureInputEvent = org.allbinary.game.input.motion.action.GameKeyCompleteMotionGestureInputEvent;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using ProcessPaintable = org.allbinary.graphics.paint.ProcessPaintable;
using MotionGestureInput = org.allbinary.input.motion.gesture.MotionGestureInput;
using TouchMotionGestureFactory = org.allbinary.input.motion.gesture.TouchMotionGestureFactory;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.input.motion.button;

public class TouchButtonsPaintableComposite : ProcessPaintable, CompleteMotionGestureInputEventListenerInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private InputMappingInterface inputMappingInterface;
    public TouchButtonsMappingPaintable touchButtonsPaintable;
    private TimeDelayHelper timeHelper = new TimeDelayHelper(250);
    private bool released = true;
    public TouchButtonsPaintableComposite(InputMappingInterface inputMappingInterface, BasicColor basicColor)
    {
        this.inputMappingInterface = inputMappingInterface;
        CompleteMotionGestureInputEventHandler.getInstance().addListenerInterface(this);
        this.touchButtonsPaintable = new TouchButtonsMappingPaintable(basicColor);
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    private readonly string METHOD_NAME = "onCompleteMotionGestureInputEvent";
    private readonly string RELEASE = "Ignoring: MotionGestureInput Release";
    private readonly string FAST_REPEAT = "Ignoring: MotionGestureInput Repeated To Quickly";
    private readonly string IGNORE = "Ignoring: Until Released";
    public override void onCompleteMotionGestureInputEvent(CompleteMotionGestureInputEvent completeMotionGestureInputEvent)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "onCompleteMotionGestureInputEvent");
            TouchMotionGestureFactory touchMotionGestureFactory = TouchMotionGestureFactory.getInstance();
            GameKeyCompleteMotionGestureInputEvent gameKeyCompleteMotionGestureInputEvent = ((GameKeyCompleteMotionGestureInputEvent) completeMotionGestureInputEvent);
            GameKey gameKey = gameKeyCompleteMotionGestureInputEvent.getGameKey();
            MotionGestureInput motionGestureInput = completeMotionGestureInputEvent.getMotionGestureInput();
            if (motionGestureInput == touchMotionGestureFactory.RELEASED) {
                this.logUtil.putF(this.RELEASE, this, this.METHOD_NAME);
                this.released = true;
                return;
            }
            if (motionGestureInput == TouchMotionGestureFactory.getInstance().NO_MOTION && !this.timeHelper.isTimeTNT()) {
                this.logUtil.putF(this.FAST_REPEAT, this, this.METHOD_NAME);
                return;
            }
            if (!this.released) {
                this.logUtil.putF(this.IGNORE, this, this.METHOD_NAME);
                return;
            }
            this.released = false;
            this.logUtil.putF(new StringMaker().append("GameKey: ").append(StringUtil.getInstance().toString(gameKey)).append(" MotionGestureInput: ").append(StringUtil.getInstance().toString(motionGestureInput)).ToString(), this, this.METHOD_NAME);
            this.inputMappingInterface.processInputMapping(gameKey, motionGestureInput);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.METHOD_NAME, e);
        }
    }

    public override void process()
    {
        CompleteMotionGestureInputEventHandler.getInstance().removeListener(this);
    }

}

