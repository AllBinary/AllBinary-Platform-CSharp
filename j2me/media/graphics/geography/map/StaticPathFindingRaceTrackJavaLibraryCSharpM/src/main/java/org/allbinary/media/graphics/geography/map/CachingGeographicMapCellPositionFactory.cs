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
using org.allbinary.util;

namespace org.allbinary.media.graphics.geography.map;

public class CachingGeographicMapCellPositionFactory : BasicGeographicMapCellPositionFactory
{
    public CachingGeographicMapCellPositionFactory(BasicGeographicMap geographicMapInterface) : base(geographicMapInterface)
    {
        // base(geographicMapInterface) is called from the constructor declaration
    }

    // throws Exception
    public override GeographicMapCellPosition createInstance(int i_column, int i_row, int width, int height)
    {
        ABHashtable<object, object> hashtable = GeographicMapCellPositionFactory.getHashtable();
        string cellPositionKey = CellPosition.toStringColRow(i_column, i_row);
        object cellPositionCanBeNull = hashtable.get(cellPositionKey);
        if (cellPositionCanBeNull == null) {
            cellPositionCanBeNull = this.geographicMapCellPositionFactoryInterface.getInstance(this.geographicMapInterface, i_column, i_row, this.getColumns(), this.getRows(), width, height);
            this.geographicMapCellPositionArray[i_row][i_column] = ((GeographicMapCellPosition) cellPositionCanBeNull);
            hashtable.put(cellPositionKey, cellPositionCanBeNull);
        }
        return ((GeographicMapCellPosition) cellPositionCanBeNull);
    }

}

