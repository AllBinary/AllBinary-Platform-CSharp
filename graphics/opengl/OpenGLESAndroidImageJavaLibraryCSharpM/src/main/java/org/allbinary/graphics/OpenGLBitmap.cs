// Generated Code Do Not Modify

using System;
using System.Linq;
using Bitmap = android.graphics.Bitmap;
using PlatformBitmapBase = org.allbinary.platform.graphics.PlatformBitmapBase;

namespace org.allbinary.graphics;

public class OpenGLBitmap : PlatformBitmapBase
{
    public readonly Bitmap bitmap;
    public OpenGLBitmap(object bitmap)
    {
        this.bitmap = ((Bitmap) bitmap);
    }

    public virtual void getPixels(int[] pixels, int offset, int stride, int x, int y, int width, int height)
    {
        this.bitmap.getPixels(pixels, offset, stride, x, y, width, height);
    }

    public virtual void setPixels(int[] pixels, int offset, int stride, int x, int y, int width, int height)
    {
        this.bitmap.setPixels(pixels, offset, stride, x, y, width, height);
    }

    public override int getWidth()
    {
        return this.bitmap.getWidth();
    }

    public override int getHeight()
    {
        return this.bitmap.getHeight();
    }

    public virtual void recycle()
    {
        this.bitmap.recycle();
    }

}

