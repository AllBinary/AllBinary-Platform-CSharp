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
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using CanvasDrawLineString = org.allbinary.graphics.draw.CanvasDrawLineString;
using InitUpdatePaintable = org.allbinary.graphics.paint.InitUpdatePaintable;

namespace org.allbinary.game.displayable.canvas;

public class PreGameSelectorPaintable : InitUpdatePaintable
{
    private readonly string title;
    private CanvasDrawLineString canvasDrawLineString;
    private readonly PreGameScrollSelectionForm preGameScrollSelectionForm;
    public PreGameSelectorPaintable(string title, PreGameScrollSelectionForm preGameScrollSelectionForm)
    {
        this.title = title;
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        this.canvasDrawLineString = new CanvasDrawLineString(displayInfo.getLastHalfWidth(), 0);
        this.preGameScrollSelectionForm = preGameScrollSelectionForm;
    }

    public override void update()
    {
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        this.canvasDrawLineString = new CanvasDrawLineString(displayInfo.getLastHalfWidth(), 0);
    }

    public override void paint(Graphics graphics)
    {
        graphics.setColor(((int) BasicColorFactory.getInstance().WHITE));
        this.canvasDrawLineString.paint(graphics, title, 0);
        this.getPreGameSelectionForm().paint(graphics);
    }

    public virtual PreGameScrollSelectionForm getPreGameSelectionForm()
    {
        return this.preGameScrollSelectionForm;
    }

}

