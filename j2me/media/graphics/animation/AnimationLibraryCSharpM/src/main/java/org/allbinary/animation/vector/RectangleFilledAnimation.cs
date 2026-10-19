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

public class RectangleFilledAnimation : Animation, ColorCompositeInterface
{
    public int widthP;
    public int heightP;
    public RectangleFilledAnimation(int width, int height, BasicColor basicColor)
    {
        this.widthP = width;
        this.heightP = height;
        this.setBasicColorP(basicColor);
    }

    public override void nextFrame()
    {
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.basicSetColorUtil.setBasicColorP3(graphics, this.getBasicColorP(), this.getColor());
        graphics.fillRect(x, y, this.widthP, this.heightP);
    }

    public virtual void setWidth(int width)
    {
        this.widthP = width;
    }

    public virtual void setHeight(int height)
    {
        this.heightP = height;
    }

}

