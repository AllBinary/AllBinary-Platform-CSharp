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

namespace org.allbinary.game.paint;

public class OverScanColorFillPaintable : ColorFillPaintable
{
    public OverScanColorFillPaintable(BasicColor basicColor) : base(basicColor)
    {
        // base(basicColor) is called from the constructor declaration
    }

    public override void paint(Graphics graphics)
    {
        graphics.setColor(this.colorP);
        graphics.fillRect(-graphics.getClipX(), -graphics.getClipY(), this.displayInfoSingleton.getLastWidth() + (graphics.getClipX() * 2), this.displayInfoSingleton.getLastHeight() + (graphics.getClipY() * 2));
    }

}

