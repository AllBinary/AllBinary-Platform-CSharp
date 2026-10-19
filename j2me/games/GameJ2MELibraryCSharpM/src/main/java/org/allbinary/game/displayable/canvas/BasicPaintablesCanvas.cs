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
//using CommandListener = javax.microedition.lcdui.CommandListener;
//using Graphics = javax.microedition.lcdui.Graphics;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using ColorFillBasePaintable = org.allbinary.game.paint.ColorFillBasePaintable;
using ColorFillPaintableFactory = org.allbinary.game.paint.ColorFillPaintableFactory;
using Paintable = org.allbinary.graphics.paint.Paintable;

namespace org.allbinary.game.displayable.canvas;

public class BasicPaintablesCanvas : GameCommandCanvas
{
    private readonly Paintable[] paintableArray;
    private readonly ColorFillBasePaintable colorFillPaintable;
    public BasicPaintablesCanvas(CommandListener cmdListener, string name, AllBinaryGameLayerManager allBinaryGameLayerManager, Paintable[] paintableArray) : base(cmdListener, name, allBinaryGameLayerManager.getBackgroundBasicColor(), allBinaryGameLayerManager.getForegroundBasicColor())
    {
        // base(cmdListener, name, allBinaryGameLayerManager.getBackgroundBasicColor(), allBinaryGameLayerManager.getForegroundBasicColor()) is called from the constructor declaration
        this.paintableArray = paintableArray;
        this.colorFillPaintable = ColorFillPaintableFactory.getInstance().getInstance(allBinaryGameLayerManager.getBackgroundBasicColor(), false);
    }

    public override void paint(Graphics graphics)
    {
        this.colorFillPaintable.paint(graphics);
        graphics.setColor(this.foregroundColor);
        for (int index = this.paintableArray.Length - 1; index >= 0; index--) {
            this.paintableArray[index].paint(graphics);
        }
        base.paint(graphics);
    }

}

