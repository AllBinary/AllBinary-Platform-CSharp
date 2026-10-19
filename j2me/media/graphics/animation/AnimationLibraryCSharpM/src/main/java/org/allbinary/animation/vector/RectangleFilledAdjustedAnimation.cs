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
using ColorCompositeInterface = org.allbinary.graphics.color.ColorCompositeInterface;

namespace org.allbinary.animation.vector;

public class RectangleFilledAdjustedAnimation : RectangleFilledAnimation, ColorCompositeInterface
{
    private int offsetX;
    private int offsetY;
    public RectangleFilledAdjustedAnimation(int width, int height, int offsetX, int offsetY, BasicColor basicColor) : base(width, height, basicColor)
    {
        // base(width, height, basicColor) is called from the constructor declaration
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
        base.paintXY(graphics, x + this.offsetX, y + this.offsetY);
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

