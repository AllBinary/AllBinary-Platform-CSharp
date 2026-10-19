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
using Angle = org.allbinary.math.Angle;
using NoDecimalTrigTable = org.allbinary.math.NoDecimalTrigTable;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.graphics.pipeline;

public class BasicGraphicsPipeline
{
    public BasicArrayList pointBasicArrayList;
    public BasicGraphicsPipeline(BasicArrayList points)
    {
        this.pointBasicArrayList = points;
    }

    public virtual void setInitMatrix(BasicArrayList points)
    {
        this.pointBasicArrayList = points;
    }

    public virtual void createMatrix()
    {
    }

    // throws Exception
    public virtual void translate(int x, int y)
    {
        BasicArrayList newBasicArrayList = new BasicArrayListD();
        int size = this.pointBasicArrayList.size();
        PointFactory pointFactory = PointFactory.getInstance();
        GPoint secondPoint = null;
        for (int index = 0; index < size; index++) {
            secondPoint = ((GPoint) this.pointBasicArrayList.objectArray[index]);
            if (secondPoint.getX() != 1000) {
                newBasicArrayList.add(pointFactory.createXY(secondPoint.getX() + x, secondPoint.getY() + y));
            } else {
                newBasicArrayList.add(secondPoint);
            }
        }
        this.pointBasicArrayList = newBasicArrayList;
    }

    // throws Exception
    public virtual void rotateToAngle(Angle angle)
    {
        this.rotate(((int) angle.getValue()));
    }

    private readonly NoDecimalTrigTable noDecimalTrigTable = NoDecimalTrigTable.getInstance();
    // throws Exception
    private void rotate(int angle)
    {
        BasicArrayList newBasicArrayList = new BasicArrayListD();
        GPoint secondPoint = null;
        long y = 0L;
        long secondX = 0L;
        long secondY = 0L;
        GPoint point = null;
        PointFactory pointFactory = PointFactory.getInstance();
        int size = this.pointBasicArrayList.size();
        long sin = 0L;
        long cos = 0L;
        for (int index = 0; index < size; index++) {
            secondPoint = ((GPoint) this.pointBasicArrayList.objectArray[index]);
            if (secondPoint.getX() != 1000) {
                sin = this.noDecimalTrigTable.sin(angle);
                cos = this.noDecimalTrigTable.cos(angle);
                y = secondPoint.getY() * sin;
                secondX = (secondPoint.getX() * cos) - y;
                secondY = (secondPoint.getX() * sin) + (secondPoint.getY() * cos);
                point = pointFactory.createXY(((int) secondX) / 10000, ((int) secondY) / 10000);
                newBasicArrayList.add(point);
            } else {
                newBasicArrayList.add(secondPoint);
            }
        }
        this.pointBasicArrayList = newBasicArrayList;
    }

    // throws Exception
    public virtual void mirror(int width)
    {
        PointFactory pointFactory = PointFactory.getInstance();
        int halfWidth = (width >> 1);
        BasicArrayList newBasicArrayList = new BasicArrayListD();
        GPoint secondPoint = null;
        int newX = 0;
        GPoint point = null;
        int size = this.pointBasicArrayList.size();
        for (int index = 0; index < size; index++) {
            secondPoint = ((GPoint) this.pointBasicArrayList.objectArray[index]);
            if (secondPoint.getX() != 1000) {
                newX = 0;
                if (secondPoint.getX() > halfWidth) {
                    newX = halfWidth - (secondPoint.getX() - halfWidth);
                } else {
                    newX = halfWidth + (halfWidth - secondPoint.getX());
                }
                point = pointFactory.createXY(newX, secondPoint.getY());
                newBasicArrayList.add(point);
            } else {
                newBasicArrayList.add(secondPoint);
            }
        }
        this.pointBasicArrayList = newBasicArrayList;
    }

    public virtual BasicArrayList getMatrix()
    {
        return this.pointBasicArrayList;
    }

}

