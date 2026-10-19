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
using BasicGeographicMap = org.allbinary.media.graphics.geography.map.BasicGeographicMap;
using GeographicMapCellHistory = org.allbinary.media.graphics.geography.map.GeographicMapCellHistory;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.media.graphics.geography.pathfinding;

public class PathGenerator : PathGeneratorInterface
{
    private static readonly PathGenerator SINGLETON = new PathGenerator();
    public static PathGenerator getInstance()
    {
        return PathGenerator.SINGLETON;
    }

    private PathGenerator()
    {
    }

    // throws Exception
    public virtual void init(object geographicMapInterface, int totalPaths)
    {
    }

    // throws Exception
    public virtual BasicArrayList getInstanceNoCache(BasicGeographicMap geographicMapInterface, PathFindingInfo pathFindingInfo, int totalPaths)
    {
        BasicArrayList geographicMapCellPositionBasicArrayList = this.create(geographicMapInterface, pathFindingInfo, totalPaths);
        return geographicMapCellPositionBasicArrayList;
    }

    // throws Exception
    public virtual BasicArrayList createList(BasicGeographicMap geographicMapInterface, GeographicMapCellHistory geographicMapCellHistory, PathFindingInfo pathFindingInfo, int totalPaths)
    {
        throw new SystemException();
    }

    // throws Exception
    private BasicArrayList create(BasicGeographicMap geographicMapInterface, PathFindingInfo pathFindingInfo, int totalPaths)
    {
        BasicArrayList startPathFindingNodeList = pathFindingInfo.getStartPathFindingNodeList();
        BasicArrayList endPathFindingNodeList = pathFindingInfo.getEndPathFindingNodeList();
        GeographicPathFinderBase geographicPathFinderInterface = pathFindingInfo.getPathFinder();
        BasicArrayList geographicMapCellPositionBasicArrayList = geographicPathFinderInterface.searchTotalPath(startPathFindingNodeList, endPathFindingNodeList, totalPaths);
        return geographicMapCellPositionBasicArrayList;
    }

    // throws Exception
    public virtual BasicArrayList createN(BasicGeographicMap geographicMapInterface, PathFindingInfo pathFindingInfo, int totalPaths, MultipassState multipassState)
    {
        BasicArrayList startPathFindingNodeList = pathFindingInfo.getStartPathFindingNodeList();
        BasicArrayList endPathFindingNodeList = pathFindingInfo.getEndPathFindingNodeList();
        GeographicPathFinderBase geographicPathFinderInterface = pathFindingInfo.getPathFinder();
        BasicArrayList geographicMapCellPositionBasicArrayList = geographicPathFinderInterface.searchTotalPathN(startPathFindingNodeList, endPathFindingNodeList, totalPaths, multipassState);
        return geographicMapCellPositionBasicArrayList;
    }

    // throws Exception
    private bool isValid(BasicArrayList pathList, GeographicMapCellHistory geographicMapCellHistory)
    {
        throw new SystemException();
    }

}

