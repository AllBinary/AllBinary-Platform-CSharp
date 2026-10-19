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

namespace org.allbinary.graphics;

public class CustomGPoint : GPoint
{
    public static readonly CustomGPoint NULL_CUSTOM_POINT = new CustomGPoint(0, 0, 0);
    public static CustomGPoint getInstance(GPoint point)
    {
        return new CustomGPoint(point.getX(), point.getY(), point.getZ());
    }

    public static CustomGPoint getInstance3(int x, int y)
    {
        return new CustomGPoint(x, y, 3);
    }

    private int cx = 0;
    private int cy = 0;
    private int cz = 0;
    public CustomGPoint(int x, int y, int z) : base(x, y, z)
    {
        // base(x, y, z) is called from the constructor declaration
    }

    public virtual void setX(int x)
    {
        this.cx = x;
    }

    public override int getX()
    {
        return this.cx;
    }

    public virtual void setY(int y)
    {
        this.cy = y;
    }

    public override int getY()
    {
        return this.cy;
    }

    public virtual void setZ(int z)
    {
        this.cz = z;
    }

    public override int getZ()
    {
        return this.cz;
    }

}

