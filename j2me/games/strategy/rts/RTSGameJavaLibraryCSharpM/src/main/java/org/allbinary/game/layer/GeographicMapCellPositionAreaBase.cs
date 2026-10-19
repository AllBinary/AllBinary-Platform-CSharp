/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.layer;

public class GeographicMapCellPositionAreaBase : GeographicMapCellPositionAreaInterface
{
    public static readonly GeographicMapCellPositionAreaBase NULL_GEOGRPAHIC_MAP_POSITION_AREA_BASE = new GeographicMapCellPositionAreaBase();
    public virtual GeographicMapCellPosition getNextSurroundingGeographicMapCellPosition()
    {
        throw new SystemException();
    }

    public virtual BasicArrayList getOccupyingGeographicMapCellPositionList()
    {
        throw new SystemException();
    }

    public virtual BasicArrayList getSurroundingGeographicMapCellPositionList()
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual void update(BasicGeographicMap geographicMapInterface)
    {
        throw new SystemException();
    }

}

