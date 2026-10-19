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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.input.motion.gesture.observer;

public class NullCompleteMotionGestureReceiver : CompleteMotionGestureListenerInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public NullCompleteMotionGestureReceiver()
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        this.logUtil.putF("Null Gesture Reciever", this, commonStrings.CONSTRUCTOR);
    }

    // throws Exception
    public virtual void onMotionGestureCompleted(BasicArrayList list)
    {
    }

}

