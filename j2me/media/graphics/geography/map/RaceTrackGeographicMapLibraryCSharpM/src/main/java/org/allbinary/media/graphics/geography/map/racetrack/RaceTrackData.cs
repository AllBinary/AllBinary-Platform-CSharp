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
//using Image = javax.microedition.lcdui.Image;
//using NullImage = javax.microedition.lcdui.NullImage;
using CellPosition = org.allbinary.graphics.CellPosition;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class RaceTrackData
{
    private Image tileSetImage = NullImage.NULL_IMAGE;
    private Image miniTileSetImage = NullImage.NULL_IMAGE;
    private int cellWidth = 0;
    private int cellHeight = 0;
    private int miniCellWidth = 0;
    private int miniCellHeight = 0;
    private int[][] mapArray = NullUtil.getInstance().NULL_INT_ARRAY_ARRAY;
    private int[] cellTypeIdToGeographicMapCellTypeArray = NullUtil.getInstance().NULL_INT_ARRAY;
    private CellPosition[] NO_OVER_PASSES_ARRAY = new CellPosition[0];
    private CellPosition[] overPassGeographicMapCellPositionArray;
    private int? id;
    public RaceTrackData(int? id, int cellWidth, int cellHeight, int miniCellWidth, int miniCellHeight, int[] cellTypeIdToGeographicMapCellTypeArray, int[][] mapArray)
    {
        this.overPassGeographicMapCellPositionArray = this.NO_OVER_PASSES_ARRAY;
        this.id = id;
        this.cellWidth = cellWidth;
        this.cellHeight = cellHeight;
        this.miniCellWidth = miniCellWidth;
        this.miniCellHeight = miniCellHeight;
        this.mapArray = mapArray;
        this.cellTypeIdToGeographicMapCellTypeArray = cellTypeIdToGeographicMapCellTypeArray;
    }

    protected virtual void setMapArray(int[][] mapArray)
    {
        this.mapArray = mapArray;
    }

    public virtual int[][] getMapArray()
    {
        return this.mapArray;
    }

    protected virtual void setCellTypeIdToGeographicMapCellTypeArray(int[] cellTypeIdToGeographicMapCellTypeArray)
    {
        this.cellTypeIdToGeographicMapCellTypeArray = cellTypeIdToGeographicMapCellTypeArray;
    }

    public virtual int[] getCellTypeIdToGeographicMapCellTypeArray()
    {
        return this.cellTypeIdToGeographicMapCellTypeArray;
    }

    private void setCellWidth(int cellWidth)
    {
        this.cellWidth = cellWidth;
    }

    public virtual int getCellWidth()
    {
        return this.cellWidth;
    }

    private void setCellHeight(int cellHeight)
    {
        this.cellHeight = cellHeight;
    }

    public virtual int getCellHeight()
    {
        return this.cellHeight;
    }

    public virtual CellPosition[] getOverPassGeographicMapCellPositionArray()
    {
        return this.overPassGeographicMapCellPositionArray;
    }

    public virtual void setOverPassGeographicMapCellPositionArray(CellPosition[] overPassGeographicMapCellPositionArray)
    {
        this.overPassGeographicMapCellPositionArray = overPassGeographicMapCellPositionArray;
    }

    public virtual Image getTileSetImage()
    {
        return this.tileSetImage;
    }

    public virtual void setTileSetImage(Image tileSetImage)
    {
        this.tileSetImage = tileSetImage;
    }

    public virtual Image getMiniTileSetImage()
    {
        return this.miniTileSetImage;
    }

    public virtual void setMiniTileSetImage(Image miniTileSetImage)
    {
        this.miniTileSetImage = miniTileSetImage;
    }

    public virtual int getMiniCellWidth()
    {
        return this.miniCellWidth;
    }

    public virtual void setMiniCellWidth(int miniCellWidth)
    {
        this.miniCellWidth = miniCellWidth;
    }

    public virtual int getMiniCellHeight()
    {
        return this.miniCellHeight;
    }

    public virtual void setMiniCellHeight(int miniCellHeight)
    {
        this.miniCellHeight = miniCellHeight;
    }

    public virtual void setId(int? id)
    {
        this.id = id;
    }

    public virtual int? getId()
    {
        return this.id;
    }

}

