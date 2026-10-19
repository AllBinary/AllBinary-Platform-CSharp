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

namespace org.allbinary.graphics.color;

public class ColorChangeEvent : AllBinaryEventObject
{
    private BasicColor basicColor = BasicColorFactory.getInstance().WHITE;
    public ColorChangeEvent(object anyType) : base(anyType)
    {
        // base(anyType) is called from the constructor declaration
    }

    public virtual void setBasicColorP(BasicColor basicColor)
    {
        this.basicColor = basicColor;
    }

    public virtual BasicColor getBasicColorP()
    {
        return this.basicColor;
    }

}

