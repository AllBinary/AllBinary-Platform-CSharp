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
using AllMotionRecognizer = org.allbinary.input.motion.AllMotionRecognizer;
using MotionRecognizer = org.allbinary.input.motion.MotionRecognizer;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.android.input.motion.api1;

public class GameInputMotionEventProcessorAPI1 : BaseGameInputMotionEventProcessor
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static GameInputMotionEventProcessorAPI1 getInstance()
    {
        if (GameInputMotionEventProcessorAPI1.instance == NullUtil.getInstance().NULL_OBJECT) {
            GameInputMotionEventProcessorAPI1.instance = new GameInputMotionEventProcessorAPI1();
        }
        return ((GameInputMotionEventProcessorAPI1) GameInputMotionEventProcessorAPI1.instance);
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly MotionRecognizer motionRecognizer = new AllMotionRecognizer();
    private GameInputMotionEventProcessorAPI1()
    {
    }

    public override void process(MotionEvent motionEvent)
    {
        try {
            int x = ((int) motionEvent.getX());
            int y = ((int) motionEvent.getY());
            int action = motionEvent.getAction();
            if (action == MotionEvent.ACTION_DOWN) {
                this.motionRecognizer.processStartMotionEvent(x, y, motionEvent.getDeviceId(), 0);
            } else if (action == MotionEvent.ACTION_UP || action == MotionEvent.ACTION_CANCEL) {
                this.motionRecognizer.processEndMotionEvent(x, y, motionEvent.getDeviceId(), 0);
            } else if (action == MotionEvent.ACTION_MOVE) {
                this.motionRecognizer.processDraggedMotionEvent(x, y, motionEvent.getDeviceId(), 0);
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.PROCESS, e);
        }
    }

}

