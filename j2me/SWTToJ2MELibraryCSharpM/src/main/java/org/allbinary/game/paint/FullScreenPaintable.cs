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
using Anchor = org.allbinary.graphics.Anchor;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using Paintable = org.allbinary.graphics.paint.Paintable;

namespace org.allbinary.game.paint;

//SwtToJ2ME
public class FullScreenPaintable : Paintable, UpdateMyFontInterface
{
    public static FullScreenPaintable getInstance()
    {
        return new FullScreenPaintable();
    }

    private readonly DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
    private MyFontProcessor myFontProcessor;
    private readonly string FULLSCREEN_TEXT = "F11 - Toggle Fullscreen";
    private int anchor = Anchor.TOP_LEFT;
    private int Y = 0;
    private int beginWidth = 0;
    private FullScreenPaintable()
    {
        this.myFontProcessor = new UpdateMyFontProcessor(this);
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.Y = 4 * font.getHeight();
        this.beginWidth = (font.stringWidth(this.FULLSCREEN_TEXT) >> 1);
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        int halfWidth = this.displayInfo.getLastHalfWidth();
        int height = this.displayInfo.getLastHeight();
        graphics.drawString(this.FULLSCREEN_TEXT, halfWidth - this.beginWidth, height - this.Y, this.anchor);
    }

}

