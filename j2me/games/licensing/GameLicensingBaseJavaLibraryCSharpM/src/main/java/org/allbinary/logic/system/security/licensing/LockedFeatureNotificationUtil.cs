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
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using ErrorSound = org.allbinary.media.audio.ErrorSound;
using PrimaryPlayerQueueFactory = org.allbinary.media.audio.PrimaryPlayerQueueFactory;

namespace org.allbinary.logic.system.security.licensing;

public class LockedFeatureNotificationUtil
{
    private static readonly LockedFeatureNotificationUtil instance = new LockedFeatureNotificationUtil();
    public static LockedFeatureNotificationUtil getInstance()
    {
        return LockedFeatureNotificationUtil.instance;
    }

    private readonly GameNotificationEvent gameNotificationEvent;
    // throws Exception
    public virtual void fire()
    {
        PrimaryPlayerQueueFactory.getInstance().add(ErrorSound.getInstance());
        GameNotificationEventHandler.getInstance().fireEvent(this.gameNotificationEvent);
    }

    // throws Exception
    public virtual void fireWithColor(BasicColor basicColor)
    {
        PrimaryPlayerQueueFactory.getInstance().add(ErrorSound.getInstance());
        this.gameNotificationEvent.setBasicColorP(basicColor);
        GameNotificationEventHandler.getInstance().fireEvent(this.gameNotificationEvent);
    }

    public LockedFeatureNotificationUtil()
    {
        this.gameNotificationEvent = new GameNotificationEvent(this, LicenseStrings.getInstance().LOCKED, SmallIntegerSingletonFactory.getInstance().getAt(3), BasicColorFactory.getInstance().RED, BooleanFactory.getInstance().FALSE);
    }

}

