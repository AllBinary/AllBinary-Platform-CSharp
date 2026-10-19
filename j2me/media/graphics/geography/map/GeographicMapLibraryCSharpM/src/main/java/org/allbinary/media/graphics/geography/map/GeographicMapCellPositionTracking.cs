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
using AllBinaryGameCanvasInterface = org.allbinary.game.displayable.canvas.AllBinaryGameCanvasInterface;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;

namespace org.allbinary.media.graphics.geography.map;

public class GeographicMapCellPositionTracking
{
    private GeographicMapCellPosition currentGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    private GeographicMapCellPosition previousGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    private GeographicMapCellPosition newGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    private GeographicMapCellType currentCellType = GeographicMapCellType.NULL_GEOGRAPHIC_MAP_CELL_TYPE;
    public GeographicMapCellPositionTracking()
    {
    }

    // throws Exception
    public virtual GeographicMapCellType getCurrentOverCellType(BasicGeographicMap geographicMap)
    {
        GeographicMapCellPosition geographicMapCellPosition = this.currentGeographicMapCellPosition;
        if (geographicMapCellPosition != this.previousGeographicMapCellPosition) {
            this.currentCellType = geographicMap.getCellTypeAt(geographicMapCellPosition);
        }
        return this.currentCellType;
    }

    // throws Exception
    public virtual bool updateStart(AllBinaryGameCanvasInterface gameCanvasInterface, AllBinaryLayer layer)
    {
        if (gameCanvasInterface != SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
            GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) gameCanvasInterface.getLayerManager());
            BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
            this.newGeographicMapCellPosition = geographicMapInterface.getCellPositionAtXY(layer.getXP() + layer.getHalfWidth(), layer.getYP() + layer.getHalfHeight());
            if (this.newGeographicMapCellPosition != this.currentGeographicMapCellPosition) {
                this.currentGeographicMapCellPosition = this.newGeographicMapCellPosition;
                return true;
            }
        }
        return false;
    }

    public virtual bool updateEnd()
    {
        if (this.currentGeographicMapCellPosition != this.previousGeographicMapCellPosition) {
            this.previousGeographicMapCellPosition = this.currentGeographicMapCellPosition;
            return true;
        }
        return false;
    }

    public virtual GeographicMapCellPosition getPreviousGeographicMapCellPosition()
    {
        return this.previousGeographicMapCellPosition;
    }

    public virtual GeographicMapCellPosition getCurrentGeographicMapCellPosition()
    {
        return this.currentGeographicMapCellPosition;
    }

}

