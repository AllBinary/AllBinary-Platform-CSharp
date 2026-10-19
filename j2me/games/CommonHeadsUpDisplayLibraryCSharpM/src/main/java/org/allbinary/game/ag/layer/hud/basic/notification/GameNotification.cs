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
using GameNotificationEvent = org.allbinary.game.layer.hud.@event.GameNotificationEvent;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using NullUtil = org.allbinary.logic.NullUtil;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.game.ag.layer.hud.basic.notification;

public class GameNotification
{
    public static readonly GameNotificationEvent NULL_GAME_NOTIFICATION_EVENT = new GameNotificationEvent(NullUtil.getInstance().NULL_OBJECT, StringUtil.getInstance().EMPTY_STRING, 0, BasicColorFactory.getInstance().RED, BooleanFactory.getInstance().FALSE);
    public readonly BasicArrayList stringList = new BasicArrayListD();
    public readonly BasicArrayList timeList = new BasicArrayListD();
    public readonly BasicArrayList colorList = new BasicArrayListD();
    public virtual void add(string @string, int? seconds, BasicColor basicColor)
    {
        if (!this.stringList.contains(@string)) {
            this.stringList.add(@string);
            this.timeList.add(seconds);
            this.colorList.add(basicColor);
        }
    }

    public virtual void clear()
    {
        this.stringList.clear();
        this.timeList.clear();
        this.colorList.clear();
    }

    public virtual int getSize()
    {
        return this.stringList.size();
    }

}

