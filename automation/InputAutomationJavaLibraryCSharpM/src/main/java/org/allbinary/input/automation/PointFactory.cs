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

public class PointFactory
{
    private static Point[][] pointArray = System.Linq.Enumerable.Range(0, 3000).Select(_ => new Point[3000]).ToArray();
    private PointFactory()
    {
    }

    public static Point getInstance(int x, int y)
    {
        Point point = PointFactory.pointArray[x][y];
        if (point == null) {
            PointFactory.pointArray[x][y] = new Point(x, y);
            point = PointFactory.pointArray[x][y];
        }
        return point;
    }

}

