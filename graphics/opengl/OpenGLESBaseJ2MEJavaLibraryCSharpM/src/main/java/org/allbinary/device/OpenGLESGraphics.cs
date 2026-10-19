// Generated Code Do Not Modify

using System;
using System.Linq;
//using GL = javax.microedition.khronos.opengles.GL;
//using GL10 = javax.microedition.khronos.opengles.GL10;
//using Font = javax.microedition.lcdui.Font;
using FontDebugBase = org.allbinary.graphics.font.FontDebugBase;
using OpenGLSurfaceChangedInterface = org.allbinary.image.opengles.OpenGLSurfaceChangedInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.device;

public class OpenGLESGraphics : OpenGLSurfaceChangedInterface, GraphicsInterface
{
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public GL10 gl = NullGL10.NULL_GL10;
    public OpenGLESGraphics()
    {
    }

    public virtual void updateGL(GL gl)
    {
    }

    public virtual void set(GL gl)
    {
    }

    // throws Exception
    public virtual void init()
    {
    }

    // throws Exception
    public virtual void update()
    {
    }

    public virtual void setOrthoginalMode()
    {
    }

    public virtual void setCameraMode()
    {
    }

    public virtual GL10 getGlP()
    {
        return this.gl;
    }

    public virtual void setFontDebug(Font font, FontDebugBase fontDebug)
    {
        throw new SystemException();
    }

}

