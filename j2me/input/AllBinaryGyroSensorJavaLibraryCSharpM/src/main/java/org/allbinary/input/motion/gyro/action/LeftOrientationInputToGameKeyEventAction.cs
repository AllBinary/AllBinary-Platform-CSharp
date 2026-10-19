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
using PlatformInputMappingFactory = org.allbinary.game.input.PlatformInputMappingFactory;
using GameKeyCompleteMotionGestureInputEvent = org.allbinary.game.input.motion.action.GameKeyCompleteMotionGestureInputEvent;
using OrientationMotionGestureFactory = org.allbinary.input.gyro.OrientationMotionGestureFactory;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.input.motion.gyro.action;

public class LeftOrientationInputToGameKeyEventAction : GameKeyCompleteMotionGestureInputEvent
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static GameKeyCompleteMotionGestureInputEvent getInstance()
    {
        if (LeftOrientationInputToGameKeyEventAction.instance == NullUtil.getInstance().NULL_OBJECT) {
            LeftOrientationInputToGameKeyEventAction.instance = new LeftOrientationInputToGameKeyEventAction();
        }
        return ((GameKeyCompleteMotionGestureInputEvent) LeftOrientationInputToGameKeyEventAction.instance);
    }

    private LeftOrientationInputToGameKeyEventAction() : base("Left Action", OrientationMotionGestureFactory.getInstance().LEFT, PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance().getInputMapping())
    {
        // base("Left Action", OrientationMotionGestureFactory.getInstance().LEFT, PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance().getInputMapping()) is called from the constructor declaration
    }

}

