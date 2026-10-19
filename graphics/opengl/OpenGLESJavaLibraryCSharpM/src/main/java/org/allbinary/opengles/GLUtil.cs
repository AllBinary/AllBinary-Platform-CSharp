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
//using Buffer = java.nio.Buffer;
//using ByteBuffer = java.nio.ByteBuffer;
//using ByteOrder = java.nio.ByteOrder;
//using FloatBuffer = java.nio.FloatBuffer;

namespace org.allbinary.opengles;

public class GLUtil
{
    private static readonly GLUtil instance = new GLUtil();
    public static GLUtil getInstance()
    {
        return GLUtil.instance;
    }

    private readonly int BYTES_PER_FLOAT = 4;
    public readonly FloatBuffer NULL_FLOAT_BUFFER = ByteBuffer.allocateDirect(0).asFloatBuffer();
    public virtual FloatBuffer makeFloatBuffer3(float p_a, float p_b, float p_c)
    {
        ByteBuffer b = ByteBuffer.allocateDirect(3 * this.BYTES_PER_FLOAT);
        b.order(ByteOrder.nativeOrder());
        FloatBuffer buffer = b.asFloatBuffer();
        buffer.put(p_a);
        buffer.put(p_b);
        buffer.put(p_c);
        this.position(buffer, 0);
        return buffer;
    }

    public virtual FloatBuffer makeFloatBuffer4(float p_a, float p_b, float p_c, float p_d)
    {
        ByteBuffer b = ByteBuffer.allocateDirect(4 * this.BYTES_PER_FLOAT);
        b.order(ByteOrder.nativeOrder());
        FloatBuffer buffer = b.asFloatBuffer();
        buffer.put(p_a);
        buffer.put(p_b);
        buffer.put(p_c);
        buffer.put(p_d);
        this.position(buffer, 0);
        return buffer;
    }

    public virtual FloatBuffer makeFloatBuffer(ByteBuffer byteBuffer)
    {
        ByteBuffer b = ByteBuffer.allocateDirect(byteBuffer.limit() * this.BYTES_PER_FLOAT);
        b.order(ByteOrder.nativeOrder());
        FloatBuffer buffer = b.asFloatBuffer();
        int unsigned = 0;
        float v = 0f;
        while (byteBuffer.hasRemaining()) {
            unsigned = (((int) byteBuffer.get())) & 0xFF;
            v = (((float) unsigned)) / 255f;
            buffer.put(v);
        }
        this.position(buffer, 0);
        return buffer;
    }

    public virtual Buffer position(Buffer buffer, int newPosition)
    {
        return buffer.position(newPosition);
    }

    public virtual void rotateUVs(float[] uvs, float angleDegrees, float pivotU, float pivotV)
    {
        double angleRad = Math.ToRadians(((double) angleDegrees));
        double cosA = Math.Cos(angleRad);
        double sinA = Math.Sin(angleRad);
        for (int i = 0; i < uvs.Length; i += 2) {
            float u = uvs[i];
            float v = uvs[i + 1];
            float du = u - pivotU;
            float dv = v - pivotV;
            float ru = ((float) (((double) du) * cosA - ((double) dv) * sinA)) + pivotU;
            float rv = ((float) (((double) du) * sinA + ((double) dv) * cosA)) + pivotV;
            uvs[i] = ru;
            uvs[i + 1] = rv;
        }
    }

}

