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
using CacheableInterface = org.allbinary.logic.util.cache.CacheableInterface;

namespace org.allbinary.media.image.comparison;

public class ImageComparisonResultFrameCacheable : CacheableInterface
{
    private long? frame;
    private ImageComparisonResult imageComparisonResult = null;
    public ImageComparisonResultFrameCacheable(ImageComparisonResult imageComparisonResult, long? frame)
    {
        this.setImageComparisonResult(imageComparisonResult);
        this.frame = frame;
    }

    public virtual object getKey()
    {
        return this.frame;
    }

    public virtual long? getFrame()
    {
        return this.frame;
    }

    public virtual void setFrame(long? frame)
    {
        this.frame = frame;
    }

    public virtual ImageComparisonResult getImageComparisonResult()
    {
        return this.imageComparisonResult;
    }

    public virtual void setImageComparisonResult(ImageComparisonResult imageComparisonResult)
    {
        this.imageComparisonResult = imageComparisonResult;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.GetType().FullName);
        stringBuffer.append(" Frame: ");
        stringBuffer.appendlong(this.getFrame());
        return stringBuffer.ToString();
    }

}

