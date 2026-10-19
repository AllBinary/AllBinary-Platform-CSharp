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
using PointFactory = org.allbinary.graphics.PointFactory;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.graphics.pipeline;

public class GraphicsPipeline : BasicGraphicsPipeline
{
    public GraphicsPipeline(BasicArrayList points) : base(points)
    {
        // base(points) is called from the constructor declaration
    }

    // throws Exception
    public virtual void rotateTheta(double aTheta)
    {
        BasicArrayList newVector = new BasicArrayListD();
        int size = this.pointBasicArrayList.size();
        for (int index = 0; index < size; index++) {
            GPoint secondPoint = ((GPoint) pointBasicArrayList.get(index));
            double secondX = (secondPoint.getX() * Math.Cos(aTheta)) - (secondPoint.getY() * Math.Sin(aTheta));
            double secondY = (secondPoint.getX() * Math.Sin(aTheta)) + (secondPoint.getY() * Math.Cos(aTheta));
            GPoint point = PointFactory.getInstance().createXY((((int) secondX)), (((int) secondY)));
            newVector.add(point);
        }
        this.pointBasicArrayList = newVector;
    }

}

