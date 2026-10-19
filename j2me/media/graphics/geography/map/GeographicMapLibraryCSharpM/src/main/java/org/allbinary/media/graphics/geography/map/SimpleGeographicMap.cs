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
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.graphics.geography.map;

public class SimpleGeographicMap
{
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly int? id;
    private readonly string name;
    public readonly int[] cellTypeIdToGeographicMapCellType;
    private readonly AllBinaryTiledLayer tiledLayer;
    private BasicColor foregroundBasicColor = BasicColorFactory.getInstance().NULL_COLOR;
    private BasicColor backgroundBasicColor = BasicColorFactory.getInstance().NULL_COLOR;
    public SimpleGeographicMap(int? id, string name, int[] cellTypeIdToGeographicMapCellType, AllBinaryTiledLayer tiledLayer, BasicColor foregroundBasicColor, BasicColor backgroundBasicColor)
    {
        this.id = id;
        this.name = name;
        this.cellTypeIdToGeographicMapCellType = cellTypeIdToGeographicMapCellType;
        this.tiledLayer = tiledLayer;
        this.setBackgroundBasicColor(backgroundBasicColor);
        this.setForegroundBasicColor(foregroundBasicColor);
    }

    public virtual int? getId()
    {
        return this.id;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual void reset()
    {
    }

    public virtual AllBinaryTiledLayer getAllBinaryTiledLayer()
    {
        return this.tiledLayer;
    }

    private readonly GeographicMapCellTypeFactory geographicMapCellTypeFactory = GeographicMapCellTypeFactory.getInstance();
    // throws Exception
    public virtual GeographicMapCellType getCellTypeAt(GeographicMapCellPosition cellPosition)
    {
        int i_column = cellPosition.getColumn();
        int i_row = cellPosition.getRow();
        int cellTypeId = this.tiledLayer.getCell(i_column, i_row);
        if (cellTypeId < 0) {
            cellTypeId = this.tiledLayer.getAnimatedTile(cellTypeId);
        }
        return this.geographicMapCellTypeFactory.get(this.cellTypeIdToGeographicMapCellType[cellTypeId]);
    }

    public virtual int getCellTypeFromMapCellTypeInt(int cellTypeId)
    {
        return this.cellTypeIdToGeographicMapCellType[cellTypeId];
    }

    public virtual BasicColor getForegroundBasicColor()
    {
        return this.foregroundBasicColor;
    }

    private void setForegroundBasicColor(BasicColor foregroundBasicColor)
    {
        this.foregroundBasicColor = foregroundBasicColor;
    }

    public virtual BasicColor getBackgroundBasicColor()
    {
        return this.backgroundBasicColor;
    }

    private void setBackgroundBasicColor(BasicColor backgroundBasicColor)
    {
        this.backgroundBasicColor = backgroundBasicColor;
    }

}

