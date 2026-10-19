// Generated Code Do Not Modify

using System;
using System.Linq;
using PlatformBitmapBase = org.allbinary.platform.graphics.PlatformBitmapBase;

namespace org.allbinary.graphics;

public class OpenGLBitmap : PlatformBitmapBase
{
    public readonly object bitmap;
    public OpenGLBitmap(object bitmap)
    {
        this.bitmap = bitmap;
    }

    public virtual void getPixels(int[] pixels, int offset, int stride, int x, int y, int width, int height)
    {
    }

    public virtual void setPixels(int[] pixels, int offset, int stride, int x, int y, int width, int height)
    {
    }

    public virtual void recycle()
    {
    }

}

