/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2006 AllBinary 
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
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
using NullPathFindingLayer = org.allbinary.game.layer.NullPathFindingLayer;
using PathFindingLayerInterface = org.allbinary.game.layer.PathFindingLayerInterface;
using RTSLayer = org.allbinary.game.layer.RTSLayer;
using SelectionHudPaintable = org.allbinary.game.layer.SelectionHudPaintable;
using KeyValueDrawString = org.allbinary.graphics.draw.KeyValueDrawString;

namespace org.allbinary.game.layer.waypoint;

public class WaypointInfoHudPaintable : SelectionHudPaintable
{
    private readonly KeyValueDrawString keyvalueDrawString;
    public PathFindingLayerInterface rtsLayerP = NullPathFindingLayer.NULL_PATH_FINDING_LAYER;
    private int textLine2Y = 0;
    public WaypointInfoHudPaintable()
    {
        this.keyvalueDrawString = new KeyValueDrawString("Owner: ", this.textX);
    }

    public override void updateMeasurement(Graphics graphics)
    {
        base.updateMeasurement(graphics);
        Font font = graphics.getFont();
        this.textLine2Y = (this.y + font.getHeight());
    }

    public override void updateSelectionInfo()
    {
        RTSLayer rtsLayer = ((RTSLayer) this.rtsLayerP);
        this.setName(rtsLayer.getName());
        this.setAnimationInterface(rtsLayer.getVerticleBuildAnimationInterface());
        this.keyvalueDrawString.update(rtsLayer.getParentLayer().getName());
    }

    public virtual void setRtsLayer(RTSLayer rtsLayer)
    {
        this.rtsLayerP = rtsLayer;
    }

    public virtual PathFindingLayerInterface getRtsLayer()
    {
        return this.rtsLayerP;
    }

    public override void paint(Graphics graphics)
    {
        base.paint(graphics);
        this.keyvalueDrawString.paint(graphics, this.textLine2Y);
        this.getAnimationInterface().paintXY(graphics, this.imageX, this.y);
    }

}

