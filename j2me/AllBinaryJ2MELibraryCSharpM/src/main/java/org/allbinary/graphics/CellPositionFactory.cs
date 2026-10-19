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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.graphics;

public class CellPositionFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static CellPositionFactory SINGLETON = new CellPositionFactory();
    public readonly CellPosition NONE = new CellPosition(-1, -1, -1, -1);
    private CellPosition[][] cellPositionArray = System.Linq.Enumerable.Range(0, 0).Select(_ => new CellPosition[0]).ToArray();
    private int columns = 0;
    private int rows = 0;
    public static CellPositionFactory getInstance()
    {
        return CellPositionFactory.SINGLETON;
    }

    private CellPositionFactory()
    {
    }

    public virtual void init(int columns, int rows)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("Init: columns: ");
        stringBuffer.appendint(columns);
        stringBuffer.append(" rows: ");
        stringBuffer.appendint(rows);
        this.logUtil.putF(stringBuffer.ToString(), this, commonStrings.INIT);
        this.cellPositionArray = System.Linq.Enumerable.Range(0, columns).Select(_ => new CellPosition[rows]).ToArray();
        this.columns = columns;
        this.rows = rows;
        for (int column = 0; column < columns; column++) {
            for (int row = 0; row < rows; row++) {
                this.createInstance(column, row);
            }
        }
    }

    public virtual CellPosition getInstanceColRow(int i_column, int i_row)
    {
        try {
            return this.cellPositionArray[i_column][i_row];
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(new StringMaker().append("columns: ").appendint(this.getColumns()).append(" rows: ").appendint(this.getRows()).append(" col: ").appendint(i_column).append(" row: ").appendint(i_row).ToString(), this, commonStrings.GET_INSTANCE, e);
            return this.NONE;
        }
    }

    public virtual CellPosition createInstance(int i_column, int i_row)
    {
        CellPosition cellPositionCanBeNull = this.cellPositionArray[i_column][i_row];
        if (cellPositionCanBeNull == null) {
            cellPositionCanBeNull = new CellPosition(i_column, i_row, this.columns, this.rows);
            this.cellPositionArray[i_column][i_row] = cellPositionCanBeNull;
        }
        return cellPositionCanBeNull;
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

