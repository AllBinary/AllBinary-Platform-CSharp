/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2006 AllBinary
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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace org.allbinary.media.graphics.geography.pathfinding;

public class PathFindingNodeCost : PathFindingNode, Comparable<PathFindingNodeCost>
{
    public static readonly PathFindingNodeCost[][] NULL_PATH_FINDING_NODE_COST_ARRAY_ARRAY = System.Linq.Enumerable.Range(0, 0).Select(_ => new PathFindingNodeCost[0]).ToArray();
    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    public PathFindingNodeCostInfo pathFindingNodeCostInfoP;
    public PathFindingNodeCost(object parent, GeographicMapCellPosition geographicMapCellPosition, PathFindingNodeCostInfo pathFindingNodeCostInfo) : base(parent, geographicMapCellPosition)
    {
        // base(parent, geographicMapCellPosition) is called from the constructor declaration
        this.pathFindingNodeCostInfoP = pathFindingNodeCostInfo;
        if (this.geographicMapCellPosition == null) {
            throw new Exception("No GeographicMapCellPosition");
        }
        if (this.getPathFindingNodeCostInfo() == null) {
            throw new Exception("No PathFindingNodeCostInfo");
        }
    }

    public virtual PathFindingNodeCostInfo getPathFindingNodeCostInfo()
    {
        return this.pathFindingNodeCostInfoP;
    }

    public virtual void setPathFindingNodeCostInfo(PathFindingNodeCostInfo pathFindingNodeCostInfo)
    {
        this.pathFindingNodeCostInfoP = pathFindingNodeCostInfo;
    }

    public override int compareTo(PathFindingNodeCost pathFindingNodeCost)
    {
        return this.pathFindingNodeCostInfoP.compareTo(pathFindingNodeCost.pathFindingNodeCostInfoP);
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.GetType().FullName);
        stringBuffer.append(CommonLabels.getInstance().COLON_SEP);
        stringBuffer.append(this.getPathFindingNodeCostInfo().ToString());
        stringBuffer.append(" Path: ");
        stringBuffer.append(this.geographicMapCellPosition.ToString());
        PathFindingNode pathFindingNode = ((PathFindingNode) this.parent);
        while (pathFindingNode != null) {
            stringBuffer.append(pathFindingNode.geographicMapCellPosition.ToString());
            stringBuffer.append(this.commonSeps.SPACE);
            pathFindingNode = ((PathFindingNode) pathFindingNode.parent);
        }
        return stringBuffer.ToString();
    }

}

