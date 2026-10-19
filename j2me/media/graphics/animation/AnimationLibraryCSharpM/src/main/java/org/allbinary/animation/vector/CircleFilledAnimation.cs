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

namespace org.allbinary.animation.vector;

public class CircleFilledAnimation : Animation, ColorCompositeInterface
{
    private int width;
    private int height;
    public CircleFilledAnimation(int width, int height, BasicColor basicColor) : base()
    {
        // base() is called from the constructor declaration
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
        graphics.fillRect(x, y, this.width, this.height);
    }

}

