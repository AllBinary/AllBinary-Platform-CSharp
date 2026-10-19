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
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CacheableInterface = org.allbinary.logic.util.cache.CacheableInterface;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.media.image.comparison.color;

public class ColorDelta : CacheableInterface
{
    private int rgb1 = 0;
    private int rgb2 = 0;
    private object key;
    public ColorDelta(int rgb1, int rgb2)
    {
        this.setRgb1(rgb1);
        this.setRgb2(rgb2);
        this.key = ColorDelta.getKey(rgb1, rgb2);
    }

    public virtual object getKey()
    {
        return this.key;
    }

    public static object getKey(int rgb1, int rgb2)
    {
        return new StringMaker().append((rgb1).ToString()).append(CommonSeps.getInstance().UNDERSCORE).append((rgb2).ToString()).ToString();
    }

    public virtual int getRgb1()
    {
        return this.rgb1;
    }

    protected virtual void setRgb1(int rgb1)
    {
        this.rgb1 = rgb1;
    }

    public virtual int getRgb2()
    {
        return this.rgb2;
    }

    protected virtual void setRgb2(int rgb2)
    {
        this.rgb2 = rgb2;
    }

    public override string ToString()
    {
        return new StringMaker().append("ColorDelta: ").append(StringUtil.getInstance().toString(this.getKey())).append(" RGB1: ").appendint(this.getRgb1()).append(" RGB2: ").appendint(this.getRgb2()).ToString();
    }

}

