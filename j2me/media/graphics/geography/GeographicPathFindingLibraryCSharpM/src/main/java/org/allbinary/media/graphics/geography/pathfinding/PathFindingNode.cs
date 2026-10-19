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
using NullUtil = org.allbinary.logic.NullUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using SimpleGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.SimpleGeographicMapCellPositionFactory;
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace org.allbinary.media.graphics.geography.pathfinding;

public class PathFindingNode
{
    public object parent = NullUtil.getInstance().NULL_OBJECT;
    public GeographicMapCellPosition geographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    public PathFindingNode(object parent, GeographicMapCellPosition geographicMapCellPosition)
    {
        this.parent = parent;
        this.setGeographicMapCellPositionP(geographicMapCellPosition);
        if (this.geographicMapCellPosition == SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION) {
            throw new Exception("No GeographicMapCellPosition");
        }
    }

    public virtual PathFindingNode getParentP()
    {
        return ((PathFindingNode) this.parent);
    }

    public virtual void setGeographicMapCellPositionP(GeographicMapCellPosition geographicMapCellPosition)
    {
        this.geographicMapCellPosition = geographicMapCellPosition;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.GetType().FullName);
        stringBuffer.append(CommonLabels.getInstance().COLON_SEP);
        stringBuffer.append(" Path: ");
        stringBuffer.append(this.geographicMapCellPosition.ToString());
        PathFindingNode pathFindingNode = this.getParentP();
        while (pathFindingNode != null) {
            stringBuffer.append(pathFindingNode.geographicMapCellPosition.ToString());
            stringBuffer.append(CommonSeps.getInstance().SPACE);
            pathFindingNode = pathFindingNode.getParentP();
        }
        return stringBuffer.ToString();
    }

}

