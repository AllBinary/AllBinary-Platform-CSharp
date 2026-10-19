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
//using java.util;
//using java.util;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using MathUtil = org.allbinary.logic.math.MathUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using BasicGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.BasicGeographicMapCellPositionFactory;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using GeographicMapCellType = org.allbinary.media.graphics.geography.map.GeographicMapCellType;
using RaceTrackGeographicMapCellType = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackGeographicMapCellType;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.media.graphics.geography.pathfinding;

public class PathFinder : GeographicPathFinderBase
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly BasicArrayListUtil basicArrayListUtil = BasicArrayListUtil.getInstance();
    private readonly MathUtil mathUtil = MathUtil.getInstance();
    private readonly PriorityQueue<PathFindingNodeCost> openPriorityQueue = new PriorityQueue<PathFindingNodeCost>();
    private readonly HashSet<PathFindingNodeCost> closedSet = new HashSet<PathFindingNodeCost>();
    private object geographicMapInterface = NullUtil.getInstance().NULL_OBJECT;
    private PathFindingNodeCost[][] costArray = PathFindingNodeCost.NULL_PATH_FINDING_NODE_COST_ARRAY_ARRAY;
    // throws Exception
    public virtual void init(BasicGeographicMap geographicMapInterface)
    {
        this.geographicMapInterface = geographicMapInterface;
        AllBinaryTiledLayer tiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
        this.costArray = System.Linq.Enumerable.Range(0, tiledLayer.getColumns()).Select(_ => new PathFindingNodeCost[tiledLayer.getRows()]).ToArray();
        BasicGeographicMapCellPositionFactory basicGeographicMapCellPositionFactory = geographicMapInterface.getGeographicMapCellPositionFactory();
        PathFindingNodeCost node = null;
        int sizeX = this.costArray.Length;
        int sizeY = this.costArray[0].Length;
        for (int column = 0; column < sizeX; column++) {
            for (int row = 0; row < sizeY; row++) {
                GeographicMapCellType geographicMapCellType = geographicMapInterface.getCellTypeAt(basicGeographicMapCellPositionFactory.getAt(column, row));
                RaceTrackGeographicMapCellType raceTrackGeographicMapCellType = ((RaceTrackGeographicMapCellType) geographicMapCellType);
                node = new PathFindingNodeCost(NullUtil.getInstance().NULL_OBJECT, basicGeographicMapCellPositionFactory.getAt(column, row), new PathFindingNodeCostInfo(((long) raceTrackGeographicMapCellType.getTravelCost()), ((long) (-1))));
                this.costArray[column][row] = node;
            }
        }
    }

    public override BasicArrayList searchTotalPath(BasicArrayList startPathFindingNodeList, BasicArrayList endPathFindingNodeList, int totalPaths)
    {
        try {
            return this.search(((PathFindingNode) startPathFindingNodeList.get(0)), ((PathFindingNode) endPathFindingNodeList.get(0)));
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, "search", e);
            return this.basicArrayListUtil.getImmutableInstance();
        }
    }

    // throws Exception
    public override BasicArrayList searchTotalPathN(BasicArrayList startPathFindingNodeList, BasicArrayList endPathFindingNodeList, int totalPaths, MultipassState multipassState)
    {
        if (multipassState.step == 0) {
            multipassState.step++;
        } else if (multipassState.step == 1) {
            this.searchStart(((PathFindingNode) startPathFindingNodeList.get(0)), ((PathFindingNode) endPathFindingNodeList.get(0)), multipassState);
        } else if (multipassState.step == 2) {
            return this.searchN(((PathFindingNode) startPathFindingNodeList.get(0)), ((PathFindingNode) endPathFindingNodeList.get(0)), multipassState);
        }
        return this.basicArrayListUtil.getImmutableInstance();
    }

    // throws Exception
    public virtual BasicArrayList search(PathFindingNode startPathFindingNode, PathFindingNode endPathFindingNode)
    {
        BasicArrayList list = this.findPath(startPathFindingNode.geographicMapCellPosition, endPathFindingNode.geographicMapCellPosition);
        BasicArrayList pathList = new BasicArrayListD();
        pathList.add(list);
        return pathList;
    }

    // throws Exception
    public virtual void searchStart(PathFindingNode startPathFindingNode, PathFindingNode endPathFindingNode, MultipassState multipassState)
    {
        this.findPathStart(startPathFindingNode.geographicMapCellPosition, endPathFindingNode.geographicMapCellPosition, multipassState);
    }

    // throws Exception
    public virtual BasicArrayList searchN(PathFindingNode startPathFindingNode, PathFindingNode endPathFindingNode, MultipassState multipassState)
    {
        BasicArrayList list = this.findPathEnd(startPathFindingNode.geographicMapCellPosition, endPathFindingNode.geographicMapCellPosition, multipassState);
        if (list == null) {
            return this.basicArrayListUtil.getImmutableInstance();
        }
        BasicArrayList pathList = new BasicArrayListD();
        pathList.add(list);
        multipassState.iteration = 0;
        multipassState.step = 0;
        return pathList;
    }

    // throws Exception
    public virtual BasicArrayList findPath(GeographicMapCellPosition start, GeographicMapCellPosition target)
    {
        this.openPriorityQueue.clear();
        this.closedSet.clear();
        long discoveryCalculation = 0L;
        PathFindingNodeCost node = null;
        int targetColumn = target.getColumn();
        int targetRow = target.getRow();
        int sizeX = this.costArray.Length;
        int sizeY = this.costArray[0].Length;
        for (int column = 0; column < sizeX; column++) {
            for (int row = 0; row < sizeY; row++) {
                discoveryCalculation = ((long) this.mathUtil.abs(column - targetColumn)) + this.mathUtil.abs(row - targetRow);
                node = this.costArray[column][row];
                node.pathFindingNodeCostInfoP.totalCostP = 0;
                node.pathFindingNodeCostInfoP.costToEndP = discoveryCalculation;
            }
        }
        PathFindingNodeCost startNode = this.costArray[start.getColumn()][start.getRow()];
        this.openPriorityQueue.add(startNode);
        BasicGeographicMap geographicMapInterface = ((BasicGeographicMap) this.geographicMapInterface);
        BasicGeographicMapCellPositionFactory basicGeographicMapCellPositionFactory = geographicMapInterface.getGeographicMapCellPositionFactory();
        AllBinaryTiledLayer allBinaryTiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
        PathFindingNodeCost targetNode = this.costArray[target.getColumn()][target.getRow()];
        PathFindingNodeCost current = null;
        do {
            current = this.openPriorityQueue.poll();
            this.closedSet.add(current);
            if (current.Equals(targetNode)) {
                return this.extractPath(start, current);
            }
            PathFindingNodeCost neighbor = null;
            PathFindingNodeCostInfo neighborInfo = null;
            long calculatedCost = 0L;
            for (int column = current.geographicMapCellPosition.getColumn() - 1; column < current.geographicMapCellPosition.getColumn() + 2; column++) {
                for (int row = current.geographicMapCellPosition.getRow() - 1; row < current.geographicMapCellPosition.getRow() + 2; row++) {
                    if (column > 0 && row > 0 && column < allBinaryTiledLayer.getColumns() && row < allBinaryTiledLayer.getRows() && geographicMapInterface.isOnMap(basicGeographicMapCellPositionFactory.getAt(column, row))) {
                        neighbor = this.costArray[column][row];
                        if (this.closedSet.contains(neighbor)) {
                            continue;
                        }
                        neighborInfo = neighbor.pathFindingNodeCostInfoP;
                        calculatedCost = neighborInfo.costToEndP + neighborInfo.costFromStartP + current.pathFindingNodeCostInfoP.totalCostP;
                        if (calculatedCost < neighborInfo.totalCostP || !this.openPriorityQueue.contains(neighbor)) {
                            neighborInfo.totalCostP = calculatedCost;
                            neighbor.parent = current;
                            if (!this.openPriorityQueue.contains(neighbor)) {
                                if (geographicMapInterface.isOfFourDirections(current.geographicMapCellPosition, neighbor.geographicMapCellPosition)) {
                                    this.openPriorityQueue.add(neighbor);
                                }
                            }
                        }
                    }
                }
            }
        } while (!this.openPriorityQueue.isEmpty());
        throw new SystemException();
    }

    // throws Exception
    public virtual void findPathStart(GeographicMapCellPosition start, GeographicMapCellPosition target, MultipassState multipassState)
    {
        this.openPriorityQueue.clear();
        this.closedSet.clear();
        long discoveryCalculation = 0L;
        PathFindingNodeCost node = null;
        int targetColumn = target.getColumn();
        int targetRow = target.getRow();
        int sizeX = this.costArray.Length;
        int sizeY = this.costArray[0].Length;
        for (int column = 0; column < sizeX; column++) {
            for (int row = 0; row < sizeY; row++) {
                discoveryCalculation = ((long) this.mathUtil.abs(column - targetColumn)) + this.mathUtil.abs(row - targetRow);
                node = this.costArray[column][row];
                node.pathFindingNodeCostInfoP.totalCostP = 0;
                node.pathFindingNodeCostInfoP.costToEndP = discoveryCalculation;
            }
        }
        PathFindingNodeCost startNode = this.costArray[start.getColumn()][start.getRow()];
        this.openPriorityQueue.add(startNode);
        multipassState.step++;
    }

    // throws Exception
    public virtual BasicArrayList findPathEnd(GeographicMapCellPosition start, GeographicMapCellPosition target, MultipassState multipassState)
    {
        BasicGeographicMap geographicMapInterface = ((BasicGeographicMap) this.geographicMapInterface);
        BasicGeographicMapCellPositionFactory basicGeographicMapCellPositionFactory = geographicMapInterface.getGeographicMapCellPositionFactory();
        AllBinaryTiledLayer allBinaryTiledLayer = geographicMapInterface.getAllBinaryTiledLayer();
        PathFindingNodeCost targetNode = this.costArray[target.getColumn()][target.getRow()];
        PathFindingNodeCost current = null;
        int total = 0;
        do {
            current = this.openPriorityQueue.poll();
            this.closedSet.add(current);
            if (current.Equals(targetNode)) {
                return this.extractPath(start, current);
            }
            PathFindingNodeCost neighbor = null;
            PathFindingNodeCostInfo neighborInfo = null;
            long calculatedCost = 0L;
            for (int column = current.geographicMapCellPosition.getColumn() - 1; column < current.geographicMapCellPosition.getColumn() + 2; column++) {
                for (int row = current.geographicMapCellPosition.getRow() - 1; row < current.geographicMapCellPosition.getRow() + 2; row++) {
                    if (column > 0 && row > 0 && column < allBinaryTiledLayer.getColumns() && row < allBinaryTiledLayer.getRows() && geographicMapInterface.isOnMap(basicGeographicMapCellPositionFactory.getAt(column, row))) {
                        neighbor = this.costArray[column][row];
                        if (this.closedSet.contains(neighbor)) {
                            continue;
                        }
                        neighborInfo = neighbor.pathFindingNodeCostInfoP;
                        calculatedCost = neighborInfo.costToEndP + neighborInfo.costFromStartP + current.pathFindingNodeCostInfoP.totalCostP;
                        if (calculatedCost < neighborInfo.totalCostP || !this.openPriorityQueue.contains(neighbor)) {
                            neighborInfo.totalCostP = calculatedCost;
                            neighbor.parent = current;
                            if (!this.openPriorityQueue.contains(neighbor)) {
                                if (geographicMapInterface.isOfFourDirections(current.geographicMapCellPosition, neighbor.geographicMapCellPosition)) {
                                    this.openPriorityQueue.add(neighbor);
                                }
                            }
                        }
                    }
                }
            }
            total++;
            if (total > 10) {
                return this.basicArrayListUtil.getImmutableInstance();
            }
        } while (!this.openPriorityQueue.isEmpty());
        throw new SystemException();
    }

    private BasicArrayList extractPath(GeographicMapCellPosition start, PathFindingNodeCost current)
    {
        BasicArrayList path = new BasicArrayListD();
        while (current.parent != NullUtil.getInstance().NULL_OBJECT) {
            path.add(current.geographicMapCellPosition);
            current = ((PathFindingNodeCost) current.parent);
        }
        path.add(start);
        this.basicArrayListUtil.reverse(path);
        return path;
    }

}

