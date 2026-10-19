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
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace org.allbinary.media.graphics.geography.pathfinding;

public class PathFindingNodeCostInfo : Comparable<PathFindingNodeCostInfo>
{
    private readonly PathFindingNodeCostInfoData pathFindingNodeCostInfoData = PathFindingNodeCostInfoData.getInstance();
    public long costFromStartP;
    public long costToEndP;
    public long totalCostP = 0L;
    public PathFindingNodeCostInfo(long costFromStart, long costToGoal)
    {
        this.costFromStartP = costFromStart;
        this.costToEndP = costToGoal;
        this.setCalculatedTotalCost();
    }

    public virtual void setCostToEnd(long costToEnd)
    {
        this.costToEndP = costToEnd;
    }

    public virtual void setTotalCost(long totalCost)
    {
        this.totalCostP = totalCost;
    }

    // throws Exception
    public virtual void setCalculatedTotalCost()
    {
        this.totalCostP = this.costFromStartP + this.costToEndP;
        if (this.totalCostP > this.pathFindingNodeCostInfoData.MAX_NODE_COST) {
            throw new Exception("Max Cost Exceeded");
        }
    }

    public virtual void setCostFromStart(long cost)
    {
        this.costFromStartP = cost;
    }

    public virtual void addCostFromStart(long cost)
    {
        this.costFromStartP += cost;
    }

    public virtual int compareTo(PathFindingNodeCostInfo pathFindingNodeCostInfo)
    {
        return java.lang.Long.compare(this.totalCostP, pathFindingNodeCostInfo.totalCostP);
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.GetType().FullName);
        stringBuffer.append(CommonLabels.getInstance().COLON_SEP);
        stringBuffer.append("CostFromStart: ");
        stringBuffer.appendlong(this.costFromStartP);
        stringBuffer.append(" CostToEnd: ");
        stringBuffer.appendlong(this.costToEndP);
        stringBuffer.append(" TotalCost: ");
        stringBuffer.appendlong(this.totalCostP);
        return stringBuffer.ToString();
    }

}

