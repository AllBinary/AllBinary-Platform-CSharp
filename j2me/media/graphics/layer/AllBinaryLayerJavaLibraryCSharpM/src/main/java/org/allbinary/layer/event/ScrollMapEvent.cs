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
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.layer.@event;

public class ScrollMapEvent : AllBinaryEventObject
{
    private int dx = 0;
    private int dy = 0;
    public ScrollMapEvent(object anyType) : base(anyType)
    {
        // base(anyType) is called from the constructor declaration
    }

    public virtual void setDx(int dx)
    {
        this.dx = dx;
    }

    public virtual int getDx()
    {
        return this.dx;
    }

    public virtual void setDy(int dy)
    {
        this.dy = dy;
    }

    public virtual int getDy()
    {
        return this.dy;
    }

    public virtual void setDxDy(int dx, int dy)
    {
        this.dx = dx;
        this.dy = dy;
    }

}

