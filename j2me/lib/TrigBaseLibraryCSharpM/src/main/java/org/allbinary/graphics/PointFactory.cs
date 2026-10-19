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
//using JsType = jsinterop.annotations.JsType;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsConstructor = jsinterop.annotations.JsConstructor;
//using JsProperty = jsinterop.annotations.JsProperty;

namespace org.allbinary.graphics;

public class PointFactory
{
    private static readonly PointFactory instance = new PointFactory();
    public static PointFactory getInstance()
    {
        return PointFactory.instance;
    }

    public GPoint ZERO_ZERO;
    public virtual void init()
    {
    }

    private PointFactory()
    {
        this.ZERO_ZERO = this.createXYZ(0, 0, 0);
    }

    public virtual GPoint createXY(int x, int y)
    {
        return new GPoint(x, y, 0);
    }

    public virtual GPoint createXYZ(int x, int y, int z)
    {
        return new GPoint(x, y, z);
    }

}

