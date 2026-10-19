// Generated Code Do Not Modify

using System;
using System.Linq;
//using GL10 = javax.microedition.khronos.opengles.GL10;
//using Image = javax.microedition.lcdui.Image;
using PlatformTextureBaseFactory = org.allbinary.platform.opengles.PlatformTextureBaseFactory;

namespace org.platform.opengl;

public class OpenGLTextureFactory : PlatformTextureBaseFactory
{
    private static readonly OpenGLTextureFactory instance = new OpenGLTextureFactory();
    public static OpenGLTextureFactory getInstance()
    {
        return OpenGLTextureFactory.instance;
    }

    private readonly OpenGLGLUUtils gluUtils = OpenGLGLUUtils.getInstance();
    private OpenGLTextureFactory()
    {
    }

    public override void load(GL10 gl, int target, int level, Image image, int border, bool flip)
    {
        throw new SystemException();
    }

}

