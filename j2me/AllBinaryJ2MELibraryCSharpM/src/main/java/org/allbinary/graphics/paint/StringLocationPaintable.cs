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

namespace org.allbinary.graphics.paint;

public class StringLocationPaintable : LocationPaintable
{
    private readonly string value;
    public StringLocationPaintable(string value)
    {
        this.value = value;
    }

    public override void paintXY(Graphics graphics, int x, int y)
    {
        graphics.drawString(this.value, x, y, 0);
    }

}

