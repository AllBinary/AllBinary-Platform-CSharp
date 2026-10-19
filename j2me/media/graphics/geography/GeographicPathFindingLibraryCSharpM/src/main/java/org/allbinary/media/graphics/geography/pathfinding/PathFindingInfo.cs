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
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.media.graphics.geography.pathfinding;

public class PathFindingInfo : PathFindingInfoInterface
{
    public static readonly PathFindingInfo NULL_PATH_FINDING_INFO = new PathFindingInfo(PathFindingNodeCostInfoFactoryBase.NULL_PATH_FINDING_NODE_COST_INFO_FACTORY_BASE, BasicArrayListUtil.getInstance().getImmutableInstance(), BasicArrayListUtil.getInstance().getImmutableInstance());
    private GeographicPathFinderBase pathFinder = GeographicPathFinderBase.NULL_GEOGRAPHIC_PATH_FINDER_BASE;
    private readonly BasicArrayList startPathFindingNodeList;
    private readonly BasicArrayList endPathFindingNodeList;
    private readonly PathFindingNodeCostInfoFactoryBase pathFindingNodeCostInfoFactoryInterface;
    public PathFindingInfo(PathFindingNodeCostInfoFactoryBase pathFindingNodeCostInfoFactoryInterface, BasicArrayList startPathFindingNodeList, BasicArrayList endPathFindingNodeList)
    {
        this.pathFindingNodeCostInfoFactoryInterface = pathFindingNodeCostInfoFactoryInterface;
        this.startPathFindingNodeList = startPathFindingNodeList;
        this.endPathFindingNodeList = endPathFindingNodeList;
    }

    public virtual BasicArrayList getStartPathFindingNodeList()
    {
        return this.startPathFindingNodeList;
    }

    public virtual BasicArrayList getEndPathFindingNodeList()
    {
        return this.endPathFindingNodeList;
    }

    public virtual GeographicPathFinderBase getPathFinder()
    {
        return this.pathFinder;
    }

    public virtual void addStartPathFindingNode(PathFindingNode startPathFindingNode)
    {
        this.startPathFindingNodeList.add(startPathFindingNode);
    }

    public virtual void addEndPathFindingNode(PathFindingNode endPathFindingNode)
    {
        this.endPathFindingNodeList.add(endPathFindingNode);
    }

    public virtual void setPathFinder(GeographicPathFinderBase pathFinder)
    {
        this.pathFinder = pathFinder;
    }

    public virtual PathFindingNodeCostInfoFactoryBase getPathFindingNodeCostInfoFactoryInterface()
    {
        return this.pathFindingNodeCostInfoFactoryInterface;
    }

}

