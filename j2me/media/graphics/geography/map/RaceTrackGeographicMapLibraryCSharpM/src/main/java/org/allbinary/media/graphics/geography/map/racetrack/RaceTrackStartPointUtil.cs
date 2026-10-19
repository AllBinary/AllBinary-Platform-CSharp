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
using GPoint = org.allbinary.graphics.GPoint;
using PointFactory = org.allbinary.graphics.PointFactory;
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using PathFindingInfo = org.allbinary.media.graphics.geography.pathfinding.PathFindingInfo;
using PathFindingNode = org.allbinary.media.graphics.geography.pathfinding.PathFindingNode;

namespace org.allbinary.media.graphics.geography.map.racetrack;

public class RaceTrackStartPointUtil
{
    // throws Exception
    public static GPoint get(BasicGeographicMap geographicMapInterface, PathFindingInfo pathFindingInfo, int index)
    {
        BasicArrayList list = pathFindingInfo.getStartPathFindingNodeList();
        PathFindingNode startPathFindingNode = ((PathFindingNode) list.get(index));
        GeographicMapCellPosition geographicMapCellPosition = startPathFindingNode.geographicMapCellPosition;
        GPoint point = geographicMapCellPosition.getPoint();
        return PointFactory.getInstance().createXY(point.getX(), point.getY() + geographicMapInterface.getAllBinaryTiledLayer().getHalfCellHeight());
    }

}

