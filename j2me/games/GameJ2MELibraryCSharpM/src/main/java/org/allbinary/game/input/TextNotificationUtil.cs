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
using GameNotificationEventHandler = org.allbinary.game.layer.hud.@event.GameNotificationEventHandler;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using ErrorSound = org.allbinary.media.audio.ErrorSound;
using PrimaryPlayerQueueFactory = org.allbinary.media.audio.PrimaryPlayerQueueFactory;
using SelectSound = org.allbinary.media.audio.SelectSound;

namespace org.allbinary.game.input;

public class TextNotificationUtil
{
    private static readonly TextNotificationUtil instance = new TextNotificationUtil();
    public static TextNotificationUtil getInstance()
    {
        return TextNotificationUtil.instance;
    }

    // throws Exception
    public virtual void fireError(string message)
    {
        PrimaryPlayerQueueFactory.getInstance().add(ErrorSound.getInstance());
        this.fire(message);
    }

    // throws Exception
    public virtual void fireNew(string message)
    {
        PrimaryPlayerQueueFactory.getInstance().add(SelectSound.getInstance());
        this.fire(message);
    }

    // throws Exception
    public virtual void fireSuccess(string message)
    {
        PrimaryPlayerQueueFactory.getInstance().add(SelectSound.getInstance());
        this.fire(message);
    }

    private readonly int? TWO = SmallIntegerSingletonFactory.getInstance().getAt(2);
    private readonly bool? FALSE = BooleanFactory.getInstance().FALSE;
    private readonly GameNotificationEventHandler gameNotificationEventHandler = GameNotificationEventHandler.getInstance();
    // throws Exception
    public virtual void fire(string message)
    {
        GameNotificationEvent gameNotificationEvent = new GameNotificationEvent(this, message, this.TWO, BasicColorFactory.getInstance().RED, this.FALSE);
        this.gameNotificationEventHandler.fireEvent(gameNotificationEvent);
    }

}

