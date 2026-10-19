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
using CommonLabels = org.allbinary.@string.CommonLabels;

namespace org.allbinary.media.image.cache;

public class BufferedImageInfo
{
    private int width;
    private int height;
    private int type;
    public BufferedImageInfo(int width, int height, int type)
    {
        this.width = width;
        this.height = height;
        this.type = type;
    }

    public virtual int getWidth()
    {
        return this.width;
    }

    public virtual void setWidth(int width)
    {
        this.width = width;
    }

    public virtual int getHeight()
    {
        return this.height;
    }

    public virtual void setHeight(int height)
    {
        this.height = height;
    }

    public virtual int getType()
    {
        return this.type;
    }

    public virtual void setType(int type)
    {
        this.type = type;
    }

    public override string ToString()
    {
        CommonLabels commonLabels = CommonLabels.getInstance();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("BufferedImageInfo -");
        stringBuffer.append(commonLabels.WIDTH_LABEL);
        stringBuffer.appendint(this.getWidth());
        stringBuffer.append(commonLabels.HEIGHT_LABEL);
        stringBuffer.appendint(this.getHeight());
        stringBuffer.append(" Type: ");
        stringBuffer.appendint(this.getType());
        return stringBuffer.ToString();
    }

}

