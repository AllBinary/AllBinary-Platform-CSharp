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
using GPoint = org.allbinary.graphics.GPoint;
using PointFactory = org.allbinary.graphics.PointFactory;

namespace org.allbinary.game.graphics.hud;

public class HudGraphicsPosition
{
    public static readonly HudGraphicsPosition NULL_HUD_GRAPHICS_POSITION = new HudGraphicsPosition(PointFactory.getInstance().ZERO_ZERO, 9);
    private int anchor = 0;
    private GPoint point = PointFactory.getInstance().ZERO_ZERO;
    public HudGraphicsPosition(GPoint point, int anchor)
    {
        this.setAnchor(anchor);
        this.setPoint(point);
    }

    public virtual int getAnchor()
    {
        return this.anchor;
    }

    private void setAnchor(int anchor)
    {
        this.anchor = anchor;
    }

    public virtual GPoint getPoint()
    {
        return this.point;
    }

    public virtual void setPoint(GPoint point)
    {
        this.point = point;
    }

}

