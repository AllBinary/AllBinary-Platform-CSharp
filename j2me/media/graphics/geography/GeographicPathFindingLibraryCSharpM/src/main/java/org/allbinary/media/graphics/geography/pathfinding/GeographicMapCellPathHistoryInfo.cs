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
using GeographicMapCellPosition = org.allbinary.media.graphics.geography.map.GeographicMapCellPosition;
using SimpleGeographicMapCellPositionFactory = org.allbinary.media.graphics.geography.map.SimpleGeographicMapCellPositionFactory;

namespace org.allbinary.media.graphics.geography.pathfinding;

public class GeographicMapCellPathHistoryInfo
{
    private GeographicMapCellPosition previousGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    private GeographicMapCellPosition previousOnPathGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    private GeographicMapCellPosition nextUnvisitedOnPathGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    private GeographicMapCellPosition nextOnPathGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    private GeographicMapCellPosition nextChosenOnPathGeographicMapCellPosition = SimpleGeographicMapCellPositionFactory.NULL_GEOGRAPHIC_MAP_CELL_POSITION;
    public virtual GeographicMapCellPosition getPreviousGeographicMapCellPosition()
    {
        return this.previousGeographicMapCellPosition;
    }

    public virtual void setPreviousGeographicMapCellPosition(GeographicMapCellPosition previousGeographicMapCellPosition)
    {
        this.previousGeographicMapCellPosition = previousGeographicMapCellPosition;
    }

    public virtual GeographicMapCellPosition getPreviousOnPathGeographicMapCellPosition()
    {
        return this.previousOnPathGeographicMapCellPosition;
    }

    public virtual void setPreviousOnPathGeographicMapCellPosition(GeographicMapCellPosition previousOnPathGeographicMapCellPosition)
    {
        this.previousOnPathGeographicMapCellPosition = previousOnPathGeographicMapCellPosition;
    }

    public virtual GeographicMapCellPosition getNextUnvisitedOnPathGeographicMapCellPosition()
    {
        return this.nextUnvisitedOnPathGeographicMapCellPosition;
    }

    public virtual void setNextUnvisitedOnPathGeographicMapCellPosition(GeographicMapCellPosition nextUnvisitedOnPathGeographicMapCellPosition)
    {
        this.nextUnvisitedOnPathGeographicMapCellPosition = nextUnvisitedOnPathGeographicMapCellPosition;
    }

    public virtual GeographicMapCellPosition getNextOnPathGeographicMapCellPosition()
    {
        return this.nextOnPathGeographicMapCellPosition;
    }

    public virtual void setNextOnPathGeographicMapCellPosition(GeographicMapCellPosition nextOnPathGeographicMapCellPosition)
    {
        this.nextOnPathGeographicMapCellPosition = nextOnPathGeographicMapCellPosition;
    }

    public virtual GeographicMapCellPosition getNextChosenOnPathGeographicMapCellPosition()
    {
        return this.nextChosenOnPathGeographicMapCellPosition;
    }

    public virtual void setNextChosenOnPathGeographicMapCellPosition(GeographicMapCellPosition nextChosenOnPathGeographicMapCellPosition)
    {
        this.nextChosenOnPathGeographicMapCellPosition = nextChosenOnPathGeographicMapCellPosition;
    }

}

