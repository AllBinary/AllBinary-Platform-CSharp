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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using CellPositionsUtil = org.allbinary.media.graphics.geography.map.CellPositionsUtil;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;

namespace org.allbinary.game.layer.geographic.map;

public class LayerCoveringCellPositionsUtil
{
    private static readonly LayerCoveringCellPositionsUtil instance = new LayerCoveringCellPositionsUtil();
    public static LayerCoveringCellPositionsUtil getInstance()
    {
        return LayerCoveringCellPositionsUtil.instance;
    }

    private readonly CellPositionsUtil cellPositionsUtil = CellPositionsUtil.getInstance();
    // throws Exception
    public BasicArrayList getAllXY(BasicGeographicMap geographicMapInterface, AllBinaryLayer layerInterface, int x, int y, BasicArrayList reusableList)
    {
        GeographicMapCellPosition topLeftGeographicMapCellPosition = geographicMapInterface.getCellPositionAtXY(x, y);
        return this.getAll(geographicMapInterface, topLeftGeographicMapCellPosition, layerInterface, reusableList);
    }

    // throws Exception
    public BasicArrayList getAll(BasicGeographicMap geographicMapInterface, GeographicMapCellPosition topLeftGeographicMapCellPosition, AllBinaryLayer layerInterface, BasicArrayList reusableList)
    {
        reusableList.clear();
        int columns = layerInterface.getWidth() / geographicMapInterface.getAllBinaryTiledLayer().getCellWidth();
        int rows = layerInterface.getHeight() / geographicMapInterface.getAllBinaryTiledLayer().getCellHeight();
        if (columns == 0) {
            columns = 1;
        }
        if (rows == 0) {
            rows = 1;
        }
        return this.cellPositionsUtil.getAll(geographicMapInterface, topLeftGeographicMapCellPosition, columns, rows, reusableList);
    }

}

