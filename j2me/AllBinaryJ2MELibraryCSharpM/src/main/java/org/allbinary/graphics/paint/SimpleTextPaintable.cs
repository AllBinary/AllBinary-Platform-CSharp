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
using BasicColor = org.allbinary.graphics.color.BasicColor;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;

namespace org.allbinary.graphics.paint;

public class SimpleTextPaintable : Paintable, UpdateMyFontInterface
{
    private readonly DisplayInfoSingleton displayInfoSingleton = DisplayInfoSingleton.getInstance();
    private readonly MyFontProcessor updateMyFontProcessor;
    private MyFontProcessor myFontProcessor;
    private string text;
    private BasicColor basicColor;
    private int topScoresWidth = 0;
    private int fontHeight = 0;
    private int anchor = Anchor.TOP_LEFT;
    public SimpleTextPaintable(string text, BasicColor basicColor)
    {
        this.updateMyFontProcessor = new UpdateMyFontProcessor(this);
        this.myFontProcessor = this.updateMyFontProcessor;
        this.text = text;
        this.basicColor = basicColor;
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.topScoresWidth = (font.stringWidth(this.text) >> 1);
        this.fontHeight = font.getHeight();
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        int width = this.displayInfoSingleton.getLast()[this.displayInfoSingleton.WIDTH];
        graphics.setColor(((int) this.getBasicColorP()));
        graphics.drawString(this.text, (width >> 1) - this.topScoresWidth, this.fontHeight, this.anchor);
    }

    public override void setBasicColorP(BasicColor basicColor)
    {
        this.basicColor = basicColor;
    }

    private BasicColor getBasicColorP()
    {
        return this.basicColor;
    }

    public virtual void setText(string text)
    {
        this.text = text;
        this.myFontProcessor = this.updateMyFontProcessor;
    }

    public virtual string getText()
    {
        return this.text;
    }

}

