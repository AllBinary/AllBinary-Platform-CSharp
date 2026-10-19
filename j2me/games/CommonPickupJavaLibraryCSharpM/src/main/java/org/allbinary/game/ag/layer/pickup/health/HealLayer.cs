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
using HealthInterface = org.allbinary.game.health.HealthInterface;
using HealthVisitorInterface = org.allbinary.game.health.HealthVisitorInterface;
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using ViewPosition = org.allbinary.view.ViewPosition;

namespace org.allbinary.game.ag.layer.pickup.health;

public class HealLayer : AllBinaryLayer, HealthVisitorInterface
{
    public HealLayer() : base(StringUtil.getInstance().EMPTY_STRING, new Rectangle(PointFactory.getInstance().ZERO_ZERO, 0, 0), ViewPosition.getInstanceD())
    {
        // base(StringUtil.getInstance().EMPTY_STRING, new Rectangle(PointFactory.getInstance().ZERO_ZERO, 0, 0), ViewPosition.getInstanceD()) is called from the constructor declaration
    }

    public override void paint(Graphics graphics)
    {
    }

    public override void visit(HealthInterface healthInterface)
    {
        if (healthInterface.isAlive()) {
            healthInterface.healMax();
        } else {
            this.logUtil.putF("Heal attempt on dead: Does not currently occur", this, "visit");
        }
    }

}

