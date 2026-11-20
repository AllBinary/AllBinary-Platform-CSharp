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

namespace org.allbinary.game.ag.layer.hud.basic.notification;

public class NoGameGameNotificationHud : GameNotificationHud
{
    public NoGameGameNotificationHud() : base(BasicHudFactory.getInstance().TOPCENTER, BasicHudFactory.getInstance().HORIZONTAL, 2, BasicColorFactory.getInstance().RED)
    {
        // base(BasicHudFactory.getInstance().TOPCENTER, BasicHudFactory.getInstance().HORIZONTAL, 2, BasicColorFactory.getInstance().RED) is called from the constructor declaration
        this.updateMaxWidth = 40;
        this.updateMaxHeight = 14;
    }

}

