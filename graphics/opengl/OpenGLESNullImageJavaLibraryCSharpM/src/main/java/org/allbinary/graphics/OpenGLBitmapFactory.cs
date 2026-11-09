// Generated Code Do Not Modify

using System;
using System.Linq;
//using IOException = java.io.IOException;
using InputStream = java.io.InputStream;
using Image = javax.microedition.lcdui.Image;
using NullUtil = org.allbinary.logic.NullUtil;
using PlatformBitmapBase = org.allbinary.platform.graphics.PlatformBitmapBase;
using PlatformBitmapBaseFactory = org.allbinary.platform.graphics.PlatformBitmapBaseFactory;

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
        public Config(OpenGLBitmapFactory outer, object bitmapConfig)
        {
            this.outer = outer;
            this.bitmapConfig = bitmapConfig;
        }

    }
    public readonly Config ARGB_8888;
    public virtual OpenGLBitmap createBitmap(int width, int height, OpenGLBitmapFactory.Config config)
    {
        return new OpenGLBitmap(NullUtil.getInstance().NULL_OBJECT);
    }

    // throws IOException
    public virtual OpenGLBitmap decodeStream(InputStream inputStream)
    {
        return new OpenGLBitmap(NullUtil.getInstance().NULL_OBJECT);
    }

    public override PlatformBitmapBase createBitmap(Image image)
    {
        return new OpenGLBitmap(NullUtil.getInstance().NULL_OBJECT);
    }

    public OpenGLBitmapFactory()
    {
        this.ARGB_8888 = new Config(this, NullUtil.getInstance().NULL_OBJECT);
    }

}

