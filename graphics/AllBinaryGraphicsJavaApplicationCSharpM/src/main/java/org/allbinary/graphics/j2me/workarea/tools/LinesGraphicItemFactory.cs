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
using CanvasJPanel = org.allbinary.graphics.j2me.workarea.canvas.CanvasJPanel;

namespace org.allbinary.graphics.j2me.workarea.tools;

public class LinesGraphicItemFactory : GraphicsItemInterfaceFactoryInterface
{
    public virtual GraphicItemInterface getInstance(CanvasJPanel canvasJPanel)
    {
        return new LinesGraphicItem();
    }

}

