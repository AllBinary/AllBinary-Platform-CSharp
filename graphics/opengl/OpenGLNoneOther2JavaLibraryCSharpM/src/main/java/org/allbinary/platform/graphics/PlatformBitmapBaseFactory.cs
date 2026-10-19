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

namespace org.allbinary.platform.graphics;

public class PlatformBitmapBaseFactory
{
    public static readonly PlatformBitmapBaseFactory NULL_PLATFORM_BITMAP_BASE_FACTORY = new PlatformBitmapBaseFactory();
    public virtual PlatformBitmapBase createBitmap(Image image)
    {
        return PlatformBitmapBase.NULL_PLATFORM_BITMAP_BASE;
    }

}

