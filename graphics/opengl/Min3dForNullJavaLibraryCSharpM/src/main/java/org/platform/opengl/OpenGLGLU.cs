// Generated Code Do Not Modify

using System;
using System.Linq;
//using GL10 = javax.microedition.khronos.opengles.GL10;

namespace org.platform.opengl;

public class OpenGLGLU
{
    private static readonly OpenGLGLU instance = new OpenGLGLU();
    public static OpenGLGLU getInstance()
    {
        return OpenGLGLU.instance;
    }

    public virtual void gluLookAt(GL10 gl, float eyeX, float eyeY, float eyeZ, float centerX, float centerY, float centerZ, float upX, float upY, float upZ)
    {
        throw new SystemException();
    }

    public virtual int gluProject(GL10 gl, float objX, float objY, float objZ, float[] model, int modelOffset, float[] project, int projectOffset, int[] view, int viewOffset, float[] win, int winOffset)
    {
        throw new SystemException();
    }

    public virtual int gluUnProject(GL10 gl, float winX, float winY, float winZ, float[] model, int modelOffset, float[] project, int projectOffset, int[] view, int viewOffset, float[] obj, int objOffset)
    {
        throw new SystemException();
    }

    public virtual void glFrustumf(GL10 gl, float lt, float rt, float btm, float top, float zNear, float zFar)
    {
        throw new SystemException();
    }

}

