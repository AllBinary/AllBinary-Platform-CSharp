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

namespace org.allbinary.media.graphics.geography.pathfinding;

public class PathFindingNodeCostInfoFactory : PathFindingNodeCostInfoFactoryBase
{
    private readonly PathFindingNodeCostInfo[][] pathFindingNodeCostInfoAdjacencyList;
    public PathFindingNodeCostInfoFactory(int max)
    {
        this.pathFindingNodeCostInfoAdjacencyList = System.Linq.Enumerable.Range(0, max).Select(_ => new PathFindingNodeCostInfo[max]).ToArray();
    }

    // throws Exception
    public override void create(BasicGeographicMap geographicMapInterface, GeographicMapCellPosition goingToGeographicMapCellPosition, GeographicMapCellPosition geographicMapCellPosition, long costFromStart, long costToEnd)
    {
        this.getInstance(goingToGeographicMapCellPosition, geographicMapCellPosition, costFromStart, costToEnd);
    }

    // throws Exception
    public virtual PathFindingNodeCostInfo getInstance(GeographicMapCellPosition goingToGeographicMapCellPosition, GeographicMapCellPosition geographicMapCellPosition, long costFromStart, long costToEnd)
    {
        PathFindingNodeCostInfo pathFindingNodeCostInfo = this.getInstance(goingToGeographicMapCellPosition, geographicMapCellPosition);
        if (pathFindingNodeCostInfo == null) {
            pathFindingNodeCostInfo = new PathFindingNodeCostInfo(costFromStart, costToEnd);
            pathFindingNodeCostInfo.setCalculatedTotalCost();
            this.pathFindingNodeCostInfoAdjacencyList[geographicMapCellPosition.getId()][goingToGeographicMapCellPosition.getId()] = pathFindingNodeCostInfo;
        } else {
            pathFindingNodeCostInfo.setCostFromStart(costFromStart);
            pathFindingNodeCostInfo.setCostToEnd(costToEnd);
            pathFindingNodeCostInfo.setCalculatedTotalCost();
        }
        return pathFindingNodeCostInfo;
    }

    public virtual PathFindingNodeCostInfo getInstance(GeographicMapCellPosition goingToFromGeographicMapCellPosition, GeographicMapCellPosition geographicMapCellPosition)
    {
        return this.pathFindingNodeCostInfoAdjacencyList[geographicMapCellPosition.getId()][goingToFromGeographicMapCellPosition.getId()];
    }

    public override long getTotalCost(BasicGeographicMap geographicMapInterface, GeographicMapCellPosition comingFromGeographicMapCellPosition, GeographicMapCellPosition geographicMapCellPosition)
    {
        return this.getInstance(comingFromGeographicMapCellPosition, geographicMapCellPosition).totalCostP;
    }

}

