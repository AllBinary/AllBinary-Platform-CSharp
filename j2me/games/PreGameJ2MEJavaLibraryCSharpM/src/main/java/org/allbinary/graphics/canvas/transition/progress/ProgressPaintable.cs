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
using Graphics = javax.microedition.lcdui.Graphics;
using Paintable = org.allbinary.graphics.paint.Paintable;

namespace org.allbinary.graphics.canvas.transition.progress;

public class ProgressPaintable : Paintable
{
    private readonly ProgressCanvas progressCanvas;
    public ProgressPaintable(ProgressCanvas progressCanvas)
    {
        this.progressCanvas = progressCanvas;
    }

    public override void paint(Graphics graphics)
    {
        this.progressCanvas.paint2(graphics);
    }

}

