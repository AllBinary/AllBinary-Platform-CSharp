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
using TrackballMotionGestureFactory = org.allbinary.input.motion.gesture.TrackballMotionGestureFactory;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.input.motion.trackball.action;

public class RightTrackballInputToGameKeyEventAction : GameKeyCompleteMotionGestureInputEvent
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static GameKeyCompleteMotionGestureInputEvent getInstance()
    {
        if (RightTrackballInputToGameKeyEventAction.instance == NullUtil.getInstance().NULL_OBJECT) {
            RightTrackballInputToGameKeyEventAction.instance = new RightTrackballInputToGameKeyEventAction();
        }
        return ((GameKeyCompleteMotionGestureInputEvent) RightTrackballInputToGameKeyEventAction.instance);
    }

    private RightTrackballInputToGameKeyEventAction() : base("Right Action", TrackballMotionGestureFactory.getInstance().RIGHT, PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance().getInputMapping())
    {
        // base("Right Action", TrackballMotionGestureFactory.getInstance().RIGHT, PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance().getInputMapping()) is called from the constructor declaration
    }

}

