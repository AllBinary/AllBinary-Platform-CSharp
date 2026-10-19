// Generated Code Do Not Modify

using System;
using System.Linq;
//using ByteBuffer = java.nio.ByteBuffer;
//using GL10 = javax.microedition.khronos.opengles.GL10;
using OpenGLBitmap = org.allbinary.graphics.OpenGLBitmap;
using OpenGLESImage = org.allbinary.image.opengles.OpenGLESImage;

namespace org.platform.opengl;

public class OpenGLGLUUtils
{
    private static readonly OpenGLGLUUtils instance = new OpenGLGLUUtils();
    public static OpenGLGLUUtils getInstance()
    {
        return OpenGLGLUUtils.instance;
    }

    public virtual ByteBuffer makeByteBuffer(OpenGLBitmap bmp, bool flip)
    {
        throw new SystemException();
    }

    public virtual void texImage2D(GL10 gl, string glVersion, int target, int level, bool generateMipMap, OpenGLESImage openGLESImage, int border, bool flip)
    {
        throw new SystemException();
    }

    public virtual void texImage2D(GL10 gl, string glVersion, int target, int level, bool generateMipMap, OpenGLBitmap bitmap, int border, bool flip)
    {
        throw new SystemException();
    }

}

