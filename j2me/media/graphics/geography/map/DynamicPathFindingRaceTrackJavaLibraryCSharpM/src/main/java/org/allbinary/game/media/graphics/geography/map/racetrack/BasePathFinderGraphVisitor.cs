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
using SimpleWeightedGraph = org.jgrapht.graph.SimpleWeightedGraph;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using PathFinderGraphVisitorBase = org.allbinary.media.graphics.geography.pathfinding.PathFinderGraphVisitorBase;
using PathFindingNode = org.allbinary.media.graphics.geography.pathfinding.PathFindingNode;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.media.graphics.geography.map.racetrack;

public class BasePathFinderGraphVisitor<V, E> : PathFinderGraphVisitorBase
{
    public BasicGeographicMap geographicMapInterface;
    public readonly int edgeMinimum;
    public readonly int minPathWeight;
    public readonly int maxPathWeight;
    public BasePathFinderGraphVisitor(BasicGeographicMap geographicMapInterface, int edgeMinimum, int minPathWeight, int maxPathWeight)
    {
        this.geographicMapInterface = geographicMapInterface;
        this.edgeMinimum = edgeMinimum;
        this.minPathWeight = minPathWeight;
        this.maxPathWeight = maxPathWeight;
    }

    // throws Exception
    public virtual void visit(SimpleWeightedGraph graph, BasicArrayList startPathFindingNodeList, BasicArrayList endPathFindingNodeList)
    {
    }

    // throws Exception
    public virtual void fixPath(BasicArrayList startPathFindingNodeList, BasicArrayList endPathFindingNodeList, BasicArrayList pathList)
    {
        for (int index = startPathFindingNodeList.size() - 1; index >= 0; index--) {
            PathFindingNode startPathFindingNode = ((PathFindingNode) startPathFindingNodeList.get(index));
            pathList.remove(startPathFindingNode.geographicMapCellPosition);
            pathList.addAt(0, startPathFindingNode.geographicMapCellPosition);
        }
    }

    public virtual bool isValid(GraphPath graphPath)
    {
        if (graphPath.getEdgeList().size() > this.edgeMinimum && graphPath.getWeight() < this.maxPathWeight && graphPath.getWeight() > this.minPathWeight) {
            return true;
        } else {
            return false;
        }
    }

    public virtual string getInvalidReason(GraphPath graphPath)
    {
        StringMaker stringBuffer = new StringMaker();
        if (graphPath.getEdgeList().size() < this.edgeMinimum) {
            stringBuffer.append("Ignoring Small: " + graphPath.getEdgeList().size());
        }
        if (graphPath.getWeight() <= this.minPathWeight) {
            stringBuffer.append(" Low Weighted Path: " + graphPath.getWeight());
        }
        if (graphPath.getWeight() >= this.maxPathWeight) {
            stringBuffer.append(" To High Weighted Path: " + graphPath.getWeight());
        }
        return stringBuffer.ToString();
    }

}

