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
using BasicHudFactory = org.allbinary.game.graphics.hud.BasicHudFactory;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using PaintableInterface = org.allbinary.graphics.paint.PaintableInterface;
using PrimitiveLongSingleton = org.allbinary.logic.math.PrimitiveLongSingleton;
using PrimitiveLongUtil = org.allbinary.logic.math.PrimitiveLongUtil;

namespace org.allbinary.game.ag.layer.hud.basic;

public class NumberStringHud : BasicHud, PaintableInterface
{
    private readonly PrimitiveLongUtil primitiveLongUtil;
    private readonly string prependString;
    private readonly char[] PREPEND_STRING;
    private int value;
    private int max;
    private int offset = 0;
    private char[] valueString;
    private int valueTotalDigits = 0;
    public NumberStringHud(string prependString, int max, int location, int direction, int bufferZone, BasicColor basicColor) : base(location, direction, bufferZone, basicColor)
    {
        // base(location, direction, bufferZone, basicColor) is called from the constructor declaration
        this.prependString = prependString;
        this.PREPEND_STRING = prependString.ToCharArray();
        this.valueString = PrimitiveLongSingleton.getInstance().NUMBER_CHAR_ARRAYS[0];
        this.primitiveLongUtil = PrimitiveLongUtil.createPowerOfTen(max + 1);
        this.max = max;
        this.value = 0;
        if (direction == 0) {
            throw new SystemException(BasicHudFactory.getInstance().DIRECTION_EXCEPTION);
        }
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.offset = font.stringWidth(this.prependString) + MyFontProcessor.defaultCharWidth(font);
        base.updateMeasurement(graphics);
    }

    public virtual int get()
    {
        return this.value;
    }

    public virtual void add(int value)
    {
        this.set(this.value + value);
    }

    public virtual void set(int value)
    {
        this.value = value;
        if (this.value > this.max) {
            this.value = 0;
        }
        this.valueString = this.primitiveLongUtil.getCharArray(this.value);
        this.valueTotalDigits = this.primitiveLongUtil.getCurrentTotalDigits();
    }

    public virtual void reduce(int value)
    {
        this.set(this.value - value);
    }

    public override void paint(Graphics graphics)
    {
        base.paintDX(graphics, this.PREPEND_STRING, 0, this.PREPEND_STRING.Length, this.valueString, 0, this.valueTotalDigits, this.offset);
    }

    public virtual void paintXY(Graphics graphics, int x, int y)
    {
        this.myFontProcessor.process(graphics);
        char[] charArray = this.PREPEND_STRING;
        int len = this.PREPEND_STRING.Length;
        char[] charArray2 = this.valueString;
        int len2 = this.valueTotalDigits;
        this.basicSetColorUtil.setBasicColorP(graphics, this.getBasicColorP());
        graphics.drawChars(charArray, 0, len, x, y, 0);
        graphics.drawChars(charArray2, 0, len2, x - this.offset, y, 0);
    }

    public override void paintThreed(Graphics graphics)
    {
    }

}

