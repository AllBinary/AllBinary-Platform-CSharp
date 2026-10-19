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
using GPoint = org.allbinary.graphics.GPoint;
using TsUtil = org.allbinary.TsUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CacheableInterface = org.allbinary.logic.util.cache.CacheableInterface;
using ColorDelta = org.allbinary.media.image.comparison.color.ColorDelta;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.media.image.comparison.pixel;

public class PixelDelta : CacheableInterface
{
    private GPoint point = null;
    private ColorDelta colorDelta = null;
    private object key;
    public PixelDelta(GPoint point, ColorDelta colorDelta)
    {
        this.setPoint(point);
        this.setColorDelta(colorDelta);
        this.key = PixelDelta.getKey(this.getPoint(), this.getColorDelta());
    }

    public virtual object getKey()
    {
        return this.key;
    }

    public static object getKey(GPoint point, ColorDelta colorDelta)
    {
        return new StringMaker().appendint(((int) TsUtil.getInstance().hashCode(point))).append(CommonSeps.getInstance().UNDERSCORE).append(colorDelta.getKey().ToString()).ToString();
    }

    public virtual GPoint getPoint()
    {
        return this.point;
    }

    public virtual void setPoint(GPoint point)
    {
        this.point = point;
    }

    public virtual ColorDelta getColorDelta()
    {
        return this.colorDelta;
    }

    public virtual void setColorDelta(ColorDelta colorDelta)
    {
        this.colorDelta = colorDelta;
    }

    public override string ToString()
    {
        return new StringMaker().append("PixelDelta: Point: ").append(this.point.ToString()).append(CommonSeps.getInstance().SPACE).append(this.colorDelta.ToString()).ToString();
    }

}

