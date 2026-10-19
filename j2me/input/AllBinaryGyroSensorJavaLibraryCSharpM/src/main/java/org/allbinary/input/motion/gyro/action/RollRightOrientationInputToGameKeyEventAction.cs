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

public class RollRightOrientationInputToGameKeyEventAction : GameKeyCompleteMotionGestureInputEvent
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static GameKeyCompleteMotionGestureInputEvent getInstance()
    {
        if (RollRightOrientationInputToGameKeyEventAction.instance == NullUtil.getInstance().NULL_OBJECT) {
            RollRightOrientationInputToGameKeyEventAction.instance = new RollRightOrientationInputToGameKeyEventAction();
        }
        return ((GameKeyCompleteMotionGestureInputEvent) RollRightOrientationInputToGameKeyEventAction.instance);
    }

    private RollRightOrientationInputToGameKeyEventAction() : base("Roll Right Action", OrientationMotionGestureFactory.getInstance().ROLL_RIGHT, PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance().getInputMapping())
    {
        // base("Roll Right Action", OrientationMotionGestureFactory.getInstance().ROLL_RIGHT, PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance().getInputMapping()) is called from the constructor declaration
    }

}

