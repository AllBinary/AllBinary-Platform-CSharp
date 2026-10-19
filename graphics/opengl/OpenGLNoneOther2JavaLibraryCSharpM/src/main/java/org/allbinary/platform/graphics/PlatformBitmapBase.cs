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
//using Image = javax.microedition.lcdui.Image;
//using NullImage = javax.microedition.lcdui.NullImage;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;

namespace org.allbinary.platform.graphics;

public class PlatformBitmapBase
{
    public static readonly PlatformBitmapBase NULL_PLATFORM_BITMAP_BASE = new PlatformBitmapBase();
    public int alpha = 255;
    public BasicColor basicColor = BasicColorFactory.getInstance().NULL_COLOR;
    public virtual int getWidth()
    {
        return 0;
    }

    public virtual int getHeight()
    {
        return 0;
    }

    public virtual Image getImage()
    {
        return NullImage.NULL_IMAGE;
    }

}

