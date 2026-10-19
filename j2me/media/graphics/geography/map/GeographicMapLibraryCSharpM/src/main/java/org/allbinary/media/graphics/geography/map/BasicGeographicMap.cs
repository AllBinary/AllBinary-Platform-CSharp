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
using Layer = org.allbinary.layer.Layer;
using MathUtil = org.allbinary.logic.math.MathUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.media.graphics.geography.map;

public class BasicGeographicMap : SimpleGeographicMap, GeographicMapInterface
{
    public static readonly BasicGeographicMap[] NULL_BASIC_GEOGRAPHIC_MAP_ARRAY = new BasicGeographicMap[0];
    private readonly MathUtil mathUtil = MathUtil.getInstance();
    private readonly BasicGeographicMapCellPositionFactory geographicMapCellPositionFactory;
    private readonly GeographicMapCellPositionFactoryInterface geographicMapCellPositionFactoryInterface;
    private readonly GeographicMapCellTypeFactory geographicMapCellTypeFactory;
    public BasicGeographicMap(int? id, string name, int[] cellTypeIdToGeographicMapCellType, AllBinaryTiledLayer tiledLayer, BasicColor foregroundBasicColor, BasicColor backgroundBasicColor, GeographicMapCellPositionFactoryInterface geographicMapCellPositionFactoryInterface, GeographicMapCellPositionBaseFactory geographicMapCellPositionBaseFactory, GeographicMapCellTypeFactory geographicMapCellTypeFactory) : base(id, name, cellTypeIdToGeographicMapCellType, tiledLayer, foregroundBasicColor, backgroundBasicColor)
    {
        // base(id, name, cellTypeIdToGeographicMapCellType, tiledLayer, foregroundBasicColor, backgroundBasicColor) is called from the constructor declaration
        this.geographicMapCellPositionFactoryInterface = geographicMapCellPositionFactoryInterface;
        this.geographicMapCellPositionFactory = geographicMapCellPositionBaseFactory.getInstance(this);
        this.geographicMapCellTypeFactory = geographicMapCellTypeFactory;
    }

    // throws Exception
    public virtual GeographicMapCellPosition getCellPosition(int direction, GeographicMapCellPosition oldGeographicMapCellPosition)
    {
        switch (direction) {
            case 0:
                return this.geographicMapCellPositionFactory.getAt(oldGeographicMapCellPosition.getColumn() - 1, oldGeographicMapCellPosition.getRow());
            case 1:
                return this.geographicMapCellPositionFactory.getAt(oldGeographicMapCellPosition.getColumn() + 1, oldGeographicMapCellPosition.getRow());
            case 2:
                return this.geographicMapCellPositionFactory.getAt(oldGeographicMapCellPosition.getColumn(), oldGeographicMapCellPosition.getRow() - 1);
            case 3:
                return this.geographicMapCellPositionFactory.getAt(oldGeographicMapCellPosition.getColumn(), oldGeographicMapCellPosition.getRow() + 1);
            default:
                throw new Exception("Only Four Directions");
        }
    }

    // throws Exception
    public virtual GeographicMapCellPosition getCellPositionNoThrow(int direction, GeographicMapCellPosition oldGeographicMapCellPosition)
    {
        switch (direction) {
            case 0:
                if (oldGeographicMapCellPosition.getColumn() - 1 >= 0) {
                    return this.geographicMapCellPositionFactory.getAt(oldGeographicMapCellPosition.getColumn() - 1, oldGeographicMapCellPosition.getRow());
                } else {
                    return SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
                }
            case 1:
                if (oldGeographicMapCellPosition.getColumn() + 1 < this.getAllBinaryTiledLayer().getColumns()) {
                    return this.geographicMapCellPositionFactory.getAt(oldGeographicMapCellPosition.getColumn() + 1, oldGeographicMapCellPosition.getRow());
                } else {
                    return SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
                }
            case 2:
                if (oldGeographicMapCellPosition.getRow() - 1 >= 0) {
                    return this.geographicMapCellPositionFactory.getAt(oldGeographicMapCellPosition.getColumn(), oldGeographicMapCellPosition.getRow() - 1);
                } else {
                    return SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
                }
            case 3:
                if (oldGeographicMapCellPosition.getRow() + 1 < this.getAllBinaryTiledLayer().getRows()) {
                    return this.geographicMapCellPositionFactory.getAt(oldGeographicMapCellPosition.getColumn(), oldGeographicMapCellPosition.getRow() + 1);
                } else {
                    return SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
                }
            default:
                return SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
        }
    }

    // throws Exception
    public virtual bool isOfFourDirections(GeographicMapCellPosition oldGeographicMapCellPosition, GeographicMapCellPosition newGeographicMapCellPosition)
    {
        for (int index = 0; index < 4; index++) {
            if (newGeographicMapCellPosition == this.getCellPositionNoThrow(index, oldGeographicMapCellPosition)) {
                return true;
            }
        }
        return false;
    }

    // throws Exception
    public override GeographicMapCellPosition getCellPositionAtXY(int x, int y)
    {
        AllBinaryTiledLayer allBinaryTiledLayer = this.getAllBinaryTiledLayer();
        int i_column = this.mathUtil.abs(x / allBinaryTiledLayer.getCellHeight());
        int i_row = this.mathUtil.abs(y / allBinaryTiledLayer.getCellWidth());
        return this.geographicMapCellPositionFactory.getAt(i_column, i_row);
    }

    public override GeographicMapCellPosition getCellPositionAtXYNoThrow(int x, int y)
    {
        AllBinaryTiledLayer allBinaryTiledLayer = this.getAllBinaryTiledLayer();
        int i_column = this.mathUtil.abs(x / allBinaryTiledLayer.getCellHeight());
        int i_row = this.mathUtil.abs(y / allBinaryTiledLayer.getCellWidth());
        if (allBinaryTiledLayer.getColumns() > i_column && allBinaryTiledLayer.getRows() > i_row) {
            try {
                return this.geographicMapCellPositionFactory.getAt(i_column, i_row);
            } catch (Exception e) {
                return SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
            }
        } else {
            return SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
        }
    }

    // throws Exception
    public virtual bool isOnMap(GeographicMapCellPosition geographicMapCellPosition)
    {
        AllBinaryTiledLayer allBinaryTiledLayer = this.getAllBinaryTiledLayer();
        int i_column = geographicMapCellPosition.getColumn();
        int i_row = geographicMapCellPosition.getRow();
        if (allBinaryTiledLayer.getColumns() > i_column && allBinaryTiledLayer.getRows() > i_row) {
            return true;
        } else {
            return false;
        }
    }

    // throws Exception
    public virtual BasicArrayList getCellPositionAtNoThrow(int x, int y, int x2, int y2, BasicArrayList geographicMapCellPositionList)
    {
        geographicMapCellPositionList.clear();
        AllBinaryTiledLayer allBinaryTiledLayer = this.getAllBinaryTiledLayer();
        int i_columnMin = this.mathUtil.abs(x / allBinaryTiledLayer.getCellHeight());
        int i_rowMin = this.mathUtil.abs(y / allBinaryTiledLayer.getCellWidth());
        int i_columnMax = this.mathUtil.abs(x2 / allBinaryTiledLayer.getCellHeight()) + 1;
        int i_rowMax = this.mathUtil.abs(y2 / allBinaryTiledLayer.getCellWidth()) + 1;
        for (int columnIndex = i_columnMin; columnIndex < i_columnMax; columnIndex++) {
            for (int rowIndex = i_rowMin; rowIndex < i_rowMax; rowIndex++) {
                if (allBinaryTiledLayer.getColumns() > columnIndex && allBinaryTiledLayer.getRows() > rowIndex) {
                    geographicMapCellPositionList.add(this.geographicMapCellPositionFactory.getAt(columnIndex, rowIndex));
                }
            }
        }
        return geographicMapCellPositionList;
    }

    // throws Exception
    public override bool getCellPositionsAt(Layer layer, GeographicMapCellPosition[][] currentCellPositionArray, GeographicMapCellPosition[][] cellPositionArray)
    {
        bool hasChanged = false;
        int size = cellPositionArray.Length;
        int size2 = cellPositionArray[0].Length;
        int xPortion = layer.getXP() / (size - 1);
        int yPortion = layer.getYP() / (size - 1);
        for (int index = 0; index < size; index++) {
            for (int index2 = 0; index2 < size2; index2++) {
                int x = xPortion * index;
                int y = yPortion * index;
                cellPositionArray[index][index2] = this.getCellPositionAtXY(x, y);
                if (currentCellPositionArray[index][index2] != cellPositionArray[index][index2]) {
                    hasChanged = true;
                }
            }
        }
        return hasChanged;
    }

    // throws Exception
    public override GeographicMapCellType getCellTypeAtXY(int x, int y)
    {
        GeographicMapCellPosition cellPosition = this.getCellPositionAtXY(x, y);
        return this.getCellTypeAt(cellPosition);
    }

    public override BasicGeographicMapCellPositionFactory getGeographicMapCellPositionFactory()
    {
        return this.geographicMapCellPositionFactory;
    }

    public override GeographicMapCellPositionFactoryInterface getGeographicMapCellPositionFactoryInterface()
    {
        return this.geographicMapCellPositionFactoryInterface;
    }

    public virtual GeographicMapCellTypeFactory getGeographicMapCellTypeFactory()
    {
        return this.geographicMapCellTypeFactory;
    }

}

