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
using GPoint = org.allbinary.graphics.GPoint;

namespace org.allbinary.view;

public class ViewPositionBase : GPoint
{
    public static readonly ViewPositionBase NULL_VIEW_POSITION = new ViewPositionBase(0, 0, 0);
    protected ViewPositionBase(int x, int y, int z) : base(x, y, z)
    {
        // base(x, y, z) is called from the constructor declaration
    }

    public virtual int getX2()
    {
        return this.getX();
    }

    public virtual int getY2()
    {
        return this.getY();
    }

    public virtual int getZ2()
    {
        return this.getZ();
    }

    public virtual void setAllbinaryLayer(object allbinaryLayer)
    {
    }

}

