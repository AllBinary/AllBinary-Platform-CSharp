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

public class RectangleAdjustedAnimation : Animation, ColorCompositeInterface
{
    private int width;
    private int height;
    private int offsetX;
    private int offsetY;
    public RectangleAdjustedAnimation(int width, int height, int offsetX, int offsetY, BasicColor basicColor)
    {
        this.width = width;
        this.height = height;
        this.offsetX = offsetX;
        this.offsetY = offsetY;
        this.setBasicColorP(basicColor);
    }

    public override void nextFrame()
    {
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        this.basicSetColorUtil.setBasicColorP3(graphics, this.getBasicColorP(), this.getColor());
        graphics.drawRect(x + this.offsetX, y + this.offsetY, this.width, this.height);
    }

    public virtual void setWidth(int width)
    {
        this.width = width;
    }

    public virtual void setHeight(int height)
    {
        this.height = height;
    }

    public virtual void setOffsetX(int offsetX)
    {
        this.offsetX = offsetX;
    }

    public virtual void setOffsetY(int offsetY)
    {
        this.offsetY = offsetY;
    }

}

