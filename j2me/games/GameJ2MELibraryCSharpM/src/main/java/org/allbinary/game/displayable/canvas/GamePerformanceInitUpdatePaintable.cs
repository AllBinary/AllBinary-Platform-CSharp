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
using GameStatisticsFactory = org.allbinary.canvas.GameStatisticsFactory;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using UpdateMyFontInterface = org.allbinary.graphics.font.UpdateMyFontInterface;
using UpdateMyFontProcessor = org.allbinary.graphics.font.UpdateMyFontProcessor;
using InitUpdatePaintable = org.allbinary.graphics.paint.InitUpdatePaintable;

namespace org.allbinary.game.displayable.canvas;

public class GamePerformanceInitUpdatePaintable : InitUpdatePaintable, UpdateMyFontInterface
{
    private readonly int halfHeight = DisplayInfoSingleton.getInstance().getLastHalfHeight();
    private readonly int[] yArray;
    private MyFontProcessor myFontProcessor;
    private char[][] baseRefreshHelperCharArray = System.Linq.Enumerable.Range(0, 0).Select(_ => new char[0]).ToArray();
    private int defaultStringWidth = 0;
    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.defaultStringWidth = MyFontProcessor.defaultStringWidth(font, 2);
        this.myFontProcessor = MyFontProcessor.getInstance();
    }

    public override void init()
    {
    }

    public override void update()
    {
        this.baseRefreshHelperCharArray = GameStatisticsFactory.getInstance().to2DCharArray();
    }

    private readonly int RED = ((int) BasicColorFactory.getInstance().RED);
    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        graphics.setColor(this.RED);
        char[] charArray = null;
        char[] charArray2 = null;
        int size2 = 0;
        int size3 = 0;
        int size = this.baseRefreshHelperCharArray.Length - 2;
        for (int index = size; index >= 0; index -= 2) {
            charArray = this.baseRefreshHelperCharArray[index];
            charArray2 = this.baseRefreshHelperCharArray[index + 1];
            size2 = charArray.Length;
            size3 = charArray2.Length;
            graphics.drawChars(charArray, 0, size2, 0, this.yArray[index], 0);
            graphics.drawChars(charArray2, 0, size3, size2 * this.defaultStringWidth, this.yArray[index + 1], 0);
        }
    }

    public GamePerformanceInitUpdatePaintable()
    {
        this.yArray = new int[] { this.halfHeight + 30, this.halfHeight + 30, this.halfHeight + 30 + 15, this.halfHeight + 30 + 15, this.halfHeight + 30 + 30, this.halfHeight + 30 + 30, this.halfHeight + 30 + 45, this.halfHeight + 30 + 45 };
        this.myFontProcessor = new UpdateMyFontProcessor(this);
    }

}

