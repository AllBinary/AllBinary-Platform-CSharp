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
using BasicHudFactory = org.allbinary.game.graphics.hud.BasicHudFactory;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.ag.layer.hud.basic.notification;

public class NoGameNotificationHudSingleton
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly NoGameNotificationHudSingleton instance = new NoGameNotificationHudSingleton();
    public static NoGameNotificationHudSingleton getInstance()
    {
        return NoGameNotificationHudSingleton.instance;
    }

    private GameNotificationHud gameNotificationHud = GameNotificationHud.NULL_GAME_NOTIFICATION;
    private NoGameNotificationHudSingleton()
    {
        try {
            BasicHudFactory basicHudFactory = BasicHudFactory.getInstance();
            class NoGameGameNotificationHud : GameNotificationHud
            {
                public NoGameGameNotificationHud() : base(basicHudFactory.TOPCENTER, basicHudFactory.HORIZONTAL, 2, BasicColorFactory.getInstance().RED)
                {
                    // base(basicHudFactory.TOPCENTER, basicHudFactory.HORIZONTAL, 2, BasicColorFactory.getInstance().RED) is called from the constructor declaration
                    this.updateMaxWidth = 40;
                    this.updateMaxHeight = 14;
                }

            }
            this.gameNotificationHud = new NoGameGameNotificationHud();
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.CONSTRUCTOR, e);
        }
    }

    public virtual GameNotificationHud getGameNotificationHud()
    {
        return this.gameNotificationHud;
    }

}

