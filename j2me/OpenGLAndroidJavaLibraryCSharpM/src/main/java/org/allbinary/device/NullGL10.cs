/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2025 AllBinary 
 *  
 * By agreeing to this license you and any business entity you represent are 
 * legally bound to the AllBinary Open License Version 1 legal agreement. 
 *  
 * You may obtain the AllBinary Open License Version 1 legal agreement from 
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository. 
 *  
 * Created By: Travis Berthelot 
 *   
 */
// Generated Code Do Not Modify

using System;
using System.Linq;
//using GL10 = javax.microedition.khronos.opengles.GL10;
//using Buffer = java.nio.Buffer;
//using FloatBuffer = java.nio.FloatBuffer;
//using IntBuffer = java.nio.IntBuffer;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.device;

public class NullGL10 : GL10
{
    public static readonly NullGL10 NULL_GL10 = new NullGL10();
    public virtual void glActiveTexture(int texture)
    {
        return;
    }

    public virtual void glAlphaFunc(int func, float @ref)
    {
        return;
    }

    public virtual void glAlphaFuncx(int func, int @ref)
    {
    }

    public virtual void glBindTexture(int target, int texture)
    {
        return;
    }

    public virtual void glBlendFunc(int sfactor, int dfactor)
    {
        return;
    }

    public virtual void glClear(int mask)
    {
        return;
    }

    public virtual void glClearColor(float red, float green, float blue, float alpha)
    {
        return;
    }

    public virtual void glClearColorx(int red, int green, int blue, int alpha)
    {
    }

    public virtual void glClearDepthf(float depth)
    {
        return;
    }

    public virtual void glClearDepthx(int depth)
    {
    }

    public virtual void glClearStencil(int s)
    {
        return;
    }

    public virtual void glClientActiveTexture(int texture)
    {
        return;
    }

    public virtual void glColor4f(float red, float green, float blue, float alpha)
    {
        return;
    }

    public virtual void glColor4x(int red, int green, int blue, int alpha)
    {
    }

    public virtual void glColorMask(bool red, bool green, bool blue, bool alpha)
    {
        return;
    }

    public virtual void glColorPointer(int size, int type, int stride, Buffer pointer)
    {
        return;
    }

    public virtual void glCompressedTexImage2D(int target, int level, int internalformat, int width, int height, int border, int imageSize, Buffer data)
    {
        return;
    }

    public virtual void glCompressedTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int imageSize, Buffer data)
    {
        return;
    }

    public virtual void glCopyTexImage2D(int target, int level, int internalformat, int x, int y, int width, int height, int border)
    {
        return;
    }

    public virtual void glCopyTexSubImage2D(int target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
    {
        return;
    }

    public virtual void glCullFace(int mode)
    {
        return;
    }

    public virtual void glDeleteTextures(int n, int[] textures, int offset)
    {
        return;
    }

    public virtual void glDeleteTextures(int n, IntBuffer textures)
    {
        return;
    }

    public virtual void glDepthFunc(int func)
    {
        return;
    }

    public virtual void glDepthMask(bool flag)
    {
        return;
    }

    public virtual void glDepthRangef(float zNear, float zFar)
    {
        return;
    }

    public virtual void glDepthRangex(int zNear, int zFar)
    {
    }

    public virtual void glDisable(int cap)
    {
        return;
    }

    public virtual void glDisableClientState(int array)
    {
        return;
    }

    public virtual void glDrawArrays(int mode, int first, int count)
    {
        return;
    }

    public virtual void glDrawElements(int mode, int count, int type, Buffer indices)
    {
        return;
    }

    public virtual void glEnable(int cap)
    {
        return;
    }

    public virtual void glEnableClientState(int array)
    {
        return;
    }

    public virtual void glFinish()
    {
        return;
    }

    public virtual void glFlush()
    {
        return;
    }

    public virtual void glFogf(int pname, float param)
    {
        return;
    }

    public virtual void glFogfv(int pname, float[] @params, int offset)
    {
        return;
    }

    public virtual void glFogfv(int pname, FloatBuffer @params)
    {
        return;
    }

    public virtual void glFogx(int pname, int param)
    {
    }

    public virtual void glFogxv(int pname, int[] @params, int offset)
    {
    }

    public virtual void glFogxv(int pname, IntBuffer @params)
    {
    }

    public virtual void glFrontFace(int mode)
    {
        return;
    }

    public virtual void glFrustumf(float left, float right, float bottom, float top, float zNear, float zFar)
    {
        return;
    }

    public virtual void glFrustumx(int left, int right, int bottom, int top, int zNear, int zFar)
    {
    }

    public virtual void glGenTextures(int n, int[] textures, int offset)
    {
        return;
    }

    public virtual void glGenTextures(int n, IntBuffer textures)
    {
        return;
    }

    public virtual int glGetError()
    {
        return 0;
    }

    public virtual void glGetIntegerv(int pname, int[] @params, int offset)
    {
        return;
    }

    public virtual void glGetIntegerv(int pname, IntBuffer @params)
    {
        return;
    }

    public virtual string glGetString(int name)
    {
        return StringUtil.getInstance().EMPTY_STRING;
    }

    public virtual void glHint(int target, int mode)
    {
        return;
    }

    public virtual void glLightModelf(int pname, float param)
    {
        return;
    }

    public virtual void glLightModelfv(int pname, float[] @params, int offset)
    {
        return;
    }

    public virtual void glLightModelfv(int pname, FloatBuffer @params)
    {
        return;
    }

    public virtual void glLightModelx(int pname, int param)
    {
    }

    public virtual void glLightModelxv(int pname, int[] @params, int offset)
    {
    }

    public virtual void glLightModelxv(int pname, IntBuffer @params)
    {
    }

    public virtual void glLightf(int light, int pname, float param)
    {
        return;
    }

    public virtual void glLightfv(int light, int pname, float[] @params, int offset)
    {
        return;
    }

    public virtual void glLightfv(int light, int pname, FloatBuffer @params)
    {
        return;
    }

    public virtual void glLightx(int light, int pname, int param)
    {
    }

    public virtual void glLightxv(int light, int pname, int[] @params, int offset)
    {
    }

    public virtual void glLightxv(int light, int pname, IntBuffer @params)
    {
    }

    public virtual void glLineWidth(float width)
    {
        return;
    }

    public virtual void glLineWidthx(int width)
    {
    }

    public virtual void glLoadIdentity()
    {
        return;
    }

    public virtual void glLoadMatrixf(float[] m, int offset)
    {
        return;
    }

    public virtual void glLoadMatrixf(FloatBuffer m)
    {
        return;
    }

    public virtual void glLoadMatrixx(int[] m, int offset)
    {
    }

    public virtual void glLoadMatrixx(IntBuffer m)
    {
    }

    public virtual void glLogicOp(int opcode)
    {
        return;
    }

    public virtual void glMaterialf(int face, int pname, float param)
    {
        return;
    }

    public virtual void glMaterialfv(int face, int pname, float[] @params, int offset)
    {
        return;
    }

    public virtual void glMaterialfv(int face, int pname, FloatBuffer @params)
    {
        return;
    }

    public virtual void glMaterialx(int face, int pname, int param)
    {
    }

    public virtual void glMaterialxv(int face, int pname, int[] @params, int offset)
    {
    }

    public virtual void glMaterialxv(int face, int pname, IntBuffer @params)
    {
    }

    public virtual void glMatrixMode(int mode)
    {
        return;
    }

    public virtual void glMultMatrixf(float[] m, int offset)
    {
        return;
    }

    public virtual void glMultMatrixf(FloatBuffer m)
    {
        return;
    }

    public virtual void glMultMatrixx(int[] m, int offset)
    {
    }

    public virtual void glMultMatrixx(IntBuffer m)
    {
    }

    public virtual void glMultiTexCoord4f(int target, float s, float t, float r, float q)
    {
        return;
    }

    public virtual void glMultiTexCoord4x(int target, int s, int t, int r, int q)
    {
    }

    public virtual void glNormal3f(float nx, float ny, float nz)
    {
        return;
    }

    public virtual void glNormal3x(int nx, int ny, int nz)
    {
    }

    public virtual void glNormalPointer(int type, int stride, Buffer pointer)
    {
        return;
    }

    public virtual void glOrthof(float left, float right, float bottom, float top, float zNear, float zFar)
    {
        return;
    }

    public virtual void glOrthox(int left, int right, int bottom, int top, int zNear, int zFar)
    {
    }

    public virtual void glPixelStorei(int pname, int param)
    {
        return;
    }

    public virtual void glPointSize(float size)
    {
        return;
    }

    public virtual void glPointSizex(int size)
    {
    }

    public virtual void glPolygonOffset(float factor, float units)
    {
        return;
    }

    public virtual void glPolygonOffsetx(int factor, int units)
    {
    }

    public virtual void glPopMatrix()
    {
        return;
    }

    public virtual void glPushMatrix()
    {
        return;
    }

    public virtual void glReadPixels(int x, int y, int width, int height, int format, int type, Buffer pixels)
    {
        return;
    }

    public virtual void glRotatef(float angle, float x, float y, float z)
    {
        return;
    }

    public virtual void glRotatex(int angle, int x, int y, int z)
    {
        return;
    }

    public virtual void glSampleCoverage(float value, bool invert)
    {
        return;
    }

    public virtual void glSampleCoveragex(int value, bool invert)
    {
    }

    public virtual void glScalef(float x, float y, float z)
    {
        return;
    }

    public virtual void glScalex(int x, int y, int z)
    {
        return;
    }

    public virtual void glScissor(int x, int y, int width, int height)
    {
        return;
    }

    public virtual void glShadeModel(int mode)
    {
        return;
    }

    public virtual void glStencilFunc(int func, int @ref, int mask)
    {
        return;
    }

    public virtual void glStencilMask(int mask)
    {
        return;
    }

    public virtual void glStencilOp(int fail, int zfail, int zpass)
    {
        return;
    }

    public virtual void glTexCoordPointer(int size, int type, int stride, Buffer pointer)
    {
        return;
    }

    public virtual void glTexEnvf(int target, int pname, float param)
    {
        return;
    }

    public virtual void glTexEnvfv(int target, int pname, float[] @params, int offset)
    {
        return;
    }

    public virtual void glTexEnvfv(int target, int pname, FloatBuffer @params)
    {
        return;
    }

    public virtual void glTexEnvx(int target, int pname, int param)
    {
    }

    public virtual void glTexEnvxv(int target, int pname, int[] @params, int offset)
    {
    }

    public virtual void glTexEnvxv(int target, int pname, IntBuffer @params)
    {
    }

    public virtual void glTexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, Buffer pixels)
    {
        return;
    }

    public virtual void glTexParameterf(int target, int pname, float param)
    {
        return;
    }

    public virtual void glTexParameterx(int target, int pname, int param)
    {
    }

    public virtual void glTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, Buffer pixels)
    {
        return;
    }

    public virtual void glTranslatef(float x, float y, float z)
    {
        return;
    }

    public virtual void glTranslatex(int x, int y, int z)
    {
    }

    public virtual void glVertexPointer(int size, int type, int stride, Buffer pointer)
    {
        return;
    }

    public virtual void glViewport(int x, int y, int width, int height)
    {
        return;
    }

}

