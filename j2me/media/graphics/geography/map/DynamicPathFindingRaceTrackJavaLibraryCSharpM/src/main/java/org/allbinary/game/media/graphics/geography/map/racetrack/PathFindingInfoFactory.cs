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
using CommonStrings = org.allbinary.@string.CommonStrings;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using BasicGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.BasicGeographicMapCellPositionFactory;
using BasicGeographicMapUtil = org.allbinary.media.graphics.geography.map.BasicGeographicMapUtil;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;
using GeographicMapCellTypeFactory = org.allbinary.media.graphics.geography.map.GeographicMapCellTypeFactory;
using BasePathFindingInfoFactory = org.allbinary.media.graphics.geography.map.racetrack.BasePathFindingInfoFactory;
using RaceTrackGeographicMapCellType = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackGeographicMapCellType;
using RaceTrackRoadsGeographicMapCellHistoryFactory = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackRoadsGeographicMapCellHistoryFactory;
using PathFindingNodeCostInfoFactoryBase = org.allbinary.media.graphics.geography.pathfinding.PathFindingNodeCostInfoFactoryBase;
using BasicGeographicMapGraph = org.allbinary.media.graphics.geography.pathfinding.BasicGeographicMapGraph;
using BasicGeographicMapPathFinder = org.allbinary.media.graphics.geography.pathfinding.BasicGeographicMapPathFinder;
using PathFinderGraphVisitorFactoryBase = org.allbinary.media.graphics.geography.pathfinding.PathFinderGraphVisitorFactoryBase;
using PathFindingInfo = org.allbinary.media.graphics.geography.pathfinding.PathFindingInfo;
using PathFindingNodeCostInfoFactory = org.allbinary.media.graphics.geography.pathfinding.PathFindingNodeCostInfoFactory;
using BasicArrayListS = org.allbinary.util.BasicArrayListS;

namespace org.allbinary.game.media.graphics.geography.map.racetrack;

public class PathFindingInfoFactory : BasePathFindingInfoFactory
{
    private static PathFindingInfoFactory instance = null;
    public static PathFindingInfoFactory getInstance()
    {
        return PathFindingInfoFactory.instance;
    }

    public static void initMax(int max)
    {
        PathFindingInfoFactory.instance = new PathFindingInfoFactory(new SimplePathFinderGraphVisitorFactory(1, 1, int.MaxValue), max);
    }

    private readonly int MAX_DIRECTIONS = 4;
    private readonly PathFindingInfo pathFindingInfo;
    private readonly BasicGeographicMapGraph basicGeographicMapGraph;
    private readonly BasicGeographicMapPathFinder basicGeographicMapPathFinder;
    private readonly PathFinderGraphVisitorFactoryBase pathFinderGraphVisitorFactoryInterface;
    private PathFindingInfoFactory(PathFinderGraphVisitorFactoryBase pathFinderGraphVisitorFactoryInterface, int max)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        PreLogUtil.put("Using Dynamic Path Finding", this, commonStrings.GET_INSTANCE);
        this.basicGeographicMapPathFinder = new BasicGeographicMapPathFinder(max);
        this.pathFindingInfo = new PathFindingInfo(new PathFindingNodeCostInfoFactory(max), new BasicArrayListS(1), new BasicArrayListS(1));
        this.basicGeographicMapGraph = new BasicGeographicMapGraph(((PathFindingNodeCostInfoFactory) this.pathFindingInfo.getPathFindingNodeCostInfoFactoryInterface()));
        this.pathFinderGraphVisitorFactoryInterface = pathFinderGraphVisitorFactoryInterface;
    }

    // throws Exception
    public override PathFindingInfo getInstancePathFindingInfo(BasicGeographicMap geographicMapInterface, int[][] mapArray)
    {
        PathFindingInfo pathFindingInfo = new PathFindingInfo(this.pathFindingInfo.getPathFindingNodeCostInfoFactoryInterface(), new BasicArrayListS(1), new BasicArrayListS(1));
        RaceTrackRoadsGeographicMapCellHistoryFactory.getInstance().init();
        this.init(geographicMapInterface, pathFindingInfo, mapArray);
        this.basicGeographicMapPathFinder.init(geographicMapInterface, this.basicGeographicMapGraph, this.pathFinderGraphVisitorFactoryInterface.getInstance(geographicMapInterface));
        pathFindingInfo.setPathFinder(this.basicGeographicMapPathFinder);
        return pathFindingInfo;
    }

    // throws Exception
    public virtual void init(BasicGeographicMap geographicMapInterface, PathFindingInfo pathFindingInfo, int[][] mapArray)
    {
        base.init(geographicMapInterface, pathFindingInfo, mapArray);
        this.buildPathFindingNodes(geographicMapInterface, pathFindingInfo, mapArray);
    }

    // throws Exception
    private void buildPathFindingNodesForCellPosition(BasicGeographicMap geographicMapInterface, PathFindingInfo pathFindingInfo, int[][] mapArray, GeographicMapCellPosition cellPosition)
    {
        BasicGeographicMapCellPositionFactory geographicMapCellPositionFactory = geographicMapInterface.getGeographicMapCellPositionFactory();
        int cellTypeId = mapArray[cellPosition.getRow()][cellPosition.getColumn()];
        GeographicMapCellType geographicMapCellType = GeographicMapCellTypeFactory.getInstance().get(geographicMapInterface.getCellTypeFromMapCellTypeInt(cellTypeId));
        RaceTrackGeographicMapCellType raceTrackGeographicMapCellType = ((RaceTrackGeographicMapCellType) geographicMapCellType);
        AllBinaryTiledLayer allBinaryTiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
        PathFindingNodeCostInfoFactoryBase pathFindingNodeCostInfoFactoryInterface = pathFindingInfo.getPathFindingNodeCostInfoFactoryInterface();
        BasicGeographicMapUtil basicGeographicMapUtil = BasicGeographicMapUtil.getInstance();
        int row = 0;
        int column = 0;
        GeographicMapCellPosition goingToGeographicMapCellPosition = null;
        int costFromStart = 0;
        int costToEnd = 0;
        for (int index = 0; index < this.MAX_DIRECTIONS; index++) {
            row = basicGeographicMapUtil.getBorderingRow(index, cellPosition);
            column = basicGeographicMapUtil.getBorderingColumn(index, cellPosition);
            if (row < allBinaryTiledLayer.getRows() && column < allBinaryTiledLayer.getColumns() && row >= 0 && column >= 0) {
                goingToGeographicMapCellPosition = geographicMapCellPositionFactory.getAt(column, row);
                costFromStart = raceTrackGeographicMapCellType.getTravelCost();
                costToEnd = costFromStart;
                pathFindingNodeCostInfoFactoryInterface.create(geographicMapInterface, goingToGeographicMapCellPosition, cellPosition, costFromStart, costToEnd);
            }
        }
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

