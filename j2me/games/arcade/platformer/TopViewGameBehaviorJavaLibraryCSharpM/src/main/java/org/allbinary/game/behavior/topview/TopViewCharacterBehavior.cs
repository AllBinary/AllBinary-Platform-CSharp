/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using Direction = org.allbinary.direction.Direction;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;
using BasicTopViewGeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.topview.BasicTopViewGeographicMapCellTypeFactory;

namespace org.allbinary.game.behavior.topview;

public class TopViewCharacterBehavior
{
    // throws Exception
    public virtual void terrainEvent(AllBinaryLayer layer, Direction direction, int x, int y, BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellPosition geographicMapCellPosition)
    {
    }

    public virtual void terrainMove(AllBinaryLayer layer, BasicGeographicMap[] geographicMapInterfaceArray, int x, int y)
    {
    }

    public virtual bool hasSolidBlock(BasicGeographicMap[] geographicMapInterfaceArray, GeographicMapCellType[] geographicMapCellTypeArray)
    {
        int size = geographicMapInterfaceArray.Length;
        BasicTopViewGeographicMapCellTypeFactory basicTopViewGeographicMapCellTypeFactory = null;
        for (int index = 0; index < size; index++) {
            basicTopViewGeographicMapCellTypeFactory = ((BasicTopViewGeographicMapCellTypeFactory) geographicMapInterfaceArray[index].getGeographicMapCellTypeFactory());
            if (basicTopViewGeographicMapCellTypeFactory.BLOCK_CELL_TYPE.isType(geographicMapCellTypeArray[index])) {
                return true;
            }
        }
        return false;
    }

}

