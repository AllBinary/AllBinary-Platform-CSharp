/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;

namespace org.allbinary.view;

public class ViewPosition : ViewPositionBase
{
    public static ViewPosition getInstanceD()
    {
        return new ViewPosition(0, 0, 0);
    }

    private AllBinaryLayer allbinaryLayer = AllBinaryLayer.NULL_ALLBINARY_LAYER;
    public ViewPosition(int x, int y, int z) : base(x, y, z)
    {
        // base(x, y, z) is called from the constructor declaration
    }

    public override int getX()
    {
        return this.allbinaryLayer.getXP();
    }

    public override int getY()
    {
        return this.allbinaryLayer.getYP();
    }

    public override int getZ()
    {
        return this.allbinaryLayer.getZP();
    }

    public override int getX2()
    {
        return this.getX() + this.allbinaryLayer.getWidth();
    }

    public override int getY2()
    {
        return this.getY() + this.allbinaryLayer.getHeight();
    }

    public override int getZ2()
    {
        return ((int) (this.getZ() + this.allbinaryLayer.getDepth()));
    }

    public override void setAllbinaryLayer(object allbinaryLayer)
    {
        this.allbinaryLayer = ((AllBinaryLayer) allbinaryLayer);
    }

}

