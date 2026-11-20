// Generated Code Do Not Modify

using System;
using System.Linq;
//using IOException = java.io.IOException;
using InputStream = java.io.InputStream;
using Image = javax.microedition.lcdui.Image;
using ImageFactory = org.allbinary.image.ImageFactory;
using PlatformBitmapBaseFactory = org.allbinary.platform.graphics.PlatformBitmapBaseFactory;
using PlatformBitmapBase = org.allbinary.platform.graphics.PlatformBitmapBase;

namespace org.allbinary.graphics;

public class OpenGLBitmapFactory : PlatformBitmapBaseFactory
{
    private static readonly OpenGLBitmapFactory instance = new OpenGLBitmapFactory();
    public static OpenGLBitmapFactory getInstance()
    {
        return OpenGLBitmapFactory.instance;
    }

    public readonly OpenGLBitmapConfig ARGB_8888 = new OpenGLBitmapConfig(null);
    public virtual OpenGLBitmap createBitmap(int width, int height, OpenGLBitmapConfig config)
    {
        return new OpenGLBitmap(Image.createImageWH(width, height));
    }

    // throws Exception
    public virtual OpenGLBitmap decodeStream(InputStream inputStream)
    {
        return new OpenGLBitmap(ImageFactory.getInstance().createImageFromInputStream(inputStream));
    }

    public override PlatformBitmapBase createBitmap(Image image)
    {
        return new OpenGLBitmap(image);
    }

}

