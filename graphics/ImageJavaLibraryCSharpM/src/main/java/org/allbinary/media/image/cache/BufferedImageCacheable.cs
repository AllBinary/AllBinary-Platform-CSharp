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

public class BufferedImageCacheable : CacheableInterface
{
    private BufferedImageInfo key;
    private BufferedImage bufferedImage = null;
    public BufferedImageCacheable(BufferedImageInfo key)
    {
        this.key = key;
        this.setBufferedImage(new BufferedImage(key.getWidth(), key.getHeight(), key.getType()));
    }

    public virtual object getKey()
    {
        return this.key;
    }

    public virtual BufferedImage getBufferedImage()
    {
        return this.bufferedImage;
    }

    private void setBufferedImage(BufferedImage bufferedImage)
    {
        this.bufferedImage = bufferedImage;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.GetType().FullName);
        stringBuffer.append(" ");
        stringBuffer.append(this.getKey().ToString());
        return stringBuffer.ToString();
    }

}

