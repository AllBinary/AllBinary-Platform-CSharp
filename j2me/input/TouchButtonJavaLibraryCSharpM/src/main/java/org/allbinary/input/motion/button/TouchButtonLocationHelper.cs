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
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.allbinary.input.motion.button;

public class TouchButtonLocationHelper
{
    private readonly int totalColumns;
    private readonly int totalRows;
    private int columnsRemainder;
    private int rowsRemainder;
    private int columnsRemainderHalf;
    private int rowsRemainderHalf;
    public TouchButtonLocationHelper()
    {
        int buttonSize = CommonButtons.getInstance().STANDARD_BUTTON_SIZE;
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        this.totalColumns = Math.Round(((float) displayInfo.getLastWidth()) / ((float) buttonSize));
        this.totalRows = Math.Round(((float) displayInfo.getLastHeight()) / ((float) buttonSize));
        this.columnsRemainder = displayInfo.getLastWidth() % buttonSize;
        this.columnsRemainderHalf = (this.columnsRemainder >> 1);
        this.rowsRemainder = displayInfo.getLastHeight() % buttonSize;
        this.rowsRemainderHalf = (this.rowsRemainder >> 1);
    }

    public virtual int getTotalColumns()
    {
        return this.totalColumns;
    }

    public virtual int getTotalRows()
    {
        return this.totalRows;
    }

    public virtual int getColumnsRemainder()
    {
        return this.columnsRemainder;
    }

    public virtual int getRowsRemainder()
    {
        return this.rowsRemainder;
    }

    public virtual int getColumnsRemainderHalf()
    {
        return this.columnsRemainderHalf;
    }

    public virtual int getRowsRemainderHalf()
    {
        return this.rowsRemainderHalf;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("totalColumns: ");
        stringBuffer.appendint(this.totalColumns);
        stringBuffer.append(" totalRows: ");
        stringBuffer.appendint(this.totalRows);
        stringBuffer.append(" columnsRemainder: ");
        stringBuffer.appendint(this.columnsRemainder);
        stringBuffer.append(" rowsRemainder: ");
        stringBuffer.appendint(this.rowsRemainder);
        stringBuffer.append(" columnsRemainderHalf: ");
        stringBuffer.appendint(this.columnsRemainderHalf);
        stringBuffer.append(" rowsRemainderHalf: ");
        stringBuffer.appendint(this.rowsRemainderHalf);
        return stringBuffer.ToString();
    }

}

