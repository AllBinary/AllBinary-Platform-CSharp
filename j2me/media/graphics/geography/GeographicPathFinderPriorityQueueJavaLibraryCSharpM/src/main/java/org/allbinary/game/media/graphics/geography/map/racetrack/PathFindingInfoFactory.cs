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
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using BasicGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.BasicGeographicMapCellPositionFactory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using BasePathFindingInfoFactory = org.allbinary.media.graphics.geography.map.racetrack.BasePathFindingInfoFactory;
using RaceTrackRoadsGeographicMapCellHistoryFactory = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackRoadsGeographicMapCellHistoryFactory;
using PathFinder = org.allbinary.media.graphics.geography.pathfinding.PathFinder;
using PathFindingInfo = org.allbinary.media.graphics.geography.pathfinding.PathFindingInfo;
using PathFindingNodeCostInfoFactory = org.allbinary.media.graphics.geography.pathfinding.PathFindingNodeCostInfoFactory;
using BasicArrayListS = org.allbinary.util.BasicArrayListS;

namespace org.allbinary.game.media.graphics.geography.map.racetrack;

//1.4.2
public class PathFindingInfoFactory : BasePathFindingInfoFactory
{
    private static readonly PathFindingInfoFactory instance = new PathFindingInfoFactory();
    public static PathFindingInfoFactory getInstance()
    {
        return PathFindingInfoFactory.instance;
    }

    private static int MAX = 32768;
    public static void initMax(int max)
    {
        PathFindingInfoFactory.MAX = max;
    }

    private readonly PathFindingInfo pathFindingInfo;
    private readonly PathFinder pathFinder;
    private PathFindingInfoFactory()
    {
        this.pathFindingInfo = new PathFindingInfo(new PathFindingNodeCostInfoFactory(PathFindingInfoFactory.MAX), new BasicArrayListS(1), new BasicArrayListS(1));
        this.pathFinder = new PathFinder();
    }

    // throws Exception
    public override PathFindingInfo getInstancePathFindingInfo(BasicGeographicMap geographicMapInterface, int[][] mapArray)
    {
        PathFindingInfo pathFindingInfo = new PathFindingInfo(this.pathFindingInfo.getPathFindingNodeCostInfoFactoryInterface(), new BasicArrayListS(1), new BasicArrayListS(1));
        RaceTrackRoadsGeographicMapCellHistoryFactory.getInstance().init();
        this.init(geographicMapInterface, pathFindingInfo, mapArray);
        this.pathFinder.init(geographicMapInterface);
        pathFindingInfo.setPathFinder(this.pathFinder);
        return pathFindingInfo;
    }

    // throws Exception
    public override void init(BasicGeographicMap geographicMapInterface, PathFindingInfo pathFindingInfo, int[][] mapArray)
    {
        base.init(geographicMapInterface, pathFindingInfo, mapArray);
        this.buildPathFindingNodes(geographicMapInterface, pathFindingInfo, mapArray);
    }

    // throws Exception
    private void buildPathFindingNodesForCellPosition(BasicGeographicMap geographicMapInterface, PathFindingInfo pathFindingInfo, int[][] mapArray, GeographicMapCellPosition cellPosition)
    {
    }

    // throws Exception
    private void buildPathFindingNodes(BasicGeographicMap geographicMapInterface, PathFindingInfo pathFindingInfo, int[][] mapArray)
    {
        BasicGeographicMapCellPositionFactory geographicMapCellPositionFactory = geographicMapInterface.getGeographicMapCellPositionFactory();
        AllBinaryTiledLayer allBinaryTiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
        int totalColumns = allBinaryTiledLayer.getColumns();
        int totalRows = allBinaryTiledLayer.getRows();
        for (int column = 0; column < totalColumns; column++) {
            for (int row = 0; row < totalRows; row++) {
                this.buildPathFindingNodesForCellPosition(geographicMapInterface, pathFindingInfo, mapArray, geographicMapCellPositionFactory.getAt(column, row));
            }
        }
    }

}

