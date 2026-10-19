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
using Layer = org.allbinary.layer.Layer;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.media.graphics.geography.map;

public class BasicGeographicMapUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly BasicGeographicMapUtil instance = new BasicGeographicMapUtil();
    public static BasicGeographicMapUtil getInstance()
    {
        return BasicGeographicMapUtil.instance;
    }

    // throws Exception
    public virtual int getBorderingRow(int direction, GeographicMapCellPosition oldGeographicMapCellPosition)
    {
        int LOCATION_CHANGE = 1;
        switch (direction) {
            case 0:
                return oldGeographicMapCellPosition.getRow();
            case 1:
                return oldGeographicMapCellPosition.getRow();
            case 2:
                return oldGeographicMapCellPosition.getRow() + LOCATION_CHANGE;
            case 3:
                return oldGeographicMapCellPosition.getRow() - LOCATION_CHANGE;
            default:
                throw new Exception("Only Four Directions");
        }
    }

    // throws Exception
    public virtual int getBorderingColumn(int direction, GeographicMapCellPosition oldGeographicMapCellPosition)
    {
        int LOCATION_CHANGE = 1;
        switch (direction) {
            case 0:
                return oldGeographicMapCellPosition.getColumn() - LOCATION_CHANGE;
            case 1:
                return oldGeographicMapCellPosition.getColumn() + LOCATION_CHANGE;
            case 2:
                return oldGeographicMapCellPosition.getColumn();
            case 3:
                return oldGeographicMapCellPosition.getColumn();
            default:
                throw new Exception("Only Four Directions");
        }
    }

    // throws Exception
    public virtual bool isSameCellPosition(GeographicMapCellPosition fromGeographicMapCellPosition, GeographicMapCellPosition toGeographicMapCellPosition)
    {
        int fromColumn = fromGeographicMapCellPosition.getColumn();
        int fromRow = fromGeographicMapCellPosition.getRow();
        int goColumn = toGeographicMapCellPosition.getColumn();
        int goRow = toGeographicMapCellPosition.getRow();
        if (fromColumn == goColumn && fromRow == goRow) {
            return true;
        } else {
            return false;
        }
    }

    public virtual Layer[] createAllBinaryTiledLayerArray(BasicGeographicMap[] geographicMapInterfaceArray)
    {
        Layer[] tiledLayerArray = new Layer[geographicMapInterfaceArray.Length];
        return this.getAllBinaryTiledLayerArray(geographicMapInterfaceArray, tiledLayerArray, 0);
    }

    public virtual Layer[] getAllBinaryTiledLayerArray(BasicGeographicMap[] geographicMapInterfaceArray, Layer[] tiledLayerArray, int startIndex)
    {
        BasicGeographicMap geographicMapInterface = null;
        int size = geographicMapInterfaceArray.Length;
        int count = 0;
        for (int index = size + startIndex; --index >= startIndex; ) {
            geographicMapInterface = geographicMapInterfaceArray[index];
            tiledLayerArray[count++] = geographicMapInterface.getAllBinaryTiledLayer();
        }
        return tiledLayerArray;
    }

    public virtual void move(BasicGeographicMap[] geographicMapInterfaceArray, int dx, int dy)
    {
        BasicGeographicMap geographicMapInterface = null;
        int size = geographicMapInterfaceArray.Length;
        for (int index = size; --index >= 0; ) {
            geographicMapInterface = geographicMapInterfaceArray[index];
            geographicMapInterface.getAllBinaryTiledLayer().moveDXY(dx, dy);
        }
    }

    public virtual void setPosition(BasicGeographicMap[] geographicMapInterfaceArray, int x, int y)
    {
        BasicGeographicMap geographicMapInterface = null;
        int size = geographicMapInterfaceArray.Length;
        for (int index = size; --index >= 0; ) {
            geographicMapInterface = geographicMapInterfaceArray[index];
            geographicMapInterface.getAllBinaryTiledLayer().setPosition(x, y, geographicMapInterface.getAllBinaryTiledLayer().getZP());
        }
    }

}

