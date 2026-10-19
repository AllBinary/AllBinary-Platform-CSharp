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
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using BasicArrayListS = org.allbinary.util.BasicArrayListS;

namespace org.allbinary.media.graphics.geography.map;

public class CellPositionsUtil
{
    private static readonly CellPositionsUtil instance = new CellPositionsUtil();
    public static CellPositionsUtil getInstance()
    {
        return CellPositionsUtil.instance;
    }

    // throws Exception
    public BasicArrayList getAll(BasicGeographicMap geographicMapInterface, GeographicMapCellPosition topRightGeographicMapCellPosition, int columns, int rows, BasicArrayList reusableList)
    {
        reusableList.clear();
        BasicGeographicMapCellPositionFactory geographicMapCellPositionFactory = geographicMapInterface.getGeographicMapCellPositionFactory();
        int lastColumn = topRightGeographicMapCellPosition.getColumn() + columns;
        int lastRow = topRightGeographicMapCellPosition.getRow() + rows;
        if ((columns > 1 && lastColumn > geographicMapInterface.getAllBinaryTiledLayer().getColumns()) || (rows > 1 && lastRow > geographicMapInterface.getAllBinaryTiledLayer().getRows())) {
            return reusableList;
        }
        for (int rowIndex = 0; rowIndex < rows; rowIndex++) {
            for (int columnIndex = 0; columnIndex < columns; columnIndex++) {
                GeographicMapCellPosition geographicMapCellPosition = geographicMapCellPositionFactory.getAt(topRightGeographicMapCellPosition.getColumn() + columnIndex, topRightGeographicMapCellPosition.getRow() + rowIndex);
                reusableList.add(geographicMapCellPosition);
            }
        }
        return reusableList;
    }

    private readonly BasicArrayList reusableSingleThreadedSurroundingList = new BasicArrayListS(8);
    // throws Exception
    public BasicArrayList getAllSurrounding(BasicGeographicMap geographicMapInterface, BasicArrayList occupyList, BasicArrayList reusableList)
    {
        reusableList.clear();
        for (int index = occupyList.size() - 1; index >= 0; index--) {
            GeographicMapCellPosition layerGeographicMapCellPosition = ((GeographicMapCellPosition) occupyList.get(index));
            BasicArrayList surroundingGeographicMapCellPositionList = this.getAllSurroundingAt(geographicMapInterface, layerGeographicMapCellPosition, this.reusableSingleThreadedSurroundingList);
            for (int index2 = surroundingGeographicMapCellPositionList.size() - 1; index2 >= 0; index2--) {
                GeographicMapCellPosition geographicMapCellPosition = ((GeographicMapCellPosition) surroundingGeographicMapCellPositionList.get(index2));
                if (!reusableList.contains(geographicMapCellPosition) && !occupyList.contains(geographicMapCellPosition)) {
                    reusableList.add(geographicMapCellPosition);
                }
            }
        }
        return reusableList;
    }

    private readonly int[][] surroundArray = new int[][] { new int[] { -1, -1 }, new int[] { 0, -1 }, new int[] { 1, -1 }, new int[] { -1, 1 }, new int[] { 0, 1 }, new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
    // throws Exception
    public BasicArrayList getAllSurroundingAt(BasicGeographicMap geographicMapInterface, GeographicMapCellPosition layerGeographicMapCellPosition, BasicArrayList reusableSurroundingList)
    {
        reusableSurroundingList.clear();
        BasicGeographicMapCellPositionFactory geographicMapCellPositionFactory = geographicMapInterface.getGeographicMapCellPositionFactory();
        AllBinaryTiledLayer tiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
        int row = 0;
        int column = 0;
        for (int index = 0; index < 8; index++) {
            column = layerGeographicMapCellPosition.getColumn() + this.surroundArray[index][0];
            row = layerGeographicMapCellPosition.getRow() + this.surroundArray[index][1];
            if (tiledLayer.isOnTileLayer(column, row)) {
                GeographicMapCellPosition geographicMapCellPosition = geographicMapCellPositionFactory.getAt(column, row);
                reusableSurroundingList.add(geographicMapCellPosition);
            }
        }
        return reusableSurroundingList;
    }

}

