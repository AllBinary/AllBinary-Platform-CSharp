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
using BoundsChangeEvent = org.allbinary.bounds.@event.BoundsChangeEvent;
using BoundsChangeEventListener = org.allbinary.bounds.@event.BoundsChangeEventListener;
using Rectangle = org.allbinary.graphics.Rectangle;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;
using EventStrings = org.allbinary.logic.util.@event.EventStrings;

namespace org.allbinary.bounds;

public class LayerBounds : BoundsChangeEventListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public Rectangle rectangle;
    public LayerBounds(Rectangle rectangle)
    {
        this.rectangle = rectangle;
    }

    public virtual Rectangle getRectangleP()
    {
        return this.rectangle;
    }

    public virtual void visit(BoundsVisitorInterface boundsVisitorInterface)
    {
    }

    public virtual void onEvent(AllBinaryEventObject eventObject)
    {
        ForcedLogUtil.log(EventStrings.getInstance().PERFORMANCE_MESSAGE, this);
    }

    public virtual void onBoundsChangeEvent(BoundsChangeEvent boundsChangeEvent)
    {
        this.rectangle = boundsChangeEvent.getRectangle();
    }

}

