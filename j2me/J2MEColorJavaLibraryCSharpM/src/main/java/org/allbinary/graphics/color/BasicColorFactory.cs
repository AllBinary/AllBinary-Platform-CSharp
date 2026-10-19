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
//using JsType = jsinterop.annotations.JsType;
using StringUtil = org.allbinary.logic.@string.StringUtil;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsProperty = jsinterop.annotations.JsProperty;

namespace org.allbinary.graphics.color;

public class BasicColorFactory
{
    private static readonly BasicColorFactory instance = new BasicColorFactory();
    public static BasicColorFactory getInstance()
    {
        return BasicColorFactory.instance;
    }

    public virtual BasicColor createInstance(int value)
    {
        return new BasicColor(BasicColorUtil.getInstance().ALPHA, value, StringUtil.getInstance().EMPTY_STRING);
    }

    public virtual BasicColor createInstanceA(int alphaValue, int value)
    {
        return new BasicColor(alphaValue, value, StringUtil.getInstance().EMPTY_STRING);
    }

    public virtual BasicColor createInstanceAN(int alphaValue, int value, string name)
    {
        return new BasicColor(alphaValue, value, name);
    }

    public virtual BasicColor createInstanceARGB(int alphaValue, int r, int g, int b, string name)
    {
        int ALPHA_MASK = 0xFF000000;
        return new BasicColor(alphaValue, ((alphaValue << 24) & ALPHA_MASK) + ((r << 16) & 0x00FF0000) + ((g << 8) & 0x0000FF00) + (b & 0x000000FF), StringUtil.getInstance().EMPTY_STRING);
    }

    public readonly BasicColor NULL_COLOR;
    public readonly BasicColor TAN;
    public readonly BasicColor SKIN_PINK;
    public readonly BasicColor RED;
    public readonly BasicColor LIGHT_RED;
    public readonly BasicColor DARK_GREEN;
    public readonly BasicColor GREEN;
    public readonly BasicColor LIGHT_GREEN;
    public readonly BasicColor PURPLE;
    public readonly BasicColor BLUE;
    public readonly BasicColor LIGHT_BLUE;
    public readonly BasicColor VERY_LIGHT_BLUE;
    public readonly BasicColor PUCE;
    public readonly BasicColor AQUA;
    public readonly BasicColor YELLOW;
    public readonly BasicColor PINK;
    public readonly BasicColor BLACK;
    public readonly BasicColor GREY;
    public readonly BasicColor LIGHT_GREY;
    public readonly BasicColor DARK_GREY;
    public readonly BasicColor ORANGE;
    public readonly BasicColor BROWN;
    public readonly BasicColor WHITE;
    public readonly BasicColor TRANSPARENT_COLOR;
    public readonly BasicColor TRANSPARENT_GREY;
    public readonly BasicColor TRANSPARENT_BLACK;
    public readonly BasicColor TRANSPARENT_RED;
    public readonly BasicColor CLEAR_COLOR;
    public readonly BasicColor BORDER_COLOR;
    public BasicColorFactory()
    {
        this.NULL_COLOR = this.createInstanceARGB(255, 255, 255, 255, "null color");
        this.TAN = this.createInstance(0xE9D8B5);
        this.SKIN_PINK = this.createInstance(0xFDCECE);
        this.RED = this.createInstanceAN(BasicColorUtil.getInstance().ALPHA, 0xFF0000, "red");
        this.LIGHT_RED = this.createInstanceAN(BasicColorUtil.getInstance().ALPHA, 0xFFA0A0, "light red");
        this.DARK_GREEN = this.createInstance(0x00FF00);
        this.GREEN = this.createInstanceAN(BasicColorUtil.getInstance().ALPHA, 0x00DD00, "green");
        this.LIGHT_GREEN = this.createInstance(0x007700);
        this.PURPLE = this.createInstanceAN(BasicColorUtil.getInstance().ALPHA, 0x400040, "purple");
        this.BLUE = this.createInstanceAN(BasicColorUtil.getInstance().ALPHA, 0x0000FF, "blue");
        this.LIGHT_BLUE = this.createInstance(0x00aaff);
        this.VERY_LIGHT_BLUE = this.createInstance(0x000033);
        this.PUCE = this.createInstance(0xFF00AA);
        this.AQUA = this.createInstance(0x00FFFF);
        this.YELLOW = this.createInstanceAN(BasicColorUtil.getInstance().ALPHA, 0xFFFF00, "yellow");
        this.PINK = this.createInstance(0xFF00FF);
        this.BLACK = this.createInstanceAN(BasicColorUtil.getInstance().ALPHA, 0x000000, "black");
        this.GREY = this.createInstanceAN(BasicColorUtil.getInstance().ALPHA, 0xAAAAAA, "grey");
        this.LIGHT_GREY = this.createInstance(0xC0C0C0);
        this.DARK_GREY = this.createInstance(0x404040);
        this.ORANGE = this.createInstance(0xe07718);
        this.BROWN = this.createInstance(0x956B00);
        this.WHITE = this.createInstance(0xFFFFFF);
        this.TRANSPARENT_COLOR = this.createInstanceAN(0x00000000, 0x000000, StringUtil.getInstance().EMPTY_STRING);
        this.TRANSPARENT_GREY = this.createInstanceAN(0x52000000, 0xECECEC, StringUtil.getInstance().EMPTY_STRING);
        this.TRANSPARENT_BLACK = this.createInstanceAN(0x52000000, 0x000000, StringUtil.getInstance().EMPTY_STRING);
        this.TRANSPARENT_RED = this.createInstanceAN(0x52000000, 0xFF0000, StringUtil.getInstance().EMPTY_STRING);
        this.CLEAR_COLOR = this.BLACK;
        this.BORDER_COLOR = this.WHITE;
    }

}

