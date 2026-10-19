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
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;

namespace org.allbinary.game.paint;

public class ColorFillPaintable : ColorFillBasePaintable
{
    public readonly DisplayInfoSingleton displayInfoSingleton = DisplayInfoSingleton.getInstance();
    public ColorFillPaintable(BasicColor basicColor) : base(basicColor)
    {
        // base(basicColor) is called from the constructor declaration
    }

    public override void paint(Graphics graphics)
    {
        graphics.setColor(this.colorP);
        graphics.fillRect(0, 0, this.displayInfoSingleton.getLastWidth(), this.displayInfoSingleton.getLastHeight());
    }

}

