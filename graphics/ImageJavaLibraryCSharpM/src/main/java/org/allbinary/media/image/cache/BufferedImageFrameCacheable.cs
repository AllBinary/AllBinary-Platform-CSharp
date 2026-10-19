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
//using BufferedImage = java.awt.image.BufferedImage;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CacheableInterface = org.allbinary.logic.util.cache.CacheableInterface;

namespace org.allbinary.media.image.cache;

public class BufferedImageFrameCacheable : CacheableInterface
{
    private long? frame;
    private BufferedImage bufferedImage = null;
    public BufferedImageFrameCacheable(BufferedImage bufferedImage, long? frame)
    {
        this.frame = frame;
        this.setBufferedImage(bufferedImage);
    }

    public virtual object getKey()
    {
        return this.frame;
    }

    public virtual BufferedImage getBufferedImage()
    {
        return this.bufferedImage;
    }

    private void setBufferedImage(BufferedImage bufferedImage)
    {
        this.bufferedImage = bufferedImage;
    }

    public virtual long? getFrame()
    {
        return this.frame;
    }

    public virtual void setFrame(long? frame)
    {
        this.frame = frame;
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

