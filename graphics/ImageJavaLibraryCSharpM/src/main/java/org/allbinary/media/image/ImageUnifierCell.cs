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

namespace org.allbinary.media.image;

public class ImageUnifierCell
{
    private int? width = null;
    private int? height = null;
    public ImageUnifierCell(int? width, int? height)
    {
        this.setWidth(width);
        this.setHeight(height);
    }

    public virtual int? getWidth()
    {
        return this.width;
    }

    public virtual void setWidth(int? width)
    {
        this.width = width;
    }

    public virtual int? getHeight()
    {
        return this.height;
    }

    public virtual void setHeight(int? height)
    {
        this.height = height;
    }

}

