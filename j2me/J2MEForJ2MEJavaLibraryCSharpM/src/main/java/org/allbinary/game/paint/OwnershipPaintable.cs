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
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using Paintable = org.allbinary.graphics.paint.Paintable;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.game.paint;

//J2MEForJ2ME
public class OwnershipPaintable : Paintable, UpdateMyFontInterface
{
    public static OwnershipPaintable getInstance()
    {
        return new OwnershipPaintable();
    }

    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
    private MyFontProcessor myFontProcessor;
    private readonly string COPYRIGHT = "AllBinary Copyright (c) 2011";
    private BasicColor basicColor = BasicColorFactory.getInstance().WHITE;
    private int color;
    private int anchor = Anchor.TOP_LEFT;
    private int COPYRIGHT_Y = 0;
    private int beginWidth = 0;
    private OwnershipPaintable()
    {
        this.myFontProcessor = new UpdateMyFontProcessor(this);
        this.color = ((int) this.basicColor);
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.COPYRIGHT_Y = 2 * font.getHeight();
        this.beginWidth = (font.stringWidth(this.COPYRIGHT) >> 1);
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public override void setBasicColorP(BasicColor basicColor)
    {
        this.basicColor = basicColor;
        this.color = ((int) basicColor);
    }

    public virtual BasicColor getBasicColorP()
    {
        return this.basicColor;
    }

    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        graphics.setColor(this.color);
        int halfWidth = this.displayInfo.getLastHalfWidth();
        int height = this.displayInfo.getLastHeight();
        graphics.drawString(this.COPYRIGHT, halfWidth - this.beginWidth, height - this.COPYRIGHT_Y, this.anchor);
    }

}

