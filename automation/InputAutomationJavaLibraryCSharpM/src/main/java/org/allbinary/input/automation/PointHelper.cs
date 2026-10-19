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
//using java.awt;

namespace org.allbinary.input.automation;

public class PointHelper
{
    private static readonly double two = 2.0;
    public PointHelper()
    {
    }

    public static Point getCenterPoint(Rectangle rectangle)
    {
        double x = rectangle.getX() + rectangle.getWidth() / PointHelper.two;
        double y = rectangle.getY() + rectangle.getHeight() / PointHelper.two;
        return PointFactory.getInstance(((int) x), ((int) y));
    }

}

