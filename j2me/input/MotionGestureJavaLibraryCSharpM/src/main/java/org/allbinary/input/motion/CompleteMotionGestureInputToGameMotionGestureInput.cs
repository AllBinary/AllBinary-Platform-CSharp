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
using TouchMotionGestureFactory = org.allbinary.input.motion.gesture.TouchMotionGestureFactory;
using MotionGestureConfiguration = org.allbinary.input.motion.gesture.configuration.MotionGestureConfiguration;
using MotionGestureConfigurationFactory = org.allbinary.input.motion.gesture.configuration.MotionGestureConfigurationFactory;
using DiagonalDownLeftTouchInputToGameKeyEventAction = org.allbinary.input.motion.touch.action.DiagonalDownLeftTouchInputToGameKeyEventAction;
using DiagonalDownRightTouchInputToGameKeyEventAction = org.allbinary.input.motion.touch.action.DiagonalDownRightTouchInputToGameKeyEventAction;
using DiagonalUpLeftTouchInputToGameKeyEventAction = org.allbinary.input.motion.touch.action.DiagonalUpLeftTouchInputToGameKeyEventAction;
using DiagonalUpRightTouchInputToGameKeyEventAction = org.allbinary.input.motion.touch.action.DiagonalUpRightTouchInputToGameKeyEventAction;
using DownTouchInputToGameKeyEventAction = org.allbinary.input.motion.touch.action.DownTouchInputToGameKeyEventAction;
using LeftTouchInputToGameKeyEventAction = org.allbinary.input.motion.touch.action.LeftTouchInputToGameKeyEventAction;
using ReleaseTouchInputToGameKeyEventAction = org.allbinary.input.motion.touch.action.ReleaseTouchInputToGameKeyEventAction;
using RightTouchInputToGameKeyEventAction = org.allbinary.input.motion.touch.action.RightTouchInputToGameKeyEventAction;
using UpTouchInputToGameKeyEventAction = org.allbinary.input.motion.touch.action.UpTouchInputToGameKeyEventAction;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.input.motion;

public class CompleteMotionGestureInputToGameMotionGestureInput
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly CompleteMotionGestureInputToGameMotionGestureInput instance = new CompleteMotionGestureInputToGameMotionGestureInput();
    public static CompleteMotionGestureInputToGameMotionGestureInput getInstance()
    {
        return CompleteMotionGestureInputToGameMotionGestureInput.instance;
    }

    public virtual void init()
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        try {
            PreLogUtil.put("Compound Motion Gestures", this, commonStrings.INIT);
            MotionGestureConfiguration motionGestureConfiguration = MotionGestureConfigurationFactory.getInstance();
            TouchMotionGestureFactory touchMotionGestureFactory = TouchMotionGestureFactory.getInstance();
            BasicArrayList list = new BasicArrayListD();
            list.add(touchMotionGestureFactory.DIAGONAL_DOWN_LEFT);
            motionGestureConfiguration.addMotionGestureAction(list, DiagonalDownLeftTouchInputToGameKeyEventAction.getInstance());
            list = new BasicArrayListD();
            list.add(touchMotionGestureFactory.DIAGONAL_DOWN_RIGHT);
            motionGestureConfiguration.addMotionGestureAction(list, DiagonalDownRightTouchInputToGameKeyEventAction.getInstance());
            list = new BasicArrayListD();
            list.add(touchMotionGestureFactory.DIAGONAL_UP_LEFT);
            motionGestureConfiguration.addMotionGestureAction(list, DiagonalUpLeftTouchInputToGameKeyEventAction.getInstance());
            list = new BasicArrayListD();
            list.add(touchMotionGestureFactory.DIAGONAL_UP_RIGHT);
            motionGestureConfiguration.addMotionGestureAction(list, DiagonalUpRightTouchInputToGameKeyEventAction.getInstance());
            list = new BasicArrayListD();
            list.add(touchMotionGestureFactory.LEFT);
            motionGestureConfiguration.addMotionGestureAction(list, LeftTouchInputToGameKeyEventAction.getInstance());
            list = new BasicArrayListD();
            list.add(touchMotionGestureFactory.RIGHT);
            motionGestureConfiguration.addMotionGestureAction(list, RightTouchInputToGameKeyEventAction.getInstance());
            list = new BasicArrayListD();
            list.add(touchMotionGestureFactory.DOWN);
            motionGestureConfiguration.addMotionGestureAction(list, DownTouchInputToGameKeyEventAction.getInstance());
            list = new BasicArrayListD();
            list.add(touchMotionGestureFactory.UP);
            motionGestureConfiguration.addMotionGestureAction(list, UpTouchInputToGameKeyEventAction.getInstance());
            list = new BasicArrayListD();
            list.add(touchMotionGestureFactory.RELEASED);
            motionGestureConfiguration.addMotionGestureAction(list, ReleaseTouchInputToGameKeyEventAction.getInstance());
        } catch (Exception e) {
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.INIT, e);
        }
    }

}

