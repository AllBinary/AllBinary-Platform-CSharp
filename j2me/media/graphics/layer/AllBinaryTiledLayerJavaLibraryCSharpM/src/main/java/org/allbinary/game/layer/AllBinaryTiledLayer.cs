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
//using Graphics = javax.microedition.lcdui.Graphics;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PaintableInterface = org.allbinary.graphics.paint.PaintableInterface;
using Layer = org.allbinary.layer.Layer;
using NamedInterface = org.allbinary.layer.NamedInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.layer;

public class AllBinaryTiledLayer : Layer, NamedInterface, PaintableInterface
{
    private int cellWidth;
    private int cellHeight;
    private readonly int halfWidth;
    private readonly int halfHeight;
    private readonly int halfCellWidth;
    private readonly int halfCellHeight;
    private readonly int? dataId;
    public AllBinaryTiledLayer(int? dataId, int width, int height, int cellWidth, int cellHeight) : base(0, 0)
    {
        // base(0, 0) is called from the constructor declaration
        this.dataId = dataId;
        this.setLayerWidth(width);
        this.setLayerHeight(height);
        base.setPosition(0, 0, 0);
        this.cellWidth = cellWidth;
        this.cellHeight = cellHeight;
        this.halfWidth = (this.getWidth() >> 1);
        this.halfHeight = (this.getHeight() >> 1);
        this.halfCellWidth = (cellWidth >> 1);
        this.halfCellHeight = (cellHeight >> 1);
    }

    public virtual void setCells(int[][] mapTwoDArray)
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Start: r: ");
        stringBuffer.appendint(mapTwoDArray.Length);
        stringBuffer.append(" c: ");
        stringBuffer.appendint(mapTwoDArray[0].Length);
        stringBuffer.append(" rows: ");
        stringBuffer.appendint(this.getRows());
        stringBuffer.append(" columns: ");
        stringBuffer.appendint(this.getColumns());
        this.logUtil.putF(stringBuffer.ToString(), this, "setCells");
        int rows = this.getRows();
        int columns = this.getColumns();
        for (int col = 0; col < columns; col++) {
            for (int row = 0; row < rows; row++) {
                this.setCell(col, row, mapTwoDArray[row][col]);
            }
        }
    }

    public virtual void updateCells(int[][] mapTwoDArray, int fromTileId, int toTileId)
    {
        int rows = this.getRows();
        int columns = this.getColumns();
        for (int col = 0; col < columns; col++) {
            for (int row = 0; row < rows; row++) {
                if (fromTileId == mapTwoDArray[row][col]) {
                    mapTwoDArray[row][col] = toTileId;
                    this.setCell(col, row, mapTwoDArray[row][col]);
                }
            }
        }
    }

    public override string getName()
    {
        return this.GetType().FullName;
    }

    public override void paint(Graphics graphics)
    {
    }

    public override void paintThreed(Graphics graphics)
    {
    }

    public virtual int getX2()
    {
        return this.x + this.getWidth();
    }

    public virtual int getY2()
    {
        return this.y + this.getHeight();
    }

    public virtual int getZ2()
    {
        return ((int) (this.z + this.getDepth()));
    }

    public virtual int getCellWidth()
    {
        return this.cellWidth;
    }

    public virtual int getCellHeight()
    {
        return this.cellHeight;
    }

    public virtual int getCell(int col, int row)
    {
        return -1;
    }

    public virtual int getColumns()
    {
        return -1;
    }

    public virtual int getRows()
    {
        return -1;
    }

    public virtual void setCell(int col, int row, int tileIndex)
    {
    }

    public virtual int getHalfWidth()
    {
        return this.halfWidth;
    }

    public virtual int getHalfHeight()
    {
        return this.halfHeight;
    }

    public virtual int? getDataId()
    {
        return this.dataId;
    }

    public virtual int getHalfCellWidth()
    {
        return this.halfCellWidth;
    }

    public virtual int getHalfCellHeight()
    {
        return this.halfCellHeight;
    }

    public virtual bool isOnTileLayer(int column, int row)
    {
        if (this.getColumns() > column && this.getRows() > row && row >= 0 && column >= 0) {
            return true;
        } else {
            return false;
        }
    }

    public virtual int getAnimatedTile(int animationTileIndex)
    {
        return animationTileIndex;
    }

}

