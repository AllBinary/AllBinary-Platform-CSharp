/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2003 AllBinary 
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
using CommonSeps = org.allbinary.@string.CommonSeps;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.layer;

public class UpgradableWideRTSLayerPaintable : RTSLayerCompositePaintable
{
    private string cost = StringUtil.getInstance().EMPTY_STRING;
    public UpgradableWideRTSLayerPaintable(UpgradableRTSLayerHudPaintable upgradableRTSLayerHudPaintable) : base(upgradableRTSLayerHudPaintable)
    {
        // base(upgradableRTSLayerHudPaintable) is called from the constructor declaration
    }

    public override void update(RTSLayer rtsLayer)
    {
        base.update(rtsLayer);
        this.setCost(new StringMaker().append(this.getUpgradeCost()).append(CommonSeps.getInstance().SPACE).append(this.getDownGradeCost()).ToString());
    }

    public override void paint(Graphics graphics)
    {
        graphics.drawString(this.getCost(), this.upgradableRTSLayerHudPaintable.textX, this.upgradableRTSLayerHudPaintable.costY, 0);
    }

    public virtual void setCost(string cost)
    {
        this.cost = cost;
    }

    public virtual string getCost()
    {
        return this.cost;
    }

}

