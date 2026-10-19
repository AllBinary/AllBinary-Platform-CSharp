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
using StringMaker = org.allbinary.logic.@string.StringMaker;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsConstructor = jsinterop.annotations.JsConstructor;
//using JsProperty = jsinterop.annotations.JsProperty;

namespace org.allbinary.graphics.color;

public class BasicColor
{
    private readonly string name;
    private readonly int value;
    private readonly float redComponent;
    private readonly float greenComponent;
    private readonly float blueComponent;
    private readonly float alphaComponent;
    public readonly short red;
    public readonly short green;
    public readonly short blue;
    public readonly short alpha;
    public BasicColor(int alphaValue, int value, string name)
    {
        this.name = name;
        int tempValue = 0;
        BasicColorUtil basicColorUtil = BasicColorUtil.getInstance();
        if (basicColorUtil.isAlpha) {
            if (basicColorUtil.ffOpaque) {
                tempValue = alphaValue | value;
            } else {
                tempValue = 0x00000000 | value;
            }
        } else {
            tempValue = value;
        }
        int alphaInt = ((tempValue >> 24) & 255);
        this.alpha = ((short) alphaInt);
        this.alphaComponent = (((float) alphaInt)) / 255f;
        int redInt = ((tempValue >> 16) & 255);
        this.red = ((short) redInt);
        this.redComponent = (((float) redInt)) / 255f;
        int greenInt = ((tempValue >> 8) & 255);
        this.green = ((short) greenInt);
        this.greenComponent = (((float) greenInt)) / 255f;
        int blueInt = ((tempValue) & 255);
        this.blue = ((short) blueInt);
        this.blueComponent = (((float) blueInt)) / 255f;
        this.value = tempValue;
    }

    public virtual int intValue()
    {
        return this.value;
    }

    public virtual int toInt()
    {
        return this.value;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("BasicColor: ");
        stringBuffer.append("Alpha: ");
        stringBuffer.appendshort(this.alpha);
        stringBuffer.append(" Red: ");
        stringBuffer.appendshort(this.red);
        stringBuffer.append(" Green: ");
        stringBuffer.appendshort(this.green);
        stringBuffer.append(" Blue: ");
        stringBuffer.appendshort(this.blue);
        stringBuffer.append(" Value: ");
        stringBuffer.appendint(this.value);
        return stringBuffer.ToString();
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual float getRedComponent()
    {
        return this.redComponent;
    }

    public virtual float getGreenComponent()
    {
        return this.greenComponent;
    }

    public virtual float getBlueComponent()
    {
        return this.blueComponent;
    }

    public virtual float getAlphaComponent()
    {
        return this.alphaComponent;
    }

}

