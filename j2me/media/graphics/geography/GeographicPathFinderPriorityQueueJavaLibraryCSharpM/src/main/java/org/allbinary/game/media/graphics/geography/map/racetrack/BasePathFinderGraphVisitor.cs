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
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using PathFinderGraphVisitorBase = org.allbinary.media.graphics.geography.pathfinding.PathFinderGraphVisitorBase;
using PathFindingNode = org.allbinary.media.graphics.geography.pathfinding.PathFindingNode;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.media.graphics.geography.map.racetrack;

//1.4.2
public class BasePathFinderGraphVisitor : PathFinderGraphVisitorBase
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
    public override void visit(object graph, BasicArrayList startPathFindingNodeList, BasicArrayList endPathFindingNodeList)
    {
    }

    // throws Exception
    public override void fixPath(BasicArrayList startPathFindingNodeList, BasicArrayList endPathFindingNodeList, BasicArrayList pathList)
    {
        PathFindingNode startPathFindingNode = null;
        for (int index = startPathFindingNodeList.size() - 1; index >= 0; index--) {
            startPathFindingNode = ((PathFindingNode) startPathFindingNodeList.get(index));
            pathList.remove(startPathFindingNode.geographicMapCellPosition);
            pathList.addAt(0, startPathFindingNode.geographicMapCellPosition);
        }
    }

    public override bool isValid(object graphPath)
    {
        return false;
    }

    public override string getInvalidReason(object graphPath)
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

}

