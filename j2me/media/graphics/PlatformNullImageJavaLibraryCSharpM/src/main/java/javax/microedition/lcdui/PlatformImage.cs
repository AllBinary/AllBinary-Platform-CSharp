/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using NullUtil = org.allbinary.logic.NullUtil;

namespace javax.microedition.lcdui;

//PlatformNullImageJavaLibrary
public class PlatformImage
{
    public virtual object getImage(object graphicsSurface2)
    {
        return NullImage.NULL_IMAGE;
    }

    public virtual int getSurfaceWidth(object graphicsSurface2, int width)
    {
        return width;
    }

    public virtual int getSurfaceHeight(object graphicsSurface2, int height)
    {
        return height;
    }

    public virtual int getWidth(Image image, int width)
    {
        return width;
    }

    public virtual int getHeight(Image image, int height)
    {
        return height;
    }

    public virtual javax.microedition.lcdui.Graphics getGraphics(object graphicsSurface, int width, int height, Image image)
    {
        throw new SystemException();
    }

    public virtual void drawImage(Image image, int x, int y, int anchor, javax.microedition.lcdui.Graphics g2, object g)
    {
    }

    public virtual void drawRegion(Image image, int x_src, int y_src, int width, int height, int transform, int x_dst, int y_dst, int anchor, javax.microedition.lcdui.Graphics g)
    {
    }

    public virtual void getRGB(int[] argb, int offset, int scanlength, int x, int y, int width, int height, Image image)
    {
    }

    public virtual void setRGB(int[] argb, int offset, int scanlength, int x, int y, int width, int height, Image image)
    {
    }

    public virtual int[] getData(Image image)
    {
        return NullUtil.getInstance().NULL_INT_ARRAY;
    }

}

