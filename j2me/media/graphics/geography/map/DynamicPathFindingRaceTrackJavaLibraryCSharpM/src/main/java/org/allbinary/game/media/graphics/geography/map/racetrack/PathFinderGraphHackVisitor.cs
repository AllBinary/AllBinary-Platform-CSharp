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
using GraphPath = org.jgrapht.GraphPath;
using DefaultWeightedEdge = org.jgrapht.graph.DefaultWeightedEdge;
using org.jgrapht.graph;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AllBinaryTiledLayer = org.allbinary.game.layer.AllBinaryTiledLayer;
using CellPosition = org.allbinary.graphics.CellPosition;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using BasicGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.BasicGeographicMapCellPositionFactory;
using BasicGeographicMapUtil = org.allbinary.media.graphics.geography.map.BasicGeographicMapUtil;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using RaceTrackGeographicMap = org.allbinary.media.graphics.geography.map.racetrack.RaceTrackGeographicMap;
using PathFindingNode = org.allbinary.media.graphics.geography.pathfinding.PathFindingNode;

namespace org.allbinary.game.media.graphics.geography.map.racetrack;

public class PathFinderGraphHackVisitor<V, E> : BasePathFinderGraphVisitor<V, E>
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public PathFinderGraphHackVisitor(BasicGeographicMap geographicMapInterface, int edgeMinimum, int minPathWeight, int maxPathWeight) : base(geographicMapInterface, edgeMinimum, minPathWeight, maxPathWeight)
    {
        // base(geographicMapInterface, edgeMinimum, minPathWeight, maxPathWeight) is called from the constructor declaration
    }

    // throws Exception
    public virtual void visit(SimpleWeightedGraph graph, BasicArrayList startPathFindingNodeList, BasicArrayList endPathFindingNodeList)
    {
        this.fixStart(graph, startPathFindingNodeList);
        this.fixEnd(graph, endPathFindingNodeList);
        this.fixOverPassEdges(graph);
    }

    // throws Exception
    private void fixStart(SimpleWeightedGraph<CellPosition, DefaultWeightedEdge> graph, BasicArrayList startPathFindingNodeList)
    {
        BasicGeographicMapCellPositionFactory geographicMapCellPositionFactory = this.geographicMapInterface.getGeographicMapCellPositionFactory();
        AllBinaryTiledLayer tiledLayer = this.geographicMapInterface.getAllBinaryTiledLayer();
        for (int index = startPathFindingNodeList.size() - 1; index >= 0; index--) {
            PathFindingNode startPathFindingNode = ((PathFindingNode) startPathFindingNodeList.get(index));
            GeographicMapCellPosition geographicMapCellPosition = startPathFindingNode.geographicMapCellPosition;
            int column = geographicMapCellPosition.getColumn();
            int row = geographicMapCellPosition.getRow();
            int nextRow = row + 1;
            if (tiledLayer.isOnTileLayer(column, nextRow)) {
                GeographicMapCellPosition geographicMapCellPositionNeighbor = geographicMapCellPositionFactory.getAt(column, nextRow);
                graph.removeEdge(geographicMapCellPosition, geographicMapCellPositionNeighbor);
            }
        }
    }

    // throws Exception
    private void fixEnd(SimpleWeightedGraph<CellPosition, DefaultWeightedEdge> graph, BasicArrayList endPathFindingNodeList)
    {
        BasicGeographicMapCellPositionFactory geographicMapCellPositionFactory = this.geographicMapInterface.getGeographicMapCellPositionFactory();
        AllBinaryTiledLayer tiledLayer = this.geographicMapInterface.getAllBinaryTiledLayer();
        for (int index = endPathFindingNodeList.size() - 1; index >= 0; index--) {
            PathFindingNode endPathFindingNode = ((PathFindingNode) endPathFindingNodeList.get(index));
            GeographicMapCellPosition geographicMapCellPosition = endPathFindingNode.geographicMapCellPosition;
            graph.addVertex(geographicMapCellPosition);
            int column = geographicMapCellPosition.getColumn();
            int row = geographicMapCellPosition.getRow();
            int nextRow = row + 1;
            if (tiledLayer.isOnTileLayer(column, nextRow)) {
                GeographicMapCellPosition geographicMapCellPositionNeighbor = geographicMapCellPositionFactory.getAt(column, nextRow);
                graph.addEdge(geographicMapCellPosition, geographicMapCellPositionNeighbor);
            }
        }
    }

    // throws Exception
    private void fixOverPassEdges(SimpleWeightedGraph<CellPosition, DefaultWeightedEdge> graph)
    {
        BasicGeographicMapCellPositionFactory geographicMapCellPositionFactory = this.geographicMapInterface.getGeographicMapCellPositionFactory();
        RaceTrackGeographicMap raceTrackGeographicMap = ((RaceTrackGeographicMap) this.geographicMapInterface);
        CellPosition[] CellPositionArray = raceTrackGeographicMap.getRaceTrackData().getOverPassGeographicMapCellPositionArray();
        for (int index = CellPositionArray.Length - 1; index >= 0; index--) {
            CellPosition overPassGeographicMapCellPosition = CellPositionArray[index];
            this.logUtil.putF("Fixing Over Pass: " + overPassGeographicMapCellPosition.getColumn() + ", " + overPassGeographicMapCellPosition.getRow(), this, "fixOverPassEdges");
            GeographicMapCellPosition underPassGeographicMapCellPosition = geographicMapCellPositionFactory.getAt(overPassGeographicMapCellPosition.getColumn(), overPassGeographicMapCellPosition.getRow());
            GeographicMapCellPosition rightUnderPassGeographicMapCellPosition = geographicMapCellPositionFactory.getAt(overPassGeographicMapCellPosition.getColumn() + 1, overPassGeographicMapCellPosition.getRow());
            GeographicMapCellPosition leftUnderPassGeographicMapCellPosition = geographicMapCellPositionFactory.getAt(overPassGeographicMapCellPosition.getColumn() - 1, overPassGeographicMapCellPosition.getRow());
            graph.removeEdge(underPassGeographicMapCellPosition, rightUnderPassGeographicMapCellPosition);
            graph.removeEdge(underPassGeographicMapCellPosition, leftUnderPassGeographicMapCellPosition);
            graph.addVertex(overPassGeographicMapCellPosition);
            graph.addEdge(overPassGeographicMapCellPosition, rightUnderPassGeographicMapCellPosition);
            graph.addEdge(overPassGeographicMapCellPosition, leftUnderPassGeographicMapCellPosition);
        }
    }

    // throws Exception
    public virtual void fixPath(BasicArrayList startPathFindingNodeList, BasicArrayList endPathFindingNodeList, BasicArrayList pathList)
    {
        for (int index = startPathFindingNodeList.size() - 1; index >= 0; index--) {
            PathFindingNode endPathFindingNode = ((PathFindingNode) endPathFindingNodeList.get(index));
            PathFindingNode startPathFindingNode = ((PathFindingNode) startPathFindingNodeList.get(index));
            if (BasicGeographicMapUtil.getInstance().isSameCellPosition(startPathFindingNode.geographicMapCellPosition, endPathFindingNode.geographicMapCellPosition)) {
                if (pathList.remove(endPathFindingNode.geographicMapCellPosition)) {
                    pathList.remove(startPathFindingNode.geographicMapCellPosition);
                    pathList.addAt(0, startPathFindingNode.geographicMapCellPosition);
                }
            }
        }
        this.removeOverPassEdges(pathList);
    }

    // throws Exception
    private void removeOverPassEdges(BasicArrayList pathList)
    {
        BasicGeographicMapCellPositionFactory geographicMapCellPositionFactory = this.geographicMapInterface.getGeographicMapCellPositionFactory();
        RaceTrackGeographicMap raceTrackGeographicMap = ((RaceTrackGeographicMap) this.geographicMapInterface);
        CellPosition[] CellPositionArray = raceTrackGeographicMap.getRaceTrackData().getOverPassGeographicMapCellPositionArray();
        for (int index = CellPositionArray.Length - 1; index >= 0; index--) {
            CellPosition overPassGeographicMapCellPosition = CellPositionArray[index];
            GeographicMapCellPosition underPassGeographicMapCellPosition = geographicMapCellPositionFactory.getAt(overPassGeographicMapCellPosition.getColumn(), overPassGeographicMapCellPosition.getRow());
            int indexOf = pathList.indexOf(overPassGeographicMapCellPosition);
            if (indexOf != -1) {
                pathList.set(indexOf, underPassGeographicMapCellPosition);
            }
        }
    }

    public virtual bool isValid(GraphPath graphPath)
    {
        if (graphPath.getEdgeList().size() > edgeMinimum && graphPath.getWeight() < maxPathWeight && graphPath.getWeight() > minPathWeight) {
            return true;
        } else {
            return false;
        }
    }

}

