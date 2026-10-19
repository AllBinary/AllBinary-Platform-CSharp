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
//using NullImage = javax.microedition.lcdui.NullImage;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using NullUtil = org.allbinary.logic.NullUtil;
using PrimitiveIntUtil = org.allbinary.logic.math.PrimitiveIntUtil;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.animation;

public class VectorAnimation : IndexedAnimation, VectorAnimationInterface
{
    public static VectorAnimation createVectorAnimation(int[][] currentPoints2, BasicColor basicColor, AnimationBehavior animationBehavior)
    {
        int[][][] currentPoints = System.Linq.Enumerable.Range(0, 1).Select(_ => System.Linq.Enumerable.Range(0, currentPoints2.Length).Select(_ => new int[2]).ToArray()).ToArray();
        int size = currentPoints2.Length;
        for (int index = 0; index < size; index++) {
            currentPoints[0][index][0] = currentPoints2[index][0];
            currentPoints[0][index][1] = currentPoints2[index][1];
        }
        return new VectorAnimation(currentPoints, basicColor, animationBehavior);
    }

    private int[][][] currentPoints = NullUtil.getInstance().NULL_INT_ARRAY_ARRAY_ARRAY;
    private CircularIndexUtil circularIndexUtil = CircularIndexUtil.createInstance(0);
    public VectorAnimation(int[][][] currentPoints, BasicColor basicColor, AnimationBehavior animationBehavior) : base(animationBehavior)
    {
        // base(animationBehavior) is called from the constructor declaration
        this.setPoints(currentPoints);
        this.setBasicColorP(basicColor);
    }

    public override void setBasicColorP(BasicColor basicColor)
    {
        bool changed = false;
        if (this.getBasicColorP() == null || ((int) this.getBasicColorP()) != ((int) basicColor)) {
            changed = true;
        }
        base.setBasicColorP(basicColor);
        if (changed) {
            this.updateModifiers();
        }
    }

    public override void changeBasicColor(BasicColor basicColor)
    {
        bool changed = false;
        if (this.getChangeBasicColor() == null || ((int) this.getChangeBasicColor()) != ((int) basicColor)) {
            changed = true;
        }
        base.changeBasicColor(basicColor);
        if (changed) {
            this.updateModifiers();
        }
    }

    public override void setAlpha(int alpha)
    {
        bool changed = false;
        if (this.alphaP != alpha) {
            changed = true;
        }
        base.setAlpha(alpha);
        if (changed) {
            this.updateModifiers();
        }
    }

    public override void setScale(float scaleX, float scaleY)
    {
    }

    public override void setMaxScale(float maxScaleX, float maxScaleY)
    {
    }

    private void updateModifiers()
    {
    }

    // throws Exception
    public override int getAnimationSize()
    {
        return this.getSize();
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

    public override void nextFrame()
    {
        this.circularIndexUtil.next();
    }

    public override void previousFrame()
    {
        this.circularIndexUtil.previous();
    }

    protected virtual void paintVectors(Graphics graphics, int x, int y)
    {
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

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.basicSetColorUtil.setBasicColorP(graphics, this.basicColor);
        this.paintVectors(graphics, x, y);
    }

    public override int getFrame()
    {
        return this.circularIndexUtil.getIndex();
    }

    public override void setFrame(int index)
    {
        this.circularIndexUtil.setIndex(index);
    }

    public override int[][] getPoints(int frame)
    {
        return this.currentPoints[frame];
    }

    public virtual void setPoints(int[][][] currentPoints)
    {
        this.currentPoints = currentPoints;
        this.circularIndexUtil = CircularIndexUtil.createInstance(currentPoints.Length);
    }

}

