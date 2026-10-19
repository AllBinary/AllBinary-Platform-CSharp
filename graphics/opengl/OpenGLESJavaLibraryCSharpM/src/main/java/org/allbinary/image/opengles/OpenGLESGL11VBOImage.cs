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
//using ByteBuffer = java.nio.ByteBuffer;
//using ByteOrder = java.nio.ByteOrder;
//using FloatBuffer = java.nio.FloatBuffer;
//using GL = javax.microedition.khronos.opengles.GL;
//using GL10 = javax.microedition.khronos.opengles.GL10;
//using Image = javax.microedition.lcdui.Image;
using OpenGLLogUtil = org.allbinary.graphics.opengles.OpenGLLogUtil;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using GLUtil = org.allbinary.opengles.GLUtil;
using PlatformBitmapBaseFactory = org.allbinary.platform.graphics.PlatformBitmapBaseFactory;
using PlatformTextureBaseFactory = org.allbinary.platform.opengles.PlatformTextureBaseFactory;

namespace org.allbinary.image.opengles;

//This is not actually VBO impl
public class OpenGLESGL11VBOImage : OpenGLESImage
{
    private readonly GLUtil glUtil = GLUtil.getInstance();
    private FloatBuffer textureVertexFloatBuffer = ByteBuffer.allocateDirect(4 * 4 * 2).order(ByteOrder.nativeOrder()).asFloatBuffer();
    public OpenGLESGL11VBOImage(Image image, PlatformBitmapBaseFactory bitmapFactory, PlatformTextureBaseFactory textureFactory) : base(image, bitmapFactory, textureFactory)
    {
        // base(image, bitmapFactory, textureFactory) is called from the constructor declaration
        this.initVertices();
        this.regionRectangleVertexFloatBuffer.put(FloatBuffer.wrap(this.regionRectangleFloatArray));
        this.regionTextureVertexFloatBuffer.put(FloatBuffer.wrap(this.regionTextureRectangleFloatArray));
    }

    protected virtual void initVertices()
    {
        this.textureVertexFloatBuffer.put(0f);
        this.textureVertexFloatBuffer.put(1f);
        this.textureVertexFloatBuffer.put(1f);
        this.textureVertexFloatBuffer.put(1f);
        this.textureVertexFloatBuffer.put(0f);
        this.textureVertexFloatBuffer.put(0f);
        this.textureVertexFloatBuffer.put(1f);
        this.textureVertexFloatBuffer.put(0f);
        this.textureVertexFloatBuffer.rewind();
    }

    public override void set(GL gl)
    {
        GL10 gl10 = ((GL10) gl);
        if (base.initTexture(gl10)) {
            this.textureFactory.load(gl10, GL10.GL_TEXTURE_2D, 0, this, 0, true);
            gl10.glDisable(GL10.GL_TEXTURE_2D);
            OpenGLLogUtil.getInstance().logError(gl10, this);
        }
    }

    public readonly float[] regionRectangleFloatArray = new float[] { 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f };
    public FloatBuffer regionRectangleVertexFloatBuffer = ByteBuffer.allocateDirect(4 * 4 * 3).order(ByteOrder.nativeOrder()).asFloatBuffer();
    private readonly float[] regionTextureRectangleFloatArray = new float[8];
    private FloatBuffer regionTextureVertexFloatBuffer = ByteBuffer.allocateDirect(4 * 4 * 2).order(ByteOrder.nativeOrder()).asFloatBuffer();
    public override void drawRegion(GL10 gl, int viewHeight, float x_src, float y_src, float width, float height, int x, int y, int z)
    {
        this.regionRectangleFloatArray[0] = ((float) x);
        this.regionRectangleFloatArray[7] = ((float) (viewHeight - y));
        this.regionRectangleFloatArray[1] = this.regionRectangleFloatArray[7] - height;
        this.regionRectangleFloatArray[3] = ((float) x) + width;
        this.regionRectangleFloatArray[4] = this.regionRectangleFloatArray[1];
        this.regionRectangleFloatArray[6] = ((float) x);
        this.regionRectangleFloatArray[9] = this.regionRectangleFloatArray[3];
        this.regionRectangleFloatArray[10] = this.regionRectangleFloatArray[7];
        this.regionTextureRectangleFloatArray[0] = x_src / this.getWidth();
        this.regionTextureRectangleFloatArray[1] = (y_src + height) / this.getHeight();
        this.regionTextureRectangleFloatArray[2] = (x_src + width) / this.getWidth();
        this.regionTextureRectangleFloatArray[3] = this.regionTextureRectangleFloatArray[1];
        this.regionTextureRectangleFloatArray[4] = this.regionTextureRectangleFloatArray[0];
        this.regionTextureRectangleFloatArray[5] = y_src / this.getHeight();
        this.regionTextureRectangleFloatArray[6] = this.regionTextureRectangleFloatArray[2];
        this.regionTextureRectangleFloatArray[7] = this.regionTextureRectangleFloatArray[5];
        this.glUtil.position(this.regionRectangleVertexFloatBuffer, 0);
        gl.glVertexPointer(3, GL10.GL_FLOAT, 0, this.regionRectangleVertexFloatBuffer);
        gl.glEnableClientState(GL10.GL_VERTEX_ARRAY);
        gl.glEnable(GL10.GL_TEXTURE_2D);
        gl.glBindTexture(GL10.GL_TEXTURE_2D, this.openGLESImageProperties.textureID);
        gl.glEnableClientState(GL10.GL_TEXTURE_COORD_ARRAY);
        this.glUtil.position(this.regionTextureVertexFloatBuffer, 0);
        gl.glTexCoordPointer(2, GL10.GL_FLOAT, 0, this.regionTextureVertexFloatBuffer);
        gl.glDrawArrays(GL10.GL_TRIANGLE_STRIP, 0, 4);
        gl.glDisableClientState(GL10.GL_VERTEX_ARRAY);
        gl.glDisableClientState(GL10.GL_TEXTURE_COORD_ARRAY);
        gl.glDisable(GL10.GL_TEXTURE_2D);
    }

    public override void draw(GL10 gl, int x, int y, int z)
    {
        this.regionRectangleFloatArray[0] = ((float) x);
        this.regionRectangleFloatArray[7] = ((float) (DisplayInfoSingleton.getInstance().getLastHeight() - y));
        this.regionRectangleFloatArray[1] = this.regionRectangleFloatArray[7] - this.getHeight();
        this.regionRectangleFloatArray[3] = ((float) (x + this.getWidth()));
        this.regionRectangleFloatArray[4] = this.regionRectangleFloatArray[1];
        this.regionRectangleFloatArray[6] = ((float) x);
        this.regionRectangleFloatArray[9] = this.regionRectangleFloatArray[3];
        this.regionRectangleFloatArray[10] = this.regionRectangleFloatArray[7];
        this.glUtil.position(this.regionRectangleVertexFloatBuffer, 0);
        gl.glVertexPointer(3, GL10.GL_FLOAT, 0, this.regionRectangleVertexFloatBuffer);
        gl.glEnableClientState(GL10.GL_VERTEX_ARRAY);
        gl.glEnable(GL10.GL_TEXTURE_2D);
        gl.glBindTexture(GL10.GL_TEXTURE_2D, this.openGLESImageProperties.textureID);
        gl.glEnableClientState(GL10.GL_TEXTURE_COORD_ARRAY);
        this.glUtil.position(this.textureVertexFloatBuffer, 0);
        gl.glTexCoordPointer(2, GL10.GL_FLOAT, 0, this.textureVertexFloatBuffer);
        gl.glDrawArrays(GL10.GL_TRIANGLE_STRIP, 0, 4);
        gl.glDisableClientState(GL10.GL_VERTEX_ARRAY);
        gl.glDisableClientState(GL10.GL_TEXTURE_COORD_ARRAY);
        gl.glDisable(GL10.GL_TEXTURE_2D);
    }

}

