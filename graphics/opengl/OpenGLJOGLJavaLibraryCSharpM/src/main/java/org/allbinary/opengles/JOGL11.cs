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
using GL = com.jogamp.opengl.GL;
using GL2 = com.jogamp.opengl.GL2;

namespace org.allbinary.opengles;

//JOGLEToKhronosGL11
public class JOGL11 : JOGL10, javax.microedition.khronos.opengles.GL11
{
    private readonly GL2 gl11;
    public JOGL11(GL gl) : this(gl, ((com.jogamp.opengl.GL2) gl))
    {
        // this(gl, ((com.jogamp.opengl.GL2) gl)) is called from the constructor declaration
    }

    public JOGL11(GL gl, com.jogamp.opengl.GL2 gl2) : base(gl, gl2)
    {
        // base(gl, gl2) is called from the constructor declaration
        this.gl11 = getJOGLGL();
    }

    public virtual void glBindBuffer(int target, int buffer)
    {
        this.gl11.glBindBuffer(target, buffer);
    }

    public virtual void glBufferData(int target, int size, java.nio.Buffer data, int usage)
    {
        this.gl11.glBufferData(target, size, data, usage);
    }

    public virtual void glBufferSubData(int target, int offset, int size, java.nio.Buffer data)
    {
        this.gl11.glBufferSubData(target, offset, size, data);
    }

    public virtual void glClipPlanef(int plane, float[] equation, int offset)
    {
        this.gl11.glClipPlanef(plane, equation, offset);
    }

    public virtual void glClipPlanef(int plane, java.nio.FloatBuffer equation)
    {
        this.gl11.glClipPlanef(plane, equation);
    }

    public virtual void glColor4ub(sbyte red, sbyte green, sbyte blue, sbyte alpha)
    {
        this.gl11.glColor4ub(red, green, blue, alpha);
    }

    public virtual void glColorPointer(int size, int type, int stride, int offset)
    {
        this.gl11.glColorPointer(size, type, stride, offset);
    }

    public virtual void glDeleteBuffers(int n, int[] buffers, int offset)
    {
        this.gl11.glDeleteBuffers(n, buffers, offset);
    }

    public virtual void glDeleteBuffers(int n, java.nio.IntBuffer buffers)
    {
        this.gl11.glDeleteBuffers(n, buffers);
    }

    public virtual void glDrawElements(int mode, int count, int type, int offset)
    {
        this.gl11.glDrawElements(mode, count, type, offset);
    }

    public virtual void glGenBuffers(int n, int[] buffers, int offset)
    {
        this.gl11.glGenBuffers(n, buffers, offset);
    }

    public virtual void glGenBuffers(int n, java.nio.IntBuffer buffers)
    {
        this.gl11.glGenBuffers(n, buffers);
    }

    public virtual void glGetBufferParameteriv(int target, int pname, int[] @params, int offset)
    {
        this.gl11.glGetBufferParameteriv(target, pname, @params, offset);
    }

    public virtual void glGetBufferParameteriv(int target, int pname, java.nio.IntBuffer @params)
    {
        this.gl11.glGetBufferParameteriv(target, pname, @params);
    }

    public virtual void glGetClipPlanef(int pname, float[] eqn, int offset)
    {
        this.gl11.glGetClipPlanef(pname, eqn, offset);
    }

    public virtual void glGetClipPlanef(int pname, java.nio.FloatBuffer eqn)
    {
        this.gl11.glGetClipPlanef(pname, eqn);
    }

    public virtual void glGetFloatv(int pname, float[] @params, int offset)
    {
        this.gl11.glGetFloatv(pname, @params, offset);
    }

    public virtual void glGetFloatv(int pname, java.nio.FloatBuffer @params)
    {
        this.gl11.glGetFloatv(pname, @params);
    }

    public virtual void glGetLightfv(int light, int pname, float[] @params, int offset)
    {
        this.gl11.glGetLightfv(light, pname, @params, offset);
    }

    public virtual void glGetLightfv(int light, int pname, java.nio.FloatBuffer @params)
    {
        this.gl11.glGetLightfv(light, pname, @params);
    }

    public virtual void glGetMaterialfv(int face, int pname, float[] @params, int offset)
    {
        this.gl11.glGetMaterialfv(face, pname, @params, offset);
    }

    public virtual void glGetMaterialfv(int face, int pname, java.nio.FloatBuffer @params)
    {
        this.gl11.glGetMaterialfv(face, pname, @params);
    }

    public virtual void glGetTexEnviv(int env, int pname, int[] @params, int offset)
    {
        this.gl11.glGetTexEnviv(env, pname, @params, offset);
    }

    public virtual void glGetTexEnviv(int env, int pname, java.nio.IntBuffer @params)
    {
        this.gl11.glGetTexEnviv(env, pname, @params);
    }

    public virtual void glGetTexParameterfv(int target, int pname, float[] @params, int offset)
    {
        this.gl11.glGetTexParameterfv(target, pname, @params, offset);
    }

    public virtual void glGetTexParameterfv(int target, int pname, java.nio.FloatBuffer @params)
    {
        this.gl11.glGetTexParameterfv(target, pname, @params);
    }

    public virtual void glGetTexParameteriv(int target, int pname, int[] @params, int offset)
    {
        this.gl11.glGetTexParameteriv(target, pname, @params, offset);
    }

    public virtual void glGetTexParameteriv(int target, int pname, java.nio.IntBuffer @params)
    {
        this.gl11.glGetTexParameteriv(target, pname, @params);
    }

    public virtual bool glIsBuffer(int buffer)
    {
        return this.gl11.glIsBuffer(buffer);
    }

    public virtual bool glIsEnabled(int cap)
    {
        return this.gl11.glIsEnabled(cap);
    }

    public virtual bool glIsTexture(int texture)
    {
        return this.gl11.glIsTexture(texture);
    }

    public virtual void glNormalPointer(int type, int stride, int offset)
    {
        this.gl11.glNormalPointer(type, stride, offset);
    }

    public virtual void glPointParameterf(int pname, float param)
    {
        this.gl11.glPointParameterf(pname, param);
    }

    public virtual void glPointParameterfv(int pname, float[] @params, int offset)
    {
        this.gl11.glPointParameterfv(pname, @params, offset);
    }

    public virtual void glPointParameterfv(int pname, java.nio.FloatBuffer @params)
    {
        this.gl11.glPointParameterfv(pname, @params);
    }

    public virtual void glTexCoordPointer(int size, int type, int stride, int offset)
    {
        this.gl11.glTexCoordPointer(size, type, stride, offset);
    }

    public virtual void glTexEnvi(int target, int pname, int param)
    {
        this.gl11.glTexEnvi(target, pname, param);
    }

    public virtual void glTexEnviv(int target, int pname, int[] @params, int offset)
    {
        this.gl11.glTexEnviv(target, pname, @params, offset);
    }

    public virtual void glTexEnviv(int target, int pname, java.nio.IntBuffer @params)
    {
        this.gl11.glTexEnviv(target, pname, @params);
    }

    public virtual void glTexParameterfv(int target, int pname, float[] @params, int offset)
    {
        this.gl11.glTexParameterfv(target, pname, @params, offset);
    }

    public virtual void glTexParameterfv(int target, int pname, java.nio.FloatBuffer @params)
    {
        this.gl11.glTexParameterfv(target, pname, @params);
    }

    public virtual void glTexParameteri(int target, int pname, int param)
    {
        this.gl11.glTexParameteri(target, pname, param);
    }

    public virtual void glTexParameteriv(int target, int pname, int[] @params, int offset)
    {
        this.gl11.glTexParameteriv(target, pname, @params, offset);
    }

    public virtual void glTexParameteriv(int target, int pname, java.nio.IntBuffer @params)
    {
        this.gl11.glTexParameteriv(target, pname, @params);
    }

    public virtual void glTexParameterxv(int target, int pname, int[] @params, int offset)
    {
        this.gl11.glTexParameteriv(target, pname, @params, offset);
    }

    public virtual void glVertexPointer(int size, int type, int stride, int offset)
    {
        this.gl11.glVertexPointer(size, type, stride, offset);
    }

}

