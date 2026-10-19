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
using TouchMotionGestureFactory = org.allbinary.input.motion.gesture.TouchMotionGestureFactory;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.input.motion.touch.action;

public class DiagonalDownLeftTouchInputToGameKeyEventAction : GameKeyCompleteMotionGestureInputEvent
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static GameKeyCompleteMotionGestureInputEvent getInstance()
    {
        if (DiagonalDownLeftTouchInputToGameKeyEventAction.instance == NullUtil.getInstance().NULL_OBJECT) {
            DiagonalDownLeftTouchInputToGameKeyEventAction.instance = new DiagonalDownLeftTouchInputToGameKeyEventAction();
        }
        return ((GameKeyCompleteMotionGestureInputEvent) DiagonalDownLeftTouchInputToGameKeyEventAction.instance);
    }

    private DiagonalDownLeftTouchInputToGameKeyEventAction() : base("Diagonal Down Left Action", TouchMotionGestureFactory.getInstance().DIAGONAL_DOWN_LEFT, PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance().getInputMapping())
    {
        // base("Diagonal Down Left Action", TouchMotionGestureFactory.getInstance().DIAGONAL_DOWN_LEFT, PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance().getInputMapping()) is called from the constructor declaration
    }

}

