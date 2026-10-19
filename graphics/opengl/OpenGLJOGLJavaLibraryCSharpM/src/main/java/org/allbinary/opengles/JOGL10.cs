/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2011 AllBinary
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
using GLU = com.jogamp.opengl.glu.GLU;

namespace org.allbinary.opengles;

//JOGLEToKhronosGL10
public class JOGL10 : javax.microedition.khronos.opengles.GL10
{
    public readonly string RED = "red: ";
    public readonly string GREEN = " green: ";
    public readonly string BLUE = " blue: ";
    public readonly string ALPHA = " alpha: ";
    public readonly string PNAME = "pname: ";
    public readonly string _PNAME = " pname: ";
    public readonly string PARAM = " param: ";
    public readonly string PARAMS = " params: ";
    public readonly string LIGHT = "light: ";
    public readonly string FACE = "face: ";
    public readonly string TARGET = "target: ";
    private readonly com.jogamp.opengl.GL2 gl10;
    public readonly GLU glu;
    public readonly int GL_LINE;
    public readonly int GL_QUAD_STRIP;
    public JOGL10(com.jogamp.opengl.GL gl, com.jogamp.opengl.GL2 gl2)
    {
        this.gl10 = gl2;
        this.glu = GLU.createGLU(this.gl10);
        this.GL_LINE = com.jogamp.opengl.GL2.GL_LINE;
        this.GL_QUAD_STRIP = com.jogamp.opengl.GL2.GL_QUAD_STRIP;
    }

    public virtual com.jogamp.opengl.GL2 getJOGLGL()
    {
        return this.gl10;
    }

    public virtual void glActiveTexture(int texture)
    {
        this.gl10.glActiveTexture(texture);
    }

    public virtual void glAlphaFunc(int func, float @ref)
    {
        this.gl10.glAlphaFunc(func, @ref);
    }

    public virtual void glBindTexture(int target, int texture)
    {
        this.gl10.glBindTexture(target, texture);
    }

    public virtual void glBlendFunc(int sfactor, int dfactor)
    {
        this.gl10.glBlendFunc(sfactor, dfactor);
    }

    public virtual void glClear(int mask)
    {
        this.gl10.glClear(mask);
    }

    public virtual void glClearColor(float red, float green, float blue, float alpha)
    {
        this.gl10.glClearColor(red, green, blue, alpha);
    }

    public virtual void glClearDepthf(float depth)
    {
        this.gl10.glClearDepthf(depth);
    }

    public virtual void glClearStencil(int s)
    {
        this.gl10.glClearStencil(s);
    }

    public virtual void glClientActiveTexture(int texture)
    {
        this.gl10.glClientActiveTexture(texture);
    }

    public virtual void glColor4f(float red, float green, float blue, float alpha)
    {
        this.gl10.glColor4f(red, green, blue, alpha);
    }

    public virtual void glColorMask(bool red, bool green, bool blue, bool alpha)
    {
        this.gl10.glColorMask(red, green, blue, alpha);
    }

    public virtual void glColorPointer(int size, int type, int stride, java.nio.Buffer pointer)
    {
        this.gl10.glColorPointer(size, type, stride, pointer);
    }

    public virtual void glCompressedTexImage2D(int target, int level, int internalformat, int width, int height, int border, int imageSize, java.nio.Buffer data)
    {
        this.gl10.glCompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, data);
    }

    public virtual void glCompressedTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int imageSize, java.nio.Buffer data)
    {
        this.gl10.glCompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, data);
    }

    public virtual void glCopyTexImage2D(int target, int level, int internalformat, int x, int y, int width, int height, int border)
    {
        this.gl10.glCopyTexImage2D(target, level, internalformat, x, y, width, height, border);
    }

    public virtual void glCopyTexSubImage2D(int target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
    {
        this.gl10.glCopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height);
    }

    public virtual void glCullFace(int mode)
    {
        this.gl10.glCullFace(mode);
    }

    public virtual void glDeleteTextures(int n, int[] textures, int offset)
    {
        this.gl10.glDeleteTextures(n, textures, offset);
    }

    public virtual void glDeleteTextures(int n, java.nio.IntBuffer textures)
    {
        this.gl10.glDeleteTextures(n, textures);
    }

    public virtual void glDepthFunc(int func)
    {
        this.gl10.glDepthFunc(func);
    }

    public virtual void glDepthMask(bool flag)
    {
        this.gl10.glDepthMask(flag);
    }

    public virtual void glDepthRangef(float zNear, float zFar)
    {
        this.gl10.glDepthRangef(zNear, zFar);
    }

    public virtual void glDisable(int cap)
    {
        this.gl10.glDisable(cap);
    }

    public virtual void glDisableClientState(int array)
    {
        this.gl10.glDisableClientState(array);
    }

    public virtual void glDrawArrays(int mode, int first, int count)
    {
        this.gl10.glDrawArrays(mode, first, count);
    }

    public virtual void glDrawElements(int mode, int count, int type, java.nio.Buffer indices)
    {
        this.gl10.glDrawElements(mode, count, type, indices);
    }

    public virtual void glEnable(int cap)
    {
        this.gl10.glEnable(cap);
    }

    public virtual void glEnableClientState(int array)
    {
        this.gl10.glEnableClientState(array);
    }

    public virtual void glFinish()
    {
        this.gl10.glFinish();
    }

    public virtual void glFlush()
    {
        this.gl10.glFlush();
    }

    public virtual void glFogf(int pname, float param)
    {
        this.gl10.glFogf(pname, param);
    }

    public virtual void glFogfv(int pname, float[] @params, int offset)
    {
        this.gl10.glFogfv(pname, @params, offset);
    }

    public virtual void glFogfv(int pname, java.nio.FloatBuffer @params)
    {
        this.gl10.glFogfv(pname, @params);
    }

    public virtual void glFrontFace(int mode)
    {
        this.gl10.glFrontFace(mode);
    }

    public virtual void glFrustumf(float left, float right, float bottom, float top, float zNear, float zFar)
    {
        this.gl10.glFrustumf(left, right, bottom, top, zNear, zFar);
    }

    public virtual void glGenTextures(int n, int[] textures, int offset)
    {
        this.gl10.glGenTextures(n, textures, offset);
    }

    public virtual void glGenTextures(int n, java.nio.IntBuffer textures)
    {
        this.gl10.glGenTextures(n, textures);
    }

    public virtual int glGetError()
    {
        return this.gl10.glGetError();
    }

    public virtual void glGetIntegerv(int pname, int[] @params, int offset)
    {
        this.gl10.glGetIntegerv(pname, @params, offset);
    }

    public virtual void glGetIntegerv(int pname, java.nio.IntBuffer @params)
    {
        this.gl10.glGetIntegerv(pname, @params);
    }

    public virtual string glGetString(int name)
    {
        return this.gl10.glGetString(name);
    }

    public virtual void glHint(int target, int mode)
    {
        this.gl10.glHint(target, mode);
    }

    public virtual void glLightModelf(int pname, float param)
    {
        this.gl10.glLightModelf(pname, param);
    }

    public virtual void glLightModelfv(int pname, float[] @params, int offset)
    {
        this.gl10.glLightModelfv(pname, @params, offset);
    }

    public virtual void glLightModelfv(int pname, java.nio.FloatBuffer @params)
    {
        this.gl10.glLightModelfv(pname, @params);
    }

    public virtual void glLightf(int light, int pname, float param)
    {
        this.gl10.glLightf(light, pname, param);
    }

    public virtual void glLightfv(int light, int pname, float[] @params, int offset)
    {
        this.gl10.glLightfv(light, pname, @params, offset);
    }

    public virtual void glLightfv(int light, int pname, java.nio.FloatBuffer @params)
    {
        this.gl10.glLightfv(light, pname, @params);
    }

    public virtual void glLineWidth(float width)
    {
        this.gl10.glLineWidth(width);
    }

    public virtual void glLoadIdentity()
    {
        this.gl10.glLoadIdentity();
    }

    public virtual void glLoadMatrixf(float[] m, int offset)
    {
        this.gl10.glLoadMatrixf(m, offset);
    }

    public virtual void glLoadMatrixf(java.nio.FloatBuffer m)
    {
        this.gl10.glLoadMatrixf(m);
    }

    public virtual void glLogicOp(int opcode)
    {
        this.gl10.glLogicOp(opcode);
    }

    public virtual void glMaterialf(int face, int pname, float param)
    {
        this.gl10.glMaterialf(face, pname, param);
    }

    public virtual void glMaterialfv(int face, int pname, float[] @params, int offset)
    {
        this.gl10.glMaterialfv(face, pname, @params, offset);
    }

    public virtual void glMaterialfv(int face, int pname, java.nio.FloatBuffer @params)
    {
        this.gl10.glMaterialfv(face, pname, @params);
    }

    public virtual void glMatrixMode(int mode)
    {
        this.gl10.glMatrixMode(mode);
    }

    public virtual void glMultMatrixf(float[] m, int offset)
    {
        this.gl10.glMultMatrixf(m, offset);
    }

    public virtual void glMultMatrixf(java.nio.FloatBuffer m)
    {
        this.gl10.glMultMatrixf(m);
    }

    public virtual void glMultiTexCoord4f(int target, float s, float t, float r, float q)
    {
        this.gl10.glMultiTexCoord4f(target, s, t, r, q);
    }

    public virtual void glNormal3f(float nx, float ny, float nz)
    {
        this.gl10.glNormal3f(nx, ny, nz);
    }

    public virtual void glNormalPointer(int type, int stride, java.nio.Buffer pointer)
    {
        this.gl10.glNormalPointer(type, stride, pointer);
    }

    public virtual void glOrthof(float left, float right, float bottom, float top, float zNear, float zFar)
    {
        this.gl10.glOrthof(left, right, bottom, top, zNear, zFar);
    }

    public virtual void glPixelStorei(int pname, int param)
    {
        this.gl10.glPixelStorei(pname, param);
    }

    public virtual void glPointSize(float size)
    {
        this.gl10.glPointSize(size);
    }

    public virtual void glPolygonOffset(float factor, float units)
    {
        this.gl10.glPolygonOffset(factor, units);
    }

    public virtual void glPopMatrix()
    {
        this.gl10.glPopMatrix();
    }

    public virtual void glPushMatrix()
    {
        this.gl10.glPushMatrix();
    }

    public virtual void glReadPixels(int x, int y, int width, int height, int format, int type, java.nio.Buffer pixels)
    {
        this.gl10.glReadPixels(x, y, width, height, format, type, pixels);
    }

    public virtual void glRotatef(float angle, float x, float y, float z)
    {
        this.gl10.glRotatef(angle, x, y, z);
    }

    public virtual void glRotatex(int angle, int x, int y, int z)
    {
        this.gl10.glRotatef(angle, x, y, z);
    }

    public virtual void glSampleCoverage(float value, bool invert)
    {
        this.gl10.glSampleCoverage(value, invert);
    }

    public virtual void glScalef(float x, float y, float z)
    {
        this.gl10.glScalef(x, y, z);
    }

    public virtual void glScalex(int x, int y, int z)
    {
        this.gl10.glScalef(x, y, z);
    }

    public virtual void glScissor(int x, int y, int width, int height)
    {
        this.gl10.glScissor(x, y, width, height);
    }

    public virtual void glShadeModel(int mode)
    {
        this.gl10.glShadeModel(mode);
    }

    public virtual void glStencilFunc(int func, int @ref, int mask)
    {
        this.gl10.glStencilFunc(func, @ref, mask);
    }

    public virtual void glStencilMask(int mask)
    {
        this.gl10.glStencilMask(mask);
    }

    public virtual void glStencilOp(int fail, int zfail, int zpass)
    {
        this.gl10.glStencilOp(fail, zfail, zpass);
    }

    public virtual void glTexCoordPointer(int size, int type, int stride, java.nio.Buffer pointer)
    {
        this.gl10.glTexCoordPointer(size, type, stride, pointer);
    }

    public virtual void glTexEnvf(int target, int pname, float param)
    {
        this.gl10.glTexEnvf(target, pname, param);
    }

    public virtual void glTexEnvfv(int target, int pname, float[] @params, int offset)
    {
        this.gl10.glTexEnvfv(target, pname, @params, offset);
    }

    public virtual void glTexEnvfv(int target, int pname, java.nio.FloatBuffer @params)
    {
        this.gl10.glTexEnvfv(target, pname, @params);
    }

    public virtual void glTexImage2D(int target, int level, int internalformat, int width, int height, int border, int format, int type, java.nio.Buffer pixels)
    {
        this.gl10.glTexImage2D(target, level, internalformat, width, height, border, format, type, pixels);
    }

    public virtual void glTexParameterf(int target, int pname, float param)
    {
        this.gl10.glTexParameterf(target, pname, param);
    }

    public virtual void glTexParameteri(int target, int pname, int param)
    {
        this.gl10.glTexParameteri(target, pname, param);
    }

    public virtual void glTexSubImage2D(int target, int level, int xoffset, int yoffset, int width, int height, int format, int type, java.nio.Buffer pixels)
    {
        this.gl10.glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels);
    }

    public virtual void glTranslatef(float x, float y, float z)
    {
        this.gl10.glTranslatef(x, y, z);
    }

    public virtual void glVertexPointer(int size, int type, int stride, java.nio.Buffer pointer)
    {
        this.gl10.glVertexPointer(size, type, stride, pointer);
    }

    public virtual void glViewport(int x, int y, int width, int height)
    {
        this.gl10.glViewport(x, y, width, height);
    }

    public virtual void glBegin(int i)
    {
        this.gl10.glBegin(i);
    }

    public virtual void glEnd()
    {
        this.gl10.glEnd();
    }

    public virtual void glVertex3f(float f, float f2, float f3)
    {
        this.gl10.glVertex3f(f, f2, f3);
    }

    public virtual void glPolygonMode(int i, int i1)
    {
        this.gl10.glPolygonMode(i, i1);
    }

}

