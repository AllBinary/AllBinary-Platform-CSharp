/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
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
//using IOException = java.io.IOException;
//using InputStream = java.io.InputStream;
using OpenGLBitmap = org.allbinary.graphics.OpenGLBitmap;
using BasicColor = org.allbinary.graphics.color.BasicColor;

namespace org.allbinary.image.opengles;

public class OpenGLImageUtilBase
{
    public virtual OpenGLBitmap paint(OpenGLBitmap alphaBitmap, OpenGLBitmap originalBitmap, int index)
    {
        throw new SystemException();
    }

    public virtual OpenGLBitmap paint(OpenGLBitmap colorBitmap, OpenGLBitmap originalBitmap, int alpha, BasicColor basicColor)
    {
        throw new SystemException();
    }

    // throws IOException
    public virtual OpenGLBitmap createImage(string name)
    {
        throw new SystemException();
    }

    // throws IOException
    public virtual OpenGLBitmap createImageFromInputStream(InputStream inputStream)
    {
        throw new SystemException();
    }

}

