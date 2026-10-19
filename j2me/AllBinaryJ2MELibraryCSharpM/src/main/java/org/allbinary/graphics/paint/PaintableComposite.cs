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

public class PaintableComposite : Paintable
{
    private PaintableInterface[] paintableArray;
    public PaintableComposite(PaintableInterface[] paintableArray)
    {
        this.paintableArray = paintableArray;
    }

    public override void paint(Graphics graphics)
    {
        for (int index = this.paintableArray.Length - 1; index >= 0; index--) {
            this.paintableArray[index].paint(graphics);
        }
    }

    public override void paintThreed(Graphics graphics)
    {
        for (int index = this.paintableArray.Length - 1; index >= 0; index--) {
            this.paintableArray[index].paintThreed(graphics);
        }
    }

}

