// Generated Code Do Not Modify

extern alias OpenGLESBaseJavaLibraryCSharp;
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

    public class Config
    {
        private readonly OpenGLBitmapFactory outer;

        public readonly object bitmapConfig;
        private Config(OpenGLBitmapFactory outer, object bitmapConfig)
        {
            this.outer = outer;
            this.bitmapConfig = bitmapConfig;
        }

    }
    public readonly Config ARGB_8888;
    public virtual OpenGLBitmap createBitmap(int width, int height, OpenGLBitmapFactory.Config config)
    {
        return new OpenGLBitmap(Image.createImage(width, height));
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

    public OpenGLBitmapFactory()
    {
        this.ARGB_8888 = new Config(this, null);
    }

}

