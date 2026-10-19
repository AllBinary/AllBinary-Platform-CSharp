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
using CellPositionFactory = org.allbinary.graphics.CellPositionFactory;
using GeographicMapCellPositionTracking = org.allbinary.media.graphics.geography.map.GeographicMapCellPositionTracking;

namespace org.allbinary.media.graphics.geography.map.@event;

public class GeographicMapCellPositionEventUtil
{
    private readonly GeographicMapCellPositionEvent geographicMapCellPositionEvent;
    private readonly GeographicMapCellPositionEventHandler geographicMapCellPositionEventHandler = GeographicMapCellPositionEventHandler.getInstance();
    public GeographicMapCellPositionEventUtil(object anyType)
    {
        this.geographicMapCellPositionEvent = new GeographicMapCellPositionEvent(anyType, CellPositionFactory.getInstance().NONE);
    }

    // throws Exception
    public virtual void update(GeographicMapCellPositionTracking geographicMapCellPositionTracking)
    {
        this.geographicMapCellPositionEvent.setGeographicMapCellPosition(geographicMapCellPositionTracking.getCurrentGeographicMapCellPosition());
        this.geographicMapCellPositionEventHandler.fireEvent(this.geographicMapCellPositionEvent);
    }

    // throws Exception
    public virtual void remove(GeographicMapCellPositionTracking geographicMapCellPositionTracking)
    {
        this.geographicMapCellPositionEvent.setGeographicMapCellPosition(geographicMapCellPositionTracking.getCurrentGeographicMapCellPosition());
        this.geographicMapCellPositionEventHandler.fireRemoveEvent(this.geographicMapCellPositionEvent);
    }

}

