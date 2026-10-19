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
using RTSLayer = org.allbinary.game.layer.RTSLayer;
using WaypointInfoHudPaintable = org.allbinary.game.layer.waypoint.WaypointInfoHudPaintable;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using KeyValueDrawCharArray = org.allbinary.graphics.draw.KeyValueDrawCharArray;

namespace org.allbinary.game.layer.geological.resources;

public class GeologicalResourceInfoHudPaintable : WaypointInfoHudPaintable
{
    private static readonly string RESOURCES = "Resources: ";
    private readonly KeyValueDrawCharArray keyvalueDrawString;
    private int fontHeight = 0;
    public GeologicalResourceInfoHudPaintable()
    {
        this.keyvalueDrawString = new KeyValueDrawCharArray(GeologicalResourceInfoHudPaintable.RESOURCES, this.textX);
    }

    public override void updateMeasurement(Graphics graphics)
    {
        base.updateMeasurement(graphics);
        Font font = graphics.getFont();
        this.fontHeight = (2 * font.getHeight());
    }

    public override void updateSelectionInfo()
    {
        base.updateSelectionInfo();
        RTSLayer rtsLayer = ((RTSLayer) this.rtsLayerP);
        BasicArrayList list = rtsLayer.geographicMapCellPositionAreaBase.getOccupyingGeographicMapCellPositionList();
        int total = 0;
        for (int index = list.size(); --index >= 0; ) {
            GeologicalGeographicMapCellPosition geographicMapCellPosition = ((GeologicalGeographicMapCellPosition) list.get(index));
            total += geographicMapCellPosition.getGeologicalResource().getTotal();
        }
        this.keyvalueDrawString.update(this.getPrimitiveLongUtil().getCharArray(total), this.getPrimitiveLongUtil().getCurrentTotalDigits());
    }

    public override void paint(Graphics graphics)
    {
        base.paint(graphics);
        this.keyvalueDrawString.paint(graphics, (this.y + this.fontHeight));
    }

}

