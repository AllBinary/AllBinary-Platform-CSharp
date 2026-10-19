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
using CellPosition = org.allbinary.graphics.CellPosition;
using GPoint = org.allbinary.graphics.GPoint;
using PointFactory = org.allbinary.graphics.PointFactory;

namespace org.allbinary.media.graphics.geography.map;

public class GeographicMapCellPosition : CellPosition
{
    private GPoint point;
    private GPoint midPoint;
    public GeographicMapCellPosition(int column, int row, int columns, int rows, int width, int height) : base(column, row, columns, rows)
    {
        // base(column, row, columns, rows) is called from the constructor declaration
        int x = this.getColumn() * width;
        int y = this.getRow() * height;
        PointFactory pointFactory = PointFactory.getInstance();
        this.point = pointFactory.createXY(x, y);
        this.midPoint = pointFactory.createXY(x + (width >> 1), y + (height >> 1));
    }

    public virtual GPoint getPoint()
    {
        return this.point;
    }

    public virtual GPoint getMidPoint()
    {
        return this.midPoint;
    }

    public virtual void setMidPoint(GPoint midPoint)
    {
        this.midPoint = midPoint;
    }

}

