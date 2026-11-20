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
using ProgressCanvas = org.allbinary.graphics.canvas.transition.progress.ProgressCanvas;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using PaintableComposite = org.allbinary.graphics.paint.PaintableComposite;
using PaintableInterface = org.allbinary.graphics.paint.PaintableInterface;

namespace org.allbinary.game.displayable.canvas;

public class DemoCanvasProgressUtil
{
    public static void showProgress(DemoCanvas demoCanvas)
    {
        DemoCanvasProgressUtil.showProgressOptionallyInTheBackground(demoCanvas, false);
    }

    public static void showProgressOptionallyInTheBackground(DemoCanvas demoCanvas, bool background)
    {
        ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
        progressCanvas.startBackground(background);
        PaintableInterface[] paintableArray = new PaintableInterface[2];
        paintableArray[0] = progressCanvas;
        paintableArray[1] = demoCanvas.getDefaultPaintableInterface();
        demoCanvas.setDefaultPaintableInterface(new PaintableComposite(paintableArray));
        demoCanvas.setPaintableInterface(demoCanvas.getDefaultPaintableInterface());
    }

}

