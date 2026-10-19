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
using BaseGameInputMotionEventProcessor = org.allbinary.android.input.motion.BaseGameInputMotionEventProcessor;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using ScalableListener = org.allbinary.graphics.displayable.ScalableListener;
using AllMotionRecognizer = org.allbinary.input.motion.AllMotionRecognizer;
using MotionRecognizer = org.allbinary.input.motion.MotionRecognizer;
using NullUtil = org.allbinary.logic.NullUtil;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.android.input.motion.api5;

public class GameInputMotionEventProcessorAPI5 : BaseGameInputMotionEventProcessor
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static GameInputMotionEventProcessorAPI5 getInstance()
    {
        if (GameInputMotionEventProcessorAPI5.instance == NullUtil.getInstance().NULL_OBJECT) {
            GameInputMotionEventProcessorAPI5.instance = new GameInputMotionEventProcessorAPI5();
        }
        return ((GameInputMotionEventProcessorAPI5) GameInputMotionEventProcessorAPI5.instance);
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
    private readonly MotionRecognizer[] motionRecognizerArray;
    private readonly int TOTAL_MINUS_ONE;
    private GameInputMotionEventProcessorAPI5()
    {
        int size = GameInputMotionInfoAPI5.getInstance().MAX_POINTERS;
        this.motionRecognizerArray = new AllMotionRecognizer[size];
        this.TOTAL_MINUS_ONE = size;
        for (int index = 0; index < size; index++) {
            this.motionRecognizerArray[index] = new AllMotionRecognizer();
        }
    }

    private bool isValid(int pointerId)
    {
        if (pointerId > this.TOTAL_MINUS_ONE) {
            string message = "Log that the pointer Ids are not what would be expected or Android has more than what I set my stuff to support pointerId: ";
            ForcedLogUtil.log(message + pointerId, this);
            return false;
        } else {
            return true;
        }
    }

    public override void process(MotionEvent motionEvent)
    {
        try {
            int action = motionEvent.getAction();
            int total = this.motionRecognizerArray.Length;
            if (total > motionEvent.getPointerCount()) {
                total = motionEvent.getPointerCount();
            } else {
                string message = "Log that Android has more pointers than I have expected so increase it motionEvent.getPointerCount(): ";
                ForcedLogUtil.log(message + motionEvent.getPointerCount(), this);
            }
            int totalMinusOne = total - 1;
            if (action == MotionEvent.ACTION_DOWN) {
                for (int pointerIndex = totalMinusOne; pointerIndex >= 0; pointerIndex--) {
                    int pointerId = motionEvent.getPointerId(pointerIndex);
                    if (this.isValid(pointerId)) {
                        ScalableListener scalableListener = this.displayInfo.getScalableListener();
                        int x = ((int) ((motionEvent.getX(pointerIndex) - this.displayInfo.getLeft()) / scalableListener.getRatio(this.displayInfo.getRatio())));
                        int y = ((int) ((motionEvent.getY(pointerIndex) - this.displayInfo.getTop()) / scalableListener.getRatio(this.displayInfo.getRatio())));
                        this.motionRecognizerArray[pointerId].processStartMotionEvent(x, y, motionEvent.getDeviceId(), 0);
                    }
                }
            } else if (action == MotionEvent.ACTION_UP || action == MotionEvent.ACTION_CANCEL) {
                for (int pointerIndex = totalMinusOne; pointerIndex >= 0; pointerIndex--) {
                    int pointerId = motionEvent.getPointerId(pointerIndex);
                    if (this.isValid(pointerId)) {
                        ScalableListener scalableListener = this.displayInfo.getScalableListener();
                        int x = ((int) ((motionEvent.getX(pointerIndex) - this.displayInfo.getLeft()) / scalableListener.getRatio(this.displayInfo.getRatio())));
                        int y = ((int) ((motionEvent.getY(pointerIndex) - this.displayInfo.getTop()) / scalableListener.getRatio(this.displayInfo.getRatio())));
                        this.motionRecognizerArray[pointerId].processEndMotionEvent(x, y, motionEvent.getDeviceId(), 0);
                    }
                }
            } else if (action == MotionEvent.ACTION_MOVE) {
                for (int pointerIndex = totalMinusOne; pointerIndex >= 0; pointerIndex--) {
                    int pointerId = motionEvent.getPointerId(pointerIndex);
                    if (this.isValid(pointerId)) {
                        ScalableListener scalableListener = this.displayInfo.getScalableListener();
                        int x = ((int) ((motionEvent.getX(pointerIndex) - this.displayInfo.getLeft()) / scalableListener.getRatio(this.displayInfo.getRatio())));
                        int y = ((int) ((motionEvent.getY(pointerIndex) - this.displayInfo.getTop()) / scalableListener.getRatio(this.displayInfo.getRatio())));
                        this.motionRecognizerArray[pointerId].processDraggedMotionEvent(x, y, motionEvent.getDeviceId(), 0);
                    }
                }
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.PROCESS, e);
        }
    }

}

