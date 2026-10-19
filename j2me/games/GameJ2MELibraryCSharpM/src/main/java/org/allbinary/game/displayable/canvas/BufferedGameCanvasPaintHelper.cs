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
//using Canvas = javax.microedition.lcdui.Canvas;
//using Graphics = javax.microedition.lcdui.Graphics;
//using Image = javax.microedition.lcdui.Image;
//using NullCanvas = javax.microedition.lcdui.NullCanvas;
//using NullImage = javax.microedition.lcdui.NullImage;
using Anchor = org.allbinary.graphics.Anchor;
using MyCanvas = org.allbinary.graphics.displayable.MyCanvas;
using ProcessPaintable = org.allbinary.graphics.paint.ProcessPaintable;
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.game.displayable.canvas;

public class BufferedGameCanvasPaintHelper : ProcessPaintable
{
    private Canvas gameCanvas = NullCanvas.NULL_CANVAS;
    private static readonly int MAX_IMAGES = 4;
    private readonly Image[] offScreenImage = new Image[BufferedGameCanvasPaintHelper.MAX_IMAGES];
    private Image previousImage = NullImage.NULL_IMAGE;
    private readonly CircularIndexUtil circularIndexUtil = CircularIndexUtil.createInstance(BufferedGameCanvasPaintHelper.MAX_IMAGES);
    private readonly CircularIndexUtil drawCircularIndexUtil = CircularIndexUtil.createInstanceAt(BufferedGameCanvasPaintHelper.MAX_IMAGES - 1, BufferedGameCanvasPaintHelper.MAX_IMAGES);
    public BufferedGameCanvasPaintHelper(AllBinaryGameCanvas gameCanvas)
    {
        throw new Exception("No Longer Used");
    }

    public override void process()
    {
        MyCanvas myCanvas = (((MyCanvas) this.gameCanvas));
        myCanvas.draw(this.offScreenImage[this.circularIndexUtil.getIndex()].getGraphics());
        this.circularIndexUtil.next();
        this.drawCircularIndexUtil.next();
    }

    private int anchor = Anchor.TOP_LEFT;
    public override void paint(Graphics graphics)
    {
        this.previousImage = this.offScreenImage[this.drawCircularIndexUtil.getIndex()];
        graphics.drawImage(this.previousImage, 0, 0, this.anchor);
    }

}

