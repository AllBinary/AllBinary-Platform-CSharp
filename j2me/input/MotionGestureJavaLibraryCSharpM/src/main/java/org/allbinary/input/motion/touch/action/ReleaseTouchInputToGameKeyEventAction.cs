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
using GameKey = org.allbinary.game.input.GameKey;
using GameKeyFactory = org.allbinary.game.input.GameKeyFactory;
using PlatformInputMappingFactory = org.allbinary.game.input.PlatformInputMappingFactory;
using GameKeyEventFactory = org.allbinary.game.input.@event.GameKeyEventFactory;
using GameKeyCompleteMotionGestureInputEvent = org.allbinary.game.input.motion.action.GameKeyCompleteMotionGestureInputEvent;
using TouchMotionGestureFactory = org.allbinary.input.motion.gesture.TouchMotionGestureFactory;
using NullUtil = org.allbinary.logic.NullUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.motion.touch.action;

public class ReleaseTouchInputToGameKeyEventAction : GameKeyCompleteMotionGestureInputEvent
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static GameKeyCompleteMotionGestureInputEvent getInstance()
    {
        if (ReleaseTouchInputToGameKeyEventAction.instance == NullUtil.getInstance().NULL_OBJECT) {
            ReleaseTouchInputToGameKeyEventAction.instance = new ReleaseTouchInputToGameKeyEventAction();
        }
        return ((GameKeyCompleteMotionGestureInputEvent) ReleaseTouchInputToGameKeyEventAction.instance);
    }

    private readonly GameKey NONE = GameKeyFactory.getInstance().NONE;
    private ReleaseTouchInputToGameKeyEventAction() : base("Release Action", TouchMotionGestureFactory.getInstance().RELEASED, PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance().getInputMapping())
    {
        // base("Release Action", TouchMotionGestureFactory.getInstance().RELEASED, PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance().getInputMapping()) is called from the constructor declaration
        try {
            this.setGameKey(this.NONE);
            this.setGameKeyEvent(GameKeyEventFactory.getInstance().getInstanceForInput(this, this.NONE));
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.CONSTRUCTOR, e);
        }
    }

    public override void update()
    {
    }

}

