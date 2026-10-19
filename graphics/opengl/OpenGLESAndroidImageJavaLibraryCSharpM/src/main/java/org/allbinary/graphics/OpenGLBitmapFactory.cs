// Generated Code Do Not Modify

using System;
using System.Linq;
//using InputStream = java.io.InputStream;
//using Image = javax.microedition.lcdui.Image;
using Bitmap = android.graphics.Bitmap;
using BitmapFactory = android.graphics.BitmapFactory;
//using IOException = java.io.IOException;
using PlatformBitmapBaseFactory = org.allbinary.platform.graphics.PlatformBitmapBaseFactory;
using PlatformBitmapBase = org.allbinary.platform.graphics.PlatformBitmapBase;
using AndroidImageInterface = org.microemu.android.device.AndroidImageInterface;

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
        public readonly Bitmap.Config bitmapConfig;
        public Config(Bitmap.Config bitmapConfig)
        {
            this.bitmapConfig = bitmapConfig;
        }

    }
    public readonly Config ARGB_8888 = new Config(Bitmap.Config.ARGB_8888);
    public virtual OpenGLBitmap createBitmap(int width, int height, OpenGLBitmapFactory.Config config)
    {
        return new OpenGLBitmap(Bitmap.createBitmap(width, height, config.bitmapConfig));
    }

    // throws IOException
    public virtual OpenGLBitmap decodeStream(InputStream inputStream)
    {
        return new OpenGLBitmap(BitmapFactory.decodeStream(inputStream));
    }

    public override PlatformBitmapBase createBitmap(Image image)
    {
        return new OpenGLBitmap((((AndroidImageInterface) image)).getBitmap());
    }

}

