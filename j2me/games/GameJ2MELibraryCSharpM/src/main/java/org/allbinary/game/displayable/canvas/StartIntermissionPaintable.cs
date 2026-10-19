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
using BasicColorSetUtil = org.allbinary.graphics.color.BasicColorSetUtil;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using FontDebugFactory = org.allbinary.graphics.font.FontDebugFactory;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using InitUpdatePaintable = org.allbinary.graphics.paint.InitUpdatePaintable;
using NullUtil = org.allbinary.logic.NullUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.game.displayable.canvas;

public class StartIntermissionPaintable : InitUpdatePaintable, UpdateMyFontInterface
{
    public readonly FontDebugFactory fontDebugFactory = FontDebugFactory.getInstance();
    public readonly BasicColorSetUtil basicSetColorUtil = BasicColorSetUtil.getInstance();
    public readonly AllBinaryGameCanvas gameCanvas;
    public readonly string[] stringArray;
    public readonly int fontSize;
    public readonly Font font;
    public readonly int[] lastWidth;
    private readonly MyFontProcessor updateMyFontProcessor;
    private MyFontProcessor myFontProcessor;
    private BasicColor basicColor = BasicColorFactory.getInstance().BLACK;
    private int color;
    public int[] lineYOffsetArray = NullUtil.getInstance().NULL_INT_ARRAY;
    private bool hasChanged = true;
    private int anchor = Anchor.TOP_LEFT;
    public int fontHeightP = 0;
    public StartIntermissionPaintable(AllBinaryGameCanvas gameCanvas, string[] stringArray, BasicColor basicColor, Font font)
    {
        this.updateMyFontProcessor = new UpdateMyFontProcessor(this);
        this.myFontProcessor = this.updateMyFontProcessor;
        this.gameCanvas = gameCanvas;
        this.stringArray = stringArray;
        this.lastWidth = new int[this.stringArray.Length];
        this.setBasicColorP(basicColor);
        this.color = ((int) basicColor);
        this.fontSize = font.getSize();
        this.font = font;
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.fontHeightP = font.getHeight();
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        Font existingFont = graphics.getFont();
        this.fontDebugFactory.setFont(this.font, graphics);
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        this.basicSetColorUtil.setBasicColorP3(graphics, this.basicColor, this.color);
        int beginWidth = 0;
        for (int index = this.lineYOffsetArray.Length - 1; index >= 0; index--) {
            if (this.hasChanged) {
                this.lastWidth[index] = (graphics.getFont().stringWidth(this.stringArray[index]) >> 1);
            }
            beginWidth = this.lastWidth[index];
            graphics.drawString(this.stringArray[index], displayInfo.getLastHalfWidth() - beginWidth, displayInfo.getLastHalfHeight() - this.lineYOffsetArray[index], this.anchor);
        }
        this.hasChanged = false;
        this.fontDebugFactory.setFont(existingFont, graphics);
    }

    private readonly string BEGIN_LEVEL = "Begin Level ";
    private readonly string EMPTY_STRING = StringUtil.getInstance().EMPTY_STRING;
    public override void update()
    {
        int level = this.gameCanvas.getLayerManager().getGameInfo().getCurrentLevel();
        this.stringArray[0] = new StringMaker().append(this.BEGIN_LEVEL).appendint(level).ToString();
        for (int index = this.stringArray.Length - 1; index >= 1; index--) {
            this.stringArray[index] = this.EMPTY_STRING;
        }
    }

    public override void setBasicColorP(BasicColor basicColor)
    {
        this.basicColor = basicColor;
    }

    public virtual BasicColor getBasicColorP()
    {
        return this.basicColor;
    }

}

