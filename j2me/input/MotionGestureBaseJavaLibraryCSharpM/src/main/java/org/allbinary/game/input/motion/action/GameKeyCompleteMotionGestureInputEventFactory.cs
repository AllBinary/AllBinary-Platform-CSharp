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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.input.motion.action;

public class GameKeyCompleteMotionGestureInputEventFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly GameKeyCompleteMotionGestureInputEventFactory SINGLETON = new GameKeyCompleteMotionGestureInputEventFactory();
    private readonly BasicArrayList eventList = new BasicArrayListD();
    public static GameKeyCompleteMotionGestureInputEventFactory getInstance()
    {
        return GameKeyCompleteMotionGestureInputEventFactory.SINGLETON;
    }

    public virtual void add(GameKeyCompleteMotionGestureInputEvent gameKeyCompleteMotionGestureInputEvent)
    {
        this.eventList.add(gameKeyCompleteMotionGestureInputEvent);
    }

    public virtual void updateAll()
    {
        this.logUtil.putF(new StringMaker().append(CommonLabels.getInstance().START_LABEL).appendint(this.eventList.size()).ToString(), this, "updateAll");
        for (int index = this.eventList.size() - 1; index >= 0; index--) {
            GameKeyCompleteMotionGestureInputEvent gameKeyCompleteMotionGestureInputEvent = ((GameKeyCompleteMotionGestureInputEvent) this.eventList.objectArray[index]);
            gameKeyCompleteMotionGestureInputEvent.update();
        }
    }

}

