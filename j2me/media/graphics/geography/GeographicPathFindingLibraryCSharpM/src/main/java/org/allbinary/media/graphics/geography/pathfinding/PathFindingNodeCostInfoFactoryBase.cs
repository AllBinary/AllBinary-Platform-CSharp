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
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;

namespace org.allbinary.media.graphics.geography.pathfinding;

public class PathFindingNodeCostInfoFactoryBase : PathFindingNodeCostInfoFactoryBaseInterface
{
    public static readonly PathFindingNodeCostInfoFactoryBase NULL_PATH_FINDING_NODE_COST_INFO_FACTORY_BASE = new PathFindingNodeCostInfoFactoryBase();
    // throws Exception
    public virtual void create(BasicGeographicMap geographicMapInterface, GeographicMapCellPosition comingFromGeographicMapCellPosition, GeographicMapCellPosition geographicMapCellPosition, long costFromStart, long costToEnd)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual long getTotalCost(BasicGeographicMap geographicMapInterface, GeographicMapCellPosition comingFromGeographicMapCellPosition, GeographicMapCellPosition geographicMapCellPosition)
    {
        throw new SystemException();
    }

}

