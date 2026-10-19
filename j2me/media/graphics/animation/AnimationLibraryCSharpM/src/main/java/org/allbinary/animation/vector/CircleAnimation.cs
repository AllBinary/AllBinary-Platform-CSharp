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
using AngleFactory = org.allbinary.math.AngleFactory;

namespace org.allbinary.animation.vector;

public class CircleAnimation : Animation, ColorCompositeInterface
{
    public readonly int TOTAL_ANGLE = ((int) AngleFactory.getInstance().TOTAL_ANGLE);
    public int width;
    public int height;
    public CircleAnimation(int width, int height, BasicColor basicColor)
    {
        this.width = width;
        this.height = height;
        this.setBasicColorP(basicColor);
    }

    public override void nextFrame()
    {
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.basicSetColorUtil.setBasicColorP3(graphics, this.getBasicColorP(), this.getColor());
        graphics.drawArc(x, y, this.width, this.height, 0, this.TOTAL_ANGLE);
    }

}

