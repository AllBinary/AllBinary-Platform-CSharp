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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;

namespace org.allbinary.game.media.graphics.geography.map.racetrack;

//1.4.2
public class PathFinderGraphHackVisitor : BasePathFinderGraphVisitor
{
    public PathFinderGraphHackVisitor(BasicGeographicMap geographicMapInterface, int edgeMinimum, int minPathWeight, int maxPathWeight) : base(geographicMapInterface, edgeMinimum, minPathWeight, maxPathWeight)
    {
        // base(geographicMapInterface, edgeMinimum, minPathWeight, maxPathWeight) is called from the constructor declaration
    }

    // throws Exception
    public override void visit(object graph, BasicArrayList startPathFindingNodeList, BasicArrayList endPathFindingNodeList)
    {
        this.fixStart(graph, startPathFindingNodeList);
        this.fixEnd(graph, endPathFindingNodeList);
        this.fixOverPassEdges(graph);
    }

    // throws Exception
    private void fixStart(object graph, BasicArrayList startPathFindingNodeList)
    {
    }

    // throws Exception
    private void fixEnd(object graph, BasicArrayList endPathFindingNodeList)
    {
    }

    // throws Exception
    private void fixOverPassEdges(object graph)
    {
    }

    // throws Exception
    public override void fixPath(BasicArrayList startPathFindingNodeList, BasicArrayList endPathFindingNodeList, BasicArrayList pathList)
    {
    }

    // throws Exception
    private void removeOverPassEdges(BasicArrayList pathList)
    {
    }

    public override bool isValid(object graphPath)
    {
        return false;
    }

}

