/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2006 AllBinary
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
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;
using RaceTrackGeographicMapCellType = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackGeographicMapCellType;

namespace org.allbinary.media.graphics.geography.pathfinding;

public class PathFindingNodeCostInfoFactory : PathFindingNodeCostInfoFactoryBase
{
    public PathFindingNodeCostInfoFactory(int max)
    {
    }

    // throws Exception
    public override void create(BasicGeographicMap geographicMapInterface, GeographicMapCellPosition goingToGeographicMapCellPosition, GeographicMapCellPosition geographicMapCellPosition, long costFromStart, long costToEnd)
    {
    }

    // throws Exception
    public override long getTotalCost(BasicGeographicMap geographicMapInterface, GeographicMapCellPosition comingFromGeographicMapCellPosition, GeographicMapCellPosition geographicMapCellPosition)
    {
        GeographicMapCellType geographicMapCellType = geographicMapInterface.getCellTypeAt(comingFromGeographicMapCellPosition);
        GeographicMapCellType geographicMapCellType2 = geographicMapInterface.getCellTypeAt(geographicMapCellPosition);
        RaceTrackGeographicMapCellType raceTrackGeographicMapCellType = ((RaceTrackGeographicMapCellType) geographicMapCellType);
        RaceTrackGeographicMapCellType raceTrackGeographicMapCellType2 = ((RaceTrackGeographicMapCellType) geographicMapCellType2);
        return ((long) raceTrackGeographicMapCellType.getTravelCost()) + raceTrackGeographicMapCellType2.getTravelCost();
    }

}

