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
using Rectangle = org.allbinary.graphics.Rectangle;
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.bounds.@event;

public class BoundsChangeEvent : AllBinaryEventObject
{
    public BoundsChangeEvent(Rectangle rectangle) : base(rectangle)
    {
        // base(rectangle) is called from the constructor declaration
    }

    public virtual Rectangle getRectangle()
    {
        return ((Rectangle) this.getSource());
    }

}

