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
using BasicHud = org.allbinary.game.graphics.hud.BasicHud;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using PrimitiveLongSingleton = org.allbinary.logic.math.PrimitiveLongSingleton;

namespace org.allbinary.game.ag.layer.hud.basic.time;

public class TimeHudWidget : BasicHud
{
    // throws Exception
    public static TimeHudWidget getInstance(int location, int direction, BasicColor basicColor, Timer timer)
    {
        return new TimeHudWidget(location, direction, 2, basicColor, timer);
    }

    private readonly string TIME_STRING = "Time ";
    private readonly char[] TIME_CHAR_ARRAY = new char[] { 'T', 'i', 'm', 'e', ' ' };
    private int offset = 0;
    private char[] @string = PrimitiveLongSingleton.getInstance().ZERO;
    private int totalDigits = 1;
    private readonly Timer timer;
    public TimeHudWidget(int location, int direction, int bufferZone, BasicColor basicColor, Timer timer) : base(location, direction, bufferZone, basicColor)
    {
        // base(location, direction, bufferZone, basicColor) is called from the constructor declaration
        this.timer = timer;
        this.set();
        this.updateMaxHeight = 14;
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.updateMaxWidth = font.getSize() * 5;
        this.offset = font.stringWidth(this.TIME_STRING) + MyFontProcessor.defaultStringWidth(font, 3);
        base.updateMeasurement(graphics);
    }

    public virtual void update()
    {
        this.timer.update();
        this.set();
    }

    private void set()
    {
        this.@string = this.timer.getTimeChars();
        this.totalDigits = this.timer.getCurrentTotalDigits();
    }

    public virtual Timer getTimer()
    {
        return this.timer;
    }

    public virtual void paint(Graphics graphics)
    {
        base.paintDX(graphics, this.TIME_CHAR_ARRAY, 0, this.TIME_CHAR_ARRAY.Length, this.@string, 0, this.totalDigits, this.offset);
    }

}

