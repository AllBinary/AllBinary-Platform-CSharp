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
using GameKeyEventSourceInterface = org.allbinary.game.input.GameKeyEventSourceInterface;
using Input = org.allbinary.game.input.Input;
using InputFactory = org.allbinary.game.input.InputFactory;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.game.input.@event;

public class GameKeyEventFactory
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static GameKeyEventFactory getInstance()
    {
        if (GameKeyEventFactory.instance == NullUtil.getInstance().NULL_OBJECT) {
            GameKeyEventFactory.instance = new GameKeyEventFactory();
        }
        return ((GameKeyEventFactory) GameKeyEventFactory.instance);
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly int TOUCH_BUTTON_SOURCE_ID = 2;
    public readonly int MOTION_GESTURE_SOURCE_ID = 3;
    private readonly int MAX_SOURCES = 4;
    private GameKeyEvent[][] ARRAY;
    private GameKeyEventFactory()
    {
        this.ARRAY = System.Linq.Enumerable.Range(0, this.MAX_SOURCES).Select(_ => new GameKeyEvent[InputFactory.getInstance().MAX]).ToArray();
    }

    public virtual void init()
    {
        NullUtil nullUtil = NullUtil.getInstance();
        int size = InputFactory.getInstance().MAX;
        for (int index = this.MAX_SOURCES; --index >= 0; ) {
            for (int index2 = size; --index2 >= 0; ) {
                this.ARRAY[index][index2] = GameKeyEvent.createEvent(nullUtil.NULL_OBJECT, index, index2);
            }
        }
    }

    // throws Exception
    public virtual GameKeyEvent getInstanceForKey(GameKeyEventSourceInterface anyType, int key)
    {
        GameKeyEvent gameKeyEvent = this.ARRAY[anyType.getSourceId()][key];
        return gameKeyEvent;
    }

    // throws Exception
    public virtual GameKeyEvent getInstanceForInput(GameKeyEventSourceInterface anyType, Input input)
    {
        GameKeyEvent gameKeyEvent = this.ARRAY[anyType.getSourceId()][input.getId()];
        return gameKeyEvent;
    }

}

