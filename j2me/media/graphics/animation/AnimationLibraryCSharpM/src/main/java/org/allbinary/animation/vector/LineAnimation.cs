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
using Animation = org.allbinary.animation.Animation;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using ColorCompositeInterface = org.allbinary.graphics.color.ColorCompositeInterface;
using PositionInterface = org.allbinary.layer.PositionInterface;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.animation.vector;

public class LineAnimation : Animation, ColorCompositeInterface, PositionInterface
{
    private int[][] newLine = System.Linq.Enumerable.Range(0, 2).Select(_ => new int[2]).ToArray();
    private int[][] tempLine = NullUtil.getInstance().NULL_INT_ARRAY_ARRAY;
    private int[][] line = System.Linq.Enumerable.Range(0, 2).Select(_ => new int[2]).ToArray();
    public LineAnimation(BasicColor basicColor)
    {
        this.setBasicColorP(basicColor);
    }

    public virtual void init(int x, int y)
    {
        this.newLine[0][0] = x;
        this.newLine[0][1] = y;
        this.newLine[1][0] = x;
        this.newLine[1][1] = y;
        this.tempLine = this.line;
        this.line = this.newLine;
        this.newLine = this.tempLine;
    }

    public override void setPosition(int x, int y, int z)
    {
        this.newLine[0][0] = this.line[1][0];
        this.newLine[0][1] = this.line[1][1];
        this.newLine[1][0] = x;
        this.newLine[1][1] = y;
        this.tempLine = this.line;
        this.line = this.newLine;
        this.newLine = this.tempLine;
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        int[][] currentLine = this.line;
        this.basicSetColorUtil.setBasicColorP3(graphics, this.getBasicColorP(), this.getColor());
        graphics.drawLine(currentLine[0][0], currentLine[0][1], currentLine[1][0], currentLine[1][1]);
    }

    public override void nextFrame()
    {
    }

}

