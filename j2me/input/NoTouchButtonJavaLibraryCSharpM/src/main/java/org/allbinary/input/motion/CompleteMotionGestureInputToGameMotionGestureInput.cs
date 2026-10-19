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
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.motion;

public class CompleteMotionGestureInputToGameMotionGestureInput
{
    private static readonly CompleteMotionGestureInputToGameMotionGestureInput instance = new CompleteMotionGestureInputToGameMotionGestureInput();
    public static CompleteMotionGestureInputToGameMotionGestureInput getInstance()
    {
        return CompleteMotionGestureInputToGameMotionGestureInput.instance;
    }

    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public virtual void init()
    {
        PreLogUtil.put("No Touch Button = No Compound Motion Gestures", this, this.commonStrings.INIT);
    }

}

