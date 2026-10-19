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
//using java.awt;
using CacheableInterface = org.allbinary.logic.util.cache.CacheableInterface;

namespace org.allbinary.graphics.color;

public class ColorCacheable : CacheableInterface
{
    private object key;
    private Color color;
    public ColorCacheable(object key)
    {
        this.key = key;
        this.color = new Color(((int) (((int?) key))));
    }

    public virtual object getKey()
    {
        return this.key;
    }

    public virtual Color getColor()
    {
        return this.color;
    }

    public virtual void setColor(Color color)
    {
        this.color = color;
    }

}

