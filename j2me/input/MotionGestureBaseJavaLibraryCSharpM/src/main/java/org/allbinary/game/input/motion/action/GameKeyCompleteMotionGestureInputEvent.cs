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
using CompleteMotionGestureInputEvent = org.allbinary.game.input.CompleteMotionGestureInputEvent;
using GameKey = org.allbinary.game.input.GameKey;
using GameKeyEventSourceInterface = org.allbinary.game.input.GameKeyEventSourceInterface;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using GameKeyEventFactory = org.allbinary.game.input.@event.GameKeyEventFactory;
using InputToGameKeyMapping = org.allbinary.game.input.mapping.InputToGameKeyMapping;
using MotionGestureInput = org.allbinary.input.motion.gesture.MotionGestureInput;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.input.motion.action;

public class GameKeyCompleteMotionGestureInputEvent : CompleteMotionGestureInputEvent, GameKeyEventSourceInterface
{
    private readonly GameKeyEventFactory gameKeyEventFactory = GameKeyEventFactory.getInstance();
    private readonly int SOURCE_ID;
    private GameKey gameKey = GameKey.NULL_GAME_KEY;
    private GameKeyEvent gameKeyEvent = GameKeyEvent.NONE;
    private InputToGameKeyMapping inputToGameKeyMapping;
    public GameKeyCompleteMotionGestureInputEvent(string name, MotionGestureInput motionGestureInput, InputToGameKeyMapping inputToGameKeyMapping) : base(name, motionGestureInput)
    {
        this.SOURCE_ID = this.gameKeyEventFactory.MOTION_GESTURE_SOURCE_ID;
        // base(name, motionGestureInput) is called from the constructor declaration
        this.inputToGameKeyMapping = inputToGameKeyMapping;
        GameKeyCompleteMotionGestureInputEventFactory.getInstance().add(this);
        this.update();
    }

    public override int getSourceId()
    {
        return this.SOURCE_ID;
    }

    public virtual void update()
    {
        try {
            this.setGameKey(this.inputToGameKeyMapping.getInstance(this.getMotionGestureInput().getId()));
            this.setGameKeyEvent(this.gameKeyEventFactory.getInstanceForInput(this, this.getGameKey()));
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.UPDATE, e);
        }
    }

    protected virtual void setGameKeyEvent(GameKeyEvent gameKeyEvent)
    {
        this.gameKeyEvent = gameKeyEvent;
    }

    public virtual GameKeyEvent getGameKeyEvent()
    {
        return this.gameKeyEvent;
    }

    protected virtual void setGameKey(GameKey gameKey)
    {
        this.gameKey = gameKey;
    }

    public virtual GameKey getGameKey()
    {
        return this.gameKey;
    }

}

