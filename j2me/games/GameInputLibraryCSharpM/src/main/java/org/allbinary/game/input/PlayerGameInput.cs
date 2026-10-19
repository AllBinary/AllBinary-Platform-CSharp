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
using System.Runtime.CompilerServices;
using GameKeyEvent = org.allbinary.game.input.@event.GameKeyEvent;
using GameKeyEventListenerInterface = org.allbinary.game.input.@event.GameKeyEventListenerInterface;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;
using CommonLabels = org.allbinary.@string.CommonLabels;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.input;

public class PlayerGameInput : GameInput, GameKeyEventListenerInterface
{
    public readonly GameInputStrings gameInputStrings = GameInputStrings.getInstance();
    private readonly int playerInputId;
    public PlayerGameInput(BasicArrayList gameKeyEventList, BasicArrayList removalGameKeyEventList, int playerInputId) : base(gameKeyEventList, removalGameKeyEventList)
    {
        // base(gameKeyEventList, removalGameKeyEventList) is called from the constructor declaration
        this.playerInputId = playerInputId;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void onPressGameKeyEvent(GameKeyEvent gameKeyEvent)
    {
        this.add(gameKeyEvent);
        this.addForRemoval(gameKeyEvent);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void onDownGameKeyEvent(GameKeyEvent gameKeyEvent)
    {
        this.add(gameKeyEvent);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void onDownKeyEvent(GameKeyEvent gameKeyEvent)
    {
        this.add(gameKeyEvent);
        this.addForRemoval(gameKeyEvent);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void onDownKey(int? gameKeyEvent)
    {
        PreLogUtil.put(new StringMaker().append(CommonLabels.getInstance().START_LABEL).append(gameKeyEvent.ToString()).ToString(), this, this.gameInputStrings.ON_DOWN_GAME_KEY);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void onUpGameKeyEvent(GameKeyEvent gameKeyEvent)
    {
        this.addForRemoval(gameKeyEvent);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void onUpKeyEvent(int? gameKeyEvent)
    {
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    public virtual int getPlayerInputId()
    {
        return this.playerInputId;
    }

}

