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
using V = org.allbinary.graph.V;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.graphics;

public class CellPosition : V
{
    private readonly int id;
    private readonly int column;
    private readonly int row;
    public CellPosition(int column, int row, int columns, int rows)
    {
        this.column = column;
        this.row = row;
        this.id = (row * columns) + column;
    }

    public virtual int getColumn()
    {
        return this.column;
    }

    public virtual int getRow()
    {
        return this.row;
    }

    public override string ToString()
    {
        return CellPosition.toStringColRow(this.getColumn(), this.getRow());
    }

    public static string toStringCellPosition(CellPosition basicGeographicMapCellPosition)
    {
        return CellPosition.toStringColRow(basicGeographicMapCellPosition.getColumn(), basicGeographicMapCellPosition.getRow());
    }

    public static string toStringColRow(int i_column, int i_row)
    {
        StringMaker stringBuffer = new StringMaker();
        CommonSeps commonSeps = CommonSeps.getInstance();
        stringBuffer.append(commonSeps.PARENTHESIS_OPEN);
        stringBuffer.appendint(i_column);
        stringBuffer.append(commonSeps.COMMA);
        stringBuffer.appendint(i_row);
        stringBuffer.append(commonSeps.PARENTHESIS_CLOSE);
        return stringBuffer.ToString();
    }

    public override int getId()
    {
        return this.id;
    }

}

