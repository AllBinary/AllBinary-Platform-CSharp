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
using OpenGLFeatureUtil = org.allbinary.graphics.opengles.OpenGLFeatureUtil;
using BasicHud = org.allbinary.game.graphics.hud.BasicHud;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using MyFontProcessor = org.allbinary.graphics.font.MyFontProcessor;
using MathUtil = org.allbinary.logic.math.MathUtil;
using PrimitiveLongSingleton = org.allbinary.logic.math.PrimitiveLongSingleton;
using PrimitiveLongUtil = org.allbinary.logic.math.PrimitiveLongUtil;

namespace org.allbinary.game.layer.hud.basic;

public class VelocityWidget : BasicHud
{
    private readonly char[] KILOMETERS_PER_HOUR_STR = new char[] { ' ', 'k', 'm', '/', 'h' };
    private readonly int totalChars;
    private int velocity;
    private int maxVelocity;
    private char[] @string = PrimitiveLongSingleton.getInstance().ZERO;
    private int totalDigits = 1;
    private readonly int powerOfTenVelocity;
    private readonly PrimitiveLongUtil primitiveLongUtil;
    private int offset = 0;
    private int offset2 = 0;
    public VelocityWidget(int powerOfTenVelocity, int location, int direction, BasicColor basicColor) : base(location, direction, 2, basicColor)
    {
        this.totalChars = this.KILOMETERS_PER_HOUR_STR.Length;
        // base(location, direction, 2, basicColor) is called from the constructor declaration
        this.powerOfTenVelocity = powerOfTenVelocity;
        this.maxVelocity = powerOfTenVelocity;
        this.velocity = 0;
        this.primitiveLongUtil = PrimitiveLongUtil.createPowerOfTen(powerOfTenVelocity);
        this.updateMaxHeight = 14;
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        this.updateMaxWidth = font.getSize() * (5 + MathUtil.getInstance().getTotalDigits(this.powerOfTenVelocity) + 1);
        base.updateMeasurement(graphics);
        this.offset = MyFontProcessor.defaultStringWidth(font, this.primitiveLongUtil.getMaxDigits()) + MyFontProcessor.defaultStringWidth(font, 2);
        this.offset2 = this.offset - MyFontProcessor.defaultStringWidth(font, this.totalDigits) - MyFontProcessor.defaultStringWidth(font, 2);
    }

    public virtual int get()
    {
        return this.velocity;
    }

    public virtual void add(int value)
    {
        this.set(this.velocity + value);
    }

    public virtual void set(int value)
    {
        int lastVelocity = this.velocity;
        this.velocity = value;
        if (this.velocity > this.maxVelocity) {
            this.velocity = 0;
        }
        if (lastVelocity != this.velocity) {
            this.@string = this.primitiveLongUtil.getCharArray(this.velocity * 18);
            if (OpenGLFeatureUtil.getInstance().isAnyThreed()) {
                this.totalDigits = this.primitiveLongUtil.getCurrentTotalDigits() + 1;
            } else {
                this.totalDigits = this.primitiveLongUtil.getCurrentTotalDigits();
            }
            this.myFontProcessor = this.updateMyFontProcessor;
        }
    }

    public virtual void reduce(int value)
    {
        this.set(this.velocity - value);
    }

    public virtual void paint(Graphics graphics)
    {
        base.paintDXY(graphics, this.@string, 0, this.totalDigits, this.KILOMETERS_PER_HOUR_STR, 0, this.totalChars, this.offset2, this.offset);
    }

}

