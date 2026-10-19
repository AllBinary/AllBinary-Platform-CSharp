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
//using Graphics = javax.microedition.lcdui.Graphics;
using BasicHud = org.allbinary.game.graphics.hud.BasicHud;
using BasicHudFactory = org.allbinary.game.graphics.hud.BasicHudFactory;
using GameNotificationEvent = org.allbinary.game.layer.hud.@event.GameNotificationEvent;
using GameNotificationListenerInterface = org.allbinary.game.layer.hud.@event.GameNotificationListenerInterface;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;

namespace org.allbinary.game.ag.layer.hud.basic.notification;

public class GameNotificationHud : BasicHud, GameNotificationListenerInterface
{
    public static readonly GameNotificationHud NULL_GAME_NOTIFICATION = new GameNotificationHud(BasicHudFactory.getInstance().TOPCENTER, BasicHudFactory.getInstance().HORIZONTAL, 0, BasicColorFactory.getInstance().RED);
    public GameNotificationHud(int location, int direction, int bufferZone, BasicColor basicColor) : base(location, direction, bufferZone, basicColor)
    {
        // base(location, direction, bufferZone, basicColor) is called from the constructor declaration
    }

    public override void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    private readonly string METHOD_NAME = "onGameNotificationEvent";
    private GameNotificationEvent lastGameNotificationEvent = GameNotification.NULL_GAME_NOTIFICATION_EVENT;
    // throws Exception
    public override void onGameNotificationEvent(GameNotificationEvent gameNotificationEvent)
    {
        if (this.lastGameNotificationEvent != gameNotificationEvent) {
            this.lastGameNotificationEvent = gameNotificationEvent;
            this.logUtil.putF(gameNotificationEvent.getString(), this, this.METHOD_NAME);
        }
        this.add(gameNotificationEvent.getString(), gameNotificationEvent.getSeconds(), gameNotificationEvent.getBasicColorP(), gameNotificationEvent.getPermanent());
    }

    protected virtual void add(string @string, int? seconds, BasicColor basicColor, bool? permanent)
    {
    }

    // throws Exception
    public virtual void processTick()
    {
    }

    public virtual void paint(Graphics graphics)
    {
    }

    public virtual void clear()
    {
    }

}

