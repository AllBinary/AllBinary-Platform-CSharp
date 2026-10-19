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
using CellPositionFactory = org.allbinary.graphics.CellPositionFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;

namespace org.allbinary.media.graphics.geography.map.@event;

public class GeographicMapCellPositionEvent : AllBinaryEventObject
{
    private CellPosition geographicMapCellPosition = CellPositionFactory.getInstance().NONE;
    public GeographicMapCellPositionEvent(object anyType, CellPosition geographicMapCellPosition) : base(anyType)
    {
        // base(anyType) is called from the constructor declaration
        this.geographicMapCellPosition = geographicMapCellPosition;
    }

    public virtual void init(object anyType)
    {
        this.setSource(anyType);
    }

    public virtual void setGeographicMapCellPosition(GeographicMapCellPosition geographicMapCellPosition)
    {
        this.geographicMapCellPosition = geographicMapCellPosition;
    }

    public virtual GeographicMapCellPosition getGeographicMapCellPosition()
    {
        return ((GeographicMapCellPosition) this.geographicMapCellPosition);
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("CellPositionEvent: ");
        stringBuffer.append("\nGeographicMapCellPosition: ");
        stringBuffer.append(StringUtil.getInstance().toString(this.getGeographicMapCellPosition()));
        return stringBuffer.ToString();
    }

}

