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
using Paintable = org.allbinary.graphics.paint.Paintable;
using NullUtil = org.allbinary.logic.NullUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.paint.help;

public class HelpPaintable : Paintable, UpdateMyFontInterface
{
    public readonly DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
    public readonly MyFontProcessor updateMyFontProcessor;
    public MyFontProcessor myFontProcessor;
    public int anchor = Anchor.TOP_LEFT;
    public readonly string title;
    public string[] inputInfo = StringUtil.getInstance().getArrayInstance();
    public BasicColor basicColor;
    public int titleBeginWidth = 0;
    private int[] beginWidthArray = NullUtil.getInstance().NULL_INT_ARRAY;
    private int charHeight = 0;
    public HelpPaintable(string title, BasicColor backgroundBasicColor, BasicColor basicColor)
    {
        this.updateMyFontProcessor = new UpdateMyFontProcessor(this);
        this.myFontProcessor = this.updateMyFontProcessor;
        this.title = title;
        this.basicColor = basicColor;
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.titleBeginWidth = (font.stringWidth(this.title) >> 1);
        this.charHeight = font.getHeight();
        int size = this.inputInfo.Length;
        for (int index = 0; index < size; index++) {
            this.beginWidthArray[index] = (font.stringWidth(this.inputInfo[index]) >> 1);
        }
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public virtual void setInputInfoP(string[] inputInfo)
    {
        this.inputInfo = inputInfo;
        this.beginWidthArray = new int[this.inputInfo.Length];
        this.myFontProcessor = this.updateMyFontProcessor;
    }

    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        int halfWidth = this.displayInfo.getLastHalfWidth();
        graphics.setColor(((int) this.basicColor));
        graphics.drawString(this.title, halfWidth - this.titleBeginWidth, this.charHeight, this.anchor);
        int size = this.inputInfo.Length;
        for (int index = 0; index < size; index++) {
            graphics.drawString(this.inputInfo[index], halfWidth - this.beginWidthArray[index], (index + 3) * this.charHeight, this.anchor);
        }
    }

}

