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
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;

namespace org.allbinary.graphics.draw;

public class CanvasDrawLineString : UpdateMyFontInterface
{
    public static readonly CanvasDrawLineString NULL_CANVAS_DRAW_LINE_STRING = new CanvasDrawLineString(0, 0);
    private readonly DrawStringUtil drawStringUtil = DrawStringUtil.getInstance();
    private MyFontProcessor myFontProcessor;
    private int x;
    private int y;
    private int fontHeight = 0;
    public CanvasDrawLineString(int x, int y)
    {
        this.myFontProcessor = new UpdateMyFontProcessor(this);
        this.x = x;
        this.y = y;
    }

    public virtual void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.fontHeight = font.getHeight();
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public virtual void paint(Graphics graphics, string @string, int line)
    {
        this.myFontProcessor.process(graphics);
        this.drawStringUtil.drawCenterString(graphics, @string, 0, @string.Length, this.x, this.y + (line * this.fontHeight));
    }

}

