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
using Paintable = org.allbinary.graphics.paint.Paintable;
using PaintableInterface = org.allbinary.graphics.paint.PaintableInterface;
using Layer = org.allbinary.layer.Layer;

namespace org.allbinary.game.layer;

public class PaintableLayerComposite : Paintable
{
    private readonly Layer[] paintableArray;
    public PaintableLayerComposite(Layer[] paintableArray)
    {
        this.paintableArray = paintableArray;
    }

    public override void paint(Graphics graphics)
    {
        for (int index = this.paintableArray.Length; --index >= 0; ) {
            this.paintableArray[index].paint(graphics);
        }
    }

    public override void paintThreed(Graphics graphics)
    {
        PaintableInterface paintableInterface = null;
        for (int index = this.paintableArray.Length; --index >= 0; ) {
            paintableInterface = ((PaintableInterface) this.paintableArray[index]);
            paintableInterface.paintThreed(graphics);
        }
    }

}

