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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.media.graphics.geography.map;

public class BasicGeographicMapCellPositionFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly GeographicMapCellPosition[][] geographicMapCellPositionArray;
    public readonly BasicGeographicMap geographicMapInterface;
    public readonly GeographicMapCellPositionFactoryInterface geographicMapCellPositionFactoryInterface;
    private readonly int columns;
    private readonly int rows;
    private readonly AllBinaryTiledLayer tiledLayer;
    public BasicGeographicMapCellPositionFactory(BasicGeographicMap geographicMapInterface)
    {
        this.geographicMapInterface = geographicMapInterface;
        this.geographicMapCellPositionFactoryInterface = this.geographicMapInterface.getGeographicMapCellPositionFactoryInterface();
        this.tiledLayer = this.geographicMapInterface.getAllBinaryTiledLayer();
        this.columns = this.tiledLayer.getColumns();
        this.rows = this.tiledLayer.getRows();
        this.geographicMapCellPositionArray = System.Linq.Enumerable.Range(0, this.rows).Select(_ => new GeographicMapCellPosition[this.columns]).ToArray();
        this.init();
    }

    // throws Exception
    private void init()
    {
        AllBinaryTiledLayer tiledLayer = this.tiledLayer;
        int columns = this.getColumns();
        int rows = this.getRows();
        int width = tiledLayer.getCellWidth();
        int height = tiledLayer.getCellHeight();
        for (int column = 0; column < columns; column++) {
            for (int row = 0; row < rows; row++) {
                this.createInstance(column, row, width, height);
            }
        }
    }

    // throws Exception
    public virtual void visit(GeographicMapCellPositionFactoryInitVisitorInterface geographicMapCelPositionFactoryInitVisitorInterface)
    {
        AllBinaryTiledLayer tiledLayer = this.tiledLayer;
        int columns = this.getColumns();
        int rows = this.getRows();
        try {
            GeographicMapCellPosition cellPosition = null;
            for (int column = 0; column < columns; column++) {
                for (int row = 0; row < rows; row++) {
                    cellPosition = this.getAt(column, row);
                    geographicMapCelPositionFactoryInitVisitorInterface.visit(tiledLayer, cellPosition);
                }
            }
        } catch (Exception e) {
            CommonSeps commonSeps = CommonSeps.getInstance();
            this.logUtil.put(new StringMaker().append(commonSeps.BRACKET_OPEN).appendint(rows).append(commonSeps.BRACKET_CLOSE).append(commonSeps.BRACKET_OPEN).appendint(columns).append(commonSeps.BRACKET_CLOSE).ToString(), this, "visit", e);
            throw e;
        }
    }

    // throws Exception
    public virtual GeographicMapCellPosition getAt(int i_column, int i_row)
    {
        return this.geographicMapCellPositionArray[i_row][i_column];
    }

    // throws Exception
    public virtual GeographicMapCellPosition getInstance(GeographicMapCellPosition anotherMapGeographicMapCellPosition)
    {
        return this.getAt(anotherMapGeographicMapCellPosition.getColumn(), anotherMapGeographicMapCellPosition.getRow());
    }

    // throws Exception
    public virtual GeographicMapCellPosition createInstance(int i_column, int i_row, int width, int height)
    {
        object cellPositionCanBeNull = this.geographicMapCellPositionArray[i_row][i_column];
        if (cellPositionCanBeNull == null) {
            cellPositionCanBeNull = this.geographicMapCellPositionFactoryInterface.getInstance(this.geographicMapInterface, i_column, i_row, this.columns, this.rows, width, height);
            this.geographicMapCellPositionArray[i_row][i_column] = ((GeographicMapCellPosition) cellPositionCanBeNull);
        }
        return ((GeographicMapCellPosition) cellPositionCanBeNull);
    }

    public virtual int getColumns()
    {
        return this.columns;
    }

    public virtual int getRows()
    {
        return this.rows;
    }

}

