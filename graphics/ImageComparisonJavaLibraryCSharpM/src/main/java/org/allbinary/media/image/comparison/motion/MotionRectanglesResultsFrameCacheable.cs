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

namespace org.allbinary.media.image.comparison.motion;

public class MotionRectanglesResultsFrameCacheable : CacheableInterface
{
    private MotionRectangles motionRectangles = null;
    private long? frame;
    public MotionRectanglesResultsFrameCacheable(MotionRectangles motionRectangles, long? frame)
    {
        this.frame = frame;
        this.setMotionRectangles(motionRectangles);
    }

    public virtual object getKey()
    {
        return this.frame;
    }

    public virtual MotionRectangles getMotionRectangles()
    {
        return this.motionRectangles;
    }

    public virtual void setMotionRectangles(MotionRectangles motionRectangles)
    {
        this.motionRectangles = motionRectangles;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.GetType().FullName);
        stringBuffer.append(" Frame: ");
        stringBuffer.append(this.getKey().ToString());
        return stringBuffer.ToString();
    }

}

