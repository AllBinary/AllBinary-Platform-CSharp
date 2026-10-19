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
//using Graphics = javax.microedition.lcdui.Graphics;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using NullUtil = org.allbinary.logic.NullUtil;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using AngleInfo = org.allbinary.math.AngleInfo;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.animation;

public class VectorBaseRotationAnimation : RotationAnimation, VectorAnimationInterface
{
    private int[][][] currentPoints = NullUtil.getInstance().NULL_INT_ARRAY_ARRAY_ARRAY;
    public VectorBaseRotationAnimation(AngleInfo angleInfo, int[][][] currentPoints, BasicColor basicColor, AnimationBehavior animationBehavior) : base(angleInfo, CircularIndexUtil.createInstance(360 / angleInfo.getAngleIncrementInfo().getAngleIncrement()), animationBehavior)
    {
        // base(angleInfo, CircularIndexUtil.createInstance(360 / angleInfo.getAngleIncrementInfo().getAngleIncrement()), animationBehavior) is called from the constructor declaration
        this.setPoints(currentPoints);
        this.setBasicColorP(basicColor);
    }

    // throws Exception
    public override int getAnimationSize()
    {
        return this.getSize();
    }

    public override int getFrame()
    {
        return this.circularIndexUtil.getIndex();
    }

    public override void setFrame(int index)
    {
        this.circularIndexUtil.setIndex(index);
    }

    public override void nextFrame()
    {
        this.circularIndexUtil.next();
    }

    public override void previousFrame()
    {
        this.circularIndexUtil.previous();
    }

    public override int getSize()
    {
        return this.currentPoints.Length;
    }

    public override void setSequence(int[] sequence)
    {
    }

    public override int[] getSequence()
    {
        return PrimitiveIntUtil.getArrayInstance();
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.basicSetColorUtil.setBasicColorP(graphics, this.basicColor);
        try {
            int nextPointX = 0;
            int nextPointY = 0;
            int[] nextPoint = null;
            int[] point = null;
            int[][] currentPointsFrame = this.currentPoints[this.circularIndexUtil.getIndex()];
            int size = currentPointsFrame.Length;
            int index = size - 2;
            while (--index >= 0) {
                nextPoint = currentPointsFrame[index];
                point = currentPointsFrame[index + 1];
                nextPointX = nextPoint[0];
                nextPointY = nextPoint[1];
                if (nextPointX != 1000) {
                    graphics.drawLine(point[0] + x, point[1] + y, nextPointX + x, nextPointY + y);
                } else {
                    index--;
                }
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "paintVectors", e);
        }
    }

    public override int[][] getPoints(int frame)
    {
        return this.currentPoints[frame];
    }

    public virtual void setPoints(int[][][] currentPoints)
    {
        this.currentPoints = currentPoints;
        this.circularIndexUtil = CircularIndexUtil.createInstance(this.currentPoints.Length);
    }

}

