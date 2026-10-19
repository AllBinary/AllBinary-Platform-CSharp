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
//using IIOImage = javax.imageio.IIOImage;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CacheableInterface = org.allbinary.logic.util.cache.CacheableInterface;

namespace org.allbinary.media.image.io;

public class IIOImageCacheable : CacheableInterface
{
    private string key;
    private IIOImage iioImage = null;
    public IIOImageCacheable(string key)
    {
        this.key = key;
    }

    public virtual object getKey()
    {
        return this.key;
    }

    public virtual void setBufferedImage(BufferedImage bufferedImage)
    {
        this.setIioImage(new IIOImage(bufferedImage, null, null));
    }

    public virtual IIOImage getIioImage()
    {
        return this.iioImage;
    }

    private void setIioImage(IIOImage iioImage)
    {
        this.iioImage = iioImage;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(this.GetType().FullName);
        stringBuffer.append(" Reusable IIOImage");
        return stringBuffer.ToString();
    }

}

