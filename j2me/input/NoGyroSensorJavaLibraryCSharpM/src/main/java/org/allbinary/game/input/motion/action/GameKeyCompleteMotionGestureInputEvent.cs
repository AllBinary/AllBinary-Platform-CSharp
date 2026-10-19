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
using InputToGameKeyMapping = org.allbinary.game.input.mapping.InputToGameKeyMapping;
using MotionGestureInput = org.allbinary.input.motion.gesture.MotionGestureInput;

namespace org.allbinary.game.input.motion.action;

public class GameKeyCompleteMotionGestureInputEvent : CompleteMotionGestureInputEvent, GameKeyEventSourceInterface
{
    private GameKey gameKey = GameKey.NULL_GAME_KEY;
    private GameKeyEvent gameKeyEvent = GameKeyEvent.NONE;
    public GameKeyCompleteMotionGestureInputEvent(string name, MotionGestureInput motionGestureInput, InputToGameKeyMapping inputToGameKeyMapping) : base(name, motionGestureInput)
    {
        // base(name, motionGestureInput) is called from the constructor declaration
    }

    public override int getSourceId()
    {
        return 0;
    }

    public virtual void update()
    {
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

