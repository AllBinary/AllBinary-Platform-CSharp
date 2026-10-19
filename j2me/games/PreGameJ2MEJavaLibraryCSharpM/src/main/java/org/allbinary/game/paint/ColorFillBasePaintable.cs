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
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using ColorCompositeInterface = org.allbinary.graphics.color.ColorCompositeInterface;
using Paintable = org.allbinary.graphics.paint.Paintable;

namespace org.allbinary.game.paint;

public class ColorFillBasePaintable : Paintable, ColorCompositeInterface
{
    public BasicColor basicColor = BasicColorFactory.getInstance().WHITE;
    public int colorP = 0;
    public ColorFillBasePaintable(BasicColor basicColor)
    {
        this.setBasicColorP(basicColor);
    }

    public override void setBasicColorP(BasicColor basicColor)
    {
        this.basicColor = basicColor;
        this.setColor(((int) this.getBasicColorP()));
    }

    public override BasicColor getBasicColorP()
    {
        return this.basicColor;
    }

    protected virtual int getColor()
    {
        return this.colorP;
    }

    protected virtual void setColor(int color)
    {
        this.colorP = color;
    }

    public override void paint(Graphics graphics)
    {
    }

}

