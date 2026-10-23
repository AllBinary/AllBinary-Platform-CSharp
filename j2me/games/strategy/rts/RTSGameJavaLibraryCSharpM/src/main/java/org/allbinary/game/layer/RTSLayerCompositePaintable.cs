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
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Paintable = org.allbinary.graphics.paint.Paintable;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.game.layer;

public class RTSLayerCompositePaintable : Paintable
{
    private string upgradeCost = StringUtil.getInstance().EMPTY_STRING;
    private string downGradeCost = StringUtil.getInstance().EMPTY_STRING;
    private readonly string UPGRADE = "Up: $";
    private readonly string DOWNGRADE = "Down: $-";
    public readonly UpgradableRTSLayerHudPaintable upgradableRTSLayerHudPaintable;
    public RTSLayerCompositePaintable(UpgradableRTSLayerHudPaintable upgradableRTSLayerHudPaintable)
    {
        this.upgradableRTSLayerHudPaintable = upgradableRTSLayerHudPaintable;
    }

    public virtual void update(RTSLayer rtsLayer)
    {
        if (rtsLayer.isUpgradeable()) {
            this.setUpgradeCost(new StringMaker().append(this.UPGRADE).appendint(((int) rtsLayer.getUpgradeCost())).ToString());
        } else {
            this.setUpgradeCost(StringUtil.getInstance().EMPTY_STRING);
        }
        if (rtsLayer.isDowngradeable()) {
            this.setDownGradeCost(new StringMaker().append(this.DOWNGRADE).appendint(((int) rtsLayer.getDowngradeCost())).ToString());
        } else {
            this.setDownGradeCost(StringUtil.getInstance().EMPTY_STRING);
        }
    }

    public override void paint(Graphics graphics)
    {
        graphics.drawString(this.getDownGradeCost(), this.upgradableRTSLayerHudPaintable.textX, this.upgradableRTSLayerHudPaintable.costY1, 0);
        graphics.drawString(this.getUpgradeCost(), this.upgradableRTSLayerHudPaintable.textX, this.upgradableRTSLayerHudPaintable.costY, 0);
    }

    public virtual void setUpgradeCost(string upgradeCost)
    {
        this.upgradeCost = upgradeCost;
    }

    public virtual string getUpgradeCost()
    {
        return this.upgradeCost;
    }

    public virtual void setDownGradeCost(string downGradeCost)
    {
        this.downGradeCost = downGradeCost;
    }

    public virtual string getDownGradeCost()
    {
        return this.downGradeCost;
    }

}

